using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using MeArch.Module.Security.Entities.Master;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess.Concrete.EntityFramework.General.Identity
{
    public interface IEfRolePermissionRepository : IEfEntityRepository<RolePermission, Guid>, IEfEntityRepositoryAsync<RolePermission, Guid>
    {

    }
    public class EfRolePermissionRepository : EfRepositoryBase<RolePermission, Guid>, IEfRolePermissionRepository
    {
        public EfRolePermissionRepository(DbContext context) : base(context)
        {
        }
    }
}
