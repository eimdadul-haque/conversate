using Conversate.Application.Accounts;
using Conversate.Shared.Account.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conversate.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _account;
        public AccountController(
             IAccount account) { 
            _account = account;
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Login(LoginDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = await _account.Login(input);

            if (!string.IsNullOrEmpty(token))
                return Ok(new { userName = input.UserName, token = token });
            else
                return BadRequest();
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> SignUp(SignUpDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (await _account.SignIn(input))
                return Ok();
            else 
                return BadRequest();
        }
    }
}
