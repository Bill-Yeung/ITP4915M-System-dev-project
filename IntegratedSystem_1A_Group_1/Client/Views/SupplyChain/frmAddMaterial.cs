using Client.Controllers;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Client.Views.SupplyChain
{
    public partial class frmAddMaterial : Form
    {
        DatabaseApicaller apiCaller = new DatabaseApicaller();
        public frmAddMaterial()
        {
            InitializeComponent();
        }
        private async void frmAddMaterial_Load(object sender, EventArgs e)
        {
            DataTable allID = await apiCaller.GetAPIResponse($"/Supply/GetMaxID?tableName=rawmaterial&fieldName=materialID");
            txtMID.Text = FormData.GenerateID("M", allID, "materialID");
            txtMID.Enabled = false;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btnAddMaterial_Click(object sender, EventArgs e)
        {

        }

        private async void btnAddMaterial_Click_1(object sender, EventArgs e)
        {
            var addMaterialData = new
            {
                materialID = txtMID.Text,
                materialName = txtMName.Text,
                //inStockQuantity = txtQuantity.Text,
                lowLevelAlertIndex = txtAlert.Text,
                price = txtPrice.Text,
                unit = txtAlertUnit.Text,


            };
            string addMaterial = "";
            //addMaterialData = InputValidation(addMaterialData); // todo: Validate the input data
            var userInput = FormData.ToDictionary(addMaterialData, null);
            if (userInput == null || userInput.Count == 0) { MessageBox.Show("Data cannot be null or empty."); }
            else addMaterial = await apiCaller.PostAPIResponse("/Supply/AddMaterial", userInput);
            if (addMaterial != "0")
            {
                MessageBox.Show("Add Material successfully.");

            }
            else
            {
                MessageBox.Show("Add Material failed.");

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtAlertUnit_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
