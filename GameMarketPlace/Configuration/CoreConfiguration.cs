using Configuration.Models.Options;
using Core.Utilities.ServiceTools;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO = System.IO;

namespace Configuration
{
    public static class CoreConfiguration
    {
        readonly static IConfigurationRoot Configuration;
        static CoreConfiguration()
        {
            Configuration = new ConfigurationBuilder()
                                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                                .Build();
        }
        
        public static IConfigurationSection GetSection(string name)
            => Configuration.GetSection(name);

        public static DataBaseOptions DataBaseOptions { get => Configuration.GetSection("DataBaseOptions").Get<DataBaseOptions>(); }
        public static TokenOptions TokenOptions { get => Configuration.GetSection("TokenOptions").Get<TokenOptions>(); }
        public static APIOptions APIOptions { get => Configuration.GetSection("APIOptions").Get<APIOptions>(); }
        public static RabbitMqOptions RabbitMqOptions { get => Configuration.GetSection("RabbitMqOptions").Get<RabbitMqOptions>(); }
        public static ImagekitOptions ImagekitOptions { get => Configuration.GetSection("ImagekitOptions").Get<ImagekitOptions>(); }

    }
}
