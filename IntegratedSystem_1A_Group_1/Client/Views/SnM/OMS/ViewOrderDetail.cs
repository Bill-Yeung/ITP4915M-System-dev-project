using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Controllers;
using EntityModels;
using Newtonsoft.Json;

namespace Client.Views.SnM.OrderManagement
{
    public partial class ViewOrderDetail : Form
    {
        private string orderID;
        private string customerID;

        public ViewOrderDetail()
        {
            InitializeComponent();
        }


        public ViewOrderDetail(string orderID, string customerID)
        {
            InitializeComponent();
            this.orderID = orderID;
            this.customerID = customerID;
        }


        private async void ViewOrderDetail_Load(object sender, EventArgs e)
        {
            if (Session.CurrentStaff == null || Session.CurrentStaff.departmentID != "D00002")
            {

                MessageBox.Show("Only for Sales & Marketing Department staff", "No Access Right", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            textBox_orderID.Text = orderID;

            try
            {
                string jsonResponse = await APIController.ApiRequest("GET", $"/OrderManagement/ViewCustomerInformation?customerID={customerID}", null);
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonResponse);
                dataGridView_customerInfo.DataSource = dt;
                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer data: {ex.Message}");
            }

            try
            {
                string jsonResponse = await APIController.ApiRequest("GET", $"/OrderManagement/ViewOrderDetail?orderID={orderID}", null);
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonResponse);
                dataGridView_orderDetail.DataSource = dt;
                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order data: {ex.Message}");
            }

            try
            {
                string jsonResponse = await APIController.ApiRequest("GET", $"/OrderManagement/GetOrderPaidAmount?orderID={orderID}", null);
                double paidAmount = JsonConvert.DeserializeObject<double>(jsonResponse);
                textBox_totalAmount.Text = paidAmount.ToString("F2");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order total amount: {ex.Message}");
            }
        }

        private void button_back_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
