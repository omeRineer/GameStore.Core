using Core.Utilities.ResultTool;
using Models.Category;
using Models.Common;
using System;
using System.Threading.Tasks;

namespace Business.Services.Abstract.Web
{
    public interface ICategoryWebService
    {
        Task<IDataResult<ListResponse<CategoryResponse>>> GetListAsync();
    }
}
