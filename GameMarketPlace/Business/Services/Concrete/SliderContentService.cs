using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Main;
using NET = Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Entities.Enum.Type;
using Models.SliderContent;
using Models.Blog;

namespace Business.Services.Concrete
{
    public class SliderContentService : ISliderContentService
    {
        readonly IEfSliderContentRepository _sliderContentRepository;
        readonly IMapper _mapper;

        public SliderContentService(IEfSliderContentRepository sliderContentRepository, IMapper mapper)
        {
            _sliderContentRepository = sliderContentRepository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateAsync(CreateSliderContentRequest request)
        {
            var entity = _mapper.Map<SliderContent>(request);
            entity.GenerateId();

            await _sliderContentRepository.AddAsync(entity);
            await _sliderContentRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var entity = await _sliderContentRepository.GetSingleAsync(f => f.Id == id);

            await _sliderContentRepository.DeleteAsync(entity);
            await _sliderContentRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<SliderContentResponse>> GetAsync(Guid id)
        {
            var entity = await _sliderContentRepository.GetSingleAsync(f => f.Id == id, includes: i => i.Include(x => x.SliderType));
            var mappedEntity = _mapper.Map<SliderContentResponse>(entity);

            return new SuccessDataResult<SliderContentResponse>(mappedEntity);
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

            await _sliderContentRepository.UpdateAsync(mappedEntity);
            await _sliderContentRepository.SaveAsync();

            return new SuccessResult();
        }
    }

}
