using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using MeArch.Module.Security.Model.UserIdentity;
using Models.Auth.Role;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class RoleService : IRoleService
    {
        readonly IRoleRepository _roleRepository;
        readonly IPermissionRepository _permissionRepository;
        readonly IRolePermissionRepository _rolePermissionRepository;

        public RoleService(IRoleRepository roleRepository, IPermissionRepository permissionRepository, IRolePermissionRepository rolePermissionRepository)
        {
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
            _rolePermissionRepository = rolePermissionRepository;
        }

        public async Task<IResult> UploadCollectionAsync(string[] roles)
        {
            var newRoles = roles.Select(s => new Role { Name = s }).ToList();

            await _roleRepository.AddRangeAsync(newRoles);
            await _roleRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> SetPermissionsAsync(SetRolePermissionsRequest request)
        {
            if (request.Permissions == null || request.Permissions.Length == 0)
                return new ErrorResult();

            var newRolePermissions = request.Permissions.Select(s => new RolePermission
            {
                PermissionId = s,
                RoleId = request.RoleId
            });

            await _rolePermissionRepository.AddRangeAsync(newRolePermissions);
            await _rolePermissionRepository.SaveAsync();

            return new SuccessResult();
        }
    }
}
