using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO = Core.Entities.DTO.File;

namespace Models.SliderContent
{
    public class SingleSliderContentResponse
    {
        public Guid Id { get; set; }
        public string? Header { get; set; }
        public string? To { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
        public DTO.File? CoverImage { get; set; }

        public SingleSliderContent_Type SliderType { get; set; }
    }

    public class SingleSliderContent_Type
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
