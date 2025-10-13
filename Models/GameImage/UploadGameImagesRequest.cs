using Core.Entities.DTO.Base;
using Entities.Enum.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.GameImage
{
    public class UploadGameImagesRequest
    {
        public Guid EntityId { get; set; }
        public List<CreateGameImageRequest> Images { get; set; }
    }
}
