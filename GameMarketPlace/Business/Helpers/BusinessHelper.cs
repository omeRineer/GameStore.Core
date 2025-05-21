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
        public static (IEnumerable<Type>? Matches, 
                       IEnumerable<Type>? MisMatchesSource,
                       IEnumerable<Type>? MisMatchesCluster) 
            GetMatchesList<Type>(IEnumerable<Type> source,
                                 IEnumerable<Type> cluster)
        {
            var matches = source.Where(f=> cluster.Contains(f)); // S ∩ C
            var sourceMisMatches = source.Where(f => !cluster.Contains(f));  // S - C
            var clusterMisMatches = cluster.Where(f => !source.Contains(f)); // C - S

            return (matches, sourceMisMatches, clusterMisMatches);
        }
    }
}
