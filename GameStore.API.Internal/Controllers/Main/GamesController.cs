using Business.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameStore.API.Web.Controllers.Base;
using MeArch.Module.Security.Filters;
using Models.Game;

namespace GameStore.API.Web.Controllers.Main
{
    public class GamesController : BaseController
    {
        IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("{id}")]
        [Authorize("SuperAdmin,API.Web.Games.Get")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var result = await _gameService.GetAsync(id);

            return Result(result);
        }

        [HttpPost("Create")]
        [Authorize("SuperAdmin,API.Web.Games.Create")]
        public async Task<IActionResult> CreateAsync(CreateGameRequest request)
        {
            var result = await _gameService.CreateAsync(request);

            return Result(result);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize("SuperAdmin,API.Web.Games.Delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _gameService.DeleteAsync(id);

            return Result(result);
        }

        [HttpPost("Update")]
        [Authorize("SuperAdmin,API.Web.Games.Update")]
        public async Task<IActionResult> UpdateAsync(UpdateGameRequest request)
        {
            var result = await _gameService.UpdateAsync(request);

            return Result(result);
        }

        [HttpPost("UploadImages")]
        [Authorize("SuperAdmin,API.Web.Games.UploadImages")]
        public async Task<IActionResult> UploadImagesAsync(UploadGameImagesRequest request)
        {
            var result = await _gameService.UploadImagesAsync(request);

            return Result(result);
        }

        [HttpGet("GetImages/{id}")]
        [Authorize("SuperAdmin,API.Web.Games.GetImages")]
        public async Task<IActionResult> GetImagesAsync([FromRoute] Guid id)
        {
            var result = await _gameService.GetImagesAsync(id);

            return Result(result);
        }
    }
}
