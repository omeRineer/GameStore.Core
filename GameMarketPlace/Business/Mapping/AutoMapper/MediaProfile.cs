using AutoMapper;
using Entities.Main;
using Models.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class MediaProfile : Profile
    {
        public MediaProfile()
        {
            CreateMap<Media, GetMediaModel>();
            CreateMap<PostMediaModel, Media>();
        }
    }
}
