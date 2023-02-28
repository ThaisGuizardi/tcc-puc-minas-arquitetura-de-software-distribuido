namespace MenuFacile.Mvc.Models.Manager.Restaurant
{
    public class RestaurantListViewModel
    {
        public int IdRestaurant { get; set; }

        public string Name { get; set; }

        public string Cnpj { get; set; }

        public string SegmentName { get; set; }

        public string CityName { get; set; }

        public string StateUF { get; set; }

        public bool Active { get; set; }
    }
}
