using System;

namespace MenuFacile.Mvc.Models.Manager.ProductItem
{
    public class ProductItemEditViewModel
    {
        public int IdProductItem { get; set; }

        public int IdProduct { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int NumberPeopleServing { get; set; }

        public bool Active { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserEdit { get; set; }
    }
}
