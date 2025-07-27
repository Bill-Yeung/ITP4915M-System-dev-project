using Microsoft.AspNetCore.Mvc;
using EntityModels;
using DatabaseAccessController;
using Newtonsoft.Json;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public OrderController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("UpdateOrderStatus")]
        public IActionResult UpdateOrderStatus([FromBody] UpdateOrderStatus model)
        {
            var keyList = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { { "orderID", model.OrderID } }
            };

            var dataList = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object>
                {
                    { "productionStatus", model.ProductionStatus },
                    { "productionExpEndDate", model.ProductionExpEndDate },
                    { "productionEndDate", model.ProductionEndDate }
                }
            };

            // use dboDatabaseController to update the order status 
            var db = new dboDatabaseController(_configuration["ConnectionStrings"]);
            int rowsAffected = db.UpdateData("placedorder", keyList, dataList);

            return rowsAffected > 0 ? Ok("success") : NotFound("No record updated");
        }

        [HttpPost("GetProductDeshboardData")]
        public IActionResult GetProductDeshboardData([FromBody] PlaceOrderQuery query)
        {
            try
            {
                var db = new dboDatabaseController(_configuration["ConnectionStrings"]);
                var dt = db.GetProductDeshboardData(query.StartDate, query.EndDate, query.Status);
                string jsonResult = JsonConvert.SerializeObject(dt);
                return Content(jsonResult, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server Error：" + ex.Message);
            }
        }
    }
}
