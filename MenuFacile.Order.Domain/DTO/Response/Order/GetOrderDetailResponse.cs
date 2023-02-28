using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Order.Domain.DTO.Response.Order
{
    public class GetOrderDetailResponse
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