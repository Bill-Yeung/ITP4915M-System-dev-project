using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class ProductMaterialVersion
    {

        public string versionID { get; set; }
        public string? productID {  get; set; }
        public string? materialID { get; set; }
        public decimal? quantity { get; set; }
        public DateTime? recordDate { get; set; }
        public string? recordPerson {  get; set; }
        public string? versionStatus { get; set; }

    }

}
