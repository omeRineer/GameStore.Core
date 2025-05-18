using AutoMapper;
using Core.Entities.Abstract;
using Core.Entities.DTO.Base;
using DataAccess.Concrete.EntityFramework;
using Entities.Main;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using GameStore.API.OData.Filters;

namespace GameStore.API.OData.Controllers.Base
{
    public abstract class BaseODataController<TEntity> : ODataController
        where TEntity : class, IEntity, new()
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> Table;

        public BaseODataController(DbContext context)
        {
            Context = context;
            Table = Context.Set<TEntity>();
        }

        #region Read Actions

        [EnableQuery]
        public virtual IQueryable<TEntity> Get()
        {
            var query = Table.AsQueryable();

            return query;
        }
        #endregion
    }
}
