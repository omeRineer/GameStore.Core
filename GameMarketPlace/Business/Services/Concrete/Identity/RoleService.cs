using AutoMapper;
using Business.Helpers;
using Business.Services.Abstract.Identity;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General.Identity;
using MeArch.Module.Security.Entities;
using MeArch.Module.Security.Entities.Master;
using Models.Identity.Role;
using Models.Identity.User;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.Concrete.Identity
{
    public class RoleService : IRoleService
    {
        readonly IEfRoleRepository _roleRepository;
        readonly IEfPermissionRepository _permissionRepository;
        readonly IEfRolePermissionRepository _rolePermissionRepository;
        readonly IMapper _mapper;

        public RoleService(IEfRoleRepository roleRepository, IEfPermissionRepository permissionRepository, IEfRolePermissionRepository rolePermissionRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _mapper = mapper;
        }

        public async Task<IResult> UploadCollectionAsync(UploadRoleCollectionRequest request)
        {
            var roles = await _roleRepository.GetListAsync();
            var matchesResult = BusinessHelper.GetMatchesList(roles.Select(s => s.Key.ToLower()), request.Roles.Select(s => s.Key.ToLower()));

            var newRoles = request.Roles.Where(f => matchesResult.MisMatchesCluster.Contains(f.Key.ToLower()))
                                        .Select(s => new Role
                                        {
                                            Key = s.Key,
                                            Name = s.Name,
                                            Description = s.Description,
                                        });

            await _roleRepository.AddRangeAsync(newRoles);
            await _roleRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> SetPermissionsAsync(SetRolePermissionsRequest request)
        {
            var rolePermissions = await _rolePermissionRepository.GetListAsync(f => f.RoleId == request.RoleId);
            var matchesResult = BusinessHelper.GetMatchesList(rolePermissions.Select(s => s.PermissionId), request.Permissions);

            var removedRolePermissions = rolePermissions.Where(f => matchesResult.MisMatchesSource.Contains(f.PermissionId));
            var newRolePermissions = matchesResult.MisMatchesCluster.Select(s => new RolePermission
            {
                PermissionId = s,
                RoleId = request.RoleId
            });

            if (removedRolePermissions.Any()) await _rolePermissionRepository.DeleteRangeAsync(removedRolePermissions);
            if (newRolePermissions.Any()) await _rolePermissionRepository.AddRangeAsync(newRolePermissions);

            if (newRolePermissions.Any() || removedRolePermissions.Any())
                await _rolePermissionRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<SingleRoleResponse>> GetAsync(Guid id)
        {
            var role = await _roleRepository.GetSingleOrDefaultAsync(f => f.Id == id);

            if (role == null)
                return new ErrorDataResult<SingleRoleResponse>("Rol bilgisi bulunamadı");

            var result = _mapper.Map<SingleRoleResponse>(role);

            return new SuccessDataResult<SingleRoleResponse>(result);
        }

        public async Task<IResult> CreateAsync(CreateRoleRequest request)
        {
            var newRole = _mapper.Map<Role>(request);

            await _roleRepository.AddAsync(newRole);
            await _roleRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(UpdateRoleRequest request)
        {
            var role = await _roleRepository.GetSingleAsync(f => f.Id == request.Id);
            var editRole = _mapper.Map(request, role);

            await _roleRepository.UpdateAsync(editRole);
            await _roleRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var role = await _roleRepository.GetSingleAsync(f => f.Id == id);

            await _roleRepository.DeleteAsync(role);
            await _roleRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<GetRolePermissionsResponse>> GetPermissionsAsync(Guid id)
        {
            var rolePermissions = await _rolePermissionRepository.GetListAsync(f => f.RoleId == id);

            var result = new GetRolePermissionsResponse
            {
                Permissions = rolePermissions.Select(s => s.PermissionId).ToList()
            };

            return new SuccessDataResult<GetRolePermissionsResponse>(result);
        }

        public async Task<IDataResult<GetRolesResponse>> GetListAsync()
        {
            var roles = await _roleRepository.GetListAsync();

            var result = new GetRolesResponse
            {
                Roles = roles.Select(s => new GetRoles_Item
                {
                    Id = s.Id,
                    Name = s.Name,
                    Key = s.Key,
                    Description = s.Description
                }).ToList()
            };

            return new SuccessDataResult<GetRolesResponse>(result);
        }
    }
}
