﻿using Core.Entities.Abstract;

namespace Core.Entities.Concrete.ProcessGroups
{
    public class TypeLookup : BaseEntity<int>
    {
        public int ProcessGroupId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public ProcessGroup ProcessGroup { get; set; }
    }
}
