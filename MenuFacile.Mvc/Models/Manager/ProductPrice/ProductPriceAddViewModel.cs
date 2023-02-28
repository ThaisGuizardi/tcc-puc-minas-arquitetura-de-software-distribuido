﻿using System;

namespace MenuFacile.Mvc.Models.Manager.ProductPrice
{
    public class ProductPriceAddViewModel
    {
        public int IdProductPrice { get; set; }

        public int IdProduct { get; set; }

        public decimal Price { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserCreate { get; set; }

        public string IdUserEdit { get; set; }
    }
}
