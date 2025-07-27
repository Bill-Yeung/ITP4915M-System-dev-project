using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class RawMaterial
    {

        public string materialID { get; set; }
        public string? materialName { get; set; }
        public int? inStockQuantity { get; set; }
        public int? requestQuantity { get; set; }
        public string? unit { get; set; }
        public int? lowLevelAlertIndex { get; set; }
        public string? stockStatus { get; set; }
        public string? restockStatus { get; set; }

    }

}
