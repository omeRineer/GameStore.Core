using Business.Services.Abstract.Identity;
using GameStore.API.Web.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Identity.Login;

namespace GameStore.API.Web.Controllers.Auth
{
    public class AuthController : BaseController
    {
        readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(UserLoginRequest request)
        {
            var result = await _authService.LoginAsync(request);

            return Result(result);
        }
    }
}
