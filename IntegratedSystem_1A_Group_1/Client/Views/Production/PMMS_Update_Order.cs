using Client.Common;
using Client.Controllers;
using EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client.Views.Production
{
    public partial class PMMS_Update_Order : Form
    {
        private UpdateOrderStatus _order;
        private void LoadSQL()
        {
            // This method can be used to load any SQL data or perform initial setup if needed.
            // Currently, it is empty but can be implemented as required.
        }

        public PMMS_Update_Order(UpdateOrderStatus order)
        {
            InitializeComponent();
            _order = order;

            OrderIDtB.ReadOnly = true;
            OrderIDtB.BackColor = Color.LightGray;
            ProductIDTb.ReadOnly = true;
            ProductIDTb.BackColor = Color.LightGray;
            ProductNameTb.ReadOnly = true;
            ProductNameTb.BackColor = Color.LightGray;
            QuantityTb.ReadOnly = true;
            QuantityTb.BackColor = Color.LightGray;
            MaterialIdTb.ReadOnly = true;
            MaterialIdTb.BackColor = Color.LightGray;
            PerdictMaterialUsageTb.ReadOnly = true;
            PerdictMaterialUsageTb.BackColor = Color.LightGray;
            //TotalCostTb.ReadOnly = true;
            //TotalCostTb.BackColor = Color.LightGray;
            StartDateDTP.Enabled = false;
            StartDateDTP.CalendarMonthBackground = Color.LightGray;
            StatusCb.Items.Add("Started");
            StatusCb.Items.Add("Finished");
            StatusCb.SelectedIndex = 0; // Set default selection

            LoadSQL();

            OrderIDtB.Text = _order.OrderID;
            ProductIDTb.Text = _order.ProductID;
            ProductNameTb.Text = _order.ProductName;
            QuantityTb.Text = _order.Quantity.ToString();
            MaterialIdTb.Text = _order.MaterialID;
            PerdictMaterialUsageTb.Text = _order.PerdictMaterialUsage.ToString();
            //TotalCostTb.Text = _order.TotalCost.ToString();

            StartDateDTP.Value = _order.ProductionStartDate;
            StatusCb.SelectedItem = _order.ProductionStatus;
            ExpectedEndDateDTP.Value = _order.ProductionExpEndDate ?? DateTime.Now;
            EndDateDTP.Value = _order.ProductionEndDate ?? DateTime.Now;
        }

        private void PMMS_Update_Order_Load(object sender, EventArgs e)
        {
        }

        private void OrderIDtB_TextChanged(object sender, EventArgs e)//Ord
        {

        }

        private void OrderIDtB_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void ProductNameLbl_Click(object sender, EventArgs e)
        {

        }

        private void StartDateDTP_ValueChanged(object sender, EventArgs e)
        {
            StartDateDTP.Enabled = false;
        }

        private void EndDateDTP_ValueChanged(object sender, EventArgs e)
        {
        }

        private void ExpectedEndDateDTP_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void StatusCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            DateTime startDate = StartDateDTP.Value;
            DateTime endDate = EndDateDTP.Value;
            DateTime expEndDate = ExpectedEndDateDTP.Value;

            var updateKey = new List<object> {
                new { orderID = OrderIDtB.Text }
            };

            var updatedOrderDict = new Dictionary<string, object>
            {
                { "productionStatus", StatusCb.SelectedItem?.ToString() },
                { "productionEndDate", endDate }
            };

            // Explicitly set to null if required
            if (expEndDate < startDate)
                updatedOrderDict["productionExpEndDate"] = null;
            else
                updatedOrderDict["productionExpEndDate"] = expEndDate;

            UpdateDataRequest updateRequest = new UpdateDataRequest
            {
                KeyList = Helper.ToDictionaryList(updateKey), // OK to use Helper here
                DataList = new List<Dictionary<string, object>> { updatedOrderDict } // Manual control
            };

            try
            {
                string response = await APIController.ApiRequest("POST", "/Common/UpdateData/PlacedOrder", updateRequest);
                if (int.TryParse(response, out int result) && result > 0)
                {
                    MessageBox.Show("Update successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update failed. Response: " + response, "Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("System error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






    }
}
