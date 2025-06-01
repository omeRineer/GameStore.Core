using Core.Entities.Abstract;
using Core.Entities.DTO.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepositoryAsync<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null,
                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                   PaginationParameter? paginationParameter = null);

        Task<Dictionary<TK, TV>> GetDictionariesAsync<TK, TV>(Func<TEntity, TK> key,
                                                                    Func<TEntity, TV> value,
                                                                    Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity?> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter);
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> expression);

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task DeleteAsync(TKey id);
        Task DeleteRangeAsync(IEnumerable<TKey> ids);

        Task UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
    }
}
