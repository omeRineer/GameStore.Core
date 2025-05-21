using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO = Core.Entities.DTO.File;

namespace Models.Game
{
    public class SingleGameResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DTO.File? CoverImage { get; set; }


        public SingleGame_Category Category { get; set; }
    }

    public class SingleGame_Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
