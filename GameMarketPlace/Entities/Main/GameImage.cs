using Core.Entities.Abstract;
using System;

namespace Entities.Main
{
    public class GameImage : BaseEntity<Guid>
    {
        public Guid GameId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Priority { get; set; }

        public Game Game { get; set; }
    }
}
