using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Repositories;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository accountRepo;

        public AccountsController(IAccountRepository repo)
        {
            accountRepo = repo;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            var result = await accountRepo.Register(registerModel);            
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var result = await accountRepo.Login(loginModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
