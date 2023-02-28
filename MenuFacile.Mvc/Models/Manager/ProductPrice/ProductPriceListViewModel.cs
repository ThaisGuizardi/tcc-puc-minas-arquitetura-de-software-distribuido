using System;

namespace MenuFacile.Mvc.Models.Manager.ProductPrice
{
    public class ProductPriceListViewModel
    {
        public int IdProductPrice { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }

        public bool Active { get; set; }
    }
}
