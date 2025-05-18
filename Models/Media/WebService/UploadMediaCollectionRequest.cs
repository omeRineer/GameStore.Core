using DTO = Core.Entities.DTO.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enum.Type;

namespace Models.Media.WebService
{
    public class UploadMediaCollectionRequest
    {
        public Guid EntityId { get; set; }
        public int MediaType { get; set; }
        public List<DTO.File> Medias { get; set; }
    }
}
