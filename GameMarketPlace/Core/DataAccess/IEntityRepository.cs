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
    public interface IEntityRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null,
                              Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                              PaginationParameter? paginationParameter = null);

        Dictionary<TK, TV> GetDictionaries<TK, TV>(Func<TEntity, TK> key,
                                                   Func<TEntity, TV> value,
                                                   Expression<Func<TEntity, bool>> filter = null);
        TEntity? GetFirst(Expression<Func<TEntity, bool>> filter);

        TEntity? GetSingle(Expression<Func<TEntity, bool>> filter);

        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter);

        TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> filter);

        bool IsExist(Expression<Func<TEntity, bool>> expression);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Delete(TKey id);
        void DeleteRange(IEnumerable<TKey> ids);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

    }


}
