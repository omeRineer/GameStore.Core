using Core.Entities.Concrete.ProcessGroups;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ProcessGroups(this ModelBuilder modelBuilder,
                                                    Type processGroup,
                                                    Type[] types = null,
                                                    Type[] statuses = null)
        {

            modelBuilder.Entity<ProcessGroup>()
                        .ToTable("ProcessGroups")
                        .Property(p => p.Id).ValueGeneratedNever();

            var seeds = Enum.GetValues(processGroup)
                            .Cast<Enum>()
                            .Select(s => new ProcessGroup
                            {
                                Id = Convert.ToInt32(s),
                                Code = s.ToString().ToUpper(new CultureInfo("en-US")),
                                Description = s.ToString()
                            });
            modelBuilder.Entity<ProcessGroup>().HasData(seeds);



            modelBuilder.Entity<TypeLookup>()
                        .ToTable("TypeLookups")
                        .Property(p => p.Id).ValueGeneratedNever();
            if (types != null)
                foreach (var type in types)
                {
                    var groupId = (int)Enum.Parse(processGroup, type.Name);
                    var values = Enum.GetValues(type)
                                     .Cast<Enum>()
                                     .Select(s => new TypeLookup
                                     {
                                         Id = Convert.ToInt32(s),
                                         Code = s.ToString().ToUpper(new CultureInfo("en-US")),
                                         Description = s.ToString(),
                                         ProcessGroupId = groupId
                                     });
                    modelBuilder.Entity<TypeLookup>().HasData(values);
                }




            modelBuilder.Entity<StatusLookup>()
                        .ToTable("StatusLookups")
                        .Property(p => p.Id).ValueGeneratedNever();
            if (statuses != null)
                foreach (var status in statuses)
                {
                    var groupId = (int)Enum.Parse(processGroup, status.Name);
                    var values = Enum.GetValues(status)
                                     .Cast<Enum>()
                                     .Select(s => new StatusLookup
                                     {
                                         Id = Convert.ToInt32(s),
                                         Code = s.ToString().ToUpper(new CultureInfo("en-US")),
                                         Description = s.ToString(),
                                         ProcessGroupId = groupId
                                     });
                    modelBuilder.Entity<StatusLookup>().HasData(values);
                }

            return modelBuilder;
        }


    }
}
