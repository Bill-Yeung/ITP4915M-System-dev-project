using Client.Controllers;
using Client.Views.Components;
using Client.Views.CS.Refund;
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

namespace Client.Views.CustomerInterface
{
    public partial class ViewCustomerOrder : Form
    {
        private string customerID;

        public ViewCustomerOrder()
        {
            InitializeComponent();
        }

        private async void ViewCustomerOrder_Load(object sender, EventArgs e)
        {
            if (Session.CurrentCustomer == null) // || Session.CurrentStaff.departmentID != "D00002"<<<<<for S&M Department
            {

                MessageBox.Show("Please login first.", "No Access Right", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BeginInvoke((Action)(() =>
                {
                    PanelController.openForm(Program.mainForm.panelContent, new frmLogin());
                    this.Close();
                }));
            }

            this.customerID = Session.CurrentCustomer.customerID;


            try
            {
                string jsonResponse = await APIController.ApiRequest("GET", $"/CustomerInterface/ViewMyOrder?customerID={customerID}", null);


                DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                dataGridView_myOrder.DataSource = dt;

                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}");
            }
        }

        private async void button_Refund_Click(object sender, EventArgs e)
        {
            if (dataGridView_myOrder.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order.");
                return;
            }

            string orderStatus = dataGridView_myOrder.SelectedRows[0].Cells["Order Status"].Value.ToString();
            if (orderStatus != "Completed")
            {
                MessageBox.Show("Refund can only be applied to orders that are 'Completed'.");
                return;
            }

            string orderID = dataGridView_myOrder.SelectedRows[0].Cells["Order ID"].Value.ToString();
            try
            {
                string result = await APIController.ApiRequest("GET", $"/OrderRefund/IsRefundExists?orderID={orderID}", null);
                bool refundExists = result == "1"; 

                if (refundExists)
                {
                    MessageBox.Show("Refund application is already made for this order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking refund status: {ex.Message}");
                return;
            }
            OrderRefundApplicationForm refund = new OrderRefundApplicationForm(orderID);
            refund.ShowDialog();
        }

        private void button_ViewOrderDetail_Click(object sender, EventArgs e)
        {
            if (dataGridView_myOrder.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order.");
                return;
            }

            string orderID = dataGridView_myOrder.SelectedRows[0].Cells["Order ID"].Value.ToString();
            ViewOrderDetail myorderdetail = new ViewOrderDetail(orderID);
            myorderdetail.ShowDialog();
        }

        private async void button_cancelOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView_myOrder.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order.");
                return;
            }

            string orderStatus = dataGridView_myOrder.SelectedRows[0].Cells["Order Status"].Value.ToString();

            if (orderStatus == "Created" || orderStatus == "SentToFinance")
            {
                var confirmResult = MessageBox.Show("Are you sure to cancel this order?", "Cancel order", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }
                string orderID = dataGridView_myOrder.SelectedRows[0].Cells["Order ID"].Value.ToString();
                try
                {
                    var result = await APIController.ApiRequest("POST", "/CustomerInterface/CancelOrder", orderID);
                    if (result == "1")
                    {
                        MessageBox.Show("Order cancelled successfully.");
                        ViewCustomerOrder_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Failed to cancel this order.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading order data: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Sorry, you can only cancel the order before making the deposit.");
                return;
            }


        }
    }
}
