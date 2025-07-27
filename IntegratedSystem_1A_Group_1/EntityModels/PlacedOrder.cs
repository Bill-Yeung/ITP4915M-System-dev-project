using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class PlacedOrder
    {

        public string? orderID {  get; set; }
        public string? quotationID { get; set; }
        public DateTime? orderDate { get; set; }
        public DateTime? invoiceDate { get; set; }
        public string? customerID { get; set; }
        public decimal? paidAmount { get; set; }
        public string? orderStatus { get; set; }
        public string? remarks { get; set; }
        public string? productionStatus {  get; set; }
        public DateTime? productionStartDate { get; set; }
        public DateTime? productionExpEndDate { get; set; }
        public DateTime? productionEndDate { get; set; }

    }

}
