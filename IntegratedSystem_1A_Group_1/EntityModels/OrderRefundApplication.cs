
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class OrderRefundApplication
    {
        public string? refundID { get; set; }
        public string customerID { get; set; }
        public string orderID { get; set; }
        public string refundDescription { get; set; }
        public string? staffAssigned { get; set; }
        public string? refundRejectReason { get; set; }
        public string? refundStatus { get; set; }
        public DateTime refundLastUpdate { get; set; }

    }

}
