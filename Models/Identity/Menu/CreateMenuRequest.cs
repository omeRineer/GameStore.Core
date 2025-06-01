using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Identity.Menu
{
    public class CreateMenuRequest
    {
        public Guid? ParentMenuId { get; set; }
        public string? Code { get; set; }
        public string Title { get; set; }
        public int? Priority { get; set; }
        public string? Path { get; set; }
        public string? Icon { get; set; }
    }
}
