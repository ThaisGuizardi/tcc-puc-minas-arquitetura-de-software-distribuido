﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Order.Domain.DTO.Request.Order
{
    public class OrderUpdateStatusRequest
    {
        public int IdOrder { get; set; }

        public string OrderStatus { get; set; }

    }
}
