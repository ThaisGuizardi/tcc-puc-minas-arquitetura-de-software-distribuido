namespace MenuFacile.Mvc.Models.Order.Dashboard
{
    public class GetListCurrentProductsByIdRestaurantViewModel
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

        public int Qty { get; set; }
    }
}
