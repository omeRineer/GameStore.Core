using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Identity.Role
{
    public class UploadRoleCollectionRequest
    {
        public List<UploadRoleCollection_Item> Roles { get; set; }
    }

    public class UploadRoleCollection_Item
    {
        public string Key { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
