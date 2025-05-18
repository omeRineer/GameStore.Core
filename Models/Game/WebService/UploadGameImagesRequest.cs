using Core.Entities.DTO.Base;
using Entities.Enum.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO = Core.Entities.DTO.File;

namespace Models.Game.WebService
{
    public class UploadGameImagesRequest
    {
        public Guid EntityId { get; set; }
        public List<DTO.File> Images { get; set; }
    }
}
