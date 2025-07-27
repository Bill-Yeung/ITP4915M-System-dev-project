using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class ProductAttributeVersion
    {

        public string? versionID { get; set; }
        public string? productID { get; set; }
        public string? attributeID { get; set; }
        public string attributeValue { get; set; }
        public string? fileID { get; set; }
        public DateTime? recordDate { get; set; }
        public string? recordPerson { get; set; }
        public string versionStatus { get; set; }

    }

}
