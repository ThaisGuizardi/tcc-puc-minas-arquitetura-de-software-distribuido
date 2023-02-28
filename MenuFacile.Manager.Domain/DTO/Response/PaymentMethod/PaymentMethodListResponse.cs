using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.DTO.Response.PaymentMethod
{
    public class PaymentMethodListResponse
    {
        public int IdPaymentMethod { get; set; }

        public string RestaurantName { get; set; }

        public bool Change { get; set; }

        public bool Active { get; set; }

        public string Name { get; set; }

    }
}
