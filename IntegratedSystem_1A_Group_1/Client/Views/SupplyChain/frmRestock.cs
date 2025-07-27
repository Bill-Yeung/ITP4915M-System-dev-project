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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static EntityModels.Supplier;


namespace Client.Views.SupplyChain
{
    public partial class frmRestock : Form
    {
        DatabaseApicaller apiCaller = new DatabaseApicaller();
        private List<MaterialRestock> restockList = new List<MaterialRestock>();
        public frmRestock()
        {
            InitializeComponent();
            initializeCustomComponents();
            InitializeDataGridView();
            InitializeDateTimePickers();
        }
        private async Task InitializeForm()
        {
            DataTable allID = await apiCaller.GetAPIResponse($"/Supply/GetMaxID?tableName=restockrequest&fieldName=restockRequestID");
            lblRequestID.Text = FormData.GenerateID("R", allID, "restockRequestID");
            DataTable dtSupplier = await apiCaller.GetAPIResponse($"/Supply/GetNameList?tableName=supplier&fieldName=*");
            DataTable dtMaterial = await apiCaller.GetAPIResponse($"/Supply/GetNameList?tableName=rawmaterial&fieldName=*");
            if (dtSupplier != null)
            {
                cmbSupplier.Items.AddRange(FormData.getNameList(dtSupplier, "supplier").ToArray());
            }
           
            if (dtMaterial != null)
            {
                cmbMaterial.Items.AddRange(FormData.getNameList(dtMaterial, "material").ToArray());
            }
           
            btnSendRequest.Enabled = false;
        }
        private async void frmRestock_Load(object sender, EventArgs e)
        {
           await InitializeForm(); 
        }
        private void addMaterialRestock()
        {
            if(cmbMaterial.SelectedIndex == -1 || cmbSupplier.SelectedIndex==-1) {MessageBox.Show("Please select a material and a supplier."); return; };
            if(string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please enter a valid quantity.");
                txtQuantity.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUnitPrice.Text))
            {
                MessageBox.Show("Please enter a valid price.");
                txtQuantity.Focus();
                return;
            }
            string value = cmbMaterial.SelectedItem?.ToString() ?? string.Empty;
            string valueSupplier = cmbSupplier.SelectedItem?.ToString() ?? string.Empty;

            var newItem = new MaterialRestock
            {
                restockRequestID = lblRequestID.Text,
                supplierID = valueSupplier.Substring(0, 6),
                materialID = value.Substring(0, 6),
                materialName = value.Substring(7),
                deliveryAddress = txtDeliveryAddress.Text,
                restockQuantity =Convert.ToDouble(txtQuantity.Text),
                unitPrice = Convert.ToDouble(txtUnitPrice.Text),
                totalPrice = Convert.ToDouble(txtQuantity.Text) * Convert.ToDouble(txtUnitPrice.Text),
                expectedDate = dtpDeliveryDate.Value.ToString("yyyy-MM-dd"),


            };

            restockList.Add(newItem);
            txtQuantity.Text = "";
            txtUnitPrice.Text = "";
            txtDeliveryAddress.Text = "";
            cmbMaterial.SelectedIndex = -1;
            cmbSupplier.Enabled = false;

            txtQuantity.Focus();
            btnSendRequest.Enabled = restockList.Any();
            dgvMaterials.DataSource = null;
            dgvMaterials.DataSource = restockList;
            UpdateTotalAmount();
        }
        private async void sendRestockRequest()
        {
            List<Dictionary<string, Object>> data = new List<Dictionary<string, Object>>();
            for (int i = 0; i < restockList.Count; i++)
            {
                var newItem = restockList[i];
                data.Add(FormData.ToDictionary(newItem, new List<string> { "materialName", " deliveryAddress", "unitPrice", "totalPrice"}));//把不需要读入table的字段去掉
            }
            string addRestock = "";
            if (data.Count == 0) { MessageBox.Show("Data cannot be null or empty."); }
            else addRestock = await apiCaller.PostAPIResponse("/Supply/AddRestockRequest", data);
            if (addRestock != "0")
            {
                MessageBox.Show("Add Material Restock Request successfully.");

            }
            else
            {
                MessageBox.Show("Add Material Restock Request failed.");

            }
        }
        //private async void sendRestockRequest()
        //{

        //}

        private void DgvMaterials_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 确保点击的是按钮列且不是标题行
            if (e.RowIndex >= 0 && dgvMaterials.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var columnName = dgvMaterials.Columns[e.ColumnIndex].Name;

                if (columnName == "Delete")
                {
                   
                    var materialID = dgvMaterials.Rows[e.RowIndex].Cells["materialID"].Value.ToString();

                  
                    if (MessageBox.Show("Delete this record?", "Confirm Deletion",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                       
                        restockList.RemoveAll(x => x.materialID == materialID);
                        dgvMaterials.DataSource = null;
                        dgvMaterials.DataSource = restockList;

                        UpdateTotalAmount();

                        btnSendRequest.Enabled = restockList.Any();
                    }
                }
                if (columnName == "Update")
                {
                    UpdateRowData(e.RowIndex);
                }
            }
        }

        private void UpdateRowData(int rowIndex)
        {
            var materialID = dgvMaterials.Rows[rowIndex].Cells["materialID"].Value.ToString();
            var itemToUpdate = restockList.FirstOrDefault(x => x.materialID == materialID);

            if (itemToUpdate != null)
            {
                if (int.TryParse(dgvMaterials.Rows[rowIndex].Cells["Quantity"].Value?.ToString(), out int newQuantity))
                {
                    itemToUpdate.restockQuantity = newQuantity;
                    itemToUpdate.totalPrice = newQuantity * itemToUpdate.unitPrice;

                    // 更新显示
                    dgvMaterials.Rows[rowIndex].Cells["totalPrice"].Value = itemToUpdate.totalPrice;

                    
                    UpdateTotalAmount();

                    MessageBox.Show("Update Succesfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please enter valid quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // 恢复原值
                    dgvMaterials.Rows[rowIndex].Cells["Quantity"].Value = itemToUpdate.restockQuantity;
                }
            
    }
        }
        private void UpdateTotalAmount()
        {
            double total = restockList.Sum(x => x.totalPrice);
            txtTotalAmount.Text = total.ToString("N2"); 
        }
    }
}
