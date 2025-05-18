﻿using Core.Entities.Concrete.ProcessGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enum.Type
{
    public enum MediaTypeEnum
    {
        GameImage = ProcessGroupEnum.MediaType + 1,
        SliderItemImage = ProcessGroupEnum.MediaType + 2,
        SliderSideItemImage = ProcessGroupEnum.MediaType + 3,
        BlogCoverImage = ProcessGroupEnum.MediaType + 4,
        GameCoverImage = ProcessGroupEnum.MediaType + 5,
    }
}
