﻿using AutoMapper;
using Entities.Main;
using Models.Game.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            #region Rest
            CreateMap<CreateGameRequest, Game>();
            CreateMap<UpdateGameRequest, Game>();
            CreateMap<Game, SingleGameResponse>();
            #endregion
        }
    }
}
