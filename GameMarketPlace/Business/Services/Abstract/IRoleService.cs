using Core.Utilities.ResultTool;
using Models.Auth.Role;
using System;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IRoleService
    {
        Task<IResult> UploadCollectionAsync(string[] roles);
        Task<IResult> SetPermissionsAsync(SetRolePermissionsRequest request);
    }
}
