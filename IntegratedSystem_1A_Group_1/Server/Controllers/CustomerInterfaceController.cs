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
    public class CustomerInterfaceController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public CustomerInterfaceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("ViewMyOrder")]
        public string ViewMyOrder(string customerID)
        {
            try
            {
                dboCustomerInterface dboCustomerInterface = new dboCustomerInterface(_configuration["ConnectionStrings"]);
                DataTable dt = dboCustomerInterface.ViewMyOrder(customerID);
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
                dboCustomerInterface dboCustomerInterface = new dboCustomerInterface(_configuration["ConnectionStrings"]);
                DataTable dt = dboCustomerInterface.ViewCustomerInformation(customerID);
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
                dboCustomerInterface dboCustomerInterface = new dboCustomerInterface(_configuration["ConnectionStrings"]);
                DataTable dt = dboCustomerInterface.ViewOrderDetail(orderID);
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
            dboCustomerInterface dbo = new dboCustomerInterface(_configuration["ConnectionStrings"]);
            return dbo.GetOrderPaidAmount(orderID);
        }

        [HttpPost("CancelOrder")]
        public int CancelOrder([FromBody] string orderID)
        {
            try
            {
                dboCustomerInterface dboCustomerInterface = new dboCustomerInterface(_configuration["ConnectionStrings"]);
                int rowsAffected = dboCustomerInterface.CancelOrder(orderID);
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
