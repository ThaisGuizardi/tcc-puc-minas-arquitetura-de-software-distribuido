using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Order.Domain.DTO.Request.Order
{
    public class GetOrderListRequest
    {
        public int IdRestaurant { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public string OrderStatus { get; set; }

    }
}
