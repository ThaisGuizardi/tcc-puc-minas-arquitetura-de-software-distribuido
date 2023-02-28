using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.DTO.Response.ProductPrice
{
    public class ProductPriceListResponse
    {
        public int IdProductPrice { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }

        public bool Active { get; set; }
    }
}
