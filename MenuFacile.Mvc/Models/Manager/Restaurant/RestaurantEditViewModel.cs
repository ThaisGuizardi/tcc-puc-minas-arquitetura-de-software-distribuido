using System;

namespace MenuFacile.Mvc.Models.Manager.Restaurant
{
    public class RestaurantEditViewModel
    {
        public int IdRestaurant { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Cnpj { get; set; }

        public decimal MinimumDeliveryValue { get; set; }

        public int DaysOperation { get; set; }

        public string StartHoursOperation { get; set; }

        public string EndHoursOperation { get; set; }

        public bool FreeDelivery { get; set; }

        public int IdSegment { get; set; }

        public string Address { get; set; }

        public string AddressNumber { get; set; }

        public string Complement { get; set; }

        public string Neighborhood { get; set; }

        public string ZipCode { get; set; }

        public int IdCity { get; set; }

        public int IdState { get; set; }

        public bool Active { get; set; }

        public string ImageLogo { get; set; }

        public bool OpenMonday { get; set; }

        public bool OpenTuesday { get; set; }

        public bool OpenWednesday { get; set; }

        public bool OpenThursday { get; set; }

        public bool OpenFriday { get; set; }

        public bool OpenSaturday { get; set; }

        public bool OpenSunday { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserEdit { get; set; }
    }
}
