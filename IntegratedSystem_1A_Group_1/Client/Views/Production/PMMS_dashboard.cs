using Client.Common;
using Client.Controllers;
using EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views.Production
{
    public partial class PMMS_dashboard : Form
    {
        private Dictionary<string, List<ProductMaterialVersion>> _productMaterialsCache = new Dictionary<string, List<ProductMaterialVersion>>();
        public PMMS_dashboard()
        {
            InitializeComponent();
        }
        private async void PMMS_dashboard_Load_1(object sender, EventArgs e)
        {
            // Initialize the StatusCB ComboBox with default values
            if (StatusCB != null)
            {
                StatusCB.Items.Clear();
                StatusCB.Items.Add("Started");
                StatusCB.Items.Add("Finished");

                LoadDashboardData();

                var updateButton = new DataGridViewButtonColumn
                {
                    Name = "Action",
                    HeaderText = "Action",
                    Text = "Update",
                    UseColumnTextForButtonValue = true
                };
                dgvProductData.Columns.Add(updateButton);


            }
        }

        private void StatusCB_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // Add the missing StatusCB definition
        private ComboBox StatusCB;

        // Add the missing InitializeComponent method
        private void InitializeComponent()
        {
            StatusCB = new ComboBox();
            EndDateLbl = new Label();
            StatusLbl = new Label();
            dgvProductData = new DataGridView();
            StartDTP = new DateTimePicker();
            EndDTP = new DateTimePicker();
            SearchBtn = new Button();
            StartDatelbl = new Label();
            ViewDeshboardLbl = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            BtnSearch = new Button();
            BtnReset = new Button();
            // ((ISupportInitialize)dgvProductData).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // StatusCB
            // 
            StatusCB.FormattingEnabled = true;
            StatusCB.Location = new Point(3, 3);
            StatusCB.Name = "StatusCB";
            StatusCB.Size = new Size(393, 23);
            StatusCB.TabIndex = 0;
            // StatusCB.UseWaitCursor = true;
            StatusCB.SelectedIndexChanged += StatusCB_SelectedIndexChanged;
            // 
            // EndDateLbl
            // 
            EndDateLbl.AutoSize = true;
            EndDateLbl.Location = new Point(3, 254);
            EndDateLbl.Name = "EndDateLbl";
            EndDateLbl.Size = new Size(131, 15);
            EndDateLbl.TabIndex = 2;
            EndDateLbl.Text = "Search Order End Date: ";
            // EndDateLbl.UseWaitCursor = true;
            // 
            // StatusLbl
            // 
            StatusLbl.AutoSize = true;
            StatusLbl.Location = new Point(3, 381);
            StatusLbl.Name = "StatusLbl";
            StatusLbl.Size = new Size(104, 15);
            StatusLbl.TabIndex = 3;
            StatusLbl.Text = "Production Status:";
            // StatusLbl.UseWaitCursor = true;
            StatusLbl.Click += StatusLbl_Click_1;
            // 
            // dgvProductData
            // 
            dgvProductData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductData.Location = new Point(259, 511);
            dgvProductData.Name = "dgvProductData";
            dgvProductData.RowHeadersWidth = 62;
            dgvProductData.Size = new Size(1234, 482);
            dgvProductData.TabIndex = 4;
            // dgvProductData.UseWaitCursor = true;
            dgvProductData.CellClick += dgvProductData_CellClick;
            // 
            // StartDTP
            // 
            StartDTP.Location = new Point(259, 130);
            StartDTP.Name = "StartDTP";
            StartDTP.Size = new Size(393, 23);
            StartDTP.TabIndex = 5;
            // StartDTP.UseWaitCursor = true;
            StartDTP.ValueChanged += StartDTP_ValueChanged;
            // 
            // EndDTP
            // 
            EndDTP.Location = new Point(259, 257);
            EndDTP.Name = "EndDTP";
            EndDTP.Size = new Size(393, 23);
            EndDTP.TabIndex = 6;
            // EndDTP.UseWaitCursor = true;
            EndDTP.ValueChanged += EndDTP_ValueChanged;
            // 
            // SearchBtn
            // 
            SearchBtn.Location = new Point(713, 220);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(112, 34);
            SearchBtn.TabIndex = 7;
            SearchBtn.Text = "Search";
            SearchBtn.UseVisualStyleBackColor = true;
            // SearchBtn.UseWaitCursor = true;
            // 
            // StartDatelbl
            // 
            StartDatelbl.AutoSize = true;
            StartDatelbl.Location = new Point(3, 127);
            StartDatelbl.Name = "StartDatelbl";
            StartDatelbl.Size = new Size(134, 15);
            StartDatelbl.TabIndex = 1;
            StartDatelbl.Text = "Search Order Start date: ";
            // StartDatelbl.UseWaitCursor = true;
            // 
            // ViewDeshboardLbl
            // 
            ViewDeshboardLbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ViewDeshboardLbl.AutoSize = true;
            ViewDeshboardLbl.Font = new Font("Segoe UI", 20F);
            ViewDeshboardLbl.Location = new Point(259, 0);
            ViewDeshboardLbl.Name = "ViewDeshboardLbl";
            ViewDeshboardLbl.Size = new Size(1434, 37);
            ViewDeshboardLbl.TabIndex = 8;
            ViewDeshboardLbl.Text = "View Dashboard";
            ViewDeshboardLbl.TextAlign = ContentAlignment.TopCenter;
            // ViewDeshboardLbl.UseWaitCursor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.1345282F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84.86547F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0F));
            tableLayoutPanel1.Controls.Add(dgvProductData, 2, 4);
            tableLayoutPanel1.Controls.Add(EndDateLbl, 1, 2);
            tableLayoutPanel1.Controls.Add(EndDTP, 2, 2);
            tableLayoutPanel1.Controls.Add(StartDTP, 2, 1);
            tableLayoutPanel1.Controls.Add(StartDatelbl, 1, 1);
            tableLayoutPanel1.Controls.Add(StatusLbl, 1, 3);
            tableLayoutPanel1.Controls.Add(ViewDeshboardLbl, 2, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 2, 3);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 485F));
            tableLayoutPanel1.Size = new Size(1697, 996);
            tableLayoutPanel1.TabIndex = 9;
            // tableLayoutPanel1.UseWaitCursor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(StatusCB, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel2.Location = new Point(259, 384);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1434, 121);
            tableLayoutPanel2.TabIndex = 9;
            // tableLayoutPanel2.UseWaitCursor = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(BtnSearch, 0, 0);
            tableLayoutPanel3.Controls.Add(BtnReset, 1, 0);
            tableLayoutPanel3.Location = new Point(720, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(711, 115);
            tableLayoutPanel3.TabIndex = 10;
            // tableLayoutPanel3.UseWaitCursor = true;
            // 
            // BtnSearch
            // 
            BtnSearch.Anchor = AnchorStyles.None;
            BtnSearch.Location = new Point(121, 40);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(112, 34);
            BtnSearch.TabIndex = 1;
            BtnSearch.Text = "Search";
            BtnSearch.UseVisualStyleBackColor = true;
            // BtnSearch.UseWaitCursor = true;
            BtnSearch.Click += BtnSearch_Click;
            // 
            // BtnReset
            // 
            BtnReset.Anchor = AnchorStyles.None;
            BtnReset.Location = new Point(477, 40);
            BtnReset.Name = "BtnReset";
            BtnReset.Size = new Size(112, 34);
            BtnReset.TabIndex = 2;
            BtnReset.Text = "Reset";
            BtnReset.UseVisualStyleBackColor = true;
            // BtnReset.UseWaitCursor = true;
            BtnReset.Click += BtnReset_Click;
            // 
            // PMMS_dashboard
            // 
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1702, 993);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(SearchBtn);
            Name = "PMMS_dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            // UseWaitCursor = true;
            Load += PMMS_dashboard_Load_1;
            // ((ISupportInitialize)dgvProductData).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void EndDTP_ValueChanged(object sender, EventArgs e)
        {
            // get the input date
            DateTimePicker dtp = sender as DateTimePicker;

            if (dtp != null && dtp.Value > DateTime.Today)
            {
                MessageBox.Show("Date cannot select be in the future",
                              "Invalid date ",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);

                // Reset thdate to today 
                dtp.Value = DateTime.Today;
            }
        }

        private void StartDTP_ValueChanged(object sender, EventArgs e)
        {

        }

        private void StatusLbl_Click_1(object sender, EventArgs e)
        {

        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            if (StartDTP.Value > DateTime.Today)
            {
                MessageBox.Show("Start date cannot be in the future.", "Invalid date",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                StartDTP.Value = DateTime.Today;
                return;
            }

            if (StartDTP.Value > EndDTP.Value)
            {
                MessageBox.Show("Start date cannot be later than end date.", "Invalid range",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime startDate = StartDTP.Value.Date;
            DateTime endDate = EndDTP.Value.Date;
            string? status = StatusCB.SelectedItem?.ToString();

            var searchParams = new
            {
                StartDate = startDate,
                EndDate = endDate,
                Status = string.IsNullOrWhiteSpace(status) ? null : status
            };

            string response = await APIController.ApiRequest("POST", "api/Order/GetProductDeshboardData", searchParams);


            if (!string.IsNullOrEmpty(response))
            {
                DataTable dt = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(response);
                dgvProductData.DataSource = dt;
                dt.AcceptChanges(); // optional
            }
            else
            {
                MessageBox.Show("No data found or error occurred.", "Result",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void LoadDashboardData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string response = await APIController.ApiRequest("POST", "/Common/GetData/placedorder/true", null);
                string response2 = await APIController.ApiRequest("POST", "/Common/GetData/product/true", null);
                string response3 = await APIController.ApiRequest("POST", "/Common/GetData/orderproduct/true", null);

                DataTable dtOrder = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(response);
                DataTable dtProduct = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(response2);
                DataTable dtOrderProduct = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(response3);
                //DataTable dtPMV = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(response4);

                if (dtOrder == null || dtProduct == null || dtOrderProduct == null)
                {
                    MessageBox.Show("Cannot get data from server.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable mergedDataTable = new DataTable();
                foreach (DataColumn col in dtOrder.Columns)
                    mergedDataTable.Columns.Add(col.ColumnName, col.DataType);

                mergedDataTable.Columns.Add("ProductID", typeof(string));
                mergedDataTable.Columns.Add("ProductName", typeof(string));
                mergedDataTable.Columns.Add("Quantity", typeof(int));
                mergedDataTable.Columns.Add("MaterialID", typeof(string));
                mergedDataTable.Columns.Add("PredictedMaterialUsage", typeof(decimal));

                foreach (DataRow orderRow in dtOrder.Rows)
                {
                    foreach (DataRow orderProductRow in dtOrderProduct.Select($"orderID = '{orderRow["orderID"]}'"))
                    {
                        DataRow[] productRows = dtProduct.Select($"productID = '{orderProductRow["productID"]}'");
                        if (productRows.Length > 0)
                        {
                            DataRow productRow = productRows[0];
                            string productID = Convert.ToString(productRow["productID"]);
                            string productName = Convert.ToString(productRow["productName"]);
                            int quantity = Convert.ToInt32(orderProductRow["quantity"]);

                            // Get all material versions for this product
                            List<ProductMaterialVersion> pmvRows = await Helper.GetLatestMaterialVersion(productID);

                            if (pmvRows.Count > 0)
                            {
                                foreach (var pmvRow in pmvRows)
                                {
                                    DataRow newRow = mergedDataTable.NewRow();
                                    newRow.ItemArray = orderRow.ItemArray.Clone() as object[];

                                    newRow["ProductID"] = productID;
                                    newRow["ProductName"] = productName;
                                    newRow["Quantity"] = quantity;

                                    newRow["MaterialID"] = pmvRow.materialID;
                                    if (pmvRow.quantity != 0)
                                    {
                                        decimal usagePerUnit = Convert.ToDecimal(pmvRow.quantity);
                                        newRow["PredictedMaterialUsage"] = usagePerUnit * quantity;
                                    }
                                    else
                                    {
                                        newRow["PredictedMaterialUsage"] = 0;
                                    }

                                    mergedDataTable.Rows.Add(newRow);
                                }
                            }
                            else
                            {
                                // No material found for product — still show a row
                                DataRow newRow = mergedDataTable.NewRow();
                                newRow.ItemArray = orderRow.ItemArray.Clone() as object[];

                                newRow["ProductID"] = productID;
                                newRow["ProductName"] = productName;
                                newRow["Quantity"] = quantity;
                                newRow["MaterialID"] = DBNull.Value;
                                newRow["PredictedMaterialUsage"] = DBNull.Value;

                                mergedDataTable.Rows.Add(newRow);
                            }
                        }
                    }
                }

                // Optional: Sort by ProductID and MaterialID for easier reading
                mergedDataTable.DefaultView.Sort = "ProductID ASC, MaterialID ASC";
                dgvProductData.DataSource = mergedDataTable.DefaultView.ToTable();
                mergedDataTable.AcceptChanges();

                // Populate cache
                var productIds = mergedDataTable.AsEnumerable()
                    .Select(row => row.Field<string>("ProductID"))
                    .Where(id => !string.IsNullOrEmpty(id))
                    .Distinct()
                    .ToList();

                _productMaterialsCache.Clear();

                foreach (var productId in productIds)
                {
                    List<ProductMaterialVersion> materialList = await Helper.GetLatestMaterialVersion(productId);
                    _productMaterialsCache[productId] = materialList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load dashboard error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }



        private async void BtnReset_Click(object sender, EventArgs e)
        {
            StartDTP.Value = DateTime.Today;
            EndDTP.Value = DateTime.Today;
            StatusCB.SelectedIndex = -1;
            LoadDashboardData();
        }


        private void dgvProductData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = dgvProductData.Columns[e.ColumnIndex].Name;
            if (e.RowIndex >= 0 && dgvProductData.Columns[e.ColumnIndex].Name == "Action")
            {
                try
                {

                    DataRowView drv = (DataRowView)dgvProductData.Rows[e.RowIndex].DataBoundItem;

                    var orderDataForUpdate = new UpdateOrderStatus();

                    orderDataForUpdate.OrderID = Convert.ToString(drv["orderID"]);
                    orderDataForUpdate.ProductID = Convert.ToString(drv["ProductID"]);
                    orderDataForUpdate.ProductName = Convert.ToString(drv["ProductName"]);
                    orderDataForUpdate.Quantity = Convert.ToInt32(drv["Quantity"]);
                    orderDataForUpdate.MaterialID = Convert.ToString(drv["MaterialID"]);
                    orderDataForUpdate.PerdictMaterialUsage = Convert.ToDecimal(drv["PredictedMaterialUsage"]);
                    //orderDataForUpdate.TotalCost = Convert.ToDecimal(drv["TotalCost"]);

                    orderDataForUpdate.ProductionStatus = Convert.ToString(drv["productionStatus"]);
                    orderDataForUpdate.ProductionStartDate = Convert.ToDateTime(drv["productionStartDate"]);

                    orderDataForUpdate.ProductionExpEndDate = drv["productionExpEndDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(drv["productionExpEndDate"]);

                    orderDataForUpdate.ProductionEndDate = drv["productionEndDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(drv["productionEndDate"]);

                    PMMS_Update_Order updateForm = new PMMS_Update_Order(orderDataForUpdate);

                    updateForm.ShowDialog();

                    LoadDashboardData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Open Windows error ：\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (columnName == "ViewMaterialsAction")
            {
                try
                {
                    DataRowView drv = (DataRowView)dgvProductData.Rows[e.RowIndex].DataBoundItem;
                    string productID = Convert.ToString(drv["ProductID"]);

                    if (_productMaterialsCache.ContainsKey(productID))
                    {
                    }
                    else
                    {
                        MessageBox.Show("Can nto find the material error" +
                            "", "errro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("load material eror ：\n" + ex.Message, "error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
