using AutoMapper;
using Entities.Main;
using Microsoft.EntityFrameworkCore;
using GameStore.API.OData.Controllers.Base;

namespace GameStore.API.OData.Controllers.Main
{
    public class GamesController : BaseODataController<Game>
    {
        public GamesController(DbContext context) : base(context)
        {
        }
    }
}
