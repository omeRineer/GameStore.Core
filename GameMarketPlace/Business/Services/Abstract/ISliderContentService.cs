using Core.Business;
using Core.Utilities.ResultTool;
using Entities.Main;
using Models.SliderContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface ISliderContentService
    {
        Task<IDataResult<SingleSliderContentResponse>> GetAsync(Guid id);
        Task<IDataResult<List<SliderContent>>> GetListAsync();
        Task<IResult> CreateAsync(CreateSliderContentRequest request);
        Task<IResult> UpdateAsync(UpdateSliderContentRequest request);
        Task<IResult> DeleteAsync(Guid id);
    }
}
