namespace MenuFacile.Mvc.Models.Order.Dashboard
{
    public class GetOrderProductsViewModel
    {
        public int IdRestaurant { get; set; }

        public string ProductName { get; set; }

        public string ProductItemDescription { get; set; }

        public decimal Price { get; set; }

        public int IdCategory { get; set; }
    }
}
