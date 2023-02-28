using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.DTO.Request.Product
{
    public class ProductEditRequest
    {
        public int IdProduct { get; set; }

        public int IdCategory { get; set; }

        public int IdRestaurant { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserEdit { get; set; }
    }
}
