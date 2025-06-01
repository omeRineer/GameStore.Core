using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using MeArch.Module.Security.Entities.Menu;
using Core.DataAccess;

namespace DataAccess.Concrete.EntityFramework.General.Identity
{
    public interface IEfMenuPermissionRepository : IEfEntityRepository<MenuPermission, Guid>, IEfEntityRepositoryAsync<MenuPermission, Guid>
    {

    }
    public class EfMenuPermissionRepository : EfRepositoryBase<MenuPermission, Guid>, IEfMenuPermissionRepository
    {
        public EfMenuPermissionRepository(DbContext context) : base(context)
        {
        }
    }


    
}
