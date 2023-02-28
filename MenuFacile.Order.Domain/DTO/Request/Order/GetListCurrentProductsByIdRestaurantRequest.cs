using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Order.Domain.DTO.Request.Order
{
    public class GetListCurrentProductsByIdRestaurantRequest
    {
        public int IdRestaurant { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }
    }
}
