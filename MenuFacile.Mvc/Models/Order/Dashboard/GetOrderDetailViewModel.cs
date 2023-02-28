namespace MenuFacile.Mvc.Models.Order.Dashboard
{
    public class GetOrderDetailViewModel
    {
        public int IdOrder { get; set; }

        public string ProductDetail { get; set; }

        public decimal ProductPrice { get; set; }

        public decimal TotalOrder { get; set; }

        public decimal DeliveryTax { get; set; }

        public string ProductName { get; set; }

        public decimal ChangeFor { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }
    }
}
