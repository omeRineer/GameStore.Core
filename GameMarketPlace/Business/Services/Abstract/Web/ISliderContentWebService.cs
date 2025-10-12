using Core.Utilities.ResultTool;
using Models.Common;
using Models.SliderContent;
using System;
using System.Threading.Tasks;

namespace Business.Services.Abstract.Web
{
    public interface ISliderContentWebService
    {
        Task<IDataResult<ListResponse<SliderContentResponse>>> GetListAsync();
    }
}
