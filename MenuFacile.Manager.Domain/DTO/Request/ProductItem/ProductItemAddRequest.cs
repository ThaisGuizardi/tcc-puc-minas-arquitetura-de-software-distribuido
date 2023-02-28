using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.DTO.Request.ProductItem
{
    public class ProductItemAddRequest
    {
        public int IdProduct { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int NumberPeopleServing { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserCreate { get; set; }

        public string IdUserEdit { get; set; }
    }
}
