using Business.Services.Abstract;
using Entities.Enum.Type;
using GameStore.API.Web.Controllers.Base;
using MeArch.Module.Security.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Category;
using Models.Identity.Menu;

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
        [Authorize("API.Web.Menus.GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _menuService.GetListAsync();

            return Result(result);
        }

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
        [Authorize("API.Web.Menus.Create")]
        public async Task<IActionResult> CreateAsync(CreateMenuRequest request)
        {
            var result = await _menuService.CreateAsync(request);

            return Result(result);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize("API.Web.Menus.Delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _menuService.DeleteAsync(id);

            return Result(result);
        }

        [HttpPost("Update")]
        [Authorize("API.Web.Menus.Update")]
        public async Task<IActionResult> UpdateAsync(UpdateMenuRequest request)
        {
            var result = await _menuService.UpdateAsync(request);

            return Result(result);
        }
    }
}
