using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.DTO.Response.MenuItem
{
    public class MenuItemListResponse
    {
        public int IdMenuItem { get; set; }

        public string MenuName { get; set; }

        public string ProductName { get; set; }

        public bool Active { get; set; }
    }
}
