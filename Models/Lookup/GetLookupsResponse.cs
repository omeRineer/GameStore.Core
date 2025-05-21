using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Lookup
{
    public class GetLookupsResponse
    {
        public List<GetLookups_Item>? Items { get; set; }
    }

    public class GetLookups_Item
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
