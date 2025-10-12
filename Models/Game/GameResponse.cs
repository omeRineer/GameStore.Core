using Models.Category;
using Models.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Game
{
    public class GameResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public MediaResponse? CoverImage { get; set; }

        public CategoryResponse Category { get; set; }
    }
}
