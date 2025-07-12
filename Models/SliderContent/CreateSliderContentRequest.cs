using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Media;

namespace Models.SliderContent
{
    public class CreateSliderContentRequest
    {
        public int SliderTypeId { get; set; }
        public string? Header { get; set; }
        public string? To { get; set; }
        public bool IsActive { get; set; }
        public int Priority { get; set; }
        public PostMediaModel? CoverImage { get; set; }
    }

}
