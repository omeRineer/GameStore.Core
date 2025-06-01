using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Security.Entities.Menu
{
    public class Menu : BaseEntity<Guid>
    {
        public Guid? ParentMenuId { get; set; }
        public string? Code { get; set; }
        public string Title { get; set; }
        public int? Priority { get; set; }
        public string? Path { get; set; }
        public string? Icon { get; set; }

        public Menu? ParentMenu { get; set; }
        public IEnumerable<MenuRole>? Roles { get; set; }
        public IEnumerable<MenuPermission>? Permissions { get; set; }

    }
}
