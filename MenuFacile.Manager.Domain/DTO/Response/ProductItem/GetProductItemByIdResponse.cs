﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.DTO.Response.ProductItem
{
    public class GetProductItemByIdResponse
    {
        public int IdProductItem { get; set; }

        public int IdProduct { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int NumberPeopleServing { get; set; }

        public bool Active { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserEdit { get; set; }

    }
}
