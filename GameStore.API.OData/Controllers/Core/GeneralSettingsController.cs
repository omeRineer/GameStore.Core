using AutoMapper;
using Core.Entities.Concrete.GeneralSettings;
using GameStore.API.OData.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.GeneralSetting.OData;

namespace GameStore.API.OData.Controllers.Core
{
    public class GeneralSettingsController : BaseODataController<GeneralSetting>
    {
        public GeneralSettingsController(DbContext context) : base(context)
        {
        }
    }
}
