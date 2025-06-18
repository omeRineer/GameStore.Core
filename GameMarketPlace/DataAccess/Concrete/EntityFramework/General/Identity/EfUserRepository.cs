using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using MeArch.Module.Security.Entities.Master;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General.Identity
{
    public interface IEfUserRepository : IEfEntityRepository<User, Guid>, IEfEntityRepositoryAsync<User, Guid>
    {
        Task<bool> IsExistByUserNameAndPassword(string userName, string password);
        Task<User> GetByUserNameAndPassword(string userName, string password);
    }
    public class EfUserRepository : EfRepositoryBase<User, Guid>, IEfUserRepository
    {
        public EfUserRepository(DbContext context) : base(context)
        {
        }

        public async Task<User> GetByUserNameAndPassword(string userName, string password)
            => await Table.Include(i => i.UserRoles)
                                .ThenInclude(i => i.Role)
                                .ThenInclude(i => i.RolePermissions)
                                .ThenInclude(i => i.Permission)
                          .Include(i => i.UserPermissions)
                                .ThenInclude(i => i.Permission)
                          .Include(i => i.UserClaims)
                                .SingleOrDefaultAsync(f => f.UserName == userName && f.Password == password);

        public async Task<bool> IsExistByUserNameAndPassword(string userName, string password)
            => await Table.AnyAsync(f => f.UserName == userName && f.Password == password);
    }
}
