using Conversate.Domain.ApplicationUsers;
using Conversate.Shared.Account.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Conversate.Application.Accounts
{
    public class Account : IAccount
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public Account(
            IConfiguration configuration,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        public async Task<bool> SignIn(SignUpDto input)
        {
            var applicationUser = new ApplicationUser()
            {
                Name = input.Name,
                Email = input.Email,
                UserName = input.Username,
                PhoneNumber = input.PhoneNumber
            };

            var result = await _userManager
                .CreateAsync(applicationUser, input.Password);

            return result.Succeeded;   
        }

        public async Task<string> Login(LoginDto input)
        {
            var result = await _signInManager
                .PasswordSignInAsync(input.UserName, input.Password, input.IsPersistent, false);
            
            if (result.Succeeded)
               return GenerateJwtToken(input.UserName);
            else 
                return string.Empty;
        }

        private string GenerateJwtToken(string email)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(_configuration["JWT:IssuerSigningKey"]));

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );

            return jwtSecurityTokenHandler.WriteToken(token);
        }
    }
}
