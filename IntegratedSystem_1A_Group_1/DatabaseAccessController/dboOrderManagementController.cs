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
    public class dboOrderManagementController : dboDatabaseController
    {
        public dboOrderManagementController(string connectionString) : base(connectionString)
        {
        }
        public DataTable ViewAllOrder()
        {
            string sqlCmd = $"SELECT orderID AS 'Order ID',placedorder.customerID AS 'Customer ID',  customerName AS 'Customer Name',orderDate AS 'Order Date', paidAmount AS 'Paid Amount', orderStatus AS 'Order Status' FROM placedorder, customer WHERE placedorder.customerID = customer.customerID";
            return GetData(sqlCmd);
        }

        public DataTable GetAllCustomer()
        {
            string sqlCmd = "SELECT customerID, customerName FROM customer";
            return GetData(sqlCmd);
        }
        public DataTable GetAllProduct()
        {
            string sqlCmd = "SELECT productID, productName FROM product";
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

        public int UpdateOrderStatus(string orderID)
        {
            string sqlCmd = $"UPDATE placedorder SET orderStatus='SentToFinance'WHERE orderID='{orderID}'";
            int result = BatchUpdate(sqlCmd);
            return result;
        }
        public int DeleteOrder(string orderID)
        {
            string sqlCmd = $"DELETE FROM orderproduct WHERE orderID='{orderID}'";
            int result = BatchUpdate(sqlCmd);

            string delCmd = $"DELETE FROM placedorder WHERE orderID='{orderID}'";
            result += BatchUpdate(delCmd);

            return result;
        }
        public int CreateQuotation(Quotation quotation, List<QuotationProduct> products)
        {
            string getLastIdCmd = $"SELECT quotationID FROM quotation ORDER BY quotationID DESC LIMIT 1";
            DataTable lastIdRow = GetData(getLastIdCmd);
            string newIdString = "";

            if (lastIdRow.Rows.Count > 0)
            {
                string lastIdString = lastIdRow.Rows[0][0].ToString().Substring(1);
                int lastId = int.Parse(lastIdString);
                int newId = lastId + 1;
                newIdString = "Q" + newId.ToString("D5");
            }
            else
            {
                newIdString = "Q00001";
            }

            quotation.quotationID = newIdString;
            string dateString = quotation.quotationDate?.ToString("yyyy-MM-dd") ?? DateTime.Now.ToString("yyyy-MM-dd");

            string sqlCmd = $"INSERT INTO quotation (quotationID, quotationDate, customerID, deposit, paymentTerm, remarks, quotationStatus) " +
                $"VALUES ('{quotation.quotationID}', '{dateString}', '{quotation.customerID}', {quotation.deposit}, '{quotation.paymentTerm}', '{quotation.remarks}', '{quotation.quotationStatus}')";
            int result = BatchUpdate(sqlCmd);


            if (products == null || products.Count == 0)
                return result;

            foreach (var p in products)
                p.quotationID = quotation.quotationID;

            StringBuilder sb = new StringBuilder();
            foreach (var p in products)
            {
                sb.AppendLine(
                    $"INSERT INTO quotationproduct (quotationID, productID, unitPrice, quantity) " +
                    $"VALUES ('{p.quotationID}', '{p.productID}', {p.unitPrice}, {p.quantity});"
                );
            }
            result += BatchUpdate(sb.ToString());
            return result;
        }

        public Quotation GetQuotationById(string quotationID)
        {
            string sql = $"SELECT * FROM quotation WHERE quotationID = '{quotationID}'";
            DataTable dt = GetData(sql);
            if (dt.Rows.Count == 0) return null;
            var row = dt.Rows[0];
            return new Quotation
            {
                quotationID = row["quotationID"].ToString(),
                quotationDate = row["quotationDate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["quotationDate"]),
                customerID = row["customerID"].ToString(),
                deposit = row["deposit"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["deposit"]),
                paymentTerm = row["paymentTerm"].ToString(),
                remarks = row["remarks"].ToString(),
                quotationStatus = row["quotationStatus"].ToString()
            };
        }
        public List<QuotationProduct> GetQuotationProductsById(string quotationID)
        {
            string sql = $"SELECT * FROM quotationproduct WHERE quotationID = '{quotationID}'";
            DataTable dt = GetData(sql);
            var list = new List<QuotationProduct>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new QuotationProduct
                {
                    quotationID = row["quotationID"].ToString(),
                    productID = row["productID"].ToString(),
                    unitPrice = row["unitPrice"] == DBNull.Value ? 0 : Convert.ToInt32(row["unitPrice"]),
                    quantity = row["quantity"] == DBNull.Value ? 0 : Convert.ToInt32(row["quantity"])
                });
            }
            return list;
        }

        public int UpdateQuotation(Quotation quotation, List<QuotationProduct> products)
        {
            int result = 0;
            if (products == null || products.Count == 0)
                return result;

            string sqlCmd = $"DELETE FROM quotationproduct WHERE quotationID = '{quotation.quotationID}'";
            result += BatchUpdate(sqlCmd);

            foreach (var p in products)
                p.quotationID = quotation.quotationID;

            StringBuilder sb = new StringBuilder();
            foreach (var p in products)
            {
                sb.AppendLine(
                    $"INSERT INTO quotationproduct (quotationID, productID, unitPrice, quantity) " +
                    $"VALUES ('{p.quotationID}', '{p.productID}', {p.unitPrice}, {p.quantity});"
                );
            }
            result += BatchUpdate(sb.ToString());

            string dateString = quotation.quotationDate?.ToString("yyyy-MM-dd") ?? DateTime.Now.ToString("yyyy-MM-dd");

            sqlCmd = $"UPDATE quotation SET customerID = '{quotation.customerID}', deposit = {quotation.deposit}, paymentTerm = '{quotation.paymentTerm}', remarks ='{quotation.remarks}', quotationStatus ='{quotation.quotationStatus}', quotationDate ='{dateString}' WHERE quotationID = '{quotation.quotationID}'";
            result += BatchUpdate(sqlCmd);

            return result;
        }
    }
}
