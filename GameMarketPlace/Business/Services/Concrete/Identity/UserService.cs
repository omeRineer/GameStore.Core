using AutoMapper;
using Business.Helpers;
using Business.Services.Abstract.Identity;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General.Identity;
using MeArch.Module.Security.Entities;
using MeArch.Module.Security.Entities.Master;
using MeArch.Module.Security.Utilities;
using Models.Identity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete.Identity
{
    public class UserService : IUserService
    {
        readonly IEfUserPermissionRepository _userPermissionRepository;
        readonly IEfUserRoleRepository _userRoleRepository;
        readonly IEfPermissionRepository _permissionRepository;
        readonly IEfRoleRepository _roleRepository;
        readonly IEfUserRepository _userRepository;
        readonly IMapper _mapper;

        public UserService(IEfUserPermissionRepository userPermissionRepository, IEfUserRoleRepository userRoleRepository, IEfPermissionRepository permissionRepository, IEfRoleRepository roleRepository, IEfUserRepository userRepository, IMapper mapper)
        {
            _userPermissionRepository = userPermissionRepository;
            _userRoleRepository = userRoleRepository;
            _permissionRepository = permissionRepository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateAsync(CreateUserRequest request)
        {
            var newUser = _mapper.Map<User>(request);

            newUser.Key = UserKeyHelper.GenerateUserKey("GMST");
            while (await _userRepository.IsExistAsync(i=> i.Key == newUser.Key))
                newUser.Key = UserKeyHelper.GenerateUserKey("GMST");

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

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var user = await _userRepository.GetSingleAsync(f => f.Id == id);

            await _userRepository.DeleteAsync(user);
            await _userRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<SingleUserResponse>> GetAsync(Guid id)
        {
            var user = await _userRepository.GetSingleOrDefaultAsync(f => f.Id == id);

            if (user == null)
                return new ErrorDataResult<SingleUserResponse>("Kullanıcı bulunamadı");

            var result = _mapper.Map<SingleUserResponse>(user);

            return new SuccessDataResult<SingleUserResponse>(result);
        }

        public async Task<IDataResult<GetUserPermissionsResponse>> GetPermissionsAsync(Guid id)
        {
            var userPermissions = await _userPermissionRepository.GetListAsync(f => f.UserId == id);

            var result = new GetUserPermissionsResponse
            {
                Permissions = userPermissions.Select(s => s.PermissionId).ToList()
            };

            return new SuccessDataResult<GetUserPermissionsResponse>(result);
        }

        public async Task<IDataResult<GetUserRolesResponse>> GetRolesAsync(Guid id)
        {
            var userRoles = await _userRoleRepository.GetListAsync(f => f.UserId == id);

            var result = new GetUserRolesResponse
            {
                Roles = userRoles.Select(s => s.RoleId).ToList()
            };

            return new SuccessDataResult<GetUserRolesResponse>(result);
        }

        public async Task<IResult> SetPermissionsAsync(SetUserPermissionsRequest request)
        {
            var userPermissions = await _userPermissionRepository.GetListAsync(f => f.UserId == request.UserId);
            var matchesResult = BusinessHelper.GetMatchesList(userPermissions.Select(s => s.PermissionId), request.Permissions);

            var removedUserPermissions = userPermissions.Where(f => matchesResult.MisMatchesSource.Contains(f.PermissionId));
            var newUserPermissions = matchesResult.MisMatchesCluster.Select(s => new UserPermission
            {
                PermissionId = s,
                UserId = request.UserId
            });

            if (removedUserPermissions.Any()) await _userPermissionRepository.DeleteRangeAsync(removedUserPermissions);
            if (newUserPermissions.Any()) await _userPermissionRepository.AddRangeAsync(newUserPermissions);

            if (newUserPermissions.Any() || removedUserPermissions.Any())
                await _userRoleRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> SetRolesAsync(SetUserRolesRequest request)
        {
            var userRoles = await _userRoleRepository.GetListAsync(f => f.UserId == request.UserId);
            var matchesResult = BusinessHelper.GetMatchesList(userRoles.Select(s => s.RoleId), request.Roles);

            var removedUserRoles = userRoles.Where(f => matchesResult.MisMatchesSource.Contains(f.RoleId));
            var newUserRoles = matchesResult.MisMatchesCluster.Select(s => new UserRole
            {
                RoleId = s,
                UserId = request.UserId
            });

            if (removedUserRoles.Any()) await _userRoleRepository.DeleteRangeAsync(removedUserRoles);
            if (newUserRoles.Any()) await _userRoleRepository.AddRangeAsync(newUserRoles);

            if (removedUserRoles.Any() || newUserRoles.Any())
                await _userRoleRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(UpdateUserRequest request)
        {
            var user = await _userRepository.GetSingleAsync(f => f.Id == request.Id);
            var editUser = _mapper.Map(request, user);

            await _userRepository.UpdateAsync(editUser);
            await _userRepository.SaveAsync();

            return new SuccessResult();
        }
    }
}
