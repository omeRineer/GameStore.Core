using Core.Entities.DTO.Base;
using Entities.Enum.Type;
using Models.Media;
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
        public List<PostMediaModel> Images { get; set; }
    }
}
