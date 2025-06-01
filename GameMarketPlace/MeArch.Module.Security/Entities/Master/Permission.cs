using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Security.Entities.Master
{
    public class Permission : BaseEntity<Guid>
    {
        public string Key { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<UserPermission>? UserPermissions { get; set; }
    }
}
