using System;

namespace MenuFacile.Mvc.Models.Manager.Menu
{
    public class MenuAddViewModel
    {
        public int IdRestaurant { get; set; }

        public string Name { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserCreate { get; set; }

        public string IdUserEdit { get; set; }
    }
}
