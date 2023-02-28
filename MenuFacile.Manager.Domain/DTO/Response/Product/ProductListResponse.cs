﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.DTO.Response.Product
{
    public class ProductListResponse
    {
        public int IdProduct { get; set; }

        public string RestaurantName { get; set; }

        public string CategoryName { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

    }
}
