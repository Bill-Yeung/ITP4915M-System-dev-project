using Client.GenaralMethod;
using static EntityModels.Supplier;
using static EntityModels.Material;
using System.Diagnostics;

namespace Client.Views.SupplyChain
{
    partial class frmMaterialOverview
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "frmMaterialOverview";
            Load += frmMaterialOverview_Load;
            ResumeLayout(false);
        }
        private DataGridView dgvMaterials;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnViewDemandDetails;
        private Button btnViewRestockDetails;
        private Button btnViewStockMovement;
        private Button btnBack;

        private void InitializeDynamicComponents()
        {
            
            // Form settings
            this.Text = "Material Overview";
            this.ClientSize = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9F);

            // Title label
            var lblTitle = new Label
            {
                Text = "Material Overview",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            // Search box
            txtSearch = new TextBox
            {
                Location = new Point(20, 80),
                Size = new Size(300, 35),
                PlaceholderText = "Search by material name or ID"
            };
            this.Controls.Add(txtSearch);

            // Search button
            btnSearch = new Button
            {
                Text = "Search",
                Location = new Point(330, 80),
                Size = new Size(80, 30),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSearch.Click += (s, e) => searchData(txtSearch.Text);
            this.Controls.Add(btnSearch);
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    searchData(txtSearch.Text);
                    e.Handled = e.SuppressKeyPress = true;
                }
            };


            // Data grid view
            dgvMaterials = new DataGridView
            {
                Location = new Point(20, 120),
                Size = new Size(960, 400),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
                         AnchorStyles.Left | AnchorStyles.Right,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                CellBorderStyle = DataGridViewCellBorderStyle.None,
                GridColor = Color.LightGray,
               
            };

            // Add columns
            //dgvMaterials.Columns.Add("MaterialID", "Material ID");
            dgvMaterials.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaterialID",
                HeaderText = "Material ID",
                DataPropertyName = "materialID",
                ReadOnly = true
            });
            //dgvMaterials.Columns.Add("MaterialName", "Name");
            dgvMaterials.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaterialName",
                HeaderText = "Name",
                DataPropertyName = "materialName",
                ReadOnly = true
            });
            //dgvMaterials.Columns.Add("CurrentStock", "Current Stock");
            dgvMaterials.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CurrentStock",
                HeaderText = "Current Stock",
                DataPropertyName = "inStockQuantity",
                ReadOnly = true
            });
            dgvMaterials.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "price",
                HeaderText = "Unit Price",
                DataPropertyName = "price",
                ReadOnly = true
            });
            //dgvMaterials.Columns.Add("RequestedQty", "Requested Qty");
            dgvMaterials.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RequestQty",
                HeaderText = "Demand_QTY(For Production)",
                DataPropertyName = "totalDemandRequested",
                ReadOnly = true
            });
            //dgvMaterials.Columns.Add("RestockQty", "Restock Qty");
            dgvMaterials.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RestockQty",
                HeaderText = "Restock_QTY(To Supplier)",
                DataPropertyName = "totalRestockRequested",
                ReadOnly = true
            });
            dgvMaterials.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StockStatus",
                HeaderText = "StockStatus",
                DataPropertyName = "stockStatus",
                ReadOnly = true
            });
            dgvMaterials.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "createAt",
                HeaderText = "Create At",
                DataPropertyName = "createAt",
                ReadOnly = true
            });
            dgvMaterials.AutoGenerateColumns = false;


            // Action button column
            var actionCol = new DataGridViewButtonColumn
            {
                Name = "Action",
                HeaderText = "Action",
                Text = "View Details",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.SteelBlue,
                    ForeColor = Color.White
                }
            };
            dgvMaterials.Columns.Add(actionCol);
           
            dgvMaterials.Columns["Action"].DisplayIndex = dgvMaterials.Columns.Count - 1;

            //dgvMaterials.CellFormatting += DgvMaterials_CellFormatting;
            dgvMaterials.CellContentClick += DgvMaterials_CellContentClick;

            this.Controls.Add(dgvMaterials);
            AddActionButtons();
        }
        private void AddActionButtons()
        {
            int buttonY = dgvMaterials.Bottom + 20;
            int buttonWidth = 200;
            int buttonSpacing = 20;
            //int buttonWidth = 120;
            int buttonHeight = 30;
            //int buttonSpacing = 10;
            int rightMargin = 20;

            btnViewDemandDetails = CreateStyledButton(
                "View Material Demand Details",
                20, buttonY, buttonWidth
            );
            //btnViewDemandDetails.Click += BtnViewDemandDetails_Click;
            this.Controls.Add(btnViewDemandDetails);
            btnViewDemandDetails.Click += (s, e) => new frmDemandOverview(frmDemandOverview.FormMode.ManagerView).ShowDialog();

            btnViewRestockDetails = CreateStyledButton(
                "View Restock Requests",
                btnViewDemandDetails.Right + buttonSpacing, buttonY, buttonWidth
            );
            //btnViewRestockDetails.Click += BtnViewRestockDetails_Click;
            this.Controls.Add(btnViewRestockDetails);
            btnViewRestockDetails.Click += (sender, e) => new frmForSupplier(frmForSupplier.FormMode.ManagerView).ShowDialog();

            var btnHome = new Button
            {
                Text = "Show All",
                Size = new Size(buttonWidth-70, buttonHeight+10),
                Location = new Point(ClientSize.Width - buttonWidth - rightMargin+50, buttonY-500),
                BackColor = Color.LightSeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold)
            };
            btnHome.Click += (s, e) => { new frmMaterialOverview().Show();};
            //btnHome.Click += frmMaterialOverview_Load;

            this.Controls.Add(btnHome);

            // Add Material按钮
            var btnAddMaterial = new Button
            {
                Text = "+ Material",
                Size = new Size(buttonWidth-70, buttonHeight+10),
                Location = new Point(btnHome.Left - buttonWidth+50, buttonY-500),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold)
            };
            btnAddMaterial.Click += (s, e) => { new frmAddMaterial().ShowDialog(); };
            this.Controls.Add(btnAddMaterial);

            btnViewStockMovement = CreateStyledButton(
                "View Delivery Requests",
                btnViewRestockDetails.Right + buttonSpacing, buttonY, buttonWidth
            );
            //btnViewStockMovement.Click += BtnViewStockMovement_Click;
            this.Controls.Add(btnViewStockMovement);
            btnViewStockMovement.Click += (sender, e) => new frmDelivery().ShowDialog();

            btnBack = CreateStyledButton(
                 "Back",
                 btnViewStockMovement.Right + buttonSpacing+100, buttonY, buttonWidth-35
             );
            FormDesign.ClickEvent(btnBack,this) ;
            this.Controls.Add(btnBack);
        }

        private Button CreateStyledButton(string text, int x, int y, int width = 300, int height = 40)
        {
            return new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = Color.LightSteelBlue,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
        }
        private async void DgvMaterials_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMaterials.Columns[e.ColumnIndex].Name == "Action")
            {
                //var currentRow = dgvMaterials.Rows[e.RowIndex];
                await ViewEditRequest(e.RowIndex);
              
            }
        }
        private async Task ViewEditRequest(int rowIndex)
        {
            var currentRow = dgvMaterials.Rows[rowIndex];
            string materialID = currentRow.Cells["materialID"].Value.ToString();
         
            var dt = await apiCaller.GetAPIResponse($"Supply/GetData?tableName=rawmaterial&columns=*&cond=WHERE materialID='{materialID}'");
            string materialName = dt.Rows[0]["materialName"].ToString();
            int inStockQuantity = Convert.ToInt32(dt.Rows[0]["inStockQuantity"]);
            string unit = dt.Rows[0]["unit"].ToString();
            int lowLevelAlertIndex = Convert.ToInt32(dt.Rows[0]["lowLevelAlertIndex"]);
            string stockStatus = dt.Rows[0]["stockStatus"].ToString();
            decimal price = Convert.ToDecimal(dt.Rows[0]["price"]);
            //string createAt = dt.Rows[0]["createAt"].ToString();
            string createdAt = dt.Rows[0]["createdAt"].ToString();
         
            using (var editForm = new Form())
            {
                editForm.Text = "View / Edit Material Details";
                editForm.StartPosition = FormStartPosition.CenterParent;
                editForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                editForm.ClientSize = new Size(550, 500); // Adjusted for all controls
                editForm.MinimizeBox = false;
                editForm.MaximizeBox = false;

                // 标题（带Material ID）
                var lblTitle = new Label
                {
                    Text = $"Material Information: {materialID}",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.DarkBlue,
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Width = 450,
                    Height = 40,
                    Location = new Point((editForm.ClientSize.Width - 450) / 2, 20)
                };

                // 字段布局（两列式）
                int leftCol1 = 50;
                int leftCol2 = 300;
                int topStart = 70;
                int rowHeight = 30;

                // Material Name（可编辑）
                var lblMaterialName = new Label
                {
                    Text = "Material Name:",
                    Location = new Point(leftCol1, topStart),
                    AutoSize = true
                };
                var txtMaterialName = new TextBox
                {
                    Location = new Point(leftCol1, topStart + rowHeight),
                    Width = 200,
                    Text = materialName
                };

               
                var lblUnit = new Label
                {
                    Text = "Unit:",
                    Location = new Point(leftCol2, topStart),
                    AutoSize = true
                };
                var txtUnit = new TextBox
                {
                    Location = new Point(leftCol2, topStart + rowHeight),
                    Width = 200,
                    Text = unit
                };

                // InStock Quantity（只读）
                var lblQuantity = new Label
                {
                    Text = "InStock Quantity:",
                    Location = new Point(leftCol1, topStart + rowHeight * 3),
                    AutoSize = true
                };
                var txtQuantity = new TextBox
                {
                    Location = new Point(leftCol1, topStart + rowHeight * 4),
                    Width = 200,
                    Text = inStockQuantity.ToString(),
                    ReadOnly = true,
                    BackColor = SystemColors.Control
                };

                // Low Level Alert（可编辑）
                var lblLowLevelAlert = new Label
                {
                    Text = "Low Level Alert:",
                    Location = new Point(leftCol2, topStart + rowHeight * 3),
                    AutoSize = true
                };
                var numLowLevelAlert = new NumericUpDown
                {
                    Location = new Point(leftCol2, topStart + rowHeight * 4),
                    Width = 200,
                    Minimum = 0,
                    Maximum = decimal.MaxValue,
                    Value = lowLevelAlertIndex
                };

                // Stock Status（只读）
                var lblStockStatus = new Label
                {
                    Text = "Stock Status:",
                    Location = new Point(leftCol1, topStart + rowHeight * 6),
                    AutoSize = true
                };
                var txtStockStatus = new TextBox
                {
                    Location = new Point(leftCol1, topStart + rowHeight * 7),
                    Width = 200,
                    Text = stockStatus,
                    ReadOnly = true,
                    BackColor = SystemColors.Control
                };

                // Price（可编辑）
                var lblPrice = new Label
                {
                    Text = "Price:",
                    Location = new Point(leftCol2, topStart + rowHeight * 6),
                    AutoSize = true
                };
                var txtPrice = new TextBox
                {
                    Location = new Point(leftCol2, topStart + rowHeight * 7),
                    Width = 200,
                    Text = price.ToString()
                };

                // Created At（只读）
                var lblCreatedAt = new Label
                {
                    Text = "Created At:",
                    Location = new Point(leftCol1, topStart + rowHeight * 9),
                    AutoSize = true
                };
                var txtCreatedAt = new TextBox
                {
                    Location = new Point(leftCol1, topStart + rowHeight * 10),
                    Width = 200,
                    Text = createdAt.ToString(),
                    ReadOnly = true,
                    BackColor = SystemColors.Control
                };

                // 按钮（底部居中）
                var btnSave = new Button
                {
                    Text = "Save",
                    Size = new Size(100, 30),
                    Location = new Point(editForm.ClientSize.Width / 2 - 110, editForm.ClientSize.Height - 60),
                    DialogResult = DialogResult.OK
                };

                var btnCancel = new Button
                {
                    Text = "Cancel",
                    Size = new Size(100, 30),
                    Location = new Point(editForm.ClientSize.Width / 2 + 10, editForm.ClientSize.Height - 60),
                    DialogResult = DialogResult.Cancel
                };

                // 添加所有控件
                editForm.Controls.AddRange(new Control[] {
                    lblTitle,
                    lblMaterialName, txtMaterialName,
                    lblUnit, txtUnit,
                    lblQuantity, txtQuantity,
                    lblLowLevelAlert, numLowLevelAlert,
                    lblStockStatus, txtStockStatus,
                    lblPrice, txtPrice,
                    lblCreatedAt, txtCreatedAt,
                    btnSave, btnCancel
                  });

                editForm.AcceptButton = btnSave;
                editForm.CancelButton = btnCancel;

                if (editForm.ShowDialog(this) == DialogResult.OK)
                {

                    var updatedData = new Material2
                    {
                        materialID = materialID,
                        materialName = txtMaterialName.Text.ToString(),
                        inStockQuantity = Convert.ToInt32(txtQuantity.Text.ToString()),
                        unit = txtUnit.Text.ToString(),
                        lowLevelAlertIndex = Convert.ToInt32(numLowLevelAlert.Value),
                        stockStatus = txtStockStatus.Text.ToString(),
                        price = Convert.ToDecimal(txtPrice.Text.ToString()),
                        createAt = createdAt.ToString()
                     
                    };

                    // 调用API更新
                    string result = await apiCaller.PostAPIResponse("/Supply/UpdateMaterial", updatedData);

                    if (result != "0")
                    {
                        MessageBox.Show("Update succesefully！", "Done!");
                        //await LoadRequestsAsync();
                    }
                    else
                    {
                        MessageBox.Show("Update，failed。", "Somthing Wrong");
                    }
                }
            }
        }
        #endregion
    }
}