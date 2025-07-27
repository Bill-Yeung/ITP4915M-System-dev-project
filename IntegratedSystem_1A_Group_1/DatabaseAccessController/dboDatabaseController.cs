using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DatabaseAccessController
{

    public class dboDatabaseController
    {

        private string connectionString { get; set; }

        public dboDatabaseController(string connectionString)
        {
            this.connectionString = connectionString;
            //System.IO.File.WriteAllText("sql_cmd.txt", sb.ToString());
        }

        public DataTable GetData(string sqlCmd)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, conn);
                    DataTable dt = new DataTable();
                    adr.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int BatchUpdate(string sqlCmd)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    int updatedRows = 0;
                    using (MySqlCommand cmd = new MySqlCommand(sqlCmd, conn))
                    {
                        updatedRows = cmd.ExecuteNonQuery();
                    }
                    return updatedRows;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataTable GetData(string tableName, bool obtainAll, Dictionary<string, object>? searchDict)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {

                    conn.Open();

                    string sqlCmd = $"SELECT * FROM {tableName}";

                    if (!obtainAll && searchDict != null && searchDict.Count > 0)
                    {
                        sqlCmd += " WHERE " + string.Join(" AND ", searchDict.Select(item => $"{item.Key} = {FormatValue(item.Value)}"));
                    }

                    MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, conn);
                    DataTable dt = new DataTable();
                    adr.Fill(dt);
                    return dt;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int InsertData(string tableName, List<Dictionary<string, object>> dataList)
        {

            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentNullException(nameof(tableName), "Table name cannot be null or empty.");
            }

            if (dataList == null || dataList.Count == 0)
            {
                throw new ArgumentNullException(nameof(dataList), "Data cannot be null or empty.");
            }

            StringBuilder sb = new StringBuilder();

            foreach (Dictionary<string, object> row in dataList)
            {
                string columns = string.Join(", ", row.Keys.Select(key => $"`{key}`"));
                string values = string.Join(", ", row.Values.Select(value => FormatValue(value)));
                sb.Append($"INSERT INTO `{tableName}` ({columns}) VALUES ({values});");
            }

            return BatchUpdate(sb.ToString());

        }

        public int UpdateData(string tableName, List<Dictionary<string, object>> keyList, List<Dictionary<string, object>> dataList)
        {

            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentNullException(nameof(tableName), "Table name cannot be null or empty.");
            }

            if (keyList == null || keyList.Count == 0)
            {
                throw new ArgumentNullException(nameof(keyList), "Key dictionary cannot be null or empty.");
            }

            if (dataList == null || dataList.Count == 0)
            {
                throw new ArgumentNullException(nameof(dataList), "Data dictionary cannot be null or empty.");
            }

            if (keyList.Count != dataList.Count)
            {
                throw new ArgumentException("The number of key dictionaries must match the number of data dictionaries.");
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < keyList.Count; i++)
            {

                Dictionary<string, object> key = keyList[i];
                Dictionary<string, object> data = dataList[i];

                string setClause = string.Join(", ", data.Select(item => $"{item.Key} = {FormatValue(item.Value)}"));
                string whereClause = string.Join(" AND ", key.Select(item => $"{item.Key} = {FormatValue(item.Value)}"));

                sb.Append($"UPDATE {tableName} SET {setClause} WHERE {whereClause};");

            }

            return BatchUpdate(sb.ToString());

        }

        public string? GetLastId(string tableName, string primaryKey)
        {

            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentNullException(nameof(tableName), "Table name cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(primaryKey))
            {
                throw new ArgumentNullException(nameof(primaryKey), "Primary key cannot be null or empty.");
            }

            string sqlCmd = $"SELECT `{primaryKey}` FROM `{tableName}` ORDER BY `{primaryKey}` DESC LIMIT 1";
            DataTable dtResult = GetData(sqlCmd);

            if (dtResult.Rows.Count > 0) 
            {
                return dtResult.Rows[0][primaryKey].ToString();
            }
            else
            {
                return null;
            }

        }

        private string FormatValue(object value)
        {

            if (value is JsonElement je)
            {
                switch (je.ValueKind)
                {
                    case JsonValueKind.String:
                        string s = je.GetString();
                        return $"'{s.Replace("'", "''")}'";
                    case JsonValueKind.Number:
                        return je.ToString();
                    case JsonValueKind.True:
                        return "1";
                    case JsonValueKind.False:
                        return "0";
                    case JsonValueKind.Null:
                        return "NULL";
                    default:
                        return $"'{je.ToString().Replace("'", "''")}'";
                }
            }

            if (value == null)
                return "NULL";

            switch (value)
            {
                case string s:
                    return $"'{s.Replace("'", "''")}'";
                case char c:
                    return $"'{c.ToString().Replace("'", "''")}'";
                case DateTime dt:
                    return $"'{dt:yyyy-MM-dd HH:mm:ss}'";
                case bool b:
                    return b ? "1" : "0";
                default:
                    return value.ToString();
            }

        }

        public DataTable GetPaymentData(DateTime StartDate, DateTime EndDate)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string formattedStart = StartDate.ToString("yyyy-MM-dd");
                    string formattedEnd = EndDate.ToString("yyyy-MM-dd");

                    string sqlCmd = $@"
                        SELECT paymentID, paymentDate, paymentAmount, orderID, customerID
                        FROM payment
                        WHERE paymentDate BETWEEN '{formattedStart}' AND '{formattedEnd}'
                    ";

                    MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, conn);
                    DataTable dt = new DataTable();
                    adr.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Error：" + ex.Message);
                    throw;
                }
            }
        }

        public DataTable GetProductDeshboardData(DateTime StartDate, DateTime EndDate, string Status)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    string sqlCmd = @"
                SELECT 
                    po.orderID, po.quotationID, po.orderDate, po.invoiceDate, po.customerID, 
                    po.paidAmount, po.orderStatus, po.remarks, po.productionStatus, 
                    po.productionStartDate, po.productionExpEndDate, po.productionEndDate,
                    p.productName, op.quantity 
                FROM 
                    placedOrder AS po
                JOIN 
                    orderproduct AS op ON po.orderID = op.orderID
                JOIN 
                    product AS p ON op.productID = p.productID
                WHERE 
                    po.orderDate BETWEEN @StartDate AND @EndDate";


                    if (!string.IsNullOrEmpty(Status))
                    {
                        sqlCmd += " AND po.productionStatus = @Status";
                    }


                    MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);


                    cmd.Parameters.AddWithValue("@StartDate", StartDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@EndDate", EndDate.ToString("yyyy-MM-dd"));

                    if (!string.IsNullOrEmpty(Status))
                    {
                        cmd.Parameters.AddWithValue("@Status", Status);
                    }

                    conn.Open();

                    MySqlDataAdapter adr = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adr.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Error in GetProductDeshboardData: " + ex.Message);
                    throw;
                }
            }
        }

        public DataTable GetSpecifyData(string tableName, string fieldName, string? condition)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sqlCmd = $"SELECT {fieldName} FROM {tableName} {condition}";
                try
                {
                    conn.Open();
                    MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, conn);
                    DataTable dt = new DataTable();
                    adr.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }

}
