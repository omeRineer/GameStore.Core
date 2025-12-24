using AutoMapper;
using Entities.Main;
using Models.Game;
using Models.Identity.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<CreateMenuRequest, Menu>();
            CreateMap<UpdateMenuRequest, Menu>();
            CreateMap<Menu, MenuResponse>();
        }
    }
}
