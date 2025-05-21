using AutoMapper;
using Business.Helpers;
using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General.Identity;
using MeArch.Module.Security.Model.UserIdentity;
using Models.Identity.Role;
using Models.Identity.User;
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
        readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IPermissionRepository permissionRepository, IRolePermissionRepository rolePermissionRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _mapper = mapper;
        }

        public async Task<IResult> UploadCollectionAsync(UploadRoleCollectionRequest request)
        {
            var roles = await _roleRepository.GetListAsync();
            var matchesResult = BusinessHelper.GetMatchesList(roles.Select(s=> s.Key.ToLower()), request.Roles.Select(s=> s.Key.ToLower()));

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
