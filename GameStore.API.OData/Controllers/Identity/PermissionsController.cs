using AutoMapper;
using Microsoft.EntityFrameworkCore;
using GameStore.API.OData.Controllers.Base;
using MeArch.Module.Security.Entities.Master;

namespace GameStore.API.OData.Controllers.Identity
{
    public class PermissionsController : BaseODataController<Permission, Guid>
    {
        public PermissionsController(DbContext context) : base(context)
        {
        }
    }
}
