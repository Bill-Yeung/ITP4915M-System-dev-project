using Client.Controllers;
using Client.Views.Components;
using EntityModels;
using Newtonsoft.Json;
using ScottPlot.MultiplotLayouts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views.UserManagement
{
    public partial class ViewAllUser : Form
    {
        public ViewAllUser()
        {
            InitializeComponent();
        }

        private async void ViewAllUser_Load(object sender, EventArgs e)
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

        }

        private async void rbtnCustomer_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string jsonResponse = await APIController.ApiRequest("GET", "/UserManagement/GetAllCustomer", null);
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                if (dt.Columns.Contains("Receive Promotion") && !dt.Columns.Contains("Receive Promotion?"))
                {
                    dt.Columns.Add("Receive Promotion?", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["Receive Promotion"] != DBNull.Value && row["Receive Promotion"].ToString() == "1")
                        {
                            row["Receive Promotion?"] = "Yes";
                        }
                        else
                        {
                            row["Receive Promotion?"] = "No";
                        }
                    }
                }

                dgvAllUserTable.DataSource = dt;

                if (dgvAllUserTable.Columns.Contains("Receive Promotion"))
                {
                    dgvAllUserTable.Columns["Receive Promotion"].Visible = false;
                }
                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}");
            }
        }

        private async void rbtnStaff_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string jsonResponse = await APIController.ApiRequest("GET", "/UserManagement/GetAllStaff", null);
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonResponse);
                dgvAllUserTable.DataSource = dt;
                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}");
            }
        }

        private void btnCreateStaff_Click(object sender, EventArgs e)
        {
            CreateStaffAccount createStaffAccount = new CreateStaffAccount();
            createStaffAccount.ShowDialog();

        }

        private void btnCreateCustomer_Click(object sender, EventArgs e)
        {
            CreateCustomerAccount createCustomerAccount = new CreateCustomerAccount();
            createCustomerAccount.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAllUserTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user.");
                return;
            }

            if (rbtnStaff.Checked)
            {
                string staffID = dgvAllUserTable.SelectedRows[0].Cells["Staff ID"].Value.ToString();
                ModifyStaffAccount modifyStaff = new ModifyStaffAccount(staffID);
                modifyStaff.ShowDialog();
            }

            if (rbtnCustomer.Checked)
            {
                string customerID = dgvAllUserTable.SelectedRows[0].Cells["Customer ID"].Value.ToString();
                ModifyCustomerAccount modifyCustomer = new ModifyCustomerAccount(customerID);
                modifyCustomer.ShowDialog();
            }

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAllUserTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this user account?", "Delete user", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            if (rbtnStaff.Checked)
            {
                string staffID = dgvAllUserTable.SelectedRows[0].Cells["Staff ID"].Value.ToString();
                var result = await APIController.ApiRequest("POST", "/UserManagement/DeleteStaff", new { staffID });
                if (result == "1")
                {
                    MessageBox.Show("Staff account deleted successfully.");
                    rbtnStaff_CheckedChanged(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to delete this staff account.");
                }
            }
            else if (rbtnCustomer.Checked)
            {
                string customerID = dgvAllUserTable.SelectedRows[0].Cells["Customer ID"].Value.ToString();
                string hasRefundResponse = await APIController.ApiRequest("GET", $"UserManagement/HasRefundForCustomer?customerID={customerID}", null);
                bool hasRefund = bool.TryParse(hasRefundResponse, out bool yesOrNoR) && yesOrNoR;

                string hasQuotationResponse = await APIController.ApiRequest("GET", $"UserManagement/HasQuotationForCustomer?customerID={customerID}", null);
                bool hasQuotation = bool.TryParse(hasQuotationResponse, out bool yesOrNoQ) && yesOrNoQ;

                string hasOrderResponse = await APIController.ApiRequest("GET", $"UserManagement/HasOrderForCustomer?customerID={customerID}", null);
                bool hasOrder = bool.TryParse(hasOrderResponse, out bool yesOrNoO) && yesOrNoO;

                string hasPaymentResponse = await APIController.ApiRequest("GET", $"UserManagement/HasPaymentForCustomer?customerID={customerID}", null);
                bool hasPayment = bool.TryParse(hasPaymentResponse, out bool yesOrNoP) && yesOrNoP;

                if (hasRefund)
                {
                    MessageBox.Show("Cannot delete customer accounts with refund record！");
                }
                else if (hasQuotation)
                {
                    MessageBox.Show("Cannot delete customer accounts with quotation record！");
                }
                else if (hasPayment)
                {
                    MessageBox.Show("Cannot delete customer accounts with payment record！");
                }
                else if (hasOrder)
                {
                    MessageBox.Show("Cannot delete customer accounts with order record！");
                }
                else
                {
                    var result = await APIController.ApiRequest("POST", "/UserManagement/DeleteCustomer", new { customerID });
                    if (result == "1")
                    {
                        MessageBox.Show("Customer account deleted successfully.");
                        rbtnCustomer_CheckedChanged(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete this customer account.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select Staff or Customer type.");
            }

        }


    }
}