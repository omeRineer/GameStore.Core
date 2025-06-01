using Business.Services.Abstract;
using Core.Utilities.Filters;
using Entities.Enum.Type;
using GameStore.API.Web.Controllers.Base;
using MeArch.Module.Security.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Category;
using Models.Identity.Menu;
using Models.Identity.Role;

namespace GameStore.API.Web.Controllers.Main
{
    public class MenusController : BaseController
    {
        readonly IMenuService _menuService;

        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        [Authorize("SuperAdmin,API.Web.Menus.GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _menuService.GetListAsync();

            return Result(result);
        }

        [Benchmark(logTypes:LogType.Notification)]
        [HttpGet("SessionMenus")]
        [Authorize]
        public async Task<IActionResult> GetSessionMenusAsync()
        {
            var result = await _menuService.GetSessionMenusAsync();

            return Result(result);
        }

        [HttpGet("{id}")]
        [Authorize("API.Web.Menus.Get")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var result = await _menuService.GetAsync(id);

            return Result(result);
        }

        [HttpPost("Create")]
        [Authorize("SuperAdmin,API.Web.Menus.Create")]
        public async Task<IActionResult> CreateAsync(CreateMenuRequest request)
        {
            var result = await _menuService.CreateAsync(request);

            return Result(result);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize("SuperAdmin,API.Web.Menus.Delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _menuService.DeleteAsync(id);

            return Result(result);
        }

        [HttpPost("Update")]
        [Authorize("SuperAdmin,API.Web.Menus.Update")]
        public async Task<IActionResult> UpdateAsync(UpdateMenuRequest request)
        {
            var result = await _menuService.UpdateAsync(request);

            return Result(result);
        }

        [HttpPost("SetPermissions")]
        [Authorize("SuperAdmin,API.Web.Menus.SetPermissions")]
        public async Task<IActionResult> SetPermissionsAsync(SetMenuPermissionsRequest request)
        {
            var result = await _menuService.SetPermissionsAsync(request);

            return Result(result);
        }

        [HttpGet("GetPermissions/{id}")]
        [Authorize("SuperAdmin,API.Web.Menus.GetPermissions")]
        public async Task<IActionResult> GetPermissionsAsync(Guid id)
        {
            var result = await _menuService.GetPermissionsAsync(id);

            return Result(result);
        }

        [HttpPost("SetRoles")]
        [Authorize("SuperAdmin,API.Web.Menus.SetRoles")]
        public async Task<IActionResult> SetRolesAsync(SetMenuRolesRequest request)
        {
            var result = await _menuService.SetRolesAsync(request);

            return Result(result);
        }

        [HttpGet("GetRoles/{id}")]
        [Authorize("SuperAdmin,API.Web.Menus.GetRoles")]
        public async Task<IActionResult> GetRolesAsync(Guid id)
        {
            var result = await _menuService.GetRolesAsync(id);

            return Result(result);
        }
    }
}
