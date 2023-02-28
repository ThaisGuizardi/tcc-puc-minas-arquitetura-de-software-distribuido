namespace MenuFacile.Mvc.Models.Order.Dashboard
{
    public class GetOrderRestaurantViewModel
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
