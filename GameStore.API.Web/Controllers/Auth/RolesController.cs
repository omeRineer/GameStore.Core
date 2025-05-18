using Business.Services.Abstract;
using GameStore.API.Web.Controllers.Base;
using MeArch.Module.Security.Filters;
using Microsoft.AspNetCore.Mvc;
using Models.Auth.Role;

namespace GameStore.API.Web.Controllers.Auth
{
    public class RolesController : BaseController
    {
        readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("UploadCollection")]
        [Authorize("SuperAdmin,API.Web.Roles.UploadCollection")]
        public async Task<IActionResult> UploadCollectionAsync(string[] roles)
        {
            var result = await _roleService.UploadCollectionAsync(roles);

            return Result(result);
        }

        [HttpPost("SetPermissions")]
        [Authorize("SuperAdmin,API.Web.Roles.SetPermissions")]
        public async Task<IActionResult> SetPermissionsAsync(SetRolePermissionsRequest request)
        {
            var result = await _roleService.SetPermissionsAsync(request);

            return Result(result);
        }
    }
}
