using Configuration;
using Core.ServiceModules;
using MeArch.Module.Security.Helpers;
using MeArch.Module.Security.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using MeArch.Module.Security.Model.Dto;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Business.ServiceModules
{
    public class MeArchitectureServiceModule : IServiceModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddDbContext<CoreContext>(options =>
            {
                options.UseSqlServer(CoreConfiguration.DataBaseOptions.ConnectionString);
            });



            services.AddCors(options =>
                            options.AddDefaultPolicy(builder =>
                            builder.AllowAnyHeader()
                                   .AllowAnyMethod()
                                   .AllowAnyOrigin()));

            services.AddAutoMapper(opt =>
            {
                opt.AddGlobalIgnore("CreateDate");
                opt.AddGlobalIgnore("EditDate");
            }, typeof(BusinessServiceModule).Assembly);


            #region Json Web Token Options
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(opt =>
                        {
                            opt.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,

                                ValidIssuer = CoreConfiguration.TokenOptions.Issuer,
                                ValidAudience = CoreConfiguration.TokenOptions.Audience,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(CoreConfiguration.TokenOptions.SecurityKey))

                            };
                        });

            services.AddScoped<CurrentUser>(i =>
            {
                var httpContextAccessor = i.GetService<IHttpContextAccessor>();
                var user = httpContextAccessor.HttpContext?.User;

                if (user != null && user.Identity.IsAuthenticated)
                {
                    var currentUser = new CurrentUser
                    {
                        Id = Guid.Parse(user.Claims.FirstOrDefault(f => f.Type == ClaimTypes.NameIdentifier)?.Value),
                        Key = user.Claims.FirstOrDefault(f => f.Type == "Key")?.Value,
                        Name = user.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Name)?.Value,
                        Phone = user.Claims.FirstOrDefault(f => f.Type == ClaimTypes.MobilePhone)?.Value,
                        Email = user.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Email)?.Value,
                        Roles = user.Claims.Where(f => f.Type == ClaimTypes.Role)?.Select(s => s.Value).ToArray(),
                        Permissions = user.Claims.Where(f => f.Type == "Permission")?.Select(s => s.Value).ToArray(),
                        IsAuthenticated = user.Identity.IsAuthenticated
                    };

                    if (user.Claims.Any(x => x.Type == "Special"))
                        currentUser.Claims = JsonConvert.DeserializeObject<Dictionary<string, string>>(user.Claims.FirstOrDefault(f => f.Type == "Special")?.Value);

                    return currentUser;
                }


                return new CurrentUser();
            });

            services.AddTokenService(options =>
            {
                options.Audience = CoreConfiguration.TokenOptions.Audience;
                options.Issuer = CoreConfiguration.TokenOptions.Issuer;
                options.ExpirationTime = CoreConfiguration.TokenOptions.ExpirationTime;
                options.SecurityKey = CoreConfiguration.TokenOptions.SecurityKey;
            });
            #endregion

        }
    }
}
