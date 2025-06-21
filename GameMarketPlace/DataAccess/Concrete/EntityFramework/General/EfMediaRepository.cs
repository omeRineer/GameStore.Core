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
    public interface IEfMediaRepository : IEfEntityRepository<Media, Guid>, IEfEntityRepositoryAsync<Media, Guid>
    {

    }
    public class EfMediaRepository : EfRepositoryBase<Media, Guid>, IEfMediaRepository
    {
        public EfMediaRepository(DbContext context) : base(context)
        {
        }
    }
}
