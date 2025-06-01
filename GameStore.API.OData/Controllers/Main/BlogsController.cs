﻿using AutoMapper;
using Entities.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameStore.API.OData.Controllers.Base;

namespace GameStore.API.OData.Controllers.Main
{
    public class BlogsController : BaseODataController<Blog, Guid>
    {
        public BlogsController(DbContext context) : base(context)
        {
        }
    }
}
