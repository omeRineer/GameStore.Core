using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameStore.API.OData.Controllers.Base;
using MeArch.Module.Security.Entities.Master;

namespace GameStore.API.OData.Controllers.Identity
{
    public class UsersController : BaseODataController<User, Guid>
    {
        public UsersController(DbContext context) : base(context)
        {
        }
    }
}
