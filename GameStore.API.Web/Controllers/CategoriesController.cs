using Business.Services.Abstract.Web;
using GameStore.API.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Web.Controllers
{
    public class CategoriesController : BaseController
    {
        readonly ICategoryWebService CategoryWebService;

        public CategoriesController(ICategoryWebService categoryWebService)
        {
            CategoryWebService = categoryWebService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await CategoryWebService.GetListAsync();

            return Result(result);
        }
    }
}
