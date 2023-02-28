using System;

namespace MenuFacile.Mvc.Models.Manager.Menu
{
    public class MenuListViewModel
    {
        public int IdMenu { get; set; }

        public string Name { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public bool Active { get; set; }

        public string RestaurantName { get; set; }
    }
}
