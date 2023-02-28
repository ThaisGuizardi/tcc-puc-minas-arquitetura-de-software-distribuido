using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.DTO.Response.ProductItem
{
    public class ProductItemListResponse
    {
        public int IdProductItem { get; set; }

        public string Description { get; set; }

        public string ProductName { get; set; }

        public bool Active { get; set; }
    }
}
