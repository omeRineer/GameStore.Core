using Core.Entities.Abstract;
using MeArch.Module.Security.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Security.Entities.Menu
{
    public class MenuRole : BaseEntity<Guid>
    {
        public Guid MenuId { get; set; }
        public Guid RoleId { get; set; }

        public Menu Menu { get; set; }
        public Role Role { get; set; }
    }
}
