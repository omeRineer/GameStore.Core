using Castle.DynamicProxy;
using Core.ServiceModules;
using Core.Utilities.Interceptor;
using Core.Utilities.ServiceTools;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceModules(this IServiceCollection services, IServiceModule[] serviceModules)
        {
            if (serviceModules.Count() != 0)
            {
                foreach (var serviceModule in serviceModules)
                {
                    serviceModule.Load(services);
                }
            }

            return services;
        }

        
        static ProxyGenerator proxyGenerator = new ProxyGenerator();
        public static IServiceCollection AddProxiedScoped<TService, TImplemented>(this IServiceCollection services)
            where TService : class
            where TImplemented : class, TService
        {
            
            services.AddScoped<TImplemented>();
            services.AddScoped<TService>(sp =>
            {
                var implemented = sp.GetService<TImplemented>();

                return proxyGenerator.CreateInterfaceProxyWithTarget<TService>(implemented, new ProxyGenerationOptions
                {
                    Selector = new InterceptorSelector()
                });
            });

            return services;
        }
    }
}
