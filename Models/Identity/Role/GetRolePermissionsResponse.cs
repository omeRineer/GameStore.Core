using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Identity.Role
{
    public class GetRolePermissionsResponse
    {
        public List<Guid>? Permissions { get; set; }
    }
}
