using System;

namespace MenuFacile.Mvc.Models.Manager.Menu
{
    public class MenuEditViewModel
    {
        public int IdMenu { get; set; }

        public int IdRestaurant { get; set; }

        public string Name { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public bool Active { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserEdit { get; set; }
    }
}
