using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.DTO.Request.Segment
{
    public class SegmentAddRequest
    {
        public SegmentAddRequest(string name, string description, bool active, DateTime createDateTime, DateTime editDateTime, string idUserCreate, string idUserEdit)
        {
            Name = name;
            Description = description;
            Active = active;
            CreateDateTime = createDateTime;
            EditDateTime = editDateTime;
            IdUserCreate = idUserCreate;
            IdUserEdit = idUserEdit;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserCreate { get; set; }

        public string IdUserEdit { get; set; }
    }
}
