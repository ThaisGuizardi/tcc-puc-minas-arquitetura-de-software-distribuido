using System;

namespace MenuFacile.Mvc.Models.Manager.PaymentMethod
{
    public class PaymentMethodAddViewModel
    {
        public int IdPaymentMethod { get; set; }

        public int IdRestaurant { get; set; }

        public string Name { get; set; }

        public bool Change { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserCreate { get; set; }

        public string IdUserEdit { get; set; }
    }
}
