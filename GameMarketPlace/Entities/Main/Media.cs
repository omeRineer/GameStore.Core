using Core.Entities.Abstract;
using Core.Entities.Concrete.ProcessGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Main
{
    public class Media : BaseEntity<Guid>
    {
        public int TypeId { get; set; }
        public Guid EntityId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public TypeLookup Type { get; set; }
    }
}
