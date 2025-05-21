using AutoMapper;
using Core.Entities.Concrete.ProcessGroups;
using Models.SliderContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class TypeLookupProfile : Profile
    {
        public TypeLookupProfile()
        {
            #region Rest
            CreateMap<TypeLookup, SingleSliderContent_Type>().ReverseMap();
            #endregion
        }
    }
}
