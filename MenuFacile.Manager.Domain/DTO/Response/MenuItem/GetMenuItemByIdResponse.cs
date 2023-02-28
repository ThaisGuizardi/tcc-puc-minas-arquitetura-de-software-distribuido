using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.DTO.Response.MenuItem
{
    public class GetMenuItemByIdResponse
    {
        public int IdMenuItem { get; set; }

        public int IdMenu { get; set; }

        public int IdProduct { get; set; }

        public bool Active { get; set; }

        public DateTime EditDateTime { get; set; }

        public string IdUserEdit { get; set; }
    }
}
