using DTO = Core.Entities.DTO.File;
using System;

namespace Models.Blog
{
    public class UpdateBlogRequest
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public bool? Status { get; set; }
        public DTO.File? CoverImage { get; set; }
    }
}
