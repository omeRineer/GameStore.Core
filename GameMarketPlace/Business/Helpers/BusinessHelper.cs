using Core.Entities.Abstract;
using Entities.Enum.Type;
using Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public static class BusinessHelper
    {
        public static MediaTypeEnum GetMediaTypeBySliderType(SliderContent sliderContent)
        {
            MediaTypeEnum mediaType = sliderContent.SliderTypeId switch
            {
                (int)SliderTypeEnum.SliderItem => MediaTypeEnum.SliderItemImage,
                (int)SliderTypeEnum.SliderSideItem => MediaTypeEnum.SliderSideItemImage,
                _ => MediaTypeEnum.SliderItemImage
            };

            return mediaType;
        }
    }
}
