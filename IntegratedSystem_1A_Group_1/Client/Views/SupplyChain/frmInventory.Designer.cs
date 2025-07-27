using Client.GenaralMethod;
using System.Data;

namespace Client.Views.SupplyChain
{
    partial class frmInventory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
    
        private DataGridView dgvInventory;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnInboundRecord;
        private Button btnOutboundRecord;
        private Button btnHome;
        private Button btnBack;

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
            this.ClientSize = new System.Drawing.Size(1000,600);
            this.Text = "Inventory Management";
            InitializeDynamicComponents();
            //Load += new System.EventHandler(this.frmInventoryManagement_Load);
            
            ResumeLayout(false);
        }
        private Label lblTitle;
        private void InitializeDynamicComponents()
        {
            // Form settings
            this.Text = "Inventory Management";
            this.ClientSize = new Size(1500, 850); // 宽度1500，高度微调至850
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10F); // 基础字体增大

          
            lblTitle = new Label
            {
                Text = "INVENTORY MANAGEMENT",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                AutoSize = true
            };

            lblTitle.Location = new Point((this.ClientSize.Width - lblTitle.Width) / 2, 25);
            this.Controls.Add(lblTitle);

            // Search box - 超长搜索框
            txtSearch = new TextBox
            {
                Location = new Point(40, 90),
                Size = new Size(600, 40), // 大幅加宽            
                PlaceholderText = "Search by item ID or name...",
                Font = new Font("Segoe UI", 11F) // 搜索框字体增大
            };
            this.Controls.Add(txtSearch);

            // Search button - 放大
            btnSearch = new Button
            {
                Text = "SEARCH",
                Location = new Point(650, 90),
                Size = new Size(120, 40),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnSearch.Click += (s, e) =>
            {
                if (lblTitle.Text == "INVENTORY MANAGEMENT") searchData(txtSearch.Text, new string[] { "MaterialID", "MaterialName", "stockStatus" });
                else if (lblTitle.Text == "INBOUND RECORD") searchData(txtSearch.Text, new string[] { "MaterialID", "MaterialName","SupplierID","SupplierName"});
                else if (lblTitle.Text == "OUTBOUND RECORD") searchData(txtSearch.Text, new string[] { "MaterialID", "MaterialName","Destination"});
            };
                    this.Controls.Add(btnSearch);

            // 回车搜索功能
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (lblTitle.Text == "INVENTORY MANAGEMENT") searchData(txtSearch.Text, new string[] { "MaterialID", "MaterialName", "stockStatus" });
                    else if (lblTitle.Text == "INBOUND RECORD") searchData(txtSearch.Text, new string[] { "MaterialID", "MaterialName","SupplierID", "SupplierName" });
                    else if (lblTitle.Text == "OUTBOUND RECORD") searchData(txtSearch.Text, new string[] { "MaterialID", "MaterialName","Destination" });
                }
            };
            Button btnShowAll = new Button
            {
                Text = "SHOW ALL",
                Size = new Size(150, 40), // 稍宽更显眼
                Location = new Point(this.ClientSize.Width - 190, 90), // 距右边190px
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right // 添加锚点确保窗口调整时位置不变
            };
            btnShowAll.Click += (s, e) => new frmInventory().Show();
            this.Controls.Add(btnShowAll);

            // Data grid view - 超宽数据表格
            dgvInventory = new DataGridView
            {
                Location = new Point(40, 150),
                Size = new Size(1420, 550), // 宽度1420(留出边距)
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeight = 40, // 加高表头
                RowTemplate = { Height = 35 }, // 加高行
                ScrollBars = ScrollBars.Both, // 确保滚动条
                Font = new Font("Segoe UI", 10F) // 表格字体增大
            };

            // Highlight low stock items
            //dgvInventory.RowPrePaint += (s, e) =>
            //{
            //    if (Convert.ToBoolean(dgvInventory.Rows[e.RowIndex].Cells["AlertLevel"].Value.ToString()=="LOW_STOCK"))
            //    {
            //        dgvInventory.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
            //    }
            //};

            this.Controls.Add(dgvInventory);
            AddActionButtons();
        }

        private void addDgvButtonColumn()
        {
            if(!dgvInventory.Columns.Contains("btnAction"))
            {
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.Name = "btnAction";
                buttonColumn.HeaderText = "Action";
                buttonColumn.Text = "Restock Request";
                buttonColumn.UseColumnTextForButtonValue = true;
                dgvInventory.Columns.Add(buttonColumn);
            }
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            //new frmRestock().ShowDialog();
            var materialID = dgvInventory.Rows[e.RowIndex].Cells["MaterialID"].Value.ToString();
            new frmRestock().ShowDialog();
        }

        private void AddActionButtons()
        {
            int buttonY = dgvInventory.Bottom + 20;
            int buttonWidth = 180;
            int buttonSpacing = 15;

            btnInboundRecord = CreateStyledButton(
                "INBOUND RECORD",
                20, buttonY, buttonWidth
            );
            btnInboundRecord.Click += (s, e) => ShowInboundRecords();
            this.Controls.Add(btnInboundRecord);

            btnOutboundRecord = CreateStyledButton(
                "OUTBOUND RECORD",
                btnInboundRecord.Right + buttonSpacing, buttonY, buttonWidth
            );
            btnOutboundRecord.Click += (s, e) => ShowOutboundRecords();
            this.Controls.Add(btnOutboundRecord);

            btnHome = CreateStyledButton(
                "INVENTORY",
                btnOutboundRecord.Right + buttonSpacing, buttonY, buttonWidth 
            );
            btnHome.Click += (s, e) => new frmInventory().ShowDialog();
            this.Controls.Add(btnHome);

            btnBack = CreateStyledButton(
                "BACK",
                btnHome.Right + buttonSpacing+560 , buttonY, buttonWidth-40 
            );
            FormDesign.ClickEvent(btnBack, this);
            this.Controls.Add(btnBack);
        }

        private Button CreateStyledButton(string text, int x, int y, int width = 180, int height = 40)
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

     
        #endregion
    }
}