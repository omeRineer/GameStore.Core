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
    public interface IEfRoleRepository : IEfEntityRepository<Role, Guid>, IEfEntityRepositoryAsync<Role, Guid>
    {

    }
    public class EfRoleRepository : EfRepositoryBase<Role, Guid>, IEfRoleRepository
    {
        public EfRoleRepository(DbContext context) : base(context)
        {
        }
    }
}
