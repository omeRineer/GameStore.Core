using Core.Entities.Abstract;
using Core.Entities.DTO.Pagination;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public interface IEfEntityRepositoryAsync<TEntity, TKey> : IEntityRepositoryAsync<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null,
                                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                   PaginationParameter? paginationParameter = null,
                                   bool isTracking = true);

        Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter,
                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                         bool isTracking = true);

        Task<TEntity?> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter,
                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                         bool isTracking = true);

        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter,
                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                         bool isTracking = true);

        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter,
                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                         bool isTracking = true);

        Task ExecuteSqlAsync(string query, params object[] parameters);

        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);

        Task SaveAsync();
    }
}
