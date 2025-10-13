using Models.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SliderContent
{
    public class SliderContentResponse
    {
        public Guid Id { get; set; }
        public string? Header { get; set; }
        public string? To { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
        public string? CoverImage { get; set; }

        public LookupResponse SliderType { get; set; }
    }
}
