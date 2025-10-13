using AutoMapper;
using Entities.Main;
using Models.GameImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class GameImageProfile : Profile
    {
        public GameImageProfile()
        {
            CreateMap<GameImage, GameImageResponse>();
        }
    }
}
