using Business.Services.Abstract.Web;
using Business.Services.Concrete.Web;
using Core.ServiceModules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceModules
{
    public class WebModule : IServiceModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<IGameWebService, GameWebService>();
            services.AddScoped<ICategoryWebService, CategoryWebService>();
            services.AddScoped<ISliderContentWebService, SliderContentWebService>();
        }
    }
}
