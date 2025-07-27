using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class Product
    {

        public string? productID { get; set; }
        public string? parentProductID { get; set; }
        public string productName { get; set; }
        public string productType { get; set; }
        public string productCategory { get; set; }
        public string productVersion { get; set; }
        public string productStatus { get; set; }

        [NotMapped]
        private string? _displayName;
        [NotMapped]
        public string? DisplayName
        {
            get => _displayName ?? $"{productID} - {productName}";
            set => _displayName = value;
        }

    }

}
