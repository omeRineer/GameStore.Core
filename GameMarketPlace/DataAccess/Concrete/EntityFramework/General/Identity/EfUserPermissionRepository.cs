using Core.DataAccess.EntityFramework;
using Core.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeArch.Module.Security.Entities.Master;

namespace DataAccess.Concrete.EntityFramework.General.Identity
{
    public interface IEfUserPermissionRepository : IEfEntityRepository<UserPermission, Guid>, IEfEntityRepositoryAsync<UserPermission, Guid>
    {

    }
    public class EfUserPermissionRepository : EfRepositoryBase<UserPermission, Guid>, IEfUserPermissionRepository
    {
        public EfUserPermissionRepository(DbContext context) : base(context)
        {
        }
    }
}
