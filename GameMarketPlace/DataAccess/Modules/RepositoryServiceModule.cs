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
            services.AddScoped<IEfGameRepository, EfGameRepository>();
            services.AddScoped<IEfGameImageRepository, EfGameImageRepository>();
            services.AddScoped<IEfSliderContentRepository, EfSliderContentRepository>();
            services.AddScoped<IEfBlogRepository, EfBlogRepository>();

            services.AddScoped<IEfMenuRepository, EfMenuRepository>();

            services.AddScoped<IEfProcessGroupRepository, EfProcessGroupRepository>();
            services.AddScoped<IEfStatusLookupRepository, EfStatusLookupRepository>();
            services.AddScoped<IEfTypeLookupRepository, EfTypeLookupRepository>();
        }
    }
}
