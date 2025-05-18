using AutoMapper;
using Business.Services.Abstract;
using MA = Core.Entities.DTO.File;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Main;
using MassTransit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enum.Type;
using Models.Blog.WebService;
using Models.Category.WebService;

namespace Business.Services.Concrete
{
    public class BlogService : IBlogService
    {
        readonly IBlogRepository _blogRepository;
        readonly IMediaService _mediaService;
        readonly IMapper _mapper;

        public BlogService(IBlogRepository blogRepository, IMapper mapper, IMediaService mediaService)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _mediaService = mediaService;
        }

        public async Task<IResult> CreateAsync(CreateBlogRequest createBlogRequest)
        {
            var entity = _mapper.Map<Blog>(createBlogRequest);
            entity.GenerateId();

            await _blogRepository.AddAsync(entity);
            await _mediaService.AddAsync(new Media
            {
                EntityId = entity.Id,
                TypeId = (int)MediaTypeEnum.BlogCoverImage,
                Node = createBlogRequest.CoverImage.Node,
                Name = createBlogRequest.CoverImage.Name
            });
            await _blogRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var entity = await _blogRepository.GetSingleAsync(f => f.Id == id);
            var medias = await _mediaService.GetListByEntityAsync(id);

            await _blogRepository.DeleteAsync(entity);
            await _mediaService.RemoveAsync(medias.Data);
            await _blogRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<SingleBlogResponse>> GetAsync(Guid id)
        {
            var entity = await _blogRepository.GetSingleAsync(f => f.Id == id);
            var mappedEntity = _mapper.Map<SingleBlogResponse>(entity);

            var coverImage = await _mediaService.GetSingleByMediaTypeAsync(entity.Id, MediaTypeEnum.BlogCoverImage);
            if (coverImage.Data != null)
                mappedEntity.CoverImage = new MA.File { Node = coverImage.Data.Node, Name = coverImage.Data.Name };

            return new SuccessDataResult<SingleBlogResponse>(mappedEntity);
        }

        public async Task<IResult> UpdateAsync(UpdateBlogRequest updateBlogRequest)
        {
            var entity = await _blogRepository.GetSingleAsync(f => f.Id == updateBlogRequest.Id);
            var mappedEntity = _mapper.Map(updateBlogRequest, entity);

            await _blogRepository.UpdateAsync(entity);

            if (updateBlogRequest.CoverImage != null)
            {
                var coverImage = await _mediaService.GetSingleByMediaTypeAsync(entity.Id, MediaTypeEnum.BlogCoverImage);

                // TODO Ömer : Burada resim dolu gelirse her seferinde güncelliyor. Versiyonlama yapılmalı
                if (coverImage.Data != null)
                {
                    coverImage.Data.Name = updateBlogRequest.CoverImage.Name;
                    coverImage.Data.Node = updateBlogRequest.CoverImage.Node;
                    await _mediaService.EditAsync(coverImage.Data);
                }
                else
                    await _mediaService.AddAsync(new Media
                    {
                        TypeId = (int)MediaTypeEnum.BlogCoverImage,
                        Node = updateBlogRequest.CoverImage.Node,
                        Name = updateBlogRequest.CoverImage.Name,
                        EntityId = entity.Id
                    });
            }

            await _blogRepository.SaveAsync();

            return new SuccessResult();
        }
    }
}
