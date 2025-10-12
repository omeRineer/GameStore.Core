using AutoMapper;
using Business.Services.Abstract.Web;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Enum.Type;
using Microsoft.EntityFrameworkCore;
using Models.Common;
using Models.Media;
using Models.SliderContent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.Concrete.Web
{
    public class SliderContentWebService : ISliderContentWebService
    {
        readonly IEfSliderContentRepository _efSliderContentRepository;
        readonly IEfMediaRepository _efMediaRepository;
        readonly IMapper Mapper;

        public SliderContentWebService(IEfSliderContentRepository efSliderContentRepository, IMapper mapper, IEfMediaRepository efMediaRepository)
        {
            _efSliderContentRepository = efSliderContentRepository;
            Mapper = mapper;
            _efMediaRepository = efMediaRepository;
        }

        public async Task<IDataResult<ListResponse<SliderContentResponse>>> GetListAsync()
        {
            var data = await _efSliderContentRepository.GetListAsync(includes: i=> i.Include(x=> x.SliderType));
            var mediaList = await _efMediaRepository.GetListAsync(f=> data.Select(s=> s.Id).Contains(f.EntityId) && (f.TypeId == (int) MediaType.SliderItemImage || f.TypeId == (int)MediaType.SliderSideItemImage));

            var collection = Mapper.Map<List<SliderContentResponse>>(data);

            collection.ForEach(item =>
            {
                var media = mediaList.FirstOrDefault(f => f.EntityId == item.Id);
                item.CoverImage = new MediaResponse
                {
                    EntityId = item.Id,
                    Id = media.Id,
                    Name = media.Name,
                    TypeId = media.TypeId,
                    Url = media.Url
                };
            });

            var result = new ListResponse<SliderContentResponse>(collection);

            return new SuccessDataResult<ListResponse<SliderContentResponse>>(result);
        }
    }
}
