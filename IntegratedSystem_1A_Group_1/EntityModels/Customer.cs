using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{

    public class Customer : User
    {

        public string? customerID { get; set; }
        public string customerName { get; set; }
        public string? customerPassword { get; set; }
        public string? companyAddress { get; set; }
        public string? customerEmail { get; set; }
        public string? customerPhone { get; set; }
        public string? country { get; set; }
        public bool? receivePromotion { get; set; }
        public List<string>? systemFunctionIds { get; set; }
        public string? DisplayName => $"{customerID} - {customerName}";

        public override string ToString()
        {
            return customerID + " " + customerName + " " + customerPassword + " " + companyAddress 
                + " " + customerEmail + " " + customerPhone + " " + country;
        }

    }

}
