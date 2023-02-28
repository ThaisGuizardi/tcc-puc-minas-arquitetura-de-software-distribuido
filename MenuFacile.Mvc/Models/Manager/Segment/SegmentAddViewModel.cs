using System;

namespace MenuFacile.Mvc.Models.Manager.Segment
{
    public class SegmentAddViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserCreate { get; set; }

        public string IdUserEdit { get; set; }
    }
}
