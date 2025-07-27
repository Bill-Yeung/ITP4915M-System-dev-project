using Client.Controllers;
using Client.Views.Components;
using Client.Views.Login;
using EntityModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views.CS.Refund
{
    public partial class OrderRefundApplicationForm : Form
    {
        private string customerID = Session.CurrentCustomer.customerID;
        private string orderID;
        //private string orderID = "O00001"; //this line to be modified later, when customer click refund button in "my order" page, the orderID will be passed to this form.

        public OrderRefundApplicationForm(string orderID)
        {
            InitializeComponent();
            this.orderID = orderID;
        }

        private async void OrderRefundApplicationForm_Load(object sender, EventArgs e)
        {
            if (Session.CurrentCustomer == null)
            {
                MessageBox.Show("Please login first", "No Access Right", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BeginInvoke((Action)(() =>
                {
                    PanelController.openForm(Program.mainForm.panelContent, new frmLogin());
                    this.Close();
                }));
            }

            textBox_orderID.Text = orderID;

            try
            {
                string jsonResponse = await APIController.ApiRequest("GET", $"/OrderRefund/GetCustomerOrder?orderID={orderID}", null);


                DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                dataGridView_orderDetail.DataSource = dt;

                dt.AcceptChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}");
            }

            comboBox_refundReason.Items.Clear();
            comboBox_refundReason.Items.AddRange(new string[] {
                "Damage/Defective Product",
                "Out of stock",
                "Wrong product specification",
                "Other",
            });
            comboBox_refundReason.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_refundDescription.Text))
            {
                MessageBox.Show("Please input description");
                return;
            }

            OrderRefundApplication refund = new OrderRefundApplication
            {
                customerID = Session.CurrentCustomer.customerID,
                orderID = textBox_orderID.Text,
                refundDescription = textBox_refundDescription.Text,
                staffAssigned = null,
                refundRejectReason = null,
                refundStatus = "Pending to CS department review",
                refundLastUpdate = DateTime.Now
            };

            string result = await APIController.ApiRequest("POST", "/OrderRefund/CreateRefundApplication", refund);

            if (result == "1")
            {
                MessageBox.Show("Order refund application is submitted, we will process it soon");
            }
            else
            {
                MessageBox.Show("Failed to submit order refund application, please contact our staff via email/phone");
            }
        }
    }
}
