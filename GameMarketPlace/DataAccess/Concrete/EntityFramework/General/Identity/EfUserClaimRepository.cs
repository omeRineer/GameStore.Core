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
    public interface IEfUserClaimRepository : IEfEntityRepository<UserClaim, Guid>, IEfEntityRepositoryAsync<UserClaim, Guid>
    {

    }
    public class EfUserClaimRepository : EfRepositoryBase<UserClaim, Guid>, IEfUserClaimRepository
    {
        public EfUserClaimRepository(DbContext context) : base(context)
        {
        }
    }
}
