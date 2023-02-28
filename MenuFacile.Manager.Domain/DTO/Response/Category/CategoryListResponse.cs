using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.DTO.Response.Category
{
    public class CategoryListResponse : ResponseBase
    {
        public int IdCategory { get; set; }

        public string RestaurantName { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

    }
}
