using MeArch.Module.Security.Model.Options;
using MeArch.Module.Security.Model.UserIdentity;
using MeArch.Module.Security.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Security.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddTokenService(this IServiceCollection services, Action<TokenOptions> options)
        {
            services.Configure(options);
            services.AddSingleton<ITokenService, JwtService>();
        }

        public static ModelBuilder UserIdentity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .ToTable("Users");

            modelBuilder.Entity<Role>()
                        .ToTable("Roles");
                        //.HasData(new List<Role>
                        //{
                        //    new Role { Name = "System" },
                        //    new Role { Name = "SuperAdmin" }
                        //});

            modelBuilder.Entity<UserRole>()
                        .ToTable("UserRoles");

            modelBuilder.Entity<Permission>()
                        .ToTable("Permissions");

            modelBuilder.Entity<UserPermission>()
                        .ToTable("UserPermissions");

            modelBuilder.Entity<RolePermission>()
                        .ToTable("RolePermissions");

            return modelBuilder;
        }
    }
}
