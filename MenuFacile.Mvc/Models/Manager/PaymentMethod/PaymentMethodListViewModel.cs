namespace MenuFacile.Mvc.Models.Manager.PaymentMethod
{
    public class PaymentMethodListViewModel
    {
        public int IdPaymentMethod { get; set; }

        public string RestaurantName { get; set; }

        public bool Change { get; set; }

        public bool Active { get; set; }

        public string Name { get; set; }
    }
}
