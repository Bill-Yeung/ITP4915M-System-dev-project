using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{

    public class Staff : User
    {

        public string? staffID { get; set; }
        public string staffName { get; set; }
        public string? staffPassword { get; set; }
        public string? staffEmail { get; set; }
        public string? staffPhone { get; set; }
        public string? departmentID { get; set; }
        public string? position { get; set; }
        public List<string>? systemFunctionIds { get; set; }

        public override string ToString()
        {
            return staffID + " " + staffName + " " + staffPassword + " " + staffEmail + " " 
                + staffPhone + " " + departmentID + " " + position;
        }

    }

}
