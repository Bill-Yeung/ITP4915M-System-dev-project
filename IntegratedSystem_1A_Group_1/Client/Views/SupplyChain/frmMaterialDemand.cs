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
using static EntityModels.Supplier;

namespace Client.Views.SupplyChain
{
    public partial class frmMaterialDemand : Form
    {
        DatabaseApicaller apiCaller = new DatabaseApicaller();
        private List<MaterialDemand> demandList = new List<MaterialDemand>();

        public frmMaterialDemand()
        {
            InitializeComponent();
            initializeCustomComponents();
            InitializeDataGridView();
        }
        private async Task InitializeForm()
        {
            DataTable allID = await apiCaller.GetAPIResponse($"/Supply/GetMaxID?tableName=materialdemand&fieldName=demandID");
            lblDemandID.Text = FormData.GenerateID("MD", allID, "demandID");
            txtReceiver.Text = "Production DPT";
            DataTable dtMaterial = await apiCaller.GetAPIResponse($"/Supply/GetNameList?tableName=rawmaterial&fieldName=*");
            if (dtMaterial != null)
            {
                cmbMaterial.Items.AddRange(FormData.getNameList(dtMaterial, "material").ToArray());
            }
            dtpExpectReceiveDate.MinDate = DateTime.Today;
            btnSendRequest.Enabled = false;
              dgvMaterials.DataSource = null;

        }
        private async void frmMaterialDemand_Load(object sender, EventArgs e)
        {
         await InitializeForm();
           

        }
        private void addMaterialDemand()
        {
            string value = cmbMaterial.SelectedItem?.ToString() ?? cmbMaterial.Text;
            var newItem = new MaterialDemand
            {
                demandID = lblDemandID.Text,
                materialID = value.Substring(0, 6),
                materialName = value.Substring(7),
                receiver = txtReceiver.Text,
                quantity = Convert.ToDouble(txtQuantity.Text),
                expectedDate = dtpExpectReceiveDate.Value.ToString("yyyy-MM-dd"),

            };

            demandList.Add(newItem);

            txtQuantity.Text = "";

            dtpExpectReceiveDate.Value = DateTime.Today;
            cmbMaterial.SelectedIndex = -1;


            txtQuantity.Focus();
            btnSendRequest.Enabled = demandList.Any();
            dgvMaterials.DataSource = null;
            dgvMaterials.DataSource = demandList;
        }
        private async void sendMaterialDemand()
        {
            string addMaterialDemand = "";

            if (demandList.Count == 0) { MessageBox.Show("Data cannot be null or empty."); }
            else
            {
                List<string> columns = new() { "demandID", "materialID", "quantity", "expectedDate", "receiver" };
                StringBuilder values = new StringBuilder();
                for (int i = 0; i < demandList.Count; i++)
                {
                    values.Append('(');
                    var item = demandList[i];
                  
                    for (int j = 0; j < columns.Count; j++)
                    {
                        string field = columns[j];
                        object value = field switch
                        {
                            "demandID" => item.demandID,
                            "materialID" => item.materialID,
                            "quantity" => item.quantity,
                            "expectedDate" => item.expectedDate,
                            "receiver" => item.receiver,
                            _ => throw new ArgumentException($"Invalid Field: {field}")
                        };
                        values.Append(FormData.FormatSqlValue(value));


                        if (j < columns.Count - 1)
                            values.Append(", ");
                    }

                    values.Append(')');

                    if (i < demandList.Count - 1)
                        values.Append(", ");
                }

                addMaterialDemand = await apiCaller.PostAPIResponse("/Supply/AddMaterialDemand", values.ToString());
            }
            if (addMaterialDemand != "0")
            {
                MessageBox.Show("Add Material Demand Request successfully.");
                // Refresh the form to reset fields and data grid view
               
            }
            else
            {
                MessageBox.Show("Add Material Demand Request failed.");

            }
            await InitializeForm();
          
        }


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

                        demandList.RemoveAll(x => x.materialID == materialID);
                        dgvMaterials.DataSource = null;
                        dgvMaterials.DataSource = demandList;
                        btnSendRequest.Enabled = demandList.Any();
                    }
                }
              
            }
        }
       
    }
}