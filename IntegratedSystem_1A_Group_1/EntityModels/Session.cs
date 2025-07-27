using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public static class Session
    {
        public static Staff? CurrentStaff { get; set; }
        public static Customer? CurrentCustomer { get; set; }

    }
}
