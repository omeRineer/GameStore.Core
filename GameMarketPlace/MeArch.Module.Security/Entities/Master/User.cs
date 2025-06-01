using Core.Entities.Abstract;
using MeArch.Module.Security.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Security.Entities.Master
{
    public class User : BaseEntity<Guid>
    {
        public string Key { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthdayDate { get; set; }

        public IEnumerable<UserRole>? UserRoles { get; set; }
        public IEnumerable<UserPermission>? UserPermissions { get; set; }
    }
}
