using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Order.Domain.DTO.Request.Order
{
    public class OrderEditRequest
    {
        public int IdOrder { get; set; }

        public int IdRestaurant { get; set; }

        public string Status { get; set; }

        public string LinkOrder { get; set; }

        public string CustomerAddress { get; set; }

        public int IdPaymentMethod { get; set; }

        public decimal ChangeFor { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public decimal TotalOrder { get; set; }

        public bool Active { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserEdit { get; set; }
    }
}
