
using Business.Services.Abstract;
using GameStore.API.Web.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Game.WebService;
using Models.Media.WebService;

namespace GameStore.API.Web.Controllers.Main
{
    public class MediasController : BaseController
    {
        readonly IMediaService _mediaService;

        public MediasController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpPost("UploadCollection")]
        public async Task<IActionResult> UploadCollectionAsync(UploadMediaCollectionRequest uploadMediaCollectionRequest)
        {
            var result = await _mediaService.UploadCollectionAsync(uploadMediaCollectionRequest);

            return Result(result);
        }
    }
}
