using Models.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Game
{
    public class SingleGameResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public GetMediaModel? CoverImage { get; set; }


        public SingleGame_Category Category { get; set; }
    }

    public class SingleGame_Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
