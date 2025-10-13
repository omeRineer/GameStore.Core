using System;

namespace Models.SliderContent
{
    public class UpdateSliderContentRequest
    {
        public Guid Id { get; set; }
        public int SliderTypeId { get; set; }
        public string? Header { get; set; }
        public string? To { get; set; }
        public bool IsActive { get; set; }
        public int Priority { get; set; }
        public string? CoverImage { get; set; }
    }

}
