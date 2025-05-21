using AutoMapper;
using Business.Helpers;
using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General.Identity;
using MeArch.Module.Security.Model.UserIdentity;
using Models.Identity.Permission;
using Models.Identity.Role;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class PermissionService : IPermissionService
    {
        readonly IPermissionRepository _permissionRepository;
        readonly IMapper _mapper;

        public PermissionService(IPermissionRepository permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateAsync(CreatePermissionRequest request)
        {
            var newPermission = _mapper.Map<Permission>(request);

            await _permissionRepository.AddAsync(newPermission);
            await _permissionRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var permission = await _permissionRepository.GetSingleAsync(f => f.Id == id);

            await _permissionRepository.DeleteAsync(permission);
            await _permissionRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<SinglePermissionResponse>> GetAsync(Guid id)
        {
            var permission = await _permissionRepository.GetSingleOrDefaultAsync(f => f.Id == id);

            if (permission == null)
                return new ErrorDataResult<SinglePermissionResponse>("İzin bilgisi bulunamadı");

            var result = _mapper.Map<SinglePermissionResponse>(permission);

            return new SuccessDataResult<SinglePermissionResponse>(result);
        }

        public async Task<IDataResult<GetPermissionsResponse>> GetListAsync()
        {
            var permissions = await _permissionRepository.GetListAsync();

            var result = new GetPermissionsResponse
            {
                Permissions = permissions.Select(s => new GetPermissions_Item
                {
                    Id = s.Id,
                    Name = s.Name,
                    Key = s.Key,
                    Description = s.Description
                }).ToList()
            };

            return new SuccessDataResult<GetPermissionsResponse>(result);
        }

        public async Task<IResult> UpdateAsync(UpdatePermissionRequest request)
        {
            var permission = await _permissionRepository.GetSingleAsync(f => f.Id == request.Id);
            var editPermission = _mapper.Map(request, permission);

            await _permissionRepository.UpdateAsync(editPermission);
            await _permissionRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> UploadCollectionAsync(UploadPermissionCollectionRequest request)
        {
            var permissions = await _permissionRepository.GetListAsync();
            var matchesResult = BusinessHelper.GetMatchesList(permissions.Select(s => s.Key.ToLower()), request.Permissions.Select(s => s.Key.ToLower()));

            var newPermissions = request.Permissions.Where(f => matchesResult.MisMatchesCluster.Contains(f.Key.ToLower()))
                                        .Select(s => new Permission
                                        {
                                            Key = s.Key,
                                            Name = s.Name,
                                            Description = s.Description,
                                        });

            await _permissionRepository.AddRangeAsync(newPermissions);
            await _permissionRepository.SaveAsync();

            return new SuccessResult();
        }
    }
}
