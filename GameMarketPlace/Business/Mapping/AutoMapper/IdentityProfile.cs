using AutoMapper;
using Entities.Main;
using MeArch.Module.Security.Entities.Master;
using MeArch.Module.Security.Entities.Menu;
using Models.Identity.Menu;
using Models.Identity.Permission;
using Models.Identity.Profile;
using Models.Identity.Role;
using Models.Identity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            #region User
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<User, SingleUserResponse>();
            #endregion

            #region Profile
            CreateMap<User, GetProfileResponse>();
            CreateMap<UpdateProfileRequest, User>();
            #endregion

            #region Role
            CreateMap<CreateRoleRequest, Role>();
            CreateMap<UpdateRoleRequest, Role>();
            CreateMap<Role, SingleRoleResponse>();
            #endregion

            #region Permission
            CreateMap<CreatePermissionRequest, Permission>();
            CreateMap<UpdatePermissionRequest, Permission>();
            CreateMap<Permission, SinglePermissionResponse>();
            #endregion

            #region Menu
            CreateMap<CreateMenuRequest, Menu>();
            CreateMap<UpdateMenuRequest, Menu>();
            CreateMap<Menu, SingleMenuResponse>();
            #endregion
        }
    }
}
