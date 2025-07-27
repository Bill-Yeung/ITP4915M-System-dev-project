using Client.Controllers;
using Client.Views.Components;
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
    public partial class ViewOrderDetail : Form
    {
        private string orderID;
        private string customerID;


        public ViewOrderDetail(string orderID)
        {
            InitializeComponent();
            this.orderID = orderID;
        }


        private async void ViewOrderDetail_Load(object sender, EventArgs e)
        {
            if (Session.CurrentCustomer == null)
            {

                MessageBox.Show("Please login first.", "No Access Right", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BeginInvoke((Action)(() =>
                {
                    PanelController.openForm(Program.homeForm.panelRight, new frmWellcome());
                    this.Close();
                }));
            }
            textBox_orderID.Text = orderID;
            this.customerID = Session.CurrentCustomer.customerID;

            try
            {
                string jsonResponse = await APIController.ApiRequest("GET", $"/CustomerInterface/ViewCustomerInformation?customerID={customerID}", null);


                DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                dataGridView_customerInfo.DataSource = dt;

                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}");
            }

            try
            {
                string jsonResponse = await APIController.ApiRequest("GET", $"/CustomerInterface/ViewOrderDetail?orderID={orderID}", null);


                DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                dataGridView_orderDetail.DataSource = dt;

                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}");
            }

            try
            {
                string jsonResponse = await APIController.ApiRequest("GET", $"/CustomerInterface/GetOrderPaidAmount?orderID={orderID}", null);
                double paidAmount = JsonConvert.DeserializeObject<double>(jsonResponse);
                textBox_totalAmount.Text = paidAmount.ToString("F2");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order total amount: {ex.Message}");
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
