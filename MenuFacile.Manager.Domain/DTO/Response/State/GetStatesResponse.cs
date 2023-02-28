using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.DTO.Response.State
{
    public class GetStatesResponse : ResponseBase
    {
        public int IdState { get; set; }

        public string Name { get; set; }
    }
}
