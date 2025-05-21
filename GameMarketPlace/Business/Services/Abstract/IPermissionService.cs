using Core.Utilities.ResultTool;
using Models.Identity.Permission;
using Models.Identity.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IPermissionService
    {
        Task<IDataResult<SinglePermissionResponse>> GetAsync(Guid id);
        Task<IDataResult<GetPermissionsResponse>> GetListAsync();
        Task<IResult> CreateAsync(CreatePermissionRequest request);
        Task<IResult> UpdateAsync(UpdatePermissionRequest request);
        Task<IResult> DeleteAsync(Guid id);
        Task<IResult> UploadCollectionAsync(UploadPermissionCollectionRequest request);
    }
}
