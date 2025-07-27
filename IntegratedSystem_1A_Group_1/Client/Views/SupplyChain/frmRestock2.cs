using Client.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Client.GenaralMethod;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EntityModels.Supplier;


namespace Client.Views.SupplyChain
{
    public partial class frmRestock2 : Form
    {
        private DataTable suppliersData = new DataTable();
        private DataTable materialsData = new DataTable();
        private DataTable requestItemsData = new DataTable();
        DatabaseApicaller apiCaller = new DatabaseApicaller();
        // UI Controls
        private TextBox txtRequestId;
        private ComboBox cmbSupplier;
        private DateTimePicker dtpDeliveryDate;
        private TextBox txtDeliveryAddress;
        private ComboBox cmbMaterial;
        private NumericUpDown nudQuantity;
        private TextBox txtUnitPrice;
        private DataGridView dgvRequestItems;
        private Label lblTotalAmount;
        public frmRestock2()
        {
            InitializeComponent();

            SetupUI();

        }
        private async void frmRestock2_Load(object sender, EventArgs e)
        {
            await InitializeForm();
        }
        private async Task InitializeForm()
        {
            DataTable allID = await apiCaller.GetAPIResponse($"/Supply/GetMaxID?tableName=restockrequest&fieldName=restockRequestID");
            txtRequestId.Text = FormData.GenerateID("R", allID, "restockRequestID");
            DataTable dtSupplier = await apiCaller.GetAPIResponse($"/Supply/GetNameList?tableName=supplier&fieldName=*");
            suppliersData = dtSupplier;
    
            DataTable dtMaterial = await apiCaller.GetAPIResponse($"/Supply/GetNameList?tableName=rawmaterial&fieldName=*");
            materialsData = dtMaterial;
           
        }

        //private void AddRequestItem()
        //{
        //    //string value = cmbMaterial.SelectedItem?.ToString() ?? string.Empty;
        //    //string valueSupplier = cmbSupplier.SelectedItem?.ToString() ?? string.Empty;
        //    //if (cmbMaterial.SelectedIndex == -1 || cmbSupplier.SelectedIndex==-1)
        //    //{
        //    //    MessageBox.Show("Please check if supplier or material not be chosen！");
        //    //    return;
        //    //}
        //    //var newItem = new MaterialRestock
        //    //{
        //    //    restockRequestID = txtRequestId.Text,
        //    //    supplierID = valueSupplier.Substring(0, 6),
        //    //    materialID = value.Substring(0, 6),
        //    //    materialName = value.Substring(7),
        //    //    deliveryAddress = txtDeliveryAddress.Text,
        //    //    restockQuantity = Convert.ToDouble(nudQuantity.Text),
        //    //    unitPrice = Convert.ToDouble(txtUnitPrice.Text),
        //    //    //unitPrice = Convert.ToDouble(txtUnitPrice.Text.FormData.GetValueOrEmpty()),
        //    //    totalPrice = Convert.ToDouble(nudQuantity.Text) * Convert.ToDouble(txtUnitPrice.Text),
        //    //    expectedDate = dtpDeliveryDate.Value.ToString("yyyy-MM-dd"),


        //    //};

        //    if (cmbMaterial.SelectedValue == null) return;

        //    string materialID = cmbMaterial.SelectedValue?.ToString() ?? "";
        //    string materialName = materialsData.AsEnumerable()
        //        .First(row => row.Field<string>("materialID") == materialID)
        //        .Field<string>("materialName");
        //    int quantity = (int)nudQuantity.Value;
        //    decimal price = materialsData.AsEnumerable()
        //        .First(row => row.Field<string>("materialID") == materialID)
        //        .Field<decimal>("price");
        //    decimal totalPrice = quantity * price;

        //    // Check if material already exists in reques
        //    var existingRow = requestItemsData.AsEnumerable()
        //        .FirstOrDefault(row => row.Field<string>("materialID") == materialID);

        //    if (existingRow != null)
        //    {
        //        // Update existing row
        //        existingRow.SetField("Quantity", existingRow.Field<int>("quantity") + quantity);
        //        existingRow.SetField("TotalPrice", existingRow.Field<int>("quantity") * price);
        //    }
        //    else
        //    {
        //        // Add new row
        //        requestItemsData.Rows.Add(materialID, materialName, quantity, price, totalPrice);
        //    }

        //    UpdateTotalAmount();
        //    ResetMaterialSelection();
        //}
    }
}
