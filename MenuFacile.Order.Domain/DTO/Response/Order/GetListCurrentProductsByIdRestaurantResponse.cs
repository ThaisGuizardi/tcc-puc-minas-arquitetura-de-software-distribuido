using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Order.Domain.DTO.Response.Order
{
    public class GetListCurrentProductsByIdRestaurantResponse
    {
        public int IdRestaurant { get; set; }

        public int IdCategory { get; set; }

        public string CategoryName { get; set; }

        public int IdProduct { get; set; }

        public string Name { get; set; }

        public int IdProductItem { get; set; }

        public string Description { get; set; }

        public int IdProductPrice { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

    }
}
