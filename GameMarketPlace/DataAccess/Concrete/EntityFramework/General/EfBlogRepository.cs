using Core.DataAccess.EntityFramework;
using Core.DataAccess;
using Entities.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General
{
    public interface IEfBlogRepository : IEfEntityRepository<Blog, Guid>, IEfEntityRepositoryAsync<Blog, Guid>
    {

    }
    public class EfBlogRepository : EfRepositoryBase<Blog, Guid>, IEfBlogRepository
    {
        public EfBlogRepository(DbContext context) : base(context)
        {
        }
    }
}
