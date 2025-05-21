using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Identity.Role
{
    public class GetRolesResponse
    {
        public List<GetRoles_Item>? Roles { get; set; }
    }

    public class GetRoles_Item
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
