using AutoMapper;
using Entities.Main;
using MeArch.Module.Security.Model.UserIdentity;
using Models.Identity.Permission;
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
        }
    }
}
