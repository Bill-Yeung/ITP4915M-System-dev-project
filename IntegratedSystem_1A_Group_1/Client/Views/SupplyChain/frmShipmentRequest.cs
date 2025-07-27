using Client.Controllers;
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
using Client.GenaralMethod;
using static EntityModels.Supplier;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Client.Views.SupplyChain
{
    public partial class frmShipmentRequest : Form
    {
        private ComboBox cmbDepartment;
        private ComboBox cmbOrderID;
        private ComboBox cmbCustomerID;
        private TextBox txtRequester;
        private DateTimePicker dtpRequestDate;
        private ComboBox cmbUrgency;
        private DataGridView dgvItems;
        private Button btnAddItem;
        private Button btnSubmit;
        private Button btnBack;
        private Button btnShowAll;
        private TextBox txtNotes;
        DatabaseApicaller apicaller = new DatabaseApicaller();
        public frmShipmentRequest()
        {
            InitializeComponent();
            InitializeForm();
            this.Load += async (sender, e) =>
            {
                await frmShipmentRequest_Load();
            };
        }
        private async Task frmShipmentRequest_Load()
        {
            DataTable dtOrder = await apicaller.GetAPIResponse($"/Supply/GetData?tableName=placedorder&columns=*&null");
            DataTable dtPendingOrder = await apicaller.GetAPIResponse($"/Supply/GetPendingOrder");
            DataTable allID = await apicaller.GetAPIResponse($"/Supply/GetMaxID?tableName=deliveryRequest&fieldName=requestID");
            lblDeliveryOrderID.Text = FormData.GenerateID("DR", allID, "requestID");
            if(dtPendingOrder == null || dtPendingOrder.Rows.Count==0 ) { MessageBox.Show("No order need to delivery."); return; }
            //if (dtPendingOrder != null && dtPendingOrder.Rows.Count > 0)
            //{
                cmbOrderID.DataSource = dtPendingOrder;
                cmbOrderID.DisplayMember = "order ID"; // 指定显示的列名
                cmbOrderID.ValueMember = "orderID"; // 可选：设置值成员
            //}
            cmbOrderID.SelectedIndexChanged += async (sender, e) =>
            {
                await LoadOrderProducts();
            };
            if (cmbOrderID.Items.Count > 0)
            {
                cmbOrderID.SelectedIndex = 0;
            }


        }
        private async Task LoadOrderProducts()
        {
            dgvItems.DataSource = null;
            if (cmbOrderID.SelectedIndex == -1) return;

            string orderID = cmbOrderID.SelectedValue?.ToString();
            if (!string.IsNullOrEmpty(orderID))
            {
                try
                {
                    DataTable pendingOrder = await apicaller.GetAPIResponse(
                        $"/Supply/GetData?tableName=orderproduct&columns=*&cond=WHERE orderID='{orderID}'");

                    dgvItems.DataSource = pendingOrder;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Load order product faild: {ex.Message}");
                }
            }
        }
        private async void submitDelivery()
        {
            if (cmbOrderID.SelectedIndex == -1) { MessageBox.Show("Please choice a order for delivery."); return; }
           
            
            DeliveryProduct delivery = new DeliveryProduct
            {
                requestID = lblDeliveryOrderID.Text.ToString(),
                orderID = cmbOrderID.Text.ToString(),
                priority = cmbUrgency.Text.ToString(),
                remarks = !string.IsNullOrEmpty(txtNotes.Text) ? txtNotes.Text : ""

            };
            string result="";
           
            result = await apicaller.PostAPIResponse("/Supply/AddDeliveryRequest", delivery);
            if (result != "0")
            {
                MessageBox.Show("Add Product Delivery Request successfully.");

                await frmShipmentRequest_Load();
            }
            else
            {
                MessageBox.Show("Add Product Delivery Request Failed.");

            }

        }
    }
}

