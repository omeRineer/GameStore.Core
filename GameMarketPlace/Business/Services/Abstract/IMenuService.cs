using Core.Utilities.ResultTool;
using Models.Category;
using Models.Identity.Menu;
using Models.Identity.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IMenuService
    {
        Task<IDataResult<GetMenusResponse>> GetListAsync();
        Task<IDataResult<GetMenusResponse>> GetSessionMenusAsync();
        Task<IDataResult<SingleMenuResponse>> GetAsync(Guid id);
        Task<IResult> CreateAsync(CreateMenuRequest request);
        Task<IResult> UpdateAsync(UpdateMenuRequest request);
        Task<IResult> DeleteAsync(Guid id);
        Task<IResult> SetPermissionsAsync(SetMenuPermissionsRequest request);
        Task<IDataResult<GetMenuPermissionsResponse>> GetPermissionsAsync(Guid id);
        Task<IResult> SetRolesAsync(SetMenuRolesRequest request);
        Task<IDataResult<GetMenuRolesResponse>> GetRolesAsync(Guid id);
    }
}
