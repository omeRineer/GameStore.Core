using AutoMapper;
using Microsoft.EntityFrameworkCore;
using GameStore.API.OData.Controllers.Base;
using MeArch.Module.Security.Entities.Master;

namespace GameStore.API.OData.Controllers.Identity
{
    public class RolesController : BaseODataController<Role, Guid>
    {
        public RolesController(DbContext context) : base(context)
        {
        }
    }
}
