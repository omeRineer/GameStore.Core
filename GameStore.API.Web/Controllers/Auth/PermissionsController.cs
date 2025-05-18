using Business.Services.Abstract;
using GameStore.API.Web.Controllers.Base;
using MeArch.Module.Security.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Web.Controllers.Auth
{
    public class PermissionsController : BaseController
    {
        readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpPost("UploadCollection")]
        [Authorize("SuperAdmin,API.Web.Permissions.UploadCollection")]
        public async Task<IActionResult> UploadCollectionAsync(string[] permissions)
        {
            var result = await _permissionService.UploadCollectionAsync(permissions);

            return Result(result);
        }
    }
}
