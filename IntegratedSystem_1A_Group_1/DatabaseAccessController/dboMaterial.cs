using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;


namespace DatabaseAccessController
{
    public class dboMaterial : dboDatabaseController
    {
        public dboMaterial(string connectionString) : base(connectionString)
        {
        }
       // public int AddMaterial(string fieldNames, string fieldValues)
       public int AddMaterial(string sqlCmd)
        {
         
           return BatchUpdate(sqlCmd);
        }
    }  
}

