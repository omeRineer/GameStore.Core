using Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceModules
{
    public static class ServiceCollectionExtensions
    {
        public static async Task<IServiceCollection> AddRabbitMqAsync(this IServiceCollection services)
        {
            var connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = CoreConfiguration.RabbitMqOptions.Host;
            connectionFactory.Port = CoreConfiguration.RabbitMqOptions.Port;
            connectionFactory.VirtualHost = CoreConfiguration.RabbitMqOptions.VirtualHost;
            connectionFactory.UserName = CoreConfiguration.RabbitMqOptions.UserName;
            connectionFactory.Password = CoreConfiguration.RabbitMqOptions.Password;

            var connection = await connectionFactory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            services.AddSingleton<IConnection>(connection);
            services.AddSingleton<IChannel>(channel);

            return services;
        }
    }
}
