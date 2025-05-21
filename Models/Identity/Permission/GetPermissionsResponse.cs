using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Identity.Permission
{
    public class GetPermissionsResponse
    {
        public List<GetPermissions_Item>? Permissions { get; set; }
    }

    public class GetPermissions_Item
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
