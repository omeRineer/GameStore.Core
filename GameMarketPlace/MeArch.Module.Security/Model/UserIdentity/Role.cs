using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Security.Model.UserIdentity
{
    public class Role : BaseEntity<Guid>, IEntity
    {
        public string Key { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<UserRole>? UserRoles { get; set; }
        public IEnumerable<RolePermission>? RolePermissions { get; set; }
    }
}
