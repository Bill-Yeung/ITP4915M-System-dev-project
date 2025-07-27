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
    public class UserManagementController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public UserManagementController(IConfiguration configuration)
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

        [HttpPost("CreateStaff")]
        public int CreateStaff([FromBody] Staff staff)
        {
            try
            {
                //string staffID = staff.staffID;
                string staffName = staff.staffName;
                string staffPassword = staff.staffPassword;
                string departmentID = staff.departmentID;
                string position = staff.position;
                string staffEmail = staff.staffEmail;
                string staffPhone = staff.staffPhone;
                List<string> systemFunctionIds = staff.systemFunctionIds;

                dboUserManagement dboUserManagement = new dboUserManagement(_configuration["ConnectionStrings"]);
                int rowsUpdated = dboUserManagement.CreateStaff(staffName, staffPassword, departmentID, position, staffEmail, staffPhone, systemFunctionIds);
                return rowsUpdated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("CreateCustomer")]
        public int CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                string customerName = customer.customerName;
                string customerPassword = customer.customerPassword;
                string companyAddress = customer.companyAddress;
                string customerEmail = customer.customerEmail;
                string customerPhone = customer.customerPhone;
                string country = customer.country;
                bool receivePromotion = customer.receivePromotion ?? false;
                List<string> systemFunctionIds = customer.systemFunctionIds;

                dboUserManagement dboUserManagement = new dboUserManagement(_configuration["ConnectionStrings"]);
                int rowsUpdated = dboUserManagement.CreateCustomer(customerName, customerPassword, companyAddress, customerEmail, customerPhone, country, receivePromotion, systemFunctionIds);
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
            return ValidateUser(staff).ToString().ToLowerInvariant(); ;
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

                dboUserManagement dboUserManagement = new dboUserManagement(_configuration["ConnectionStrings"]);
                DataTable dtResult = dboUserManagement.GetAllStaff();
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

                dboUserManagement dboUserManagement = new dboUserManagement(_configuration["ConnectionStrings"]);
                DataTable dtResult = dboUserManagement.GetAllCustomer();
                return JsonConvert.SerializeObject(dtResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetStaffByID")]
        public Staff GetStaffByID(string staffID)
        {
            try
            {
                dboUserManagement dboUserManagement = new dboUserManagement(_configuration["ConnectionStrings"]);
                DataTable dt = dboUserManagement.GetStaffByID(staffID);

                if (dt.Rows.Count == 0)
                    return null;

                DataRow row = dt.Rows[0];
                Staff staff = new Staff
                {
                    staffID = row["staffID"].ToString(),
                    staffName = row["staffName"].ToString(),
                    staffPassword = row["staffPassword"].ToString(),
                    departmentID = row["departmentID"].ToString(),
                    position = row["position"].ToString(),
                    staffEmail = row["staffEmail"].ToString(),
                    staffPhone = row["staffPhone"].ToString()
                };

                DataTable dtAccess = dboUserManagement.GetStaffAccessRight(staffID);
                staff.systemFunctionIds = dtAccess.AsEnumerable()
                    .Select(r => r["systemFunctionID"].ToString())
                    .ToList();

                return staff;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetCustomerByID")]
        public Customer GetCustomerByID(string customerID)
        {
            try
            {
                dboUserManagement dboUserManagement = new dboUserManagement(_configuration["ConnectionStrings"]);
                DataTable dt = dboUserManagement.GetCustomerByID(customerID);

                if (dt.Rows.Count == 0)
                    return null;

                DataRow row = dt.Rows[0];
                Customer customer = new Customer
                {
                    customerID = row["customerID"].ToString(),
                    customerName = row["customerName"].ToString(),
                    customerPassword = row["customerPassword"].ToString(),
                    companyAddress = row["companyAddress"].ToString(),
                    customerEmail = row["customerEmail"].ToString(),
                    customerPhone = row["customerPhone"].ToString(),
                    country = row["country"].ToString(),
                    receivePromotion = row["receivePromotion"] != DBNull.Value ? Convert.ToBoolean(row["receivePromotion"]) : (bool?)null
                };

                DataTable dtAccess = dboUserManagement.GetCustomerAccessRight(customerID);
                customer.systemFunctionIds = dtAccess.AsEnumerable()
                    .Select(r => r["systemFunctionID"].ToString())
                    .ToList();

                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("UpdateStaff")]
        public int UpdateStaff([FromBody] Staff staff)
        {
            try
            {
                dboUserManagement dboUserManagement = new dboUserManagement(_configuration["ConnectionStrings"]);
                int rowsUpdated = dboUserManagement.UpdateStaff(
                    staff.staffID,
                    staff.staffName,
                    staff.staffPassword,
                    staff.departmentID,
                    staff.position,
                    staff.staffEmail,
                    staff.staffPhone,
                    staff.systemFunctionIds
                );
                return rowsUpdated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("UpdateCustomer")]
        public int UpdateCustomer([FromBody] Customer customer)
        {
            try
            {
                dboUserManagement dboUserManagement = new dboUserManagement(_configuration["ConnectionStrings"]);
                bool receivePromotion = customer.receivePromotion ?? false;
                int receivePromotionValue = 0;
                if (receivePromotion == true)
                    receivePromotionValue = 1;
                else
                    receivePromotionValue = 0;
                int rowsUpdated = dboUserManagement.UpdateCustomer(
                     customer.customerID,
                     customer.customerName,
                     customer.customerPassword,
                     customer.companyAddress,
                     customer.customerEmail,
                     customer.customerPhone,
                     customer.country,
                     receivePromotionValue,
                     customer.systemFunctionIds
                 );
                return rowsUpdated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("DeleteStaff")]
        public int DeleteStaff([FromBody] dynamic staff)
        {
            try
            {
                string staffID = staff.GetProperty("staffID").GetString();
                dboUserManagement dboUserManagement = new dboUserManagement(_configuration["ConnectionStrings"]);
                int rowsAffected = dboUserManagement.DeleteStaff(staffID);
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("DeleteCustomer")]
        public int DeleteCustomer([FromBody] dynamic customer)
        {
            try
            {
                string customerID = customer.GetProperty("customerID").GetString();
                dboUserManagement dboUserManagement = new dboUserManagement(_configuration["ConnectionStrings"]);
                int rowsAffected = dboUserManagement.DeleteCustomer(customerID);
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("HasRefundForCustomer")]
        public bool HasRefundForCustomer(string customerID)
        {
            dboUserManagement dboUserManagement = new dboUserManagement(_configuration["ConnectionStrings"]);
            return dboUserManagement.HasRefundForCustomer(customerID);
        }

        [HttpGet("HasQuotationForCustomer")]
        public bool HasQuotationForCustomer(string customerID)
        {
            dboUserManagement dboUserManagement = new dboUserManagement(_configuration["ConnectionStrings"]);
            return dboUserManagement.HasQuotationForCustomer(customerID);
        }

        [HttpGet("HasOrderForCustomer")]
        public bool HasOrderForCustomer(string customerID)
        {
            dboUserManagement dboUserManagement = new dboUserManagement(_configuration["ConnectionStrings"]);
            return dboUserManagement.HasOrderForCustomer(customerID);
        }

        [HttpGet("HasPaymentForCustomer")]
        public bool HasPaymentForCustomer(string customerID)
        {
            dboUserManagement dboUserManagement = new dboUserManagement(_configuration["ConnectionStrings"]);
            return dboUserManagement.HasPaymentForCustomer(customerID);
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
