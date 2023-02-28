using System;

namespace MenuFacile.Mvc.Models.Manager.RestaurantUser
{
    public class RestaurantUserAddViewModel
    {
        public int IdRestaurant { get; set; }

        public string IdUser { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserCreate { get; set; }

        public string IdUserEdit { get; set; }
    }
}
