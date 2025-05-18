using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GM = Core.Entities.DTO.File;

namespace Models.Blog.WebService
{
    public class SingleBlogResponse
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public int ReaderCount { get; set; }
        public bool Status { get; set; }
        public GM.File CoverImage { get; set; }
    }
}
