using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Identity.Permission
{
    public class UploadPermissionCollectionRequest
    {
        public List<UploadPermissionCollection_Item> Permissions { get; set; }
    }

    public class UploadPermissionCollection_Item
    {
        public string Key { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
