using Conversate.Shared.Account.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conversate.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        public AccountController() { 
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Login(LoginDto input)
        {
            var token = "ets";
            return Ok();
        }
    }
}
