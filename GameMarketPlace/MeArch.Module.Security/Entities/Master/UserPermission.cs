using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Security.Entities.Master
{
    public class UserPermission : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid PermissionId { get; set; }

        public User User { get; set; }
        public Permission Permission { get; set; }
    }
}
