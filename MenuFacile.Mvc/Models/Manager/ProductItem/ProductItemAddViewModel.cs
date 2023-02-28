using System;

namespace MenuFacile.Mvc.Models.Manager.ProductItem
{
    public class ProductItemAddViewModel
    {
        public int IdProduct { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int NumberPeopleServing { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserCreate { get; set; }

        public string IdUserEdit { get; set; }
    }
}
