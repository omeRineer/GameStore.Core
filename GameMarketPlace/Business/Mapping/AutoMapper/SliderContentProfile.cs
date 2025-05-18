using AutoMapper;
using Entities.Main;
using Models.SliderContent.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class SliderContentProfile : Profile
    {
        public SliderContentProfile()
        {
            #region Rest
            CreateMap<CreateSliderContentRequest, SliderContent>().ReverseMap();
            CreateMap<SliderContent, SingleSliderContentResponse>().ReverseMap();
            CreateMap<UpdateSliderContentRequest, SliderContent>().ReverseMap();
            #endregion
        }
    }
}
