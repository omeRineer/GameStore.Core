using Business.Services;
using Business.Services.Abstract;
using Business.Services.Abstract.Identity;
using Business.Services.Abstract.Lookup;
using Business.Services.Concrete;
using Business.Services.Concrete.Identity;
using Business.Services.Concrete.Lookup;
using Business.Services.External;
using Business.Services.Internal;
using Castle.DynamicProxy;
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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Extensions;

namespace Business.ServiceModules
{
    public class BusinessServiceModule : IServiceModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddSingleton<RabbitMqClientService>();
            services.AddSingleton<NotificationService>();

            services.AddProxiedScoped<ICategoryService, CategoryService>();
            services.AddProxiedScoped<IBlogService, BlogService>();
            services.AddProxiedScoped<IGameService, GameService>();
            services.AddProxiedScoped<IMenuService, MenuService>();
            services.AddProxiedScoped<ISliderContentService, SliderContentService>();
            services.AddScoped<ImageKitStorageService>();

            services.AddProxiedScoped<IAuthService, AuthService>();
            services.AddProxiedScoped<IProfileService, ProfileService>();
            services.AddProxiedScoped<IUserService, UserService>();
            services.AddProxiedScoped<IRoleService, RoleService>();
            services.AddProxiedScoped<IPermissionService, PermissionService>();

            services.AddProxiedScoped<ILookupService, LookupService>();
        }
    }
}
