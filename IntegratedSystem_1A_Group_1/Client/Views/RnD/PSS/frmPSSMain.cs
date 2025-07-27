using Client.Common;
using Client.Controllers;
using Newtonsoft.Json;
using EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views.RnD.PSS
{
    public partial class frmPSSMain : Form
    {

        private DataTable dtProduct { get; set; }

        public frmPSSMain()
        {
            InitializeComponent();
        }

        private async void frmPSSMain_Load(object sender, EventArgs e)
        {

            dgvProduct.RowHeadersVisible = false;
            dgvProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProduct.AllowUserToResizeRows = false;
            dgvProduct.AllowUserToResizeColumns = false;

            dgvProduct.EnableHeadersVisualStyles = false;
            dgvProduct.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dgvProduct.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightGreen;
            dgvProduct.ColumnHeadersHeight = 50;
            dgvProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvProduct.RowTemplate.Height = 40;
            dgvProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            string jsonString = await APIController.ApiRequest("POST", "/Common/GetData/Product/true", null);
            DataTable dtResult = JsonConvert.DeserializeObject<DataTable>(jsonString);
            dtProduct = dtResult.Copy();

            resetView();

            dgvProduct.Columns["productID"].HeaderText = "Product ID";
            dgvProduct.Columns["productID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProduct.Columns["productID"].FillWeight = 20;

            dgvProduct.Columns["parentProductID"].Visible = false;

            dgvProduct.Columns["productName"].HeaderText = "Product Name";
            dgvProduct.Columns["productName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProduct.Columns["productName"].FillWeight = 30;

            dgvProduct.Columns["productType"].HeaderText = "Product Type";
            dgvProduct.Columns["productType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProduct.Columns["productType"].FillWeight = 18;

            dgvProduct.Columns["productCategory"].HeaderText = "Product Category";
            dgvProduct.Columns["productCategory"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProduct.Columns["productCategory"].FillWeight = 22;

            dgvProduct.Columns["productVersion"].Visible = false;

            dgvProduct.Columns["productStatus"].HeaderText = "Product Status";
            dgvProduct.Columns["productStatus"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProduct.Columns["productStatus"].FillWeight = 22;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string searchText = txtSearch.Text.ToLower();

            DataView dv = dtProduct.DefaultView;
            dv.RowFilter = $"(productID LIKE '%{searchText}%' OR " +
                $"productName LIKE '%{searchText}%' OR " +
                $"productCategory LIKE '%{searchText}%' OR " +
                $"productType LIKE '%{searchText}%' OR " +
                $"productStatus LIKE '%{searchText}%')" +
                $" AND productStatus <> 'Terminated'";
            dv.Sort = "productID ASC";
            dgvProduct.DataSource = dv.ToTable();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetView();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            string jsonString = await APIController.ApiRequest("POST", "/Common/GetData/Product/true", null);
            DataTable dtResult = JsonConvert.DeserializeObject<DataTable>(jsonString);
            dtProduct = dtResult.Copy();
            resetView();
        }

        private void resetView()
        {
            DataView dv = dtProduct.DefaultView;
            dv.RowFilter = "productStatus <> 'Terminated'";
            dv.Sort = "productID ASC";
            dgvProduct.DataSource = dtProduct;
            txtSearch.Text = "";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            PanelController.openForm(Program.homeForm.panelRight, new frmCreateProduct());
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {

            if (dgvProduct.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvProduct.SelectedRows[0];
                string selectedProductID = selectedRow.Cells["productID"].Value.ToString();
                if (selectedProductID != null)
                {
                    var primaryKey = new
                    {
                        productID = selectedProductID
                    };
                    string productString = await APIController.ApiRequest("POST", "/Common/GetData/Product/false", Helper.ToDictionary(primaryKey));
                    List<Product> product = JsonConvert.DeserializeObject<List<Product>>(productString);
                    string productAttributeVersionString = await APIController.ApiRequest("POST", "/Common/GetData/ProductAttributeVersion/false", Helper.ToDictionary(primaryKey));
                    List<ProductAttributeVersion> productAttributeVersion = JsonConvert.DeserializeObject<List<ProductAttributeVersion>>(productAttributeVersionString);
                    if (product[0].productStatus == "Pending approval")
                    {
                        PanelController.openForm(Program.homeForm.panelRight, new frmApproveProduct(product[0]));
                    }
                    else
                    {
                        PanelController.openForm(Program.homeForm.panelRight, new frmEditProduct(product[0], productAttributeVersion));
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to view/edit!");
            }

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgvProduct.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvProduct.SelectedRows[0];
                string selectedProductID = selectedRow.Cells["productID"].Value.ToString();
                if (selectedProductID != null)
                {

                    var user = (Staff)Program.user;
                    var productTeamKey = new
                    {
                        productID = selectedProductID,
                        role = "ProductLeader"
                    };
                    string leaderString = await APIController.ApiRequest("POST", "/Common/GetData/ProductTeam/false", productTeamKey);
                    List<ProductTeam> leaderList = JsonConvert.DeserializeObject<List<ProductTeam>>(leaderString);

                    if (leaderList.Count != 0 && leaderList[0].personID == user.staffID)
                    {

                        DialogResult dialogResult = MessageBox.Show("Are you sure that you want to delete the product?", "ACTION: DELETE product",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                        if (dialogResult == DialogResult.OK)
                        {

                            List<Product> productKey = new List<Product>();
                            productKey.Add(new Product
                            {
                                productID = selectedProductID
                            });

                            List<Product> productData = new List<Product>();
                            productData.Add(new Product
                            {
                                productStatus = "Terminated"
                            });

                            UpdateDataRequest productRequest = new UpdateDataRequest();
                            productRequest.KeyList = Helper.ToDictionaryList(productKey);
                            productRequest.DataList = Helper.ToDictionaryList(productData);

                            string result = await APIController.ApiRequest("POST", "/Common/UpdateData/Product", productRequest);

                            try
                            {
                                if (int.Parse(result) > 0)
                                {
                                    MessageBox.Show("Product deleted successfully!");
                                    PanelController.openForm(Program.homeForm.panelRight, new frmPSSMain());
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                        else if (dialogResult == DialogResult.Cancel)
                        {
                            MessageBox.Show("It has been cancelled!", "ACTION: DELETE product");
                        }
                        else
                        {
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("You are not the leader of this product!");
                    }

                }
                else
                {
                    MessageBox.Show("Please select a product to delete!");
                }

            }

        }

    }

}
