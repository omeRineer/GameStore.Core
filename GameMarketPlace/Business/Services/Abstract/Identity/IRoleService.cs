using Core.Utilities.ResultTool;
using Models.Identity.Role;
using Models.Identity.User;
using System;
using System.Threading.Tasks;

namespace Business.Services.Abstract.Identity
{
    public interface IRoleService
    {
        Task<IDataResult<SingleRoleResponse>> GetAsync(Guid id);
        Task<IDataResult<GetRolesResponse>> GetListAsync();
        Task<IResult> CreateAsync(CreateRoleRequest request);
        Task<IResult> UpdateAsync(UpdateRoleRequest request);
        Task<IResult> DeleteAsync(Guid id);
        Task<IResult> UploadCollectionAsync(UploadRoleCollectionRequest request);
        Task<IResult> SetPermissionsAsync(SetRolePermissionsRequest request);
        Task<IDataResult<GetRolePermissionsResponse>> GetPermissionsAsync(Guid id);
    }
}
