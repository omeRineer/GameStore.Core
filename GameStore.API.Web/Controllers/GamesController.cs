using Business.Services.Abstract;
using Business.Services.Abstract.Web;
using GameStore.API.Web.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Web.Controllers
{
    public class GamesController : BaseController
    {
        readonly IGameWebService GameWebService;

        public GamesController(IGameWebService gameWebService)
        {
            GameWebService = gameWebService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await GameWebService.GetListAsync();

            return Result(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await GameWebService.GetAsync(id);

            return Result(result);
        }
    }
}
