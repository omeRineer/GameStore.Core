using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Media
{
    public class GetMediaModel
    {
        public Guid Id { get; set; }
        public Guid EntityId { get; set; }
        public int TypeId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
    }
}
