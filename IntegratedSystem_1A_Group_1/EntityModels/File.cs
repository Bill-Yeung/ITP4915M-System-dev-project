using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class File
    {

        public string fileID { get; set; }
        public string? fileName { get; set; }
        public string? filePath { get; set; }
        public string? fileType { get; set; }
        public DateTime? recordDate { get; set; }
        public string? recordPerson { get; set; }

    }

}
