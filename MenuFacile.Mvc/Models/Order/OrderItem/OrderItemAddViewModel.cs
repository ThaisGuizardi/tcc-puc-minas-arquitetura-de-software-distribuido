using System;

namespace MenuFacile.Mvc.Models.Order.OrderItem
{
    public class OrderItemAddViewModel
    {
        public int IdOrder { get; set; }

        public int IdProduct { get; set; }

        public int Qty { get; set; }

        public decimal ProductPrice { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserCreate { get; set; }

        public string IdUserEdit { get; set; }
    }
}
