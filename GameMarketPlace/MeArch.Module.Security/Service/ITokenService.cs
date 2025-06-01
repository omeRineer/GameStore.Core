using MeArch.Module.Security.Entities.Master;
using MeArch.Module.Security.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Security.Service
{
    public interface ITokenService
    {
        AccessToken GenerateToken(User user, List<Role> roles, List<Permission> permissions);
    }
}
