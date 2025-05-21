using Business.Services.Abstract.Lookup;
using Core.Entities.Concrete.ProcessGroups;
using GameStore.API.Web.Controllers.Base;
using MeArch.Module.Security.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Web.Controllers.Lookups
{
    [Authorize("SuperAdmin,API.Web.Lookups")]
    public class LookupsController : BaseController
    {
        readonly ILookupService _lookupService;

        public LookupsController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProcessGroups()
            => Result(await _lookupService.GetProcessGroupsAsync());

        [HttpGet("Types/{processGroup}")]
        public async Task<IActionResult> GetTypeLookups(int processGroup)
            => Result(await _lookupService.GetTypesAsync(processGroup));

        [HttpGet("Statuses/{processGroup}")]
        public async Task<IActionResult> GetStatusLookups(int processGroup)
            => Result(await _lookupService.GetStatusesAsync(processGroup));



        [HttpGet("SliderTypes")]
        public async Task<IActionResult> GetSliderTypes()
            => Result(await _lookupService.GetTypesAsync((int) ProcessGroupEnum.SliderType));

        [HttpGet("MediaTypes")]
        public async Task<IActionResult> GetMediaTypes()
            => Result(await _lookupService.GetTypesAsync((int)ProcessGroupEnum.MediaType));
    }
}
