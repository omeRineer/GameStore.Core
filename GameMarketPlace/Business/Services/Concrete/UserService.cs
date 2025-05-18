using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using MeArch.Module.Security.Model.UserIdentity;
using Models.Auth.User;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class UserService : IUserService
    {
        readonly IUserPermissionRepository _userPermissionRepository;
        readonly IUserRoleRepository _userRoleRepository;
        readonly IPermissionRepository _permissionRepository;
        readonly IRoleRepository _roleRepository;
        readonly IUserRepository _userRepository;

        public UserService(IUserPermissionRepository userPermissionRepository, IUserRoleRepository userRoleRepository, IPermissionRepository permissionRepository, IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _userPermissionRepository = userPermissionRepository;
            _userRoleRepository = userRoleRepository;
            _permissionRepository = permissionRepository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public async Task<IResult> CreateAsync(CreateUserRequest request)
        {
            var newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                Phone = request.Phone,
                UserName = request.UserName,
                BirthdayDate = DateTime.Now
            };

            if (request.Roles != null && request.Roles.Length > 0)
                newUser.UserRoles = request.Roles.Select(s => new UserRole
                {
                    RoleId = s
                }).ToList();

            if (request.Permissions != null && request.Permissions.Length > 0)
                newUser.UserPermissions = request.Permissions.Select(s => new UserPermission
                {
                    PermissionId = s
                }).ToList();

            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> SetPermissionsAsync(SetUserPermissionsRequest request)
        {
            if (request.Permissions == null || request.Permissions.Length == 0)
                return new ErrorResult();

            var newUserPermissions = request.Permissions.Select(s => new UserPermission
            {
                PermissionId = s,
                UserId = request.UserId
            });

            await _userPermissionRepository.AddRangeAsync(newUserPermissions);
            await _userPermissionRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> SetRolesAsync(SetUserRolesRequest request)
        {
            if (request.Roles == null || request.Roles.Length == 0)
                return new ErrorResult();

            var newUserRoles = request.Roles.Select(s => new UserRole
            {
                RoleId = s,
                UserId = request.UserId
            });

            await _userRoleRepository.AddRangeAsync(newUserRoles);
            await _userRoleRepository.SaveAsync();

            return new SuccessResult();
        }
    }
}
