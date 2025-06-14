using Core.Utilities.ResultTool;
using Models.Identity.Profile;
using Models.Identity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract.Identity
{
    public interface IProfileService
    {
        Task<IDataResult<GetProfileResponse>> GetAsync();
        Task<IResult> UpdateAsync(UpdateProfileRequest request);
    }
}
