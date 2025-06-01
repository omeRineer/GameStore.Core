using Core.Entities.Abstract;
using Core.Entities.Concrete.Mongo;
using Core.Entities.DTO.Pagination;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MongoDB.Driver;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto;

namespace Core.DataAccess.Mongo
{
    public class MongoRepositoryBase<TEntity, TKey> : IEntityRepositoryAsync<TEntity, TKey>
        where TEntity : MongoBaseEntity<TKey>, new()
    {
        protected readonly IMongoCollection<TEntity> Collection;

        public MongoRepositoryBase(IMongoDatabase dataBase, string collectionName)
        {
            Collection = dataBase.GetCollection<TEntity>(collectionName);
        }

        public async Task AddAsync(TEntity entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = true };
            await Collection.InsertOneAsync(entity, options);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
            await Collection.BulkWriteAsync((IEnumerable<WriteModel<TEntity>>)entities, options);
        }

        public async Task DeleteAsync(TKey id)
        {
            await Collection.FindOneAndDeleteAsync(Builders<TEntity>.Filter.Eq(x => x.Id, id)); ;
        }

        public async Task DeleteRangeAsync(IEnumerable<TKey> ids)
        {
            await Collection.DeleteManyAsync(Builders<TEntity>.Filter.In(x => x.Id, ids));
        }

        public async Task<Dictionary<TK, TV>> GetDictionariesAsync<TK, TV>(Func<TEntity, TK> key, Func<TEntity, TV> value, Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = Collection.AsQueryable();

            if (filter != null) query = query.Where(filter);

            return await query.ToDictionaryAsync(key, value);
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter)
            => await Collection.Find(filter).FirstAsync();

        public async Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
            => await Collection.Find(filter).FirstOrDefaultAsync();

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, PaginationParameter? paginationParameter = null)
        {
            IQueryable<TEntity> query = Collection.AsQueryable();

            if (filter != null) query = query.Where(filter);
            if (orderBy != null) query = orderBy(query);
            if (paginationParameter != null) query = query.Skip(paginationParameter.Value.Page * paginationParameter.Value.Size).Take(paginationParameter.Value.Size);

            return await Task.FromResult(query.ToList());
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
            => await Collection.Find(filter).SingleAsync();

        public async Task<TEntity?> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
            => await Collection.Find(filter).SingleOrDefaultAsync();

        public Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> expression)
            => Collection.AsQueryable().AnyAsync(expression);

        public async Task UpdateAsync(TEntity entity)
        {
            await Collection.FindOneAndReplaceAsync(Builders<TEntity>.Filter.Eq(x => x.Id, entity.Id), entity);
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            var updates = new List<WriteModel<TEntity>>();

            foreach (var entity in entities)
            {
                var filter = Builders<TEntity>.Filter.Eq(x => x.Id, entity.Id);

                var update = new ReplaceOneModel<TEntity>(filter, entity)
                {
                    IsUpsert = false
                };

                updates.Add(update);
            }

            if (updates.Any())
                await Collection.BulkWriteAsync(updates);
        }
    }
}
