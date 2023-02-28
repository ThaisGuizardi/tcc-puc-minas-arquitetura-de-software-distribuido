using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.DTO.Response.Menu
{
    public class MenuListResponse
    {
        public int IdMenu { get; set; }

        public string Name { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public bool Active { get; set; }

        public string RestaurantName { get; set; }
    }
}
