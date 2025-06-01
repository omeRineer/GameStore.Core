using Core.DataAccess.EntityFramework;
using Core.DataAccess;
using Entities.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeArch.Module.Security.Entities.Menu;

namespace DataAccess.Concrete.EntityFramework.General.Identity
{
    public interface IEfMenuRepository : IEfEntityRepository<Menu, Guid>, IEfEntityRepositoryAsync<Menu, Guid>
    {

    }
    public class EfMenuRepository : EfRepositoryBase<Menu, Guid>, IEfMenuRepository
    {
        public EfMenuRepository(DbContext context) : base(context)
        {
        }
    }
}
