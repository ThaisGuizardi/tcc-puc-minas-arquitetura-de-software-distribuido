using System;

namespace MenuFacile.Mvc.Models.Manager.MenuItem
{
    public class MenuItemAddViewModel
    {
        public int IdMenu { get; set; }

        public int IdProduct { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserCreate { get; set; }

        public string IdUserEdit { get; set; }
    }
}
