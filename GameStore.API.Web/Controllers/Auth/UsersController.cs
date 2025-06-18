using Business.Services.Abstract.Identity;
using Business.Services.Concrete;
using GameStore.API.Web.Controllers.Base;
using MeArch.Module.Security.Filters;
using Microsoft.AspNetCore.Mvc;
using Models.Identity.User;

namespace GameStore.API.Web.Controllers.Auth
{
    public class UsersController : BaseController
    {
        readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        [Authorize("API.Web.Users.Get")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var result = await _userService.GetAsync(id);

            return Result(result);
        }

        [HttpPost("Create")]
        [Authorize("API.Web.Users.Create")]
        public async Task<IActionResult> CreateAsync(CreateUserRequest request)
        {
            var result = await _userService.CreateAsync(request);

            return Result(result);
        }

        [HttpPost("Update")]
        [Authorize("API.Web.Users.Update")]
        public async Task<IActionResult> UpdateAsync(UpdateUserRequest request)
        {
            var result = await _userService.UpdateAsync(request);

            return Result(result);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize("API.Web.Users.Delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _userService.DeleteAsync(id);

            return Result(result);
        }

        [HttpPost("SetClaims")]
        [Authorize("API.Web.Users.SetClaims")]
        public async Task<IActionResult> SetClaimsAsync(SetUserClaimsRequest request)
        {
            var result = await _userService.SetClaimsAsync(request);

            return Result(result);
        }

        [HttpPost("SetRoles")]
        [Authorize("API.Web.Users.SetRoles")]
        public async Task<IActionResult> SetRolesAsync(SetUserRolesRequest request)
        {
            var result = await _userService.SetRolesAsync(request);

            return Result(result);
        }

        [HttpPost("SetPermissions")]
        [Authorize("API.Web.Users.SetPermissions")]
        public async Task<IActionResult> SetPermissionsAsync(SetUserPermissionsRequest request)
        {
            var result = await _userService.SetPermissionsAsync(request);

            return Result(result);
        }

        [HttpGet("GetRoles/{id}")]
        [Authorize("API.Web.Users.GetRoles")]
        public async Task<IActionResult> GetRolesAsync([FromRoute]Guid id)
        {
            var result = await _userService.GetRolesAsync(id);

            return Result(result);
        }

        [HttpGet("GetPermissions/{id}")]
        [Authorize("API.Web.Users.GetPermissions")]
        public async Task<IActionResult> GetPermissionsAsync([FromRoute] Guid id)
        {
            var result = await _userService.GetPermissionsAsync(id);

            return Result(result);
        }

        [HttpGet("GetClaims/{id}")]
        [Authorize("API.Web.Users.GetClaims")]
        public async Task<IActionResult> GetClaimsAsync([FromRoute] Guid id)
        {
            var result = await _userService.GetClaimsAsync(id);

            return Result(result);
        }
    }
}
