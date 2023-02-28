using System;

namespace MenuFacile.Mvc.Models.Manager.Product
{
    public class ProductEditViewModel
    {
        public int IdProduct { get; set; }

        public int IdCategory { get; set; }

        public int IdRestaurant { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserEdit { get; set; }
    }
}
