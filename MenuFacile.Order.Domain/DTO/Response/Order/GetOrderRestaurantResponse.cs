using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Order.Domain.DTO.Response.Order
{
    public class GetOrderRestaurantResponse
    {
        public int IdRestaurant { get; set; }

        public string ImageLogo { get; set; }

        public string RestaurantName { get; set; }

        public string SegmentName { get; set; }

        public int IdSegment { get; set; }

        public decimal MinimumDeliveryValue { get; set; }

        public decimal DeliveryTax { get; set; }

        public string RestaurantOpen { get; set; }

        public string RestaurantAddress { get; set; }
    }
}
