using Core.Utilities.ResultTool;
using Models.Identity.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<UserLoginResponse>> LoginAsync(UserLoginRequest request);
    }
}
