using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using MeArch.Module.Security.Model.UserIdentity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.General
{
    public interface IRolePermissionRepository : IEntityRepository<RolePermission>
    {

    }
    public class RolePermissionRepository : EfRepositoryBase<RolePermission>, IRolePermissionRepository
    {
        public RolePermissionRepository(DbContext context) : base(context)
        {
        }
    }
}
