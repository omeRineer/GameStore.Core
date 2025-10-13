using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.GameImage
{
    public class GameImageResponse
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Priority { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
    }
}
