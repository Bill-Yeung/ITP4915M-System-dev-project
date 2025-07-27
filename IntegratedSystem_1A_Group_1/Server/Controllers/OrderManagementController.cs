using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using EntityModels;
using DatabaseAccessController;
using Newtonsoft.Json;
using System.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderManagementController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public OrderManagementController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("ViewAllOrder")]
        public string ViewAllOrder()
        {
            try
            {
                dboOrderManagementController dboOrderManagementController = new dboOrderManagementController(_configuration["ConnectionStrings"]);
                DataTable dt = dboOrderManagementController.ViewAllOrder();
                return JsonConvert.SerializeObject(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetAllCustomer")]
        public string GetAllCustomer()
        {
            try
            {
                dboOrderManagementController dboOrderManagementController = new dboOrderManagementController(_configuration["ConnectionStrings"]);
                DataTable dt = dboOrderManagementController.GetAllCustomer();
                return JsonConvert.SerializeObject(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetAllProduct")]
        public string GetAllProduct()
        {
            try
            {
                dboOrderManagementController dboOrderManagementController = new dboOrderManagementController(_configuration["ConnectionStrings"]);
                DataTable dt = dboOrderManagementController.GetAllProduct();
                return JsonConvert.SerializeObject(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("ViewCustomerInformation")]
        public string ViewCustomerInformation(string customerID)
        {
            try
            {
                dboOrderManagementController dboOrderManagementController = new dboOrderManagementController(_configuration["ConnectionStrings"]);
                DataTable dt = dboOrderManagementController.ViewCustomerInformation(customerID);
                return JsonConvert.SerializeObject(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("ViewOrderDetail")]
        public string ViewOrderDetail(string orderID)
        {
            try
            {
                dboOrderManagementController dboOrderManagementController = new dboOrderManagementController(_configuration["ConnectionStrings"]);
                DataTable dt = dboOrderManagementController.ViewOrderDetail(orderID);
                return JsonConvert.SerializeObject(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetOrderPaidAmount")]
        public double GetOrderPaidAmount(string orderID)
        {
            dboOrderManagementController dboOrderManagementController = new dboOrderManagementController(_configuration["ConnectionStrings"]);
            return dboOrderManagementController.GetOrderPaidAmount(orderID);
        }

        [HttpPost("UpdateOrderStatus")]
        public int UpdateOrderStatus([FromBody] System.Text.Json.JsonElement data)
        {
            try
            {
                string orderID = data.GetProperty("orderID").GetString();
                dboOrderManagementController dboOrderManagementController = new dboOrderManagementController(_configuration["ConnectionStrings"]);
                int rowsUpdated = dboOrderManagementController.UpdateOrderStatus(orderID);
                return rowsUpdated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("DeleteOrder")]
        public int DeleteOrder([FromBody] System.Text.Json.JsonElement data)
        {
            try
            {
                string orderID = data.GetProperty("orderID").GetString();
                dboOrderManagementController dboOrderManagementController = new dboOrderManagementController(_configuration["ConnectionStrings"]);
                int rowsUpdated = dboOrderManagementController.DeleteOrder(orderID);
                return rowsUpdated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("CreateQuotation")]

        public IActionResult CreateQuotation([FromBody] CreateQuotationRequest request)
        {
            // request.Quotation and request.QuotationProducts will be automatically deserialized from the JSON body
            dboOrderManagementController dboOrderManagementController = new dboOrderManagementController(_configuration["ConnectionStrings"]);
            int result = dboOrderManagementController.CreateQuotation(request.Quotation, request.QuotationProducts);
            return Ok(result);
        }

        public class CreateQuotationRequest
        {
            public Quotation Quotation { get; set; }
            public List<QuotationProduct> QuotationProducts { get; set; }
        }

        [HttpGet("GetQuotationDetail")]
        public IActionResult GetQuotationDetail(string quotationID)
        {
            dboOrderManagementController dboOrderManagementController = new dboOrderManagementController(_configuration["ConnectionStrings"]);
            var quotation = dboOrderManagementController.GetQuotationById(quotationID);
            var products = dboOrderManagementController.GetQuotationProductsById(quotationID);
            return Ok(new { Quotation = quotation, QuotationProducts = products });
        }

        [HttpPost("UpdateQuotation")]

        public IActionResult UpdateQuotation([FromBody] UpdateQuotationRequest request)
        {
            // request.Quotation and request.QuotationProducts will be automatically deserialized from the JSON body
            dboOrderManagementController dboOrderManagementController = new dboOrderManagementController(_configuration["ConnectionStrings"]);
            int result = dboOrderManagementController.UpdateQuotation(request.Quotation, request.QuotationProducts);
            return Ok(result);
        }

        public class UpdateQuotationRequest
        {
            public Quotation Quotation { get; set; }
            public List<QuotationProduct> QuotationProducts { get; set; }
        }
    }

}
