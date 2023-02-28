using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.DTO.Response.Segment
{
    public class SegmentListResponse : ResponseBase
    {
        public int IdSegment { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }
    }
}
