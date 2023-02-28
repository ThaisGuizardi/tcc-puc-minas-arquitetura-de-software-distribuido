using System;

namespace MenuFacile.Mvc.Models.Manager.Segment
{
    public class SegmentEditViewModel
    {
        public int IdSegment { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserEdit { get; set; }
    }
}
