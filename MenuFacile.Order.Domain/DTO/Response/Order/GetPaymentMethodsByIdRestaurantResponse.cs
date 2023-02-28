using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Order.Domain.DTO.Response.Order
{
    public class GetPaymentMethodsByIdRestaurantResponse
    {
        public int IdPaymentMethod { get; set; }

        public int IdRestaurant { get; set; }

        public string Name { get; set; }

    }
}
