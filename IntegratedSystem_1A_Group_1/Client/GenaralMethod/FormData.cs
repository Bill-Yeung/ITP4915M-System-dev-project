using Client.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Client.GenaralMethod;
using System.Threading.Tasks;

namespace Client.GenaralMethod
{
    public class FormData
    {
        public static Dictionary<string, object> ToDictionary(Object inputData,List<string>? excludeFields)
        {
            if (inputData == null) throw new ArgumentNullException(nameof(inputData), "Input data cannot be null.");
            var dictionary = new Dictionary<string, object>();
            var properties = inputData.GetType().GetProperties();
            foreach (var prop in properties)
            {
                if (excludeFields != null && excludeFields.Contains(prop.Name))
                    continue;
                var value = prop.GetValue(inputData);
                if (value != null && !string.IsNullOrWhiteSpace(value.ToString())) // Only add non-empty values
                {
                    dictionary.Add(prop.Name, value);
                }
            }
            return dictionary;
        }
        public static List<string> getNameList(DataTable dt,string tableName)
        {
            List<string> items = new List<string>();

            string str1=$"{tableName}"+ "ID";
            string str2= $"{tableName}" + "Name";
         
                foreach (DataRow row in dt.Rows)
                {
                    string ID = row[str1].ToString();
                    string Name = row[str2].ToString();
                    string nameList = ID + "_" + Name;
                    items.Add(nameList);
                }
                //cmbSupplier.DisplayMember = "Text";
                //cmbSupplier.ValueMember = "Value";
                return items;
        }
        public static string GenerateID(string prefix,DataTable dt,string generatedField)
        {
          
            string maxid = dt.Rows.Count > 0 ? dt.Rows[0][generatedField].ToString().Substring(prefix.Length) : "0";
            int num = int.Parse(maxid);
            string newNumber = prefix+(num + 1).ToString("D" + (dt.Rows[0][generatedField].ToString().Length-prefix.Length));//减去ID开头字母的长度，注意表中有的2个字母开头
            return newNumber;
        }
        public static string FormatSqlValue(object value)
        {
            if (value == null) return "NULL";
            return value switch
            {
                string s => $"'{s.Replace("'", "''")}'",
                DateTime dt => $"'{dt:yyyy-MM-dd}'",
                bool b => b ? "1" : "0",_ => value.ToString()
            };
        }
     
    }
}
