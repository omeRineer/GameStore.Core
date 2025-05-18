using AutoMapper;
using MeArch.Module.Security.Model.UserIdentity;
using Microsoft.EntityFrameworkCore;
using GameStore.API.OData.Controllers.Base;

namespace GameStore.API.OData.Controllers.Identity
{
    public class PermissionsController : BaseODataController<Permission>
    {
        public PermissionsController(DbContext context) : base(context)
        {
        }
    }
}
