using AutoMapper;
using Business.Services.Abstract.Web;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Enum.Type;
using Entities.Main;
using Microsoft.EntityFrameworkCore;
using Models.Common;
using Models.SliderContent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.Concrete.Web
{
    public class SliderContentWebService : ISliderContentWebService
    {
        readonly IEfSliderContentRepository _efSliderContentRepository;
        readonly IMapper Mapper;

        public SliderContentWebService(IEfSliderContentRepository efSliderContentRepository, IMapper mapper)
        {
            _efSliderContentRepository = efSliderContentRepository;
            Mapper = mapper;
        }

        public async Task<IDataResult<ListResponse<SliderContentResponse>>> GetListAsync()
        {
            var data = await _efSliderContentRepository.GetListAsync(f=> f.IsActive, includes: i=> i.Include(x=> x.SliderType));

            List<SliderContent> filteredData = new();
            filteredData.AddRange(data.Where(f => f.SliderTypeId == (int)SliderType.SliderSideItem)
                                            .OrderByDescending(o => o.CreateDate)
                                            .ThenByDescending(o => o.Priority)
                                            .Take(4));
            filteredData.AddRange(data.Where(f => f.SliderTypeId == (int)SliderType.SliderItem)
                                            .OrderByDescending(o => o.CreateDate)
                                            .ThenByDescending(o => o.Priority));

            var collection = Mapper.Map<List<SliderContentResponse>>(filteredData);

            var result = new ListResponse<SliderContentResponse>(collection);

            return new SuccessDataResult<ListResponse<SliderContentResponse>>(result);
        }
    }
}
