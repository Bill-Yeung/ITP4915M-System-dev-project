using Client.Common;
using Client.Controllers;
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

namespace Client.Views.RnD.PSS
{
    public partial class frmVersionHistory : Form
    {

        private string productID { get; set; }

        public frmVersionHistory(string productID)
        {
            InitializeComponent();
            this.productID = productID;
        }

        private async void frmVersionHistory_Load(object sender, EventArgs e)
        {

            // Product Attribute

            dgvProductAttribute.RowHeadersVisible = false;
            dgvProductAttribute.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductAttribute.AllowUserToResizeRows = false;
            dgvProductAttribute.AllowUserToResizeColumns = false;

            dgvProductAttribute.EnableHeadersVisualStyles = false;
            dgvProductAttribute.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dgvProductAttribute.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightGreen;
            dgvProductAttribute.ColumnHeadersHeight = 50;
            dgvProductAttribute.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvProductAttribute.RowTemplate.Height = 40;
            dgvProductAttribute.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            var productKey = new
            {
                productID = productID
            };

            string jsonString = await APIController.ApiRequest("POST", "/Common/GetData/ProductAttributeVersion/false", Helper.ToDictionary(productKey));
            DataTable dtResult = JsonConvert.DeserializeObject<DataTable>(jsonString);

            DataView dv = dtResult.DefaultView;
            dv.Sort = "attributeID ASC, versionID DESC";
            dgvProductAttribute.DataSource = dv;

            dgvProductAttribute.Columns["versionID"].HeaderText = "Version ID";
            dgvProductAttribute.Columns["versionID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProductAttribute.Columns["versionID"].FillWeight = 20;

            dgvProductAttribute.Columns["productID"].Visible = false;

            dgvProductAttribute.Columns["attributeID"].HeaderText = "Attribute ID";
            dgvProductAttribute.Columns["attributeID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProductAttribute.Columns["attributeID"].FillWeight = 30;

            dgvProductAttribute.Columns["attributeValue"].HeaderText = "Attribute Value";
            dgvProductAttribute.Columns["attributeValue"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProductAttribute.Columns["attributeValue"].FillWeight = 18;

            dgvProductAttribute.Columns["fileID"].HeaderText = "File ID";
            dgvProductAttribute.Columns["fileID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProductAttribute.Columns["fileID"].FillWeight = 22;

            dgvProductAttribute.Columns["recordDate"].HeaderText = "Record Date";
            dgvProductAttribute.Columns["recordDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProductAttribute.Columns["recordDate"].FillWeight = 22;

            dgvProductAttribute.Columns["recordPerson"].HeaderText = "Record Person";
            dgvProductAttribute.Columns["recordPerson"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProductAttribute.Columns["recordPerson"].FillWeight = 22;

            dgvProductAttribute.Columns["versionStatus"].HeaderText = "Version Status";
            dgvProductAttribute.Columns["versionStatus"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProductAttribute.Columns["versionStatus"].FillWeight = 22;

            // Material

            dgvMaterial.RowHeadersVisible = false;
            dgvMaterial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterial.AllowUserToResizeRows = false;
            dgvMaterial.AllowUserToResizeColumns = false;

            dgvMaterial.EnableHeadersVisualStyles = false;
            dgvMaterial.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dgvMaterial.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightGreen;
            dgvMaterial.ColumnHeadersHeight = 50;
            dgvMaterial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvMaterial.RowTemplate.Height = 40;
            dgvMaterial.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            string jsonString2 = await APIController.ApiRequest("POST", "/Common/GetData/ProductMaterialVersion/false", Helper.ToDictionary(productKey));

            if (jsonString2 != "[]")
            {

                DataTable dtResult2 = JsonConvert.DeserializeObject<DataTable>(jsonString2);

                DataView dv2 = dtResult2.DefaultView;
                dv2.Sort = "materialID ASC, versionID DESC";
                dgvMaterial.DataSource = dv2;

                dgvMaterial.Columns["versionID"].HeaderText = "Version ID";
                dgvMaterial.Columns["versionID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMaterial.Columns["versionID"].FillWeight = 20;

                dgvMaterial.Columns["productID"].Visible = false;

                dgvMaterial.Columns["materialID"].HeaderText = "Material ID";
                dgvMaterial.Columns["materialID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMaterial.Columns["materialID"].FillWeight = 30;

                dgvMaterial.Columns["quantity"].HeaderText = "Quantity";
                dgvMaterial.Columns["quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMaterial.Columns["quantity"].FillWeight = 18;

                dgvMaterial.Columns["recordDate"].HeaderText = "Record Date";
                dgvMaterial.Columns["recordDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMaterial.Columns["recordDate"].FillWeight = 22;

                dgvMaterial.Columns["recordPerson"].HeaderText = "Record Person";
                dgvMaterial.Columns["recordPerson"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMaterial.Columns["recordPerson"].FillWeight = 22;

                dgvMaterial.Columns["versionStatus"].HeaderText = "Version Status";
                dgvMaterial.Columns["versionStatus"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMaterial.Columns["versionStatus"].FillWeight = 22;

            }

        }

    }

}
