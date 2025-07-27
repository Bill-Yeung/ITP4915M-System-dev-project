using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using EntityModels;

namespace DatabaseAccessController
{
    public class dboCustomerInterface : dboDatabaseController
    {
        public dboCustomerInterface(string connectionString) : base(connectionString)
        {
        }

        public DataTable ViewMyOrder(string customerID)
        {
            string sqlCmd = $"SELECT customerID AS 'Customer ID', orderID AS 'Order ID', orderDate AS 'Order Date', paidAmount AS 'Total Amount', orderStatus AS 'Order Status' FROM placedorder WHERE customerID = '{customerID}'";
            return GetData(sqlCmd);
        }

        public DataTable ViewCustomerInformation(string customerID)
        {
            string sqlCmd = $"SELECT customerID AS 'Customer ID',customerName AS 'Customer Name',customerEmail AS 'Customer Contact Email',customerPhone AS 'Customer Contact Phone',companyAddress AS 'Customer Contact Address' FROM customer WHERE customerID = '{customerID}'";
            return GetData(sqlCmd);
        }

        public DataTable ViewOrderDetail(string orderID)
        {
            string sqlCmd = $"SELECT orderproduct.productID AS 'Product ID', productName AS 'Product Name', unitPrice AS 'Unit Price',quantity AS 'Quantity', (unitPrice*quantity) AS 'Total Price' FROM orderproduct, product WHERE orderID = '{orderID}' AND orderproduct.productID = product.productID";
            return GetData(sqlCmd);
        }

        public double GetOrderPaidAmount(string orderID)
        {
            string sqlCmd = $"SELECT paidAmount FROM placedorder WHERE orderID = '{orderID}'";
            DataTable dt = GetData(sqlCmd);
            if (dt.Rows.Count > 0 && dt.Rows[0]["paidAmount"] != DBNull.Value)
            {
                return Convert.ToDouble(dt.Rows[0]["paidAmount"]);
            }
            return 0.0;
        }

        public int CancelOrder(string orderID)
        {
            string sqlCmd = $"UPDATE placedorder SET orderStatus = 'Cancelled' WHERE orderID = '{orderID}'";
            return BatchUpdate(sqlCmd);
        }
    }
}
