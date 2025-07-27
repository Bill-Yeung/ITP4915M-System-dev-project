using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Common;
using EntityModels;

namespace DatabaseAccessController
{
    public class dboOrderRefund : dboDatabaseController
    {
        public dboOrderRefund(string connectionString) : base(connectionString)
        {
        }
        public DataTable GetCustomerOrder(string orderID)
        {
            string sqlCmd = $"SELECT placedorder.orderID, orderDate, orderStatus , productID, unitPrice, quantity, paidAmount FROM placedorder, orderproduct WHERE placedorder.orderID = '{orderID}' AND placedorder.orderID = orderproduct.orderID";
            return GetData(sqlCmd);
        }
        public bool IsRefundExists(string orderID)
        {
            string sqlCmd = $"SELECT COUNT(1) FROM refund WHERE orderID = '{orderID}'";
            DataTable result = GetData(sqlCmd);

            if (result.Rows.Count > 0)
            {
                int count = Convert.ToInt32(result.Rows[0][0]);
                return count > 0;
            }
            return false;
        }

        public int CreateRefundApplication(string customerID, string orderID, string refundDescription, string? staffAssigned, string? refundRejectReason, string? refundStatus, DateTime refundLastUpdate)
        {

            string getLastIdCmd = $"SELECT refundID FROM refund ORDER BY refundID DESC LIMIT 1";
            DataTable lastIdRow = GetData(getLastIdCmd);
            string newIdString = "";

            if (lastIdRow.Rows.Count > 0)
            {
                string lastIdString = lastIdRow.Rows[0][0].ToString().Substring(2);
                int lastId = int.Parse(lastIdString);
                int newId = lastId + 1;
                newIdString = "OR" + newId.ToString("D5");
            }
            else
            {
                newIdString = "OR00001";
            }
            string staffAssignedValue = string.IsNullOrEmpty(staffAssigned) ? "NULL" : $"'{staffAssigned}'";
            string refundRejectReasonValue = string.IsNullOrEmpty(refundRejectReason) ? "NULL" : $"'{refundRejectReason}'";
            string refundStatusValue = string.IsNullOrEmpty(refundStatus) ? "NULL" : $"'{refundStatus}'";

            string sqlCmd = $"INSERT INTO refund VALUES ('{newIdString}', '{customerID}', '{orderID}'," +
                $"'{refundDescription}', {staffAssignedValue}, {refundRejectReasonValue}, {refundStatusValue}, '{refundLastUpdate:yyyy-MM-dd}')";

            return BatchUpdate(sqlCmd);
        }

        public DataTable ViewAllRefund()
        {
            string sqlCmd = $"SELECT refundID AS 'Refund ID', customerID AS 'Customer ID',orderID AS 'Order ID', refundDescription AS 'Refund Description' , staffAssigned AS 'Staff Assigned', refundRejectReason AS 'Refund Reject Reason', refundStatus AS 'Refund Status', refundLastUpdate AS 'Refund Last Update'FROM refund";
            return GetData(sqlCmd);
        }

        public int ApproveRefundByCS(string refundID, string staffID, string newStatus, string refundRejectReason, DateTime updateDate)
        {
            string refundRejectReasonValue = string.IsNullOrEmpty(refundRejectReason) ? "NULL" : $"'{refundRejectReason}'";
            string sqlCmd = $"UPDATE refund SET refundStatus = '{newStatus}', refundLastUpdate = '{updateDate:yyyy-MM-dd}', staffAssigned = '{staffID}', refundRejectReason = '{refundRejectReason}'WHERE refundID = '{refundID}'";
            return BatchUpdate(sqlCmd);
        }

        public int ApproveRefundByFinance(string refundID, string staffID, string newStatus, string refundRejectReason, DateTime updateDate)
        {
            string refundRejectReasonValue = string.IsNullOrEmpty(refundRejectReason) ? "NULL" : $"'{refundRejectReason}'";
            string sqlCmd = $"UPDATE refund SET refundStatus = '{newStatus}', refundLastUpdate = '{updateDate:yyyy-MM-dd}', staffAssigned = '{staffID}', refundRejectReason = '{refundRejectReason}' WHERE refundID = '{refundID}'";
            return BatchUpdate(sqlCmd);
        }

        public int RejectRefund(string refundID, string staffID, string rejectReason, DateTime updateDate)
        {
            string sqlCmd = $"UPDATE refund SET refundStatus = 'Rejected', refundRejectReason = '{rejectReason}', refundLastUpdate = '{updateDate:yyyy-MM-dd}', staffAssigned = '{staffID}' WHERE refundID = '{refundID}'";
            return BatchUpdate(sqlCmd);
        }
    }

}
