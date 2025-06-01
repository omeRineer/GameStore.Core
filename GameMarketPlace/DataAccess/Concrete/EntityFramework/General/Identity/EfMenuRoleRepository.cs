using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using MeArch.Module.Security.Entities.Menu;
using Core.DataAccess;

namespace DataAccess.Concrete.EntityFramework.General.Identity
{
    public interface IEfMenuRoleRepository : IEfEntityRepository<MenuRole, Guid>, IEfEntityRepositoryAsync<MenuRole, Guid>
    {

    }
    public class EfMenuRoleRepository : EfRepositoryBase<MenuRole, Guid>, IEfMenuRoleRepository
    {
        public EfMenuRoleRepository(DbContext context) : base(context)
        {
        }
    }
}
