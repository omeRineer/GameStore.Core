using Core.ServiceModules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Concrete.EntityFramework.General;
using DataAccess.Concrete.EntityFramework.General.Identity;
using DataAccess.Concrete.EntityFramework.General.Lookup;

namespace DataAccess.ServiceModules
{
    public class RepositoryServiceModule : IServiceModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<IEfCategoryRepository, EfCategoryRepository>();
            services.AddScoped<IEfCategoryRepository, EfCategoryRepository>();
            services.AddScoped<IEfGameRepository, EfGameRepository>();
            services.AddScoped<IEfSliderContentRepository, EfSliderContentRepository>();
            services.AddScoped<IEfBlogRepository, EfBlogRepository>();
            services.AddScoped<IEfMediaRepository, EfMediaRepository>();

            services.AddScoped<IEfPermissionRepository, EfPermissionRepository>();
            services.AddScoped<IEfMenuRepository, EfMenuRepository>();
            services.AddScoped<IEfMenuPermissionRepository, EfMenuPermissionRepository>();
            services.AddScoped<IEfUserRoleRepository, EfUserRoleRepository>();
            services.AddScoped<IEfUserRepository, EfUserRepository>();
            services.AddScoped<IEfRoleRepository, EfRoleRepository>();
            services.AddScoped<IEfRolePermissionRepository, EfRolePermissionRepository>();
            services.AddScoped<IEfUserPermissionRepository, EfUserPermissionRepository>();
            services.AddScoped<IEfUserClaimRepository, EfUserClaimRepository>();

            services.AddScoped<IEfProcessGroupRepository, EfProcessGroupRepository>();
            services.AddScoped<IEfStatusLookupRepository, EfStatusLookupRepository>();
            services.AddScoped<IEfTypeLookupRepository, EfTypeLookupRepository>();
        }
    }
}
