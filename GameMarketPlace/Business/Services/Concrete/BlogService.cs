using AutoMapper;
using Business.Services.Abstract;
using MA = Core.Entities.DTO.File;
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
        readonly IEfMediaRepository _mediaRepository;
        readonly IMapper _mapper;

        public BlogService(IEfBlogRepository blogRepository, IMapper mapper, IEfMediaRepository mediaRepository)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _mediaRepository = mediaRepository;
        }

        public async Task<IResult> CreateAsync(CreateBlogRequest createBlogRequest)
        {
            var entity = _mapper.Map<Blog>(createBlogRequest);
            entity.GenerateId();

            await _blogRepository.AddAsync(entity);
            if (createBlogRequest.CoverImage != null)
            {
                var coverImage = new Media
                {
                    Name = createBlogRequest.CoverImage.Name,
                    EntityId = entity.Id,
                    Url = createBlogRequest.CoverImage.Url,
                    TypeId = (int)MediaType.BlogCoverImage
                };

                await _mediaRepository.AddAsync(coverImage);
            }
            await _blogRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var entity = await _blogRepository.GetSingleAsync(f => f.Id == id);
            var mediaList = await _mediaRepository.GetListAsync(f => f.EntityId == id);

            await _blogRepository.DeleteAsync(entity);
            await _mediaRepository.DeleteRangeAsync(mediaList);
            await _blogRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<SingleBlogResponse>> GetAsync(Guid id)
        {
            var entity = await _blogRepository.GetSingleAsync(f => f.Id == id);
            var mappedEntity = _mapper.Map<SingleBlogResponse>(entity);

            var coverImage = await _mediaRepository.GetSingleOrDefaultAsync(f => f.EntityId == id && f.TypeId == (int)MediaType.BlogCoverImage);
            if (coverImage != null)
                mappedEntity.CoverImage = new MA.File { Url = coverImage.Url, Name = coverImage.Name };

            return new SuccessDataResult<SingleBlogResponse>(mappedEntity);
        }

        public async Task<IResult> UpdateAsync(UpdateBlogRequest updateBlogRequest)
        {
            var entity = await _blogRepository.GetSingleAsync(f => f.Id == updateBlogRequest.Id);
            var mappedEntity = _mapper.Map(updateBlogRequest, entity);

            await _blogRepository.UpdateAsync(entity);

            if (updateBlogRequest.CoverImage != null)
            {
                var coverImage = await _mediaRepository.GetSingleOrDefaultAsync(f => f.EntityId == entity.Id && f.TypeId == (int)MediaType.BlogCoverImage);

                // TODO Ömer : Burada resim dolu gelirse her seferinde güncelliyor. Versiyonlama yapılmalı
                if (coverImage != null)
                {
                    coverImage.Name = updateBlogRequest.CoverImage.Name;
                    coverImage.Url = updateBlogRequest.CoverImage.Url;
                    await _mediaRepository.UpdateAsync(coverImage);
                }
                else
                    await _mediaRepository.AddAsync(new Media
                    {
                        TypeId = (int)MediaType.BlogCoverImage,
                        Name = updateBlogRequest.CoverImage.Name,
                        EntityId = entity.Id,
                        Url = updateBlogRequest.CoverImage.Url
                    });
            }

            await _blogRepository.SaveAsync();

            return new SuccessResult();
        }
    }
}
