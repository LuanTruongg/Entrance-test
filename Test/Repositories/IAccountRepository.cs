using Microsoft.AspNetCore.Identity;
using Test.Models;

namespace Test.Repositories
{
    public interface IAccountRepository
    {
        public Task<string> Login(LoginModel model);
        public Task<IdentityResult> Register(RegisterModel model);
    }
}
