﻿using Business.Services.External;
using GameStore.API.Web.Controllers.Base;
using MeArch.Module.Security.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Web.Controllers.Storage
{
    public class StorageController : BaseController
    {
        readonly ImageKitStorageService imageKitStorageService;

        public StorageController(ImageKitStorageService imageKitStorageService)
        {
            this.imageKitStorageService = imageKitStorageService;
        }

        [HttpGet("GetFiles/{fileType}")]
        [Authorize("API.Web.Storage")]
        public async Task<IActionResult> GetFilesAsync([FromRoute] string? tag)
        {
            var result = await imageKitStorageService.GetListAsync(tag);

            return Result(result);
        }
    }
}
