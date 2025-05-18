using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.ServiceTools
{
    public static class StaticServiceProvider
    {
        private static IServiceScopeFactory ServiceScopeFactory { get; set; }
        public static void CreateInstance(IServiceScopeFactory serviceScopeFactory)
        {
            if (ServiceScopeFactory != null)
                throw new Exception("Provider is not null!");

            ServiceScopeFactory = serviceScopeFactory;
        }

        public static TService GetService<TService>()
        {
            var serviceScope = ServiceScopeFactory.CreateScope();
            return serviceScope.ServiceProvider.GetService<TService>();
        }
    }
}
