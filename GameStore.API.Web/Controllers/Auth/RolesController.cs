using Business.Services.Abstract;
using Business.Services.Concrete;
using GameStore.API.Web.Controllers.Base;
using MeArch.Module.Security.Filters;
using Microsoft.AspNetCore.Mvc;
using Models.Identity.Role;
using Models.Identity.User;

namespace GameStore.API.Web.Controllers.Auth
{
    public class RolesController : BaseController
    {
        readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Authorize("SuperAdmin,API.Web.Roles.GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _roleService.GetListAsync();

            return Result(result);
        }

        [HttpGet("{id}")]
        [Authorize("SuperAdmin,API.Web.Roles.Get")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var result = await _roleService.GetAsync(id);

            return Result(result);
        }

        [HttpPost("Create")]
        [Authorize("SuperAdmin,API.Web.Roles.Create")]
        public async Task<IActionResult> CreateAsync(CreateRoleRequest request)
        {
            var result = await _roleService.CreateAsync(request);

            return Result(result);
        }

        [HttpPost("Update")]
        [Authorize("SuperAdmin,API.Web.Roles.Update")]
        public async Task<IActionResult> UpdateAsync(UpdateRoleRequest request)
        {
            var result = await _roleService.UpdateAsync(request);

            return Result(result);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize("SuperAdmin,API.Web.Roles.Delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _roleService.DeleteAsync(id);

            return Result(result);
        }

        [HttpPost("UploadCollection")]
        [Authorize("SuperAdmin,API.Web.Roles.UploadCollection")]
        public async Task<IActionResult> UploadCollectionAsync(UploadRoleCollectionRequest request)
        {
            var result = await _roleService.UploadCollectionAsync(request);

            return Result(result);
        }

        [HttpPost("SetPermissions")]
        [Authorize("SuperAdmin,API.Web.Roles.SetPermissions")]
        public async Task<IActionResult> SetPermissionsAsync(SetRolePermissionsRequest request)
        {
            var result = await _roleService.SetPermissionsAsync(request);

            return Result(result);
        }

        [HttpGet("GetPermissions")]
        [Authorize("SuperAdmin,API.Web.Roles.GetPermissions")]
        public async Task<IActionResult> GetPermissionsAsync(Guid id)
        {
            var result = await _roleService.GetPermissionsAsync(id);

            return Result(result);
        }
    }
}
