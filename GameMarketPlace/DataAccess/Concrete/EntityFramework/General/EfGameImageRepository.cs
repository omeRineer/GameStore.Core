using Core.DataAccess.EntityFramework;
using Entities.Main;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess.Concrete.EntityFramework.General
{
    public interface IEfGameImageRepository : IEfEntityRepository<GameImage, Guid>, IEfEntityRepositoryAsync<GameImage, Guid>
    {

    }
    public class EfGameImageRepository : EfRepositoryBase<GameImage, Guid>, IEfGameImageRepository
    {
        public EfGameImageRepository(DbContext context) : base(context)
        {
        }
    }
}
