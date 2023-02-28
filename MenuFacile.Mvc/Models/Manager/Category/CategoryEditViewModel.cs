using System;

namespace MenuFacile.Mvc.Models.Manager.Category
{
    public class CategoryEditViewModel
    {
        public int IdCategory { get; set; }

        public int IdRestaurant { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserEdit { get; set; }
    }
}
