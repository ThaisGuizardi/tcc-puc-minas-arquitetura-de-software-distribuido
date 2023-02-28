using System.Collections.Generic;

namespace MenuFacile.Mvc.Models.Order.Dashboard
{
    public class OrderViewModel
    {
        public IEnumerable<GetListCurrentProductsByIdRestaurantViewModel> GetListCurrentProductsByIdRestaurant { get; set; }

        public GetOrderRestaurantViewModel GetRestaurant { get; set; }

        public IEnumerable<GetOrderProductsViewModel> ListProducts { get; set; }

        public OrderAddViewModel OrderAdd { get; set; }

    }
}
