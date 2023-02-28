using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.DTO.Request.ProductPrice
{
    public class ProductPriceAddRequest
    {
        public int IdProductPrice { get; set; }

        public int IdProduct { get; set; }

        public decimal Price { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserCreate { get; set; }

        public string IdUserEdit { get; set; }
    }
}
