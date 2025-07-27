using Client.Controllers;
using Client.GenaralMethod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views.SupplyChain
{
    public partial class frmAddSupplier : Form
    {
        DatabaseApicaller apiCaller = new DatabaseApicaller();
        public frmAddSupplier()
        {
            InitializeComponent();
        }

        private async void frmAddSupplier_Load(object sender, EventArgs e)
        {
            DataTable allID = await apiCaller.GetAPIResponse($"/Supply/GetMaxID?tableName=supplier&fieldName=supplierID");
            txtSupplierID.Text = FormData.GenerateID("S", allID, "supplierID");
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var addSupplierData = new
            {
                supplierID = txtSupplierID.Text,
                supplierName = txtSupplierName.Text,
                supplierPhone = txtPhoneNumber.Text,
                supplierEmail = txtEmail.Text,
                supplierAddress = txtAddress.Text,
                contactPerson = txtContactPerson.Text,

            };
            string addSupplier = "";
            //addMaterialData = InputValidation(addMaterialData); // Validate the input data
            var userInput = FormData.ToDictionary(addSupplierData, null);
            if (userInput == null || userInput.Count == 0) { MessageBox.Show("Data cannot be null or empty."); }
            else addSupplier = await apiCaller.PostAPIResponse("/Supply/AddSupplier", userInput);
            if (addSupplier == "1")
            {
                MessageBox.Show("Add Material successfully.");

            }
            else
            {
                MessageBox.Show("Add Material failed.");

            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }
    }
}
