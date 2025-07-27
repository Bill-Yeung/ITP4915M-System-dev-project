using Client.Common;
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

namespace Client.Views.SnM.OrderManagement
{
    public partial class ViewAllOrder : Form
    {
        public ViewAllOrder()
        {
            InitializeComponent();
        }

        private async void ViewAllOrder_Load(object sender, EventArgs e)
        {
            if (Session.CurrentStaff == null || Session.CurrentStaff.departmentID != "D00002")
            {

                MessageBox.Show("Only for Sales & Marketing Department staff", "No Access Right", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BeginInvoke((Action)(() =>
                {
                    PanelController.openForm(Program.homeForm.panelRight, new frmWellcome());
                    this.Close();
                }));
            }

            try
            {
                string jsonResponse = await APIController.ApiRequest("GET", $"/OrderManagement/ViewAllOrder", null);


                DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                dataGridView_allOrder.DataSource = dt;

                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}");
            }
        }

        private void button_ViewOrderDetail_Click(object sender, EventArgs e)
        {
            if (dataGridView_allOrder.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order.");
                return;
            }

            string orderID = dataGridView_allOrder.SelectedRows[0].Cells["Order ID"].Value.ToString();
            string customerID = dataGridView_allOrder.SelectedRows[0].Cells["Customer ID"].Value.ToString();

            ViewOrderDetail vieworderdetail = new ViewOrderDetail(orderID, customerID);
            vieworderdetail.ShowDialog();
        }

        private async void button_sendToFinance_Click(object sender, EventArgs e)
        {
            if (dataGridView_allOrder.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order.");
                return;
            }

            string orderID = dataGridView_allOrder.SelectedRows[0].Cells["Order ID"].Value.ToString();
            string orderStatus = dataGridView_allOrder.SelectedRows[0].Cells["Order Status"].Value.ToString();

            if (orderStatus != "Created")
            {
                MessageBox.Show("This order is already sent to Finanace Department!");
                return;
            }
            try
            {
                var result = await APIController.ApiRequest("POST", "/OrderManagement/UpdateOrderStatus", new { orderID });

                if (result == "1")
                {
                    MessageBox.Show("Order sent to Finance Department successfully!");
                    ViewAllOrder_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Fail to sent this order to Finance Department.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order data: {ex.Message}");
            }
        }

        private async void button_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView_allOrder.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this order?", "Delete Order", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            string orderID = dataGridView_allOrder.SelectedRows[0].Cells["Order ID"].Value.ToString();
            string orderStatus = dataGridView_allOrder.SelectedRows[0].Cells["Order Status"].Value.ToString();
            if (orderStatus != "Created")
            {
                MessageBox.Show("Cannot delete order when it is being handled by other departments.");
                return;
            }

            var result = await APIController.ApiRequest("POST", "/OrderManagement/DeleteOrder", new { orderID });

            if (result != "0")
            {
                MessageBox.Show("Order deleted successfully.");
                ViewAllOrder_Load(null, null);
            }
            else
            {
                MessageBox.Show("Failed to delete this order.");
            }
        }

        private async void button_generateInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridView_allOrder.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order.");
                return;
            }

            if (dataGridView_allOrder.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView_allOrder.SelectedRows[0];
                string orderID = selectedRow.Cells["Order ID"].Value.ToString();

                var save = new SaveFileDialog
                {
                    Filter = "PDF file|*.pdf",
                    FileName = $"invoice-{orderID}.pdf"
                };

                if (save.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                var invoiceForm = new frmGenerateInvoice(orderID);
                invoiceForm.CreateControl();
                foreach (Control c in invoiceForm.Controls)
                {
                    c.CreateControl();
                }
                invoiceForm.StartPosition = FormStartPosition.Manual;
                invoiceForm.Location = new Point(-2000, -2000);
                invoiceForm.Show();
                await invoiceForm.LoadCompleted;

                invoiceForm.Refresh();
                Application.DoEvents();

                Helper.SaveControlAsPdf(invoiceForm.panel, save.FileName);

                invoiceForm.Close();
                invoiceForm.Dispose();

                MessageBox.Show("PDF generated at:\n" + save.FileName);

            }

    }
    }
}

