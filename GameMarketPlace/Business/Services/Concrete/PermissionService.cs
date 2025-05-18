using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using MeArch.Module.Security.Model.UserIdentity;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class PermissionService : IPermissionService
    {
        readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<IResult> UploadCollectionAsync(string[] permissions)
        {
            var avaiblePermissions = await _permissionRepository.GetListAsync(f => permissions.Contains(f.Name));
            var newPermissions = permissions.Where(f => !avaiblePermissions.Any(x => x.Name == f))
                                            .Select(s => new Permission
                                            {
                                                Name = s
                                            });

            if (newPermissions.Any())
            {
                await _permissionRepository.AddRangeAsync(newPermissions);
                await _permissionRepository.SaveAsync();
            }

            return new SuccessResult();
        }
    }
}
