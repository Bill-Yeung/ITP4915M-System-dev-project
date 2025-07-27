using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class OrderModel
    {
        public string OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string MaterialID { get; set; }
        public decimal PredictedMaterialUsage { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ProductionStartDate { get; set; }
        public DateTime ProductionExpEndDate { get; set; }
        public DateTime ProductionEndDate { get; set; }
        public string OrderStatus { get; set; }
        public string ProductionStatus { get; set; }
        public string Remarks { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal PaidAmount { get; set; }
    }

}
