using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class Material
    {
        public string materialID { get; set; }
        public string materialName { get; set; }
        //public int stockQuantity { get; set; }
        public string unitQuantity { get; set; }
        public int alertQuantity { get; set; }
        public string unitAlert { get; set; }
        public decimal price { get; set; }

        //还有photo未写


    }

    public class Supplier
    {
        public Boolean IsSelected { get; set; }
        public string supplierID { get; set; }
        public string supplierName { get; set; }
        public string supplierPhone { get; set; }
        public string supplierEmail { get; set; }
        public string supplierAddress { get; set; }
        public string contactPerson { get; set; }
        public string status { get; set; } = "Active"; // 默认状态为 Active
        public BindingList<Supplier> dtToList(DataTable dt) {
            var suppliers = new BindingList<Supplier>();

            if (dt == null || dt.Rows.Count == 0)
                return suppliers;

            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    suppliers.Add(new Supplier
                    {
                        IsSelected = false,
                        supplierID = row["supplierID"]?.ToString() ?? string.Empty,
                        supplierName = row["supplierName"]?.ToString() ?? string.Empty,
                        supplierPhone = row["supplierPhone"]?.ToString() ?? string.Empty,
                        supplierEmail = row["supplierEmail"]?.ToString() ?? string.Empty,
                        supplierAddress = row["supplierAddress"]?.ToString() ?? string.Empty,
                        contactPerson = row["ContactPerson"]?.ToString() ?? string.Empty
                    });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Failed to convert row: {ex.Message}");
                }
            }

            return suppliers;
        }
        public class MaterialRestock
        {
            public string restockRequestID {  get; set; }
            public string materialID { get; set; }
            public string materialName { get; set; }
            public string supplierID { get; set; }
             
            public string deliveryAddress { get; set; }
            public double restockQuantity {  get; set; }
            public double unitPrice { get; set; }
            public double totalPrice { get; set; }
            public string expectedDate { get; set; }

        }
        public class MaterialDemand
        {
            public string demandID { get; set; }
            public string materialID { get; set; }

            public string materialName { get; set; }
            public double quantity { get; set; }
            public string expectedDate { get; set; }
            public string receiver { get; set; }
        }
        public class RestockUpdate
        {
            public string restockRequestID { get; set; }
            public string materialID { get; set; }
            public string restockStatus { get; set; }
            public string updatedDate { get; set; }
            public int restockQuantity   { get; set; }
            public string expectedDate { get; set; }
            public string supplierID { get; set; }
           
        }
        public class DemandUpdate
        {
            public string demandID { get; set; }
            public string materialID { get; set; }
            public string status { get; set; }
            public string updatedAt { get; set; }
            public int quantity { get; set; }
            
        }
        public class Material2
        {
            public string materialID { get; set; }
            public string materialName { get; set; }
            public int inStockQuantity { get; set; }
            public string unit { get; set; }
            public int lowLevelAlertIndex { get; set; }
            public string stockStatus { get; set; }
            public decimal price { get; set; }
            public string createAt { get; set; }
            // 其他字段...
        }
        public class DeliveryProduct
        {
            public string requestID { get; set; }
            public string orderID {  get; set; }
            public string remarks { get; set; }
            public string priority {  get; set; }
        }
        public class ProcessDelivery
        {
            public string? deliveryOrderID { get; set; }
            public string requestID { get; set; }
            public string? courierID { get; set; }
            public string? customerName { get; set; }
            public string? companyAddress { get; set; }
            public string? customerPhone { get; set; }
            public string? trackingID { get; set; }
            //public List<DeliveryProduct> products { get; set; } = new List<DeliveryProduct>();
        }
    }

}