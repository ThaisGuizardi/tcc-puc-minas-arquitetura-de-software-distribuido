using System;
using System.Collections.Generic;

namespace MenuFacile.Mvc.Models.Order.Dashboard
{
    public class DashboardViewModel
    {
        public int IdRestaurant { get; set; }

        public DateTime DateFrom { get; set; } = DateTime.Now.Date;

        public DateTime DateTo { get; set; } = DateTime.Now.Date;

        public List<GetOrderListViewModel> GetOrderList { get; set; }
    }
}
