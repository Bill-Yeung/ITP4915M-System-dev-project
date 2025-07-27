using Client.Controllers;
using System.Data;
using Client.GenaralMethod;
using System.Threading.Tasks;
using EntityModels;
using static EntityModels.Supplier;
using System.Diagnostics;
using System.Windows.Forms;

namespace Client.Views.SupplyChain
{

    partial class frmForSupplier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // frmForSupplier
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "frmForSupplier";
            Text = "frmForSupplier";
            ResumeLayout(false);
        }
        private DataGridView dgvRequests;
        DatabaseApicaller apiCaller = new DatabaseApicaller();
        private TextBox txtSearch;
        private Button btnSearch;



        private void InitializeUI()
        {
            this.Text = "Supplier Purchase Requests";
            this.Size = new Size(1100, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;


            var lblTitle = new Label
            {
                Text = "Purchase Requests Overview",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                AutoSize = true,
                Location = new Point(20, 20)
            };
            this.Controls.Add(lblTitle);

            txtSearch = new TextBox
            {
                Location = new Point(20, 65),
                Size = new Size(250, 35),
                Font = new Font("Segoe UI", 10F),
                PlaceholderText = "Search by Material ID or Name"
            };
            this.Controls.Add(txtSearch);
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SearchData(txtSearch.Text);
                    e.Handled = e.SuppressKeyPress = true;
                }
            };

            // 🔍 Search Button
            btnSearch = new Button
            {
                Text = "Search",
                Location = new Point(280, 65),
                Size = new Size(100, 35),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            this.Controls.Add(btnSearch);
            btnSearch.Click += (s, e) => SearchData(txtSearch.Text);


            dgvRequests = new DataGridView
            {
                Location = new Point(20, 110),
                Size = new Size(1050, 550),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                BackgroundColor = Color.White,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Font = new Font("Segoe UI", 10F),
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    WrapMode = DataGridViewTriState.True // ← 自动换行
                }

            };
            // ⬅️ Back Button
            var btnBack = new Button
            {
                Text = "Back",
                Size = new Size(100, 35),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(this.ClientSize.Width - 120, 25),
                Anchor = AnchorStyles.Top | AnchorStyles.Right

            };
            var btnShowAll = new Button
            {
                Text = "Show All",
                Size = new Size(100, 35),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                //BackColor = Color.LightSeaGreen,
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(this.ClientSize.Width - 240, 25),
                Anchor = AnchorStyles.Top | AnchorStyles.Right

            };
            FormDesign.ClickEvent(btnBack, this);
            //btnBack.Click += (s, e) => {
            //    this.DialogResult = DialogResult.Cancel;
            //    this.Close();
            //};
            this.Controls.Add(btnBack);
            this.Controls.Add(btnShowAll);
            btnShowAll.Click += btnShowAll_Click;
            dgvRequests.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            var columnList = new List<(string, string)>
                            {
                                ("Request ID", "restockRequestID"),
                                ("Supplier ID", "supplierID"),
                                ("Material ID", "materialID"),
                                ("Material Name", "materialName"),
                                ("Quantity", "restockQuantity"),
                                ("Created On", "createDate"),
                                ("Expected Date", "expectedDate"),
                                ("Request Status", "restockStatus"),
                                ("Update Date", "updatedDate")

                            };


            FormDesign.AddColumnsToGrid(dgvRequests, columnList);
            //FormDesign.AddColumnsToGrid(dgvRequests, columnList);
            //dgvRequests.Columns["restockRequestID"].ReadOnly = false;
            //dgvRequests.Columns["expetedDate"].ReadOnly = false;

            FormDesign.AddButtonColumn(dgvRequests, "btnEdit", "Edit", "Edit");
            FormDesign.AddButtonColumn(dgvRequests, "probtn", "Process", "Process Request");
            FormDesign.AddButtonColumn(dgvRequests, "cancelbtn", "Cancel", "Cancel", Color.MediumSeaGreen, Color.White);
            if (_currentMode == FormMode.SupplierView)
            {
                dgvRequests.Columns["supplierID"].Visible = false;
                dgvRequests.Columns["btnEdit"].Visible = false;
            }
            if (_currentMode == FormMode.ManagerView) dgvRequests.Columns["probtn"].Visible = false;
            // ✅ 新增字段

            dgvRequests.CellContentClick += DgvRequests_CellContentClick;

            this.Controls.Add(dgvRequests);
           
            dgvRequests.ColumnHeaderMouseClick += DgvRequests_ColumnHeaderMouseClick;

        }

        private void DgvRequests_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dgvRequests.Columns["probtn"].Index ||
                                   e.ColumnIndex == dgvRequests.Columns["cancelbtn"].Index ||
                                    e.ColumnIndex == dgvRequests.Columns["btnEdit"].Index))
            {
                var status = dgvRequests.Rows[e.RowIndex].Cells["restockStatus"].Value?.ToString();
                if (status == "Completed" || status == "Cancelled")
                {
                    e.CellStyle.BackColor = Color.Gray;
                    e.CellStyle.ForeColor = Color.DarkGray;
                    dgvRequests.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                  

                }
            }
        }

        private void DgvRequests_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // 排序后强制刷新样式
            var disabledStatus = new List<string> { "Completed", "Cancelled" };
            FormDesign.DisableButtonsByStatus(dgvRequests, "probtn", "restockStatus", disabledStatus);
            FormDesign.DisableButtonsByStatus(dgvRequests, "cancelbtn", "restockStatus", disabledStatus);
            FormDesign.DisableButtonsByStatus(dgvRequests, "btnEdit", "restockStatus", disabledStatus);
        }



        private async Task LoadRequestsAsync()
        {
            try
            {
                DataTable dt = await apiCaller.GetAPIResponse("/Supply/GetRestockRequest");
                originalData = dt;
                // 绑定数据源前暂停布局计算
                dgvRequests.SuspendLayout();
                dgvRequests.DataSource = dt;

                // 应用禁用状态
                var disabledStatus = new List<string> { "Completed", "Cancelled" };
                FormDesign.DisableButtonsByStatus(dgvRequests, "probtn", "restockStatus", disabledStatus);
                FormDesign.DisableButtonsByStatus(dgvRequests, "cancelbtn", "restockStatus", disabledStatus);
                FormDesign.DisableButtonsByStatus(dgvRequests, "btnEdit", "restockStatus", disabledStatus);

                dgvRequests.ResumeLayout();
                dgvRequests.ClearSelection();
                //dgvRequests.DataSource = dt;
                //dgvRequests.ClearSelection();

                //var disabledStatus = new List<string> { "Completed", "Cancelled" };
                //FormDesign.DisableButtonsByStatus(dgvRequests, "probtn", "restockStatus", disabledStatus);
                //FormDesign.DisableButtonsByStatus(dgvRequests, "cancelbtn", "restockStatus", disabledStatus);
                //FormDesign.DisableButtonsByStatus(dgvRequests, "btnEdit", "restockStatus", disabledStatus);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load purchase requests:\n" + ex.Message, "Error");
            }
        }


        private async void DgvRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;
            var status = dgvRequests.Rows[e.RowIndex].Cells["restockStatus"].Value?.ToString();
            if (status == "Completed" || status == "Cancelled")
            {
                MessageBox.Show($"This record is {status}.");
                return;
            }

            if (dgvRequests.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                await HandleEditRequest(e.RowIndex);
                //dgvRequests.Refresh();
                return;
            }
            else if (dgvRequests.Columns[e.ColumnIndex].Name != "probtn" && dgvRequests.Columns[e.ColumnIndex].Name != "cancelbtn")
            {
                return;
            }
        
            RestockUpdate updateStatus = null;
            if (e.RowIndex >= 0)
            {
                string restockrequestID = dgvRequests.Rows[e.RowIndex].Cells["restockrequestID"].Value.ToString();
                string materialID = dgvRequests.Rows[e.RowIndex].Cells["materialID"].Value.ToString();
                string materialName = dgvRequests.Rows[e.RowIndex].Cells["materialName"].Value.ToString();
                string restockquantity = dgvRequests.Rows[e.RowIndex].Cells["restockQuantity"].Value.ToString();
                string expectedDate = dgvRequests.Rows[e.RowIndex].Cells["expectedDate"].Value.ToString();
                string supplierID = dgvRequests.Rows[e.RowIndex].Cells["supplierID"].Value.ToString();
                string btn = dgvRequests.Columns[e.ColumnIndex].Name;
                string actionname = "";
                if (btn == "btnEdit") actionname = "Updated";
                else actionname = (btn == "probtn") ? "Completed" : "Cancelled";

                var confirm = MessageBox.Show(
                      $"Mark request '{restockrequestID}' for '{materialName}' as {actionname}?",
                      "Confirm Process",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question
                      );
                if (confirm == DialogResult.Yes && btn == "probtn")
                    updateStatus = new RestockUpdate
                    {
                        restockRequestID = restockrequestID,
                        materialID = materialID,
                        restockStatus = "Completed",
                        updatedDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        restockQuantity = Convert.ToInt32(restockquantity),
                        expectedDate = expectedDate,
                        supplierID=supplierID
                        
                    };
                else if (confirm == DialogResult.Yes && btn == "cancelbtn")
                    updateStatus = new RestockUpdate
                    {
                        restockRequestID = restockrequestID,
                        materialID = materialID,
                        restockStatus = "Cancelled",
                        restockQuantity = Convert.ToInt32(restockquantity),
                        updatedDate = DateTime.Now.ToString(),
                        expectedDate = expectedDate,
                        supplierID= supplierID
                    };
                //else if (confirm == DialogResult.Yes && btn == "btnEdit")
                //    updateStatus = new RestockUpdate
                //    {

                //    };
                else if (confirm == DialogResult.No) return;

                // 调用 API 更新数据库
                string result = await apiCaller.PostAPIResponse("/Supply/UpdateRestock?btnEvent=updateStatus", updateStatus);
                // 可在此调用 API 更新状态，如：/Supply/MarkRequestProcessed
                if (result != "0")
                {
                    MessageBox.Show("Order processed successfully!", "Done");

                    await LoadRequestsAsync();
                }
                else
                {
                    MessageBox.Show("Update failed. Please try again later.");
                }

            }

        }
       
        private async Task HandleEditRequest(int rowIndex)
        {
            var currentRow = dgvRequests.Rows[rowIndex];
            string restockID = currentRow.Cells["restockRequestID"].Value.ToString();
            string restockStatus = currentRow.Cells["restockStatus"].Value.ToString();
            string materialID = currentRow.Cells["materialID"].Value.ToString();


            // 获取当前值
            int currentQuantity = Convert.ToInt32(currentRow.Cells["restockQuantity"].Value);
            DateTime currentDate;
            DateTime.TryParse(currentRow.Cells["expectedDate"].Value.ToString(), out currentDate);

            // 创建编辑表单
            using (var editForm = new Form())
            {
                editForm.Text = "Edit Purchase Request";
                editForm.StartPosition = FormStartPosition.CenterParent;
                editForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                editForm.ClientSize = new Size(450, 320); // Slightly increased height for better spacing

                // Add title showing Restock ID and Material ID (centered)
                var lblTitle = new Label
                {
                    Text = $"Editing Request\nRequest ID: {restockID}\nMaterial ID: {materialID}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.DarkBlue,
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Width = 350,
                    Height = 80, // Increased height for 3-line text
                    Location = new Point((editForm.ClientSize.Width - 350) / 2, 25) // Moved down slightly
                };

                // Quantity controls (adjusted positions)
                var lblQuantity = new Label
                {
                    Text = "Quantity:",
                    Left = 50,
                    Top = 130,  // Increased from 100 to 130
                    AutoSize = true
                };

                var numQuantity = new NumericUpDown
                {
                    Left = 200,
                    Top = 128,
                    Width = 200,
                    Minimum = 1,
                    Maximum = decimal.MaxValue,
                    Value = currentQuantity
                };

                // Expected Date controls (adjusted positions)
                var lblExpectedDate = new Label
                {
                    Text = "Expected Date:",
                    Left = 50,
                    Top = 170,  
                    AutoSize = true
                };

                var dtpExpectedDate = new DateTimePicker
                {
                    Left = 200,
                    Top = 168,
                    Width = 200,
                    Value = currentDate,
                    MinDate = DateTime.Today
                };

                // Buttons (adjusted positions)
                var btnSave = new Button
                {
                    Text = "Save",
                    Left = (editForm.ClientSize.Width - 180) / 2,
                    Top = 230,  // Increased from 200 to 230
                    Width = 80,
                    DialogResult = DialogResult.OK
                };

                var btnCancel = new Button
                {
                    Text = "Cancel",
                    Left = (editForm.ClientSize.Width - 180) / 2 + 100,
                    Top = 230,  // Increased from 200 to 230
                    Width = 80,
                    DialogResult = DialogResult.Cancel
                };

                editForm.Controls.AddRange(new Control[] {
                lblTitle,
                lblQuantity, numQuantity,
                lblExpectedDate, dtpExpectedDate,
                btnSave, btnCancel
            });

                editForm.AcceptButton = btnSave;
                editForm.CancelButton = btnCancel;

                if (editForm.ShowDialog(this) == DialogResult.OK)
                {
                 
                    var updatedData = new RestockUpdate
                    {
                        restockRequestID = restockID,
                        materialID= materialID,
                        restockQuantity = (int)numQuantity.Value,
                        expectedDate = dtpExpectedDate.Value.ToString("yyyy-MM-dd"),
                        updatedDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        restockStatus = restockStatus 
                    };

                    // 调用API更新
                    string result = await apiCaller.PostAPIResponse("/Supply/UpdateRestock?btnEvent=edit", updatedData);

                    if (result != "0")
                    {
                        MessageBox.Show("Update succesefully！", "Done!");
                        await LoadRequestsAsync(); 
                    }
                    else
                    {
                        MessageBox.Show("Update，failed。", "Somthing Wrong");
                    }
                }
            }
        }
    }
}



#endregion
