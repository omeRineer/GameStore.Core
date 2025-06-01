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
    public interface IEfPermissionRepository : IEfEntityRepository<Permission, Guid>, IEfEntityRepositoryAsync<Permission, Guid>
    {

    }
    public class EfPermissionRepository : EfRepositoryBase<Permission, Guid>, IEfPermissionRepository
    {
        public EfPermissionRepository(DbContext context) : base(context)
        {
        }
    }
}
