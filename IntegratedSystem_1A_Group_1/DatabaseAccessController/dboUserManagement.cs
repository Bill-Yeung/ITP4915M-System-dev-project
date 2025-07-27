using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModels;

namespace DatabaseAccessController
{
    public class dboUserManagement : dboDatabaseController
    {
        public dboUserManagement(string connectionString) : base(connectionString)
        {
        }

        public int RegisterCustomer(string username, string password, string address, string email, string phone, string country)
        {
            string getLastIdCmd = $"SELECT `customerID` FROM `customer` ORDER BY `customerID` DESC LIMIT 1";
            DataTable lastIdRow = GetData(getLastIdCmd);
            string newIdString = "";

            if (lastIdRow.Rows.Count > 0)
            {
                string lastIdString = lastIdRow.Rows[0][0].ToString().Substring(1);
                int lastId = int.Parse(lastIdString);
                int newId = lastId + 1;
                newIdString = "C" + newId.ToString("D5");
            }
            else
            {
                newIdString = "C00001";
            }

            string sqlCmd = $"INSERT INTO `customer` VALUES ('{newIdString}', '{username}', '{password}'," +
                $"'{address}', '{email}', '{phone}', '{country}')";

            return BatchUpdate(sqlCmd);
        }

        public DataTable GetCustomer(string username)
        {

            string sqlCmd = "";

            if (username == "ALL")
            {
                sqlCmd = $"SELECT * FROM `customer`";
            }
            else
            {
                sqlCmd = $"SELECT * FROM `customer` WHERE customerName = '{username}'";
            }

            return GetData(sqlCmd);

        }

        public DataTable GetStaff(string username)
        {

            string sqlCmd = "";

            if (username == "ALL")
            {
                sqlCmd = $"SELECT * FROM `staff`";
            }
            else
            {
                sqlCmd = $"SELECT * FROM `staff` WHERE staffName = '{username}'";
            }

            return GetData(sqlCmd);

        }

        public DataTable GetAllStaff()
        {
            string sqlCmd = $"SELECT staffID AS 'Staff ID', staffName AS 'Staff Name', staffPassword AS 'Staff Password' , departmentID AS 'Department ID' , position AS 'Position' , staffEmail AS 'Staff Email', staffPhone AS 'Staff Phone'FROM `staff`";
            return GetData(sqlCmd);

        }

        public DataTable GetAllCustomer()
        {
            string sqlCmd = $"SELECT customerID AS 'Customer ID', customerName AS 'Customer Name', customerPassword AS 'Customer Password', companyAddress AS 'Company Address', customerEmail AS 'Customer Email', customerPhone AS 'Customer Phone', country AS 'Country', receivePromotion AS 'Receive Promotion'FROM `customer`";
            return GetData(sqlCmd);
        }

        public int CreateStaff(string staffName, string staffPassword, string departmentID, string position, string staffEmail, string staffPhone, List<string> systemFunctionIds)
        {
            string getLastIdCmd = $"SELECT `staffID` FROM `staff` ORDER BY `staffID` DESC LIMIT 1";
            DataTable lastIdRow = GetData(getLastIdCmd);
            string newIdString = "";

            if (lastIdRow.Rows.Count > 0)
            {
                string lastIdString = lastIdRow.Rows[0][0].ToString().Substring(1);
                int lastId = int.Parse(lastIdString);
                int newId = lastId + 1;
                newIdString = "E" + newId.ToString("D5");
            }
            else
            {
                newIdString = "E00001";
            }

            string sqlCmd = $"INSERT INTO `staff` VALUES ('{newIdString}', '{staffName}', '{staffPassword}'," +
                $"'{departmentID}','{position}', '{staffEmail}', '{staffPhone}')";

            int result = BatchUpdate(sqlCmd);

            // add staff accessright
            foreach (var functionId in systemFunctionIds)
            {
                string accessRightCmd = $"INSERT INTO `staffsystemaccessright` (`staffID`, `systemFunctionID`, `systemAccessRight`) " +
                                        $"VALUES ('{newIdString}', '{functionId}', 2)";
                BatchUpdate(accessRightCmd);
            }

            return result;
        }

        public int CreateCustomer(string customerName, string customerPassword, string companyAddress, string customerEmail, string customerPhone, string country, bool receivePromotion, List<string> systemFunctionIds)
        {
            int receivePromotionValue = 0;
            if (receivePromotion == true)
            {
                receivePromotionValue = 1;
            }

            string getLastIdCmd = $"SELECT `customerID` FROM `customer` ORDER BY `customerID` DESC LIMIT 1";
            DataTable lastIdRow = GetData(getLastIdCmd);
            string newIdString = "";

            if (lastIdRow.Rows.Count > 0)
            {
                string lastIdString = lastIdRow.Rows[0][0].ToString().Substring(1);
                int lastId = int.Parse(lastIdString);
                int newId = lastId + 1;
                newIdString = "C" + newId.ToString("D5");
            }
            else
            {
                newIdString = "C00001";
            }

            string sqlCmd = $"INSERT INTO customer VALUES ('{newIdString}', '{customerName}', '{customerPassword}'," +
                $"'{companyAddress}','{customerEmail}', '{customerPhone}', '{country}', {receivePromotionValue})";

            int result = BatchUpdate(sqlCmd);

            // add customer accessright
            foreach (var functionId in systemFunctionIds)
            {
                string accessRightCmd = $"INSERT INTO `customersystemaccessright` (`customerID`, `systemFunctionID`, `systemAccessRight`) " +
                                        $"VALUES ('{newIdString}', '{functionId}', 2)";
                BatchUpdate(accessRightCmd);
            }

            return result;
        }

