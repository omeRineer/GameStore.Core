using AutoMapper;
using Core.Entities.Concrete.Menu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameStore.API.OData.Controllers.Base;

namespace GameStore.API.OData.Controllers.Core
{
    public class MenusController : BaseODataController<Menu>
    {
        public MenusController(DbContext context) : base(context)
        {
        }
    }
}
