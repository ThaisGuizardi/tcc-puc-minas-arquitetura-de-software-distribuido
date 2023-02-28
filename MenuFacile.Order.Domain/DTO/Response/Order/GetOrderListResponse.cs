using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Order.Domain.DTO.Response.Order
{
    public class GetOrderListResponse
    {
        public int IdOrder { get; set; }

        public int IdRestaurant { get; set; }

        public string CurrentStatus { get; set; }

        public string CurrentStatusView { get; set; }

        public string NextStatus { get; set; }

        public string NextStatusView { get; set; }

        public string OrderProductsDetails { get; set; }
    }
}
