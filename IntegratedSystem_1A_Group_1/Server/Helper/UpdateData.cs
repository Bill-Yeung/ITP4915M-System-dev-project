using Microsoft.AspNetCore.Mvc;

namespace Server.Helper
{
    public static class UpdateData
    {

        public static string InsertData([FromBody] Dictionary<string, object> newData, string tableName)
        {
            if (string.IsNullOrEmpty(tableName)) throw new ArgumentNullException("Table name cannot be null or empty.", nameof(tableName));
            if (newData == null || newData.Count == 0) throw new ArgumentNullException("Data cannot be null or empty.", nameof(newData));
            List<string> fieldNames = newData.Keys.ToList();
            List<object> fieldValues = newData.Values.ToList();
            string columns = string.Join(", ", fieldNames);
            // string values = string.Join(", ", materialData.Values.Select(v =>( v is string || v is DateTime)? $"'{v}'" : v.ToString()));
            string values = string.Join(", ", newData.Values.Select(v => $"'{v}'"));
            string sqlCmd = $"INSERT INTO `{tableName}` ({columns}) VALUES ({values});";

            return sqlCmd;
        }
        public static string multiInsertData([FromBody] List<Dictionary<string, object>> newData, string tableName)
        {
            if (string.IsNullOrEmpty(tableName)) throw new ArgumentNullException("Table name cannot be null or empty.", nameof(tableName));
            if (newData == null || newData.Count == 0) throw new ArgumentNullException("Data cannot be null or empty.", nameof(newData));
            string sqlCmd = "";
            for (int i = 0; i < newData.Count; i++)
            {
                var item = newData[i];
                List<string> fieldNames = item.Keys.ToList();
                List<object> fieldValues = item.Values.ToList();
                string columns = string.Join(", ", fieldNames);
                // string values = string.Join(", ", materialData.Values.Select(v =>( v is string || v is DateTime)? $"'{v}'" : v.ToString()));
                string values = string.Join(", ", item.Values.Select(v => $"'{v}'"));
                sqlCmd = sqlCmd + $"INSERT INTO `{tableName}` ({columns}) VALUES ({values});";

            }
            return sqlCmd;

        }


    }

}
