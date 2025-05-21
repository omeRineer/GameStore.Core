using Core.DataAccess.EntityFramework;
using Core.DataAccess;
using MeArch.Module.Security.Model.UserIdentity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General.Identity
{
    public interface IUserRoleRepository : IEntityRepository<UserRole>
    {

    }
    public class UserRoleRepository : EfRepositoryBase<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(DbContext context) : base(context)
        {
        }
    }
}
