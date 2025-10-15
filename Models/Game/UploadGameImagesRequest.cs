using Core.Entities.DTO.Base;
using Entities.Enum.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Game
{
    public class UploadGameImagesRequest
    {
        public Guid EntityId { get; set; }
        public List<UploadGameImages_Item> Images { get; set; }

        public class UploadGameImages_Item
        {
            public string Name { get; set; }
            public string Url { get; set; }
            public int Priority { get; set; }
        }
    }
}
