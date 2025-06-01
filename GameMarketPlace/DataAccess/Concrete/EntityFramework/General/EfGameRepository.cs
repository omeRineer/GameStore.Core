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
    public interface IEfGameRepository : IEfEntityRepository<Game, Guid>, IEfEntityRepositoryAsync<Game, Guid>
    { 

    }
    public class EfGameRepository : EfRepositoryBase<Game, Guid>, IEfGameRepository
    {
        public EfGameRepository(DbContext context) : base(context)
        {
        }
    }
}
