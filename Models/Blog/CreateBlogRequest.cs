using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Media;

namespace Models.Blog
{
    public class CreateBlogRequest
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public PostMediaModel? CoverImage { get; set; }
    }
}
