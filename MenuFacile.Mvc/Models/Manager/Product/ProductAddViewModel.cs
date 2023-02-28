using System;

namespace MenuFacile.Mvc.Models.Manager.Product
{
    public class ProductAddViewModel
    {
        public int IdCategory { get; set; }

        public int IdRestaurant { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserCreate { get; set; }

        public string IdUserEdit { get; set; }
    }
}
