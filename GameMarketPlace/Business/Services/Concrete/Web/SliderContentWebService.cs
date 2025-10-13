using AutoMapper;
using Business.Services.Abstract.Web;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Enum.Type;
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

        public SliderContentWebService(IEfSliderContentRepository efSliderContentRepository)
        {
            _efSliderContentRepository = efSliderContentRepository;
        }

        public async Task<IDataResult<ListResponse<SliderContentResponse>>> GetListAsync()
        {
            var data = await _efSliderContentRepository.GetListAsync(includes: i=> i.Include(x=> x.SliderType));

            var collection = Mapper.Map<List<SliderContentResponse>>(data);

            var result = new ListResponse<SliderContentResponse>(collection);

            return new SuccessDataResult<ListResponse<SliderContentResponse>>(result);
        }
    }
}
