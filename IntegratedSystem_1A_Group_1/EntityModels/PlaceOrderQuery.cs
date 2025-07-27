using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class PlaceOrderQuery
    {
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string? Status { get; set; }
    }
}
