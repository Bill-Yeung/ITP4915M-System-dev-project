using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using EntityModels;
using DatabaseAccessController;
using Newtonsoft.Json;
using System.Data;
using System.ComponentModel;
using System.Diagnostics;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserLoginController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public UserLoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("RegisterCustomer")]
        public int RegisterCustomer([FromBody] Customer customer)
        {
            try
            {
                string username = customer.customerName;
                string password = customer.customerPassword;
                string address = customer.companyAddress;
                string email = customer.customerEmail;
                string phone = customer.customerPhone;
                string country = customer.country;

                dboUserLogin dboUserLogin = new dboUserLogin(_configuration["ConnectionStrings"]);
                int rowsUpdated = dboUserLogin.RegisterCustomer(username, password, address, email, phone, country);
                return rowsUpdated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("ValidateCustomer")]
        public string ValidateCustomer([FromBody] Customer customer)
        {
            return ValidateUser(customer).ToString().ToLowerInvariant(); ;
        }

        [HttpPost("ValidateStaff")]
        public string ValidateStaff([FromBody] Staff staff)
        {
            return ValidateUser(staff).ToString().ToLowerInvariant();;
        }

        private bool ValidateUser(User user)
        {

            DataTable dtResult;
            string username = "";
            string password = "";

            try
            {

                dboUserLogin dboUserLogin = new dboUserLogin(_configuration["ConnectionStrings"]);

                if (user is Customer)
                {
                    username = ((Customer)user).customerName;
                    password = ((Customer)user).customerPassword;
                    dtResult = dboUserLogin.GetCustomer(username);
                }
                else if (user is Staff)
                {
                    username = ((Staff)user).staffName;
                    password = ((Staff)user).staffPassword;
                    dtResult = dboUserLogin.GetStaff(username);
                }
                else
                {
                    return false;
                }

                string jsonString = JsonConvert.SerializeObject(dtResult);

                // Check if the inputs are valid

                if (jsonString == "[]")
                {
                    return false;
                }

                if (user is Customer)
                {
                    List<Customer> users = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
                    return users[0].customerName == username && users[0].customerPassword == password;
                }
                else if (user is Staff)
                {
                    List<Staff> users = JsonConvert.DeserializeObject<List<Staff>>(jsonString);
                    return users[0].staffName == username && users[0].staffPassword == password;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("GetCustomerInfo")]
        public string GetCustomerInfo([FromBody] Customer customer)
        {
            return GetUserInfo(customer);
        }

        [HttpPost("GetStaffInfo")]
        public string GetStaffInfo([FromBody] Staff staff)
        {
            return GetUserInfo(staff);
        }

        [HttpGet("GetAllStaff")]
        public string GetAllStaff()
        {

            try
            {

                dboUserLogin dboUserLogin = new dboUserLogin(_configuration["ConnectionStrings"]);
                DataTable dtResult = dboUserLogin.GetStaff("ALL");
                return JsonConvert.SerializeObject(dtResult);

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

                dboUserLogin dboUserLogin = new dboUserLogin(_configuration["ConnectionStrings"]);
                DataTable dtResult = dboUserLogin.GetCustomer("ALL");
                return JsonConvert.SerializeObject(dtResult);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetUserInfo(User user)
        {

            DataTable dtResult;
            string username = "";

            try
            {

                dboUserLogin dboUserLogin = new dboUserLogin(_configuration["ConnectionStrings"]);

                if (user is Customer)
                {
                    username = ((Customer)user).customerName;
                    dtResult = dboUserLogin.GetCustomer(username);
                }
                else if (user is Staff)
                {
                    username = ((Staff)user).staffName;
                    dtResult = dboUserLogin.GetStaff(username);
                }
                else
                {
                    throw new Exception();
                }

                return JsonConvert.SerializeObject(dtResult);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }

}
