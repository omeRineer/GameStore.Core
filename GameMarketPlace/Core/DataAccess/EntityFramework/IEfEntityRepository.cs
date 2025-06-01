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
    public interface IEfEntityRepository<TEntity, TKey> : IEntityRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null,
                             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                             PaginationParameter? paginationParameter = null,
                             bool isTracking = true);

        TEntity? GetFirst(Expression<Func<TEntity, bool>> filter,
                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                    bool isTracking = true);

        TEntity? GetSingle(Expression<Func<TEntity, bool>> filter,
                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                    bool isTracking = true);

        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter,
                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                    bool isTracking = true);

        TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> filter,
                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                    bool isTracking = true);
        void ExecuteSql(string query, params object[] parameters);

        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        void Save();

    }
}
