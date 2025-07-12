using Models.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Blog
{
    public class SingleBlogResponse
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public int ReaderCount { get; set; }
        public bool Status { get; set; }
        public GetMediaModel CoverImage { get; set; }
    }
}
