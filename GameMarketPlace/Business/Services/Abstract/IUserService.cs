using Core.Utilities.ResultTool;
using Models.Auth.User;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IUserService
    {
        Task<IResult> CreateAsync(CreateUserRequest request);
        Task<IResult> SetPermissionsAsync(SetUserPermissionsRequest request);
        Task<IResult> SetRolesAsync(SetUserRolesRequest request);
    }
}
