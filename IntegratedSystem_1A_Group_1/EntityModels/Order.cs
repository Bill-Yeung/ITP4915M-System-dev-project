using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{

    public class Order
    {
        public string? orderID { get; set; }
        public string? quotationID { get; set; }
        public DateTime? orderDate { get; set; }
        public DateTime? invoiceDate { get; set; }
        public string? customerID { get; set; }
        public decimal? paidAmount { get; set; }
        public string? orderStatus { get; set; }
        public string? remarks { get; set; }
        public ICollection<OrderProductP>? orderProducts { get; set; }
    }

    public class OrderProductP
    {
        public string? orderID { get; set; }
        public string? productID { get; set; }
        public decimal? unitPrice { get; set; }
        public int? quantity { get; set; }
        public Order? order { get; set; }
    }

}
