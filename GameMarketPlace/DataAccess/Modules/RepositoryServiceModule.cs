﻿using Core.ServiceModules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Concrete.EntityFramework.General;

namespace DataAccess.ServiceModules
{
    public class RepositoryServiceModule : IServiceModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ISystemRequirementRepository, SystemRequirementRepository>();
            services.AddScoped<IMediaRepository, MediaRepository>();
            services.AddScoped<ISliderContentRepository, SliderContentRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBackgroundJobRepository, BackgroundJobRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
        }
    }
}
