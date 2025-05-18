using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Main;
using NET = Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using MA = Core.Entities.DTO.File;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.IO;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using Entities.Enum.Type;
using Models.SliderContent.WebService;
using Models.Category.WebService;
using Business.Helpers;
using Models.Blog.WebService;

namespace Business.Services.Concrete
{
    public class SliderContentService : ISliderContentService
    {
        readonly IMediaService _mediaService;
        readonly ISliderContentRepository _sliderContentRepository;
        readonly IMapper _mapper;

        public SliderContentService(ISliderContentRepository sliderContentRepository, IMapper mapper, IMediaService mediaService)
        {
            _sliderContentRepository = sliderContentRepository;
            _mapper = mapper;
            _mediaService = mediaService;
        }

        public async Task<IResult> CreateAsync(CreateSliderContentRequest request)
        {
            var entity = _mapper.Map<SliderContent>(request);
            entity.GenerateId();

            await _sliderContentRepository.AddAsync(entity);
            await _mediaService.AddAsync(new Media
            {
                EntityId = entity.Id,
                TypeId = (int)BusinessHelper.GetMediaTypeBySliderType(entity),
                Node = request.Image.Node,
                Name = request.Image.Name
            });
            await _sliderContentRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var entity = await _sliderContentRepository.GetSingleAsync(f => f.Id == id);
            var medias = await _mediaService.GetListByEntityAsync(id);

            await _mediaService.RemoveAsync(medias.Data);
            await _sliderContentRepository.DeleteAsync(entity);
            await _sliderContentRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<SingleSliderContentResponse>> GetAsync(Guid id)
        {
            var entity = await _sliderContentRepository.GetSingleAsync(f => f.Id == id, includes: i => i.Include(x => x.SliderType));
            var mappedEntity = _mapper.Map<SingleSliderContentResponse>(entity);

            var coverImage = await _mediaService.GetSingleByMediaTypeAsync(entity.Id, BusinessHelper.GetMediaTypeBySliderType(entity));
            if (coverImage.Data != null)
                mappedEntity.Image = new MA.File { Node = coverImage.Data.Node, Name = coverImage.Data.Name };

            return new SuccessDataResult<SingleSliderContentResponse>(mappedEntity);
        }

        public async Task<IDataResult<List<SliderContent>>> GetListAsync()
        {
            var result = await _sliderContentRepository.GetListAsync(includes: i=> i.Include(x=> x.SliderType));

            return new SuccessDataResult<List<SliderContent>>(result);
        }

        public async Task<IResult> UpdateAsync(UpdateSliderContentRequest request)
        {
            var entity = await _sliderContentRepository.GetSingleAsync(f => f.Id == request.Id);
            var mappedEntity = _mapper.Map(request, entity);
            var mediaType = BusinessHelper.GetMediaTypeBySliderType(mappedEntity);

            await _sliderContentRepository.UpdateAsync(entity);
            if (request.Image != null)
            {
                var coverImage = await _mediaService.GetSingleByMediaTypeAsync(entity.Id, mediaType);

                // TODO Ömer : Burada resim dolu gelirse her seferinde güncelliyor. Versiyonlama yapılmalı
                if (coverImage.Data != null)
                {
                    coverImage.Data.Name = request.Image.Name;
                    coverImage.Data.Node = request.Image.Node;
                    await _mediaService.EditAsync(coverImage.Data);
                }
                else
                    await _mediaService.AddAsync(new Media
                    {
                        TypeId = (int)mediaType,
                        Node = request.Image.Node,
                        Name = request.Image.Name,
                        EntityId = entity.Id
                    });
            }
            await _sliderContentRepository.SaveAsync();

            return new SuccessResult();
        }
    }

}
