using Business.Services.Abstract;
using GameStore.API.Web.Controllers.Base;
using MeArch.Module.Security.Filters;
using Microsoft.AspNetCore.Mvc;
using Models.Auth.User;
using Models.User;

namespace GameStore.API.Web.Controllers.Auth
{
    public class UsersController : BaseController
    {
        readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Create")]
        [Authorize("SuperAdmin,API.Web.Users.Create")]
        public async Task<IActionResult> CreateAsync(CreateUserRequest request)
        {
            var result = await _userService.CreateAsync(request);

            return Result(result);
        }

        [HttpPost("SetRoles")]
        [Authorize("SuperAdmin,API.Web.Users.SetRoles")]
        public async Task<IActionResult> SetRolesAsync(SetUserRolesRequest request)
        {
            var result = await _userService.SetRolesAsync(request);

            return Result(result);
        }

        [HttpPost("SetPermissions")]
        [Authorize("SuperAdmin,API.Web.Users.SetPermissions")]
        public async Task<IActionResult> SetPermissionsAsync(SetUserPermissionsRequest request)
        {
            var result = await _userService.SetPermissionsAsync(request);

            return Result(result);
        }
    }
}
