using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Order.Domain.DTO.Request.OrderItem
{
    public class OrderItemAddRequest
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
