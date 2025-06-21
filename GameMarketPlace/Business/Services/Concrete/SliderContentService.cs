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
using Entities.Enum.Type;
using Business.Helpers;
using Models.SliderContent;
using Models.Blog;

namespace Business.Services.Concrete
{
    public class SliderContentService : ISliderContentService
    {
        readonly IEfSliderContentRepository _sliderContentRepository;
        readonly IEfMediaRepository _mediaRepository;
        readonly IMapper _mapper;

        public SliderContentService(IEfSliderContentRepository sliderContentRepository, IMapper mapper, IEfMediaRepository mediaRepository)
        {
            _sliderContentRepository = sliderContentRepository;
            _mapper = mapper;
            _mediaRepository = mediaRepository;
        }

        public async Task<IResult> CreateAsync(CreateSliderContentRequest request)
        {
            var entity = _mapper.Map<SliderContent>(request);
            entity.GenerateId();

            await _sliderContentRepository.AddAsync(entity);
            if (request.CoverImage != null)
            {
                var coverImage = new Media
                {
                    Name = request.CoverImage.Name,
                    EntityId = entity.Id,
                    Url = request.CoverImage.Url,
                    TypeId = (int)BusinessHelper.GetMediaTypeBySliderType(entity)
                };

                await _mediaRepository.AddAsync(coverImage);
            }
            await _sliderContentRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var entity = await _sliderContentRepository.GetSingleAsync(f => f.Id == id);
            var mediaList = await _mediaRepository.GetListAsync(f => f.EntityId == id);

            await _sliderContentRepository.DeleteAsync(entity);
            await _mediaRepository.DeleteRangeAsync(mediaList);
            await _sliderContentRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<SingleSliderContentResponse>> GetAsync(Guid id)
        {
            var entity = await _sliderContentRepository.GetSingleAsync(f => f.Id == id, includes: i => i.Include(x => x.SliderType));
            var mappedEntity = _mapper.Map<SingleSliderContentResponse>(entity);
            var mediaType = BusinessHelper.GetMediaTypeBySliderType(entity);

            var coverImage = await _mediaRepository.GetSingleOrDefaultAsync(f => f.EntityId == id && f.TypeId == (int)mediaType);
            if (coverImage != null)
                mappedEntity.CoverImage = new MA.File { Url = coverImage.Url, Name = coverImage.Name };

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
            if (request.CoverImage != null)
            {
                var coverImage = await _mediaRepository.GetSingleOrDefaultAsync(f => f.EntityId == entity.Id && f.TypeId == (int)mediaType);

                // TODO Ömer : Burada resim dolu gelirse her seferinde güncelliyor. Versiyonlama yapılmalı
                if (coverImage != null)
                {
                    coverImage.Name = request.CoverImage.Name;
                    coverImage.Url = request.CoverImage.Url;
                    await _mediaRepository.UpdateAsync(coverImage);
                }
                else
                    await _mediaRepository.AddAsync(new Media
                    {
                        TypeId = (int)mediaType,
                        Name = request.CoverImage.Name,
                        EntityId = entity.Id,
                        Url = request.CoverImage.Url,
                    });
            }
            await _sliderContentRepository.SaveAsync();

            return new SuccessResult();
        }
    }

}
