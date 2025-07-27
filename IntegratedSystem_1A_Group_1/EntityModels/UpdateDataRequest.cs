using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class UpdateDataRequest
    {

        public List<Dictionary<string, object>> KeyList { get; set; }
        public List<Dictionary<string, object>> DataList { get; set; }

    }

}
