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
    public class OrderRefundController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public OrderRefundController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetCustomerOrder")]
        public string GetCustomerOrder(string orderID)
        {
            try
            {
                dboOrderRefund dboOrderRefund = new dboOrderRefund(_configuration["ConnectionStrings"]);
                DataTable dt = dboOrderRefund.GetCustomerOrder(orderID);
                return JsonConvert.SerializeObject(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("IsRefundExists")]
        public IActionResult IsRefundExists(string orderID)
        {
            try
            {
                dboOrderRefund dboOrderRefund = new dboOrderRefund(_configuration["ConnectionStrings"]);
                bool exists = dboOrderRefund.IsRefundExists(orderID); 
                return Ok(exists ? 1 : 0); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("CreateRefundApplication")]
        public int CreateRefundApplication([FromBody] OrderRefundApplication refund)
        {
            try
            {
                dboOrderRefund dboOrderRefund = new dboOrderRefund(_configuration["ConnectionStrings"]);
                int rowsAffected = dboOrderRefund.CreateRefundApplication(
                    refund.customerID,
                    refund.orderID,
                    refund.refundDescription,
                    refund.staffAssigned,
                    refund.refundRejectReason,
                    refund.refundStatus,
                    refund.refundLastUpdate
                );
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("ViewAllRefund")]
        public string ViewAllRefund()
        {

            try
            {
                dboOrderRefund dboOrderRefund = new dboOrderRefund(_configuration["ConnectionStrings"]);
                DataTable dtResult = dboOrderRefund.ViewAllRefund();
                return JsonConvert.SerializeObject(dtResult);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("ApproveRefundByCS")]
        public int ApproveRefundByCS([FromBody] System.Text.Json.JsonElement data)
        {
            try
            {
                string refundID = data.GetProperty("refundID").GetString();
                string staffID = data.GetProperty("staffID").GetString();
                string newStatus = "Pending to Finance Department approval";
                string refundRejectReason = "NULL";
                DateTime updateDate = DateTime.Now;

                dboOrderRefund dboOrderRefund = new dboOrderRefund(_configuration["ConnectionStrings"]);
                int rowsAffected = dboOrderRefund.ApproveRefundByCS(refundID, staffID, newStatus, refundRejectReason, updateDate);
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("ApproveRefundByFinance")]
        public int ApproveRefundByFinance([FromBody] System.Text.Json.JsonElement data)
        {
            try
            {
                string refundID = data.GetProperty("refundID").GetString();
                string staffID = data.GetProperty("staffID").GetString();
                string newStatus = "Refunded";
                string refundRejectReason = "NULL";
                DateTime updateDate = DateTime.Now;

                dboOrderRefund dboOrderRefund = new dboOrderRefund(_configuration["ConnectionStrings"]);
                int rowsAffected = dboOrderRefund.ApproveRefundByFinance(refundID, staffID, newStatus, refundRejectReason, updateDate);
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost("RejectRefundByCS")]
        public int RejectRefundByCS([FromBody] System.Text.Json.JsonElement data)
        {
            try
            {
                dboOrderRefund dboOrderRefund = new dboOrderRefund(_configuration["ConnectionStrings"]);
                string refundID = data.GetProperty("refundID").GetString();
                string staffID = data.GetProperty("staffID").GetString();
                string rejectReason = data.GetProperty("rejectReason").GetString();

                int rowsAffected = dboOrderRefund.RejectRefund(refundID, staffID, rejectReason, DateTime.Now);
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
