using System;
using Models.Media;

namespace Models.Blog
{
    public class UpdateBlogRequest
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public bool? Status { get; set; }
        public PostMediaModel? CoverImage { get; set; }
    }
}
