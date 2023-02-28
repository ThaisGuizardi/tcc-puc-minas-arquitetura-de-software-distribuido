using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.DTO.Response.Restaurant
{
    public class RestaurantListResponse : ResponseBase
    {
        public int IdRestaurant { get; set; }

        public string Name { get; set; }

        public string Cnpj { get; set; }

        public string SegmentName { get; set; }

        public string CityName { get; set; }

        public string StateUF { get; set; }

        public bool Active { get; set; }
    }
}
