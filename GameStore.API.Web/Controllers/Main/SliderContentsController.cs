using Business.Services.Abstract;
using Entities.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameStore.API.Web.Controllers.Base;
using Models.SliderContent.WebService;
using MeArch.Module.Security.Filters;

namespace GameStore.API.Web.Controllers.Main
{
    public class SliderContentsController : BaseController
    {
        readonly ISliderContentService _sliderContentService;

        public SliderContentsController(ISliderContentService sliderContentService)
        {
            _sliderContentService = sliderContentService;
        }

        [HttpGet("{id}")]
        [Authorize("SuperAdmin,API.Web.SliderContents.Get")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var result = await _sliderContentService.GetAsync(id);

            return Result(result);
        }

        [HttpPost("Create")]
        [Authorize("SuperAdmin,API.Web.SliderContents.Create")]
        public async Task<IActionResult> CreateAsync(CreateSliderContentRequest request)
        {
            var result = await _sliderContentService.CreateAsync(request);

            return Result(result);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize("SuperAdmin,API.Web.SliderContents.Delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _sliderContentService.DeleteAsync(id);

            return Result(result);
        }

        [HttpPost("Update")]
        [Authorize("SuperAdmin,API.Web.SliderContents.Update")]
        public async Task<IActionResult> UpdateAsync(UpdateSliderContentRequest request)
        {
            var result = await _sliderContentService.UpdateAsync(request);

            return Result(result);
        }
    }
}
