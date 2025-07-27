using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class Quotation
    {

        public string? quotationID {  get; set; }
        public DateTime? quotationDate { get; set; }
        public string? customerID { get; set; }
        public decimal? deposit {  get; set; }
        public string? paymentTerm { get; set; }
        public string? remarks { get; set; }
        public string? quotationStatus { get; set; }
        public ICollection<QuotationProduct>? quotationProducts { get; set; }

    }

}
