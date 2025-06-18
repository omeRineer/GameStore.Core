using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Security.Entities.Master
{
    public class UserClaim : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        public User User { get; set; }
    }
}
