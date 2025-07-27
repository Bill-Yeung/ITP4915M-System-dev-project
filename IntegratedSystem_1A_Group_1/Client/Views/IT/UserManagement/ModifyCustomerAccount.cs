using Client.Controllers;
using Client.Views.Components;
using EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views.UserManagement
{
    public partial class ModifyCustomerAccount : Form
    {
        private string customerID;
        private bool isLoadingCustomer = false;
        private readonly Dictionary<string, List<string>> systemFunctionMap = new Dictionary<string, List<string>>
        {
            { "General System", new List<string> { "SF00001", "SF00002" } },
            { "Project Management System", new List<string> { "SF00101", "SF00102", "SF00103", "SF00104" } },
            { "Product Specification System", new List<string> { "SF00105", "SF00106", "SF00107", "SF00108" } },
            { "Order Management System", new List<string> { "SF00201", "SF00202", "SF00203", "SF00204", "SF00205", "SF00206", "SF00207", "SF00208", "SF00209", "SF00210" } },
            { "Production Monitoring System", new List<string> { "SF00301", "SF00302" } },
            { "Raw Material Management System", new List<string> { "SF00401", "SF00402", "SF00403", "SF00404", "SF00405", "SF00406", "SF00407", "SF00408" } },
            { "Inventory Management System", new List<string> { "SF00501", "SF00502" } },
            { "Delivery System", new List<string> { "SF00601", "SF00602", "SF00603" } },
            { "Supplier Control System", new List<string> { "SF00701", "SF00702", "SF00703", "SF00704" } },
            { "Customer Feedback System", new List<string> { "SF00801", "SF00802", "SF00803", "SF00804" } },
            { "Product Refund System", new List<string> { "SF00901", "SF00902", "SF00903", "SF00904" } },
            { "Finance Analysis Tool", new List<string> { "SF01001", "SF01002" } },
            { "Payment Gateway", new List<string> { "SF01101" } },
            { "User Management System", new List<string> { "SF01201", "SF01202", "SF01203" } },
            { "Support Request System", new List<string> { "SF01301", "SF01302", "SF01303", "SF01304", "SF01305", "SF01306", "SF01307" } },
            { "System Learning Platform", new List<string> { "SF01401", "SF01402", "SF01403", "SF01404", "SF01405" } },
            { "Software Feedback Collection System", new List<string> { "SF01501", "SF01502", "SF01503" } }
        };

        public ModifyCustomerAccount(string customerID)
        {
            InitializeComponent();
            this.customerID = customerID;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void ModifyCustomerAccount_Load(object sender, EventArgs e)
        {
            if (Session.CurrentStaff == null || Session.CurrentStaff.departmentID != "D00007")
            {
                MessageBox.Show("Only for IT Department staff", "No Access Right", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BeginInvoke((Action)(() =>
                {
                    PanelController.openForm(Program.homeForm.panelRight, new frmWellcome());
                    this.Close();
                }));
            }

            checkedListBox_system.Items.Clear();
            checkedListBox_system.Items.AddRange(new string[] {
                "General System",
                "Order Management System",
                "Customer Feedback System",
                "Product Refund System",
                "Payment Gateway"
            });

            var json = await APIController.ApiRequest("GET", $"/UserManagement/GetCustomerById?customerID={customerID}", null);
            var customer = Newtonsoft.Json.JsonConvert.DeserializeObject<EntityModels.Customer>(json);

            tbCustomerName.Text = customer.customerName;
            tbCustomerPassword.Text = customer.customerPassword;
            tbCompanyAddress.Text = customer.companyAddress;
            tbCustomerEmail.Text = customer.customerEmail;
            tbCustomerPhone.Text = customer.customerPhone;
            tbCustomerCountry.Text = customer.country;

            if (customer.receivePromotion == true)
            {
                radioButton_Yes.Checked = true;
            }
            else
            {
                radioButton_No.Checked = true;
            }
            isLoadingCustomer = true;

            if (customer.systemFunctionIds != null)
            {
                for (int i = 0; i < checkedListBox_system.Items.Count; i++)
                {
                    string systemName = checkedListBox_system.Items[i].ToString();
                    if (systemFunctionMap.TryGetValue(systemName, out var functionIds))
                    {
                        if (functionIds.Any(fid => customer.systemFunctionIds.Contains(fid)))
                        {
                            checkedListBox_system.SetItemChecked(i, true);
                        }
                    }
                }
            }
            isLoadingCustomer = false;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            switch (true)
            {
                case true when string.IsNullOrEmpty(tbCustomerName.Text):
                    MessageBox.Show("Please input customer name!");
                    return;
                case true when string.IsNullOrEmpty(tbCustomerPassword.Text):
                    MessageBox.Show("Please input password!");
                    return;
                case true when string.IsNullOrEmpty(tbCompanyAddress.Text):
                    MessageBox.Show("Please input company address!");
                    return;
                case true when string.IsNullOrEmpty(tbCustomerEmail.Text):
                    MessageBox.Show("Please input email!");
                    return;
                case true when string.IsNullOrEmpty(tbCustomerPhone.Text):
                    MessageBox.Show("Please input phone!");
                    return;
                case true when string.IsNullOrEmpty(tbCustomerCountry.Text):
                    MessageBox.Show("Please input country!");
                    return;
                default:
                    break;
            }

            Customer customer = new Customer();
            customer.customerID = customerID;
            customer.customerName = tbCustomerName.Text;
            customer.customerPassword = APIController.HashPassword(tbCustomerPassword.Text);
            customer.companyAddress = tbCompanyAddress.Text;
            customer.customerEmail = tbCustomerEmail.Text;
            customer.customerPhone = tbCustomerPhone.Text;
            customer.country = tbCustomerCountry.Text;
            customer.receivePromotion = radioButton_Yes.Checked;

            // get the selected system name
            string[] selectedSystems = checkedListBox_system.CheckedItems
                .OfType<string>()
                .ToArray();

            // create a dictionary for mapping system name with function id
            Dictionary<string, List<string>> systemFunctionMap = new Dictionary<string, List<string>>
{
    { "General System", new List<string> { "SF00001", "SF00002" } },
    { "Project Management System", new List<string> { "SF00101", "SF00102", "SF00103", "SF00104" } },
    { "Product Specification System", new List<string> { "SF00105","SF00106","SF00107","SF00108" } },
    { "Order Management System", new List<string> { "SF00201", "SF00202", "SF00203", "SF00204", "SF00205", "SF00206", "SF00207", "SF00208", "SF00209", "SF00210" } },
    { "Production Monitoring System", new List<string> { "SF00301", "SF00302" } },
    { "Raw Material Management System", new List<string> { "SF00401", "SF00402", "SF00403", "SF00404", "SF00405", "SF00406", "SF00407", "SF00408" } },
    { "Inventory Management System", new List<string> { "SF00501", "SF00502" } },
    { "Delivery System", new List<string> { "SF00601", "SF00602", "SF00603" } },
    { "Supplier Control System", new List<string> { "SF00701", "SF00702", "SF00703", "SF00704" } },
    { "Customer Feedback System", new List<string> { "SF00801", "SF00802", "SF00803", "SF00804" } },
    { "Product Refund System", new List<string> { "SF00901", "SF00902", "SF00903", "SF00904" } },
    { "Finance Analysis Tool", new List<string> { "SF01001", "SF01002" } },
    { "Payment Gateway", new List<string> { "SF01101" } },
    { "User Management System", new List<string> { "SF01201", "SF01202", "SF01203" } },
    { "Support Request System", new List<string> { "SF01301", "SF01302", "SF01303", "SF01304", "SF01305", "SF01306", "SF01307" } },
    { "System Learning Platform", new List<string> { "SF01401", "SF01402", "SF01403", "SF01404", "SF01405" } },
    { "Software Feedback Collection System", new List<string> { "SF01501", "SF01502", "SF01503" } },
};

            // assign values to selectedFunctionIds base on selected system name and systemFunctionMap
            List<string> selectedFunctionIds = new List<string>();
            foreach (string system in selectedSystems)
            {
                if (systemFunctionMap.TryGetValue(system, out List<string> functionIds))
                {
                    selectedFunctionIds.AddRange(functionIds);
                }
            }
            customer.systemFunctionIds = selectedFunctionIds;

            var result = await APIController.ApiRequest("POST", "/UserManagement/UpdateCustomer", customer);

            if (result == "1")
            {
                MessageBox.Show("Customer account updated successfully!");
                this.Close();
                PanelController.openForm(Program.homeForm.panelRight, new ViewAllUser());
            }
            else
            {
                MessageBox.Show("Fail to update staff account.");
            }
        }
    }
}
