using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Main
{
    public class Menu : BaseEntity<Guid>
    {
        public Guid? ParentMenuId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int? Priority { get; set; }
        public string Path { get; set; }
        public string Icon { get; set; }
        public string? Permission { get; set; }

        public Menu? ParentMenu { get; set; }

    }
}
