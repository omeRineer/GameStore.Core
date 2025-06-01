using Core.Entities.Abstract;
using Core.Entities.DTO.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TKey> : IEfEntityRepository<TEntity, TKey>, IEfEntityRepositoryAsync<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> Table;
        public EfRepositoryBase(DbContext context)
        {
            this._context = context;
            Table = _context.Set<TEntity>();
        }

        #region Sync

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, PaginationParameter? paginationParameter = null)
            => GetList(filter, null, orderBy, paginationParameter, false);

        public TEntity GetFirst(Expression<Func<TEntity, bool>> filter)
            => GetFirst(filter, null, false);

        public TEntity GetSingle(Expression<Func<TEntity, bool>> filter)
            => GetSingle(filter, null, false);

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter)
            => GetFirstOrDefault(filter, null, false);

        public TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> filter)
            => GetSingleOrDefault(filter, null, false);

        public void Delete(TKey id)
        {
            var entity = Table.Find(id);
            Delete(entity);
        }

        public void DeleteRange(IEnumerable<TKey> ids)
        {
            var entities = Table.Where(f => ids.Contains(f.Id));
            DeleteRange(entities);
        }
        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter,
                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                           bool isTracking = true)
        {
            IQueryable<TEntity> query = Table.AsQueryable();

            if (!isTracking) query = query.AsNoTracking();
            if (includes != null) query = includes(query);

            return query.FirstOrDefault(filter);
        }

        public TEntity? GetSingleOrDefault(Expression<Func<TEntity, bool>> filter,
                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                           bool isTracking = true)
        {
            IQueryable<TEntity> query = Table.AsQueryable();

            if (!isTracking) query = query.AsNoTracking();
            if (includes != null) query = includes(query);

            return query.SingleOrDefault(filter);
        }

        public TEntity GetFirst(Expression<Func<TEntity, bool>> filter,
                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                           bool isTracking = true)
        {
            IQueryable<TEntity> query = Table.AsQueryable();

            if (!isTracking) query = query.AsNoTracking();
            if (includes != null) query = includes(query);

            return query.First(filter);
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> filter,
                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                           bool isTracking = true)
        {
            IQueryable<TEntity> query = Table.AsQueryable();

            if (!isTracking) query = query.AsNoTracking();
            if (includes != null) query = includes(query);

            return query.Single(filter);
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null,
                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                    PaginationParameter? paginationParameter = null,
                                    bool isTracking = true)
        {
            IQueryable<TEntity> query = Table.AsQueryable();

            if (!isTracking) query = query.AsNoTracking();
            if (filter != null) query = query.Where(filter);
            if (includes != null) query = includes(query);
            if (orderBy != null) query = orderBy(query);
            if (paginationParameter != null) query = query.Skip(paginationParameter.Value.Page * paginationParameter.Value.Size).Take(paginationParameter.Value.Size);

            return query.ToList();
        }

        public bool IsExist(Expression<Func<TEntity, bool>> expression)
        {
            return Table.Any(expression);
        }

        public void Add(TEntity entity)
        {
            var addEntity = _context.Entry(entity);
            addEntity.State = EntityState.Added;
        }
        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            var addEntity = _context.Entry(entity);
            addEntity.State = EntityState.Deleted;
        }
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            var addEntity = _context.Entry(entity);
            addEntity.State = EntityState.Modified;
        }
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _context.UpdateRange(entities);
        }

        public void ExecuteSql(string query, params object[] parameters)
        {
            _context.Database.ExecuteSqlRaw(query, parameters);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Dictionary<TK, TV> GetDictionaries<TK, TV>(Func<TEntity, TK> key,
                                                                      Func<TEntity, TV> value,
                                                                      Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = Table.AsQueryable();

            if (filter != null) query = query.Where(filter);

            return query.ToDictionary(key, value);
        }
        #endregion


        #region Async
        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null,
                                                      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                                                      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                      PaginationParameter? paginationParameter = null,
                                                      bool isTracking = true)
        {
            IQueryable<TEntity> query = Table.AsQueryable();

            if (!isTracking) query = query.AsNoTracking();
            if (filter != null) query = query.Where(filter);
            if (includes != null) query = includes(query);
            if (orderBy != null) query = orderBy(query);
            if (paginationParameter != null) query = query.Skip(paginationParameter.Value.Page * paginationParameter.Value.Size).Take(paginationParameter.Value.Size);

            return await query.ToListAsync();
        }

        public async Task<Dictionary<TK, TV>> GetDictionariesAsync<TK, TV>(Func<TEntity, TK> key, Func<TEntity, TV> value, Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = Table.AsQueryable();

            if (filter != null) query = query.Where(filter);

            return await query.ToDictionaryAsync(key, value);
        }

        public async Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter,
                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                                            bool isTracking = true)
        {
            IQueryable<TEntity> query = Table.AsQueryable();

            if (!isTracking) query = query.AsNoTracking();
            if (includes != null) query = includes(query);

            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<TEntity?> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter,
                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                                            bool isTracking = true)
        {
            IQueryable<TEntity> query = Table.AsQueryable();

            if (!isTracking) query = query.AsNoTracking();
            if (includes != null) query = includes(query);

            return await query.SingleOrDefaultAsync(filter);
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter,
                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                                            bool isTracking = true)
        {
            IQueryable<TEntity> query = Table.AsQueryable();

            if (!isTracking) query = query.AsNoTracking();
            if (includes != null) query = includes(query);

            return await query.FirstAsync(filter);
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter,
                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                                            bool isTracking = true)
        {
            IQueryable<TEntity> query = Table.AsQueryable();

            if (!isTracking) query = query.AsNoTracking();
            if (includes != null) query = includes(query);

            return await query.SingleAsync(filter);
        }

        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Table.AnyAsync(expression);
        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.AddRangeAsync(entities);
        }

        public async Task ExecuteSqlAsync(string query, params object[] parameters)
        {
            await _context.Database.ExecuteSqlRawAsync(query, parameters);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Remove(entity);

            await Task.CompletedTask;
        }

        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.RemoveRange(entities);

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);

            await Task.CompletedTask;
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.UpdateRange(entities);

            await Task.CompletedTask;
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, PaginationParameter? paginationParameter = null)
            => await GetListAsync(filter, null, orderBy, paginationParameter, false);

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
            => await GetFirstOrDefaultAsync(filter, null, false);

        public async Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
            => await GetSingleOrDefaultAsync(filter, null, false);

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter)
            => await GetFirstAsync(filter, null, false);

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
            => await GetSingleAsync(filter, null, false);

        public async Task DeleteAsync(TKey id)
        {
            var entity = await Table.FindAsync(id);
            Table.Remove(entity);
        }

        public async Task DeleteRangeAsync(IEnumerable<TKey> ids)
        {
            var entities = Table.Where(f => ids.Contains(f.Id));
            Table.RemoveRange(entities);

            await Task.CompletedTask;
        }



        #endregion
    }
}