        public DataTable GetStaffByID(string staffID)
        {
            string sqlCmd = $"SELECT * FROM `staff` WHERE staffID = '{staffID}'";
            return GetData(sqlCmd);
        }

        public DataTable GetCustomerByID(string customerID)
        {
            string sqlCmd = $"SELECT * FROM `customer` WHERE customerID = '{customerID}'";
            return GetData(sqlCmd);
        }

        public DataTable GetStaffAccessRight(string staffID)
        {
            string sqlCmd = $"SELECT systemFunctionID FROM staffsystemaccessright WHERE staffID = '{staffID}' AND systemAccessRight = 2";
            return GetData(sqlCmd);
        }

        public DataTable GetCustomerAccessRight(string customerID)
        {
            string sqlCmd = $"SELECT systemFunctionID FROM customersystemaccessright WHERE customerID = '{customerID}' AND systemAccessRight = 2";
            return GetData(sqlCmd);
        }

        public int UpdateStaff(string staffID, string staffName, string staffPassword, string departmentID, string position, string staffEmail, string staffPhone, List<string> systemFunctionIds)
        {
            //update staff table
            string sqlCmd = $"UPDATE `staff` SET staffName='{staffName}', staffPassword='{staffPassword}', departmentID='{departmentID}', position='{position}', staffEmail='{staffEmail}', staffPhone='{staffPhone}' WHERE staffID='{staffID}'";
            int result = BatchUpdate(sqlCmd);

            // remove access rights first
            string delCmd = $"DELETE FROM `staffsystemaccessright` WHERE staffID='{staffID}'";
            BatchUpdate(delCmd);

            // add new access rights
            foreach (var functionId in systemFunctionIds)
            {
                string accessRightCmd = $"INSERT INTO `staffsystemaccessright` (`staffID`, `systemFunctionID`, `systemAccessRight`) VALUES ('{staffID}', '{functionId}', 2)";
                BatchUpdate(accessRightCmd);
            }

            return result;
        }

        public int UpdateCustomer(string customerID, string customerName, string customerPassword, string companyAddress, string customerEmail, string customerPhone, string country, int receivePromotionValue, List<string> systemFunctionIds)
        {
            //update staff table
            string sqlCmd = $"UPDATE `customer` SET customerName='{customerName}', customerPassword='{customerPassword}', companyAddress='{companyAddress}', customerEmail='{customerEmail}', customerPhone='{customerPhone}', country='{country}', receivePromotion = {receivePromotionValue} WHERE customerID='{customerID}'";
            int result = BatchUpdate(sqlCmd);

            // remove access rights first
            string delCmd = $"DELETE FROM `customersystemaccessright` WHERE customerID='{customerID}'";
            BatchUpdate(delCmd);

            // add new access rights
            foreach (var functionId in systemFunctionIds)
            {
                string accessRightCmd = $"INSERT INTO `customersystemaccessright` (`customerID`, `systemFunctionID`, `systemAccessRight`) VALUES ('{customerID}', '{functionId}', 2)";
                BatchUpdate(accessRightCmd);
            }

            return result;
        }

        public int DeleteStaff(string staffID)
        {
            // delete staff account from table "staffsystemaccessright" first
            string delAccessCmd = $"DELETE FROM `staffsystemaccessright` WHERE staffID = '{staffID}'";
            BatchUpdate(delAccessCmd);

            // delete staff account from table "staff"
            string delStaffCmd = $"DELETE FROM `staff` WHERE staffID = '{staffID}'";
            return BatchUpdate(delStaffCmd);
        }

        public int DeleteCustomer(string customerID)
        {
            string delAccessCmd = $"DELETE FROM `customersystemaccessright` WHERE customerID = '{customerID}'";
            BatchUpdate(delAccessCmd);

            string delCustomerCmd = $"DELETE FROM `customer` WHERE customerID = '{customerID}'";
            return BatchUpdate(delCustomerCmd);
        }

        public bool HasRefundForCustomer(string customerID)
        {
            string sql = $"SELECT COUNT(*) FROM refund WHERE customerID = '{customerID}'";
            DataTable dt = GetData(sql);
            if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
                return true;
            return false;
        }
        public bool HasQuotationForCustomer(string customerID)
        {
            string sql = $"SELECT COUNT(*) FROM quotation WHERE customerID = '{customerID}'";
            DataTable dt = GetData(sql);
            if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
                return true;
            return false;
        }
        public bool HasOrderForCustomer(string customerID)
        {
            string sql = $"SELECT COUNT(*) FROM placedorder WHERE customerID = '{customerID}'";
            DataTable dt = GetData(sql);
            if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
                return true;
            return false;
        }

        public bool HasPaymentForCustomer(string customerID)
        {
            string sql = $"SELECT COUNT(*) FROM paymentdetails WHERE customerID = '{customerID}'";
            DataTable dt = GetData(sql);
            if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
                return true;
            return false;
        }


    }

}
