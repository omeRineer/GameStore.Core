using Core.Utilities.ResultTool;
using Models.Identity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<SingleUserResponse>> GetAsync(Guid id);
        Task<IResult> CreateAsync(CreateUserRequest request);
        Task<IResult> UpdateAsync(UpdateUserRequest request);
        Task<IResult> DeleteAsync(Guid id);
        Task<IResult> SetPermissionsAsync(SetUserPermissionsRequest request);
        Task<IResult> SetRolesAsync(SetUserRolesRequest request);
        Task<IDataResult<GetUserRolesResponse>> GetRolesAsync(Guid id);
        Task<IDataResult<GetUserPermissionsResponse>> GetPermissionsAsync(Guid id);
    }
}
