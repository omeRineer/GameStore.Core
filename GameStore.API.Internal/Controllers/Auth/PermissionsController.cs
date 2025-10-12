using Business.Services.Abstract.Identity;
using Business.Services.Concrete;
using GameStore.API.Web.Controllers.Base;
using MeArch.Module.Security.Filters;
using Microsoft.AspNetCore.Mvc;
using Models.Identity.Permission;
using Models.Identity.Role;

namespace GameStore.API.Web.Controllers.Auth
{
    public class PermissionsController : BaseController
    {
        readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        [Authorize("SuperAdmin,API.Web.Permissions.GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _permissionService.GetListAsync();

            return Result(result);
        }

        [HttpGet("{id}")]
        [Authorize("SuperAdmin,API.Web.Permissions.Get")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var result = await _permissionService.GetAsync(id);

            return Result(result);
        }

        [HttpPost("Create")]
        [Authorize("SuperAdmin,API.Web.Permissions.Create")]
        public async Task<IActionResult> CreateAsync(CreatePermissionRequest request)
        {
            var result = await _permissionService.CreateAsync(request);

            return Result(result);
        }

        [HttpPost("Update")]
        [Authorize("SuperAdmin,API.Web.Permissions.Update")]
        public async Task<IActionResult> UpdateAsync(UpdatePermissionRequest request)
        {
            var result = await _permissionService.UpdateAsync(request);

            return Result(result);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize("SuperAdmin,API.Web.Permissions.Delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _permissionService.DeleteAsync(id);

            return Result(result);
        }

        [HttpPost("UploadCollection")]
        [Authorize("SuperAdmin,API.Web.Permissions.UploadCollection")]
        public async Task<IActionResult> UploadCollectionAsync(UploadPermissionCollectionRequest request)
        {
            var result = await _permissionService.UploadCollectionAsync(request);

            return Result(result);
        }
    }
}
