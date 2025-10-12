using Business.Services.Abstract.Web;
using GameStore.API.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Web.Controllers
{
    public class SliderContentsController : BaseController
    {
        readonly ISliderContentWebService SliderContentWebService;

        public SliderContentsController(ISliderContentWebService sliderContentWebService)
        {
            SliderContentWebService = sliderContentWebService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await SliderContentWebService.GetListAsync();

            return Result(result);
        }
    }
}
