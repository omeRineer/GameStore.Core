using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using Microsoft.AspNetCore.Mvc;
using GameStore.API.Web.Controllers.Base;
using Models.Category.WebService;
using MeArch.Module.Security.Filters;

namespace GameStore.API.Web.Controllers.Main
{
    public class CategoriesController : BaseController
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        [Authorize("SuperAdmin,API.Web.Categories.Get")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var result = await _categoryService.GetAsync(id);

            return Result(result);
        }

        [HttpPost("Create")]
        [Authorize("SuperAdmin,API.Web.Categories.Create")]
        public async Task<IActionResult> CreateAsync(CreateCategoryRequest request)
        {
            var result = await _categoryService.CreateAsync(request);

            return Result(result);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize("SuperAdmin,API.Web.Categories.Delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _categoryService.DeleteAsync(id);

            return Result(result);
        }

        [HttpPost("Update")]
        [Authorize("SuperAdmin,API.Web.Categories.Update")]
        public async Task<IActionResult> UpdateAsync(UpdateCategoryRequest request)
        {
            var result = await _categoryService.UpdateAsync(request);

            return Result(result);
        }
    }
}
