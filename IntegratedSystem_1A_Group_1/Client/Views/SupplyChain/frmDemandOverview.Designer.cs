using Client.Controllers;
using Client.GenaralMethod;
using System.Data;
using System.Diagnostics;
using static EntityModels.Supplier;

namespace Client.Views.SupplyChain
{
    partial class frmDemandOverview
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
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "frmMaterialDemandOverview";
            Text = "frmMaterialDemandOverview";
            ResumeLayout(false);
            //Load += frmDemandOverview_Load;
        }
        #endregion

        private DataGridView dgvDemands;
        DatabaseApicaller apiCaller = new DatabaseApicaller();
        private TextBox txtSearch;
        private Button btnSearch;

        private void InitializeUI()
        {
            this.Text = "Material Demand Requests Overview";
            this.Size = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            // Title
            var lblTitle = new Label
            {
                Text = "Material Demand Requests Overview",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                AutoSize = true,
                Location = new Point(20, 20)
            };
            this.Controls.Add(lblTitle);

            // Search Controls
            txtSearch = new TextBox
            {
                Location = new Point(20, 65),
                Size = new Size(250, 35),
                Font = new Font("Segoe UI", 10F),
                PlaceholderText = "Search by Material ID or Name"
            };
            this.Controls.Add(txtSearch);

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
            btnSearch.Click += (s, e) => searchData(txtSearch.Text);
            this.Controls.Add(btnSearch);

            // Back Button
            var btnBack = new Button
            {
                Text = "Back",
                Size = new Size(100, 35),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.LightSlateGray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(this.ClientSize.Width - 120, 20),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            FormDesign.ClickEvent(btnBack, this);
            this.Controls.Add(btnBack);

            // DataGridView Setup
            dgvDemands = new DataGridView
            {
                Location = new Point(20, 110),
                Size = new Size(1200, 680),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Font = new Font("Segoe UI", 10F),
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    WrapMode = DataGridViewTriState.True
                }
            };

            //Define Columns
                var columnList = new List<(string, string)>
                {
                    ("Demand ID", "demandID"),
                    ("Receiver", "receiver"),
                    ("Material ID", "materialID"),
                    ("Material Name", "materialName"),
                    ("Quantity", "quantity"),
                    ("Expected Date", "expectedDate"),
                    ("Status", "status"),
                    ("Created At", "createdAt"),
                    ("Updated Date", "updatedAt")
                };

            FormDesign.AddColumnsToGrid(dgvDemands, columnList);

            // Add action buttons
            FormDesign.AddButtonColumn(dgvDemands, "processBtn", "Process", "Process Request");
            FormDesign.AddButtonColumn(dgvDemands, "cancelBtn", "Cancel", "Cancel", Color.MediumSeaGreen, Color.White);

            dgvDemands.CellContentClick += DgvDemands_CellContentClick;
            dgvDemands.CellFormatting += DgvDemands_CellFormatting;
            this.Controls.Add(dgvDemands);
            if (_currentMode == FormMode.ProductionView) dgvDemands.Columns["processBtn"].Visible = false;

            // Load data when form is shown

        }




        private void DgvDemands_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == dgvDemands.Columns["processBtn"].Index ||
                                   e.ColumnIndex == dgvDemands.Columns["cancelBtn"].Index))
            {
                var status = dgvDemands.Rows[e.RowIndex].Cells["status"].Value?.ToString();
                if (status == "COMPLETED" || status == "CANCELLED")
                {
                    e.CellStyle.BackColor = Color.Gray;
                    e.CellStyle.ForeColor = Color.DarkGray;
                }
            }
        }

        private async Task LoadDemandsAsync()
        {
            try
            {
                DataTable dt = await apiCaller.GetAPIResponse("/Supply/GetAllDemands");
                bindingSource.DataSource = dt;
                dgvDemands.DataSource = bindingSource;
                dgvDemands.ClearSelection();

                var disabledStatus = new List<string> { "COMPLETED", "CANCELLED" };
                FormDesign.DisableButtonsByStatus(dgvDemands, "processBtn", "status", disabledStatus);
                FormDesign.DisableButtonsByStatus(dgvDemands, "cancelBtn", "status", disabledStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load demand requests:\n" + ex.Message, "Error");
            }
        }
        private async void DgvDemands_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                (dgvDemands.Columns[e.ColumnIndex].Name != "processBtn" &&
                 dgvDemands.Columns[e.ColumnIndex].Name != "cancelBtn"))
            {
                return;
            }
            var status = dgvDemands.Rows[e.RowIndex].Cells["status"].Value?.ToString();
            if (status == "COMPLETED" || status == "CANCELLED")
            {
                MessageBox.Show($"This record is {status}.");
                return;
            }
            DemandUpdate updateStatus = null;
            if (e.RowIndex >= 0)
            {
                string demandID = dgvDemands.Rows[e.RowIndex].Cells["demandID"].Value.ToString();
                string materialID = dgvDemands.Rows[e.RowIndex].Cells["materialID"].Value.ToString();
                string materialName = dgvDemands.Rows[e.RowIndex].Cells["materialName"].Value.ToString();
                string quantity = dgvDemands.Rows[e.RowIndex].Cells["quantity"].Value.ToString();
                string btn = dgvDemands.Columns[e.ColumnIndex].Name;
                string actionname = (btn == "processBtn") ? "Completed" : "Cancelled";

                var confirm = MessageBox.Show(
                      $"Mark demand request '{demandID}' for '{materialName}' as {actionname}?",
                      "Confirm Process",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question
                      );
                if (confirm == DialogResult.Yes && btn == "processBtn")
                {
                    updateStatus = new DemandUpdate
                    {
                        demandID = demandID,
                        materialID = materialID,
                        status = "COMPLETED",
                        updatedAt = DateTime.Now.ToString("yyyy-MM-dd"),
                        quantity = Convert.ToInt32(quantity)
                    };
                    int current_quantity = 0;
                    DataTable dt = await apiCaller.GetAPIResponse($"Supply/GetData?tableName=rawmaterial&columns=*&cond=WHERE materialID='{materialID}'");
                    if( dt != null ) current_quantity =  Convert.ToInt32(dt.Rows[0]["inStockQuantity"]);
                    if(Convert.ToInt32(quantity)>current_quantity) { MessageBox.Show("Current stock quantity is not enough!"); return; }
                }
                if (confirm == DialogResult.Yes && btn == "cancelBtn")
                    updateStatus = new DemandUpdate
                    {
                        demandID = demandID,
                        materialID = materialID,
                        status = "CANCELLED",
                        quantity = Convert.ToInt32(quantity),
                        updatedAt = DateTime.Now.ToString("yyyy-MM-dd")
                    };
                else if (confirm == DialogResult.No) return;

                // 调用 API 更新数据库
                string result = await apiCaller.PostAPIResponse("/Supply/UpdateDemandStatus", updateStatus);
                // 可在此调用 API 更新状态，如：/Supply/MarkRequestProcessed
                if (result != "0")
                {
                    MessageBox.Show("Order processed successfully!", "Done");

                    await LoadDemandsAsync();
                }
                else
                {
                    MessageBox.Show("Update failed. Please try again later.");
                }

            }

        }

    }
}

    
   