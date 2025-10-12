using Business.Services.Abstract.Identity;
using GameStore.API.Web.Controllers.Base;
using MeArch.Module.Security.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Identity.Profile;
using Models.Identity.User;

namespace GameStore.API.Web.Controllers.Auth
{
    public class ProfileController : BaseController
    {
        readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _profileService.GetAsync();

            return Result(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateAsync(UpdateProfileRequest request)
        {
            var result = await _profileService.UpdateAsync(request);

            return Result(result);
        }
    }
}
