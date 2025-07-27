using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class OrderProduct
    {

        public string? orderID {  get; set; }
        public string? productID { get; set; }
        public decimal? unitPrice { get; set; }
        public int? quantity { get; set; }

    }

}
