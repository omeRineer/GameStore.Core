using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Main;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enum.Type;
using Models.Blog;

namespace Business.Services.Concrete
{
    public class BlogService : IBlogService
    {
        readonly IEfBlogRepository _blogRepository;
        readonly IMapper _mapper;

        public BlogService(IEfBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateAsync(CreateBlogRequest createBlogRequest)
        {
            var entity = _mapper.Map<Blog>(createBlogRequest);
            entity.GenerateId();

            await _blogRepository.AddAsync(entity);

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var entity = await _blogRepository.GetSingleAsync(f => f.Id == id);

            await _blogRepository.DeleteAsync(entity);
            await _blogRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<BlogResponse>> GetAsync(Guid id)
        {
            var entity = await _blogRepository.GetSingleAsync(f => f.Id == id);
            var mappedEntity = _mapper.Map<BlogResponse>(entity);

            return new SuccessDataResult<BlogResponse>(mappedEntity);
        }

        public async Task<IResult> UpdateAsync(UpdateBlogRequest updateBlogRequest)
        {
            var entity = await _blogRepository.GetSingleAsync(f => f.Id == updateBlogRequest.Id);
            var mappedEntity = _mapper.Map(updateBlogRequest, entity);

            await _blogRepository.UpdateAsync(entity);

            await _blogRepository.SaveAsync();

            return new SuccessResult();
        }
    }
}
