using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessController
{
    public class dboUserLogin : dboDatabaseController
    {
        public dboUserLogin(string connectionString) : base(connectionString)
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
                newIdString = "C00000";
            }

            string sqlCmd = $"INSERT INTO `customer` VALUES ('{newIdString}', '{username}', '{password}'," +
                $"'{address}', '{email}', '{phone}', '{country}', 1)";

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

    }

}
