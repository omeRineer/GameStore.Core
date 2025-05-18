﻿using Business.Services;
using Business.Services.Abstract;
using Business.Services.Concrete;
using Configuration;
using Core.ServiceModules;
using DataAccess;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceModules
{
    public class BusinessServiceModule : IServiceModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IMediaService, MediaService>();
            services.AddScoped<ISliderContentService, SliderContentService>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPermissionService, PermissionService>();
        }
    }
}
