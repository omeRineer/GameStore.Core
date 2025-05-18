﻿using AutoMapper;
using Core.Entities.Concrete.ProcessGroups;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameStore.API.OData.Controllers.Base;

namespace GameStore.API.OData.Controllers.Core
{
    public class TypeLookupsController : BaseODataController<TypeLookup>
    {
        public TypeLookupsController(DbContext context) : base(context)
        {
        }
    }
}
