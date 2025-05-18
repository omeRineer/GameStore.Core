using AutoMapper;
using MeArch.Module.Security.Model.UserIdentity;
using Microsoft.EntityFrameworkCore;
using GameStore.API.OData.Controllers.Base;

namespace GameStore.API.OData.Controllers.Identity
{
    public class RolesController : BaseODataController<Role>
    {
        public RolesController(DbContext context) : base(context)
        {
        }
    }
}
