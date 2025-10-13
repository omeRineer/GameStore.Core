using Models.GameImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Game
{
    public class GameDetailResponse : GameResponse
    {
        public List<GameImageResponse>? Images { get; set; }
    }
}
