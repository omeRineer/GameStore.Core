using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameStore.API.OData.Controllers.Base;
using MeArch.Module.Security.Entities.Menu;

namespace GameStore.API.OData.Controllers.Core
{
    public class MenusController : BaseODataController<Menu, Guid>
    {
        public MenusController(DbContext context) : base(context)
        {
        }
    }
}
