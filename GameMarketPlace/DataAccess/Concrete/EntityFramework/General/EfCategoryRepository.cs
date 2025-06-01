using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Entities.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General
{
    public interface IEfCategoryRepository : IEfEntityRepository<Category, Guid>, IEfEntityRepositoryAsync<Category, Guid>
    {

    }
    public class EfCategoryRepository : EfRepositoryBase<Category, Guid>, IEfCategoryRepository
    {
        public EfCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
