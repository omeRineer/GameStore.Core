using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Auth.User
{
    public class SetUserPermissionsRequest
    {
        public Guid UserId { get; set; }
        public Guid[] Permissions { get; set; }
    }
}
