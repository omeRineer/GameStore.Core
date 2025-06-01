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
    public interface IEfUserRoleRepository : IEfEntityRepository<UserRole, Guid>, IEfEntityRepositoryAsync<UserRole, Guid>
    {

    }
    public class EfUserRoleRepository : EfRepositoryBase<UserRole, Guid>, IEfUserRoleRepository
    {
        public EfUserRoleRepository(DbContext context) : base(context)
        {
        }
    }
}
