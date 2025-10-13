using Core.Entities.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entities.Main
{
    public class Game : BaseEntity<Guid>
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? CoverImage { get; set; }

        public Category Category { get; set; }
        public List<GameImage>? Images { get; set; }
    }
}
