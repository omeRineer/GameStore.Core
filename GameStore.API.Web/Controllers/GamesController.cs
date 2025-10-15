using Business.Services.Abstract;
using Business.Services.Abstract.Web;
using GameStore.API.Web.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Common;

namespace GameStore.API.Web.Controllers
{
    public class GamesController : BaseController
    {
        readonly IGameWebService GameWebService;

        public GamesController(IGameWebService gameWebService)
        {
            GameWebService = gameWebService;
        }

        [HttpPost]
        public async Task<IActionResult> GetListAsync(PaginationRequest req)
        {
            var result = await GameWebService.GetListByPage(req);

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
