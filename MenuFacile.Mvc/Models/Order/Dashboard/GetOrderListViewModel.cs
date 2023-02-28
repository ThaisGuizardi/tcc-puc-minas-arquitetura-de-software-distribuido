namespace MenuFacile.Mvc.Models.Order.Dashboard
{
    public class GetOrderListViewModel
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
