using Business.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameStore.API.Web.Controllers.Base;
using MeArch.Module.Security.Filters;
using Models.Blog;

namespace GameStore.API.Web.Controllers.Main
{
    public class BlogsController : BaseController
    {
        readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("{id}")]
        [Authorize("Blogger,API.Web.Blogs.Get")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var result = await _blogService.GetAsync(id);

            return Result(result);
        }

        [HttpPost("Create")]
        [Authorize("Blogger,API.Web.Blogs.Create")]
        public async Task<IActionResult> CreateAsync(CreateBlogRequest request)
        {
            var result = await _blogService.CreateAsync(request);

            return Result(result);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize("Blogger,API.Web.Blogs.Delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _blogService.DeleteAsync(id);

            return Result(result);
        }

        [HttpPost("Update")]
        [Authorize("Blogger,API.Web.Blogs.Update")]
        public async Task<IActionResult> UpdateAsync(UpdateBlogRequest request)
        {
            var result = await _blogService.UpdateAsync(request);

            return Result(result);
        }
    }
}
