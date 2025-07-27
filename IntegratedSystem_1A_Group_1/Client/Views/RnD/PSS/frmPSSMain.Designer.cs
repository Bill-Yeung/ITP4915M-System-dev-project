namespace Client.Views.RnD.PSS
{
    partial class frmPSSMain
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
            tableMain = new TableLayoutPanel();
            tableLayout = new TableLayoutPanel();
            lblheader = new Label();
            dgvProduct = new DataGridView();
            flowLayoutButton = new FlowLayoutPanel();
            btnCreate = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnReset = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnRefresh = new Button();
            tableMain.SuspendLayout();
            tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProduct).BeginInit();
            flowLayoutButton.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableMain
            // 
            tableMain.ColumnCount = 3;
            tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableMain.Controls.Add(tableLayout, 1, 1);
            tableMain.Dock = DockStyle.Fill;
            tableMain.Location = new Point(0, 0);
            tableMain.Margin = new Padding(0);
            tableMain.Name = "tableMain";
            tableMain.RowCount = 3;
            tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableMain.Size = new Size(1280, 720);
            tableMain.TabIndex = 0;
            // 
            // tableLayout
            // 
            tableLayout.ColumnCount = 1;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayout.Controls.Add(lblheader, 0, 0);
            tableLayout.Controls.Add(dgvProduct, 0, 2);
            tableLayout.Controls.Add(flowLayoutButton, 0, 3);
            tableLayout.Controls.Add(tableLayoutPanel1, 0, 1);
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.Location = new Point(131, 75);
            tableLayout.Name = "tableLayout";
            tableLayout.RowCount = 4;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayout.Size = new Size(1018, 570);
            tableLayout.TabIndex = 0;
            // 
            // lblheader
            // 
            lblheader.AutoSize = true;
            lblheader.Dock = DockStyle.Fill;
            lblheader.Font = new Font("Arial", 16.2F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblheader.Location = new Point(3, 0);
            lblheader.Name = "lblheader";
            lblheader.Size = new Size(1012, 70);
            lblheader.TabIndex = 0;
            lblheader.Text = "Research && Development - Product Specification";
            lblheader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvProduct
            // 
            dgvProduct.AllowUserToAddRows = false;
            dgvProduct.AllowUserToDeleteRows = false;
            dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProduct.Dock = DockStyle.Fill;
            dgvProduct.Location = new Point(3, 143);
            dgvProduct.Name = "dgvProduct";
            dgvProduct.ReadOnly = true;
            dgvProduct.RowHeadersWidth = 51;
            dgvProduct.Size = new Size(1012, 354);
            dgvProduct.TabIndex = 2;
            // 
            // flowLayoutButton
            // 
            flowLayoutButton.Anchor = AnchorStyles.None;
            flowLayoutButton.Controls.Add(btnCreate);
            flowLayoutButton.Controls.Add(btnEdit);
            flowLayoutButton.Controls.Add(btnDelete);
            flowLayoutButton.Location = new Point(51, 512);
            flowLayoutButton.Name = "flowLayoutButton";
            flowLayoutButton.Size = new Size(915, 45);
            flowLayoutButton.TabIndex = 3;
            // 
            // btnCreate
            // 
            btnCreate.Anchor = AnchorStyles.None;
            btnCreate.BackColor = Color.Moccasin;
            btnCreate.Location = new Point(120, 3);
            btnCreate.Margin = new Padding(120, 3, 3, 3);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(146, 35);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Create Product";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.None;
            btnEdit.BackColor = Color.Moccasin;
            btnEdit.Location = new Point(369, 3);
            btnEdit.Margin = new Padding(100, 3, 3, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(173, 35);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "View / Edit Product";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.None;
            btnDelete.BackColor = Color.Moccasin;
            btnDelete.Location = new Point(645, 3);
            btnDelete.Margin = new Padding(100, 3, 3, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(157, 35);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete Product";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.Controls.Add(btnReset, 2, 0);
            tableLayoutPanel1.Controls.Add(txtSearch, 0, 0);
            tableLayoutPanel1.Controls.Add(btnSearch, 1, 0);
            tableLayoutPanel1.Controls.Add(btnRefresh, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 73);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1012, 64);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnReset.Location = new Point(855, 18);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(74, 27);
            btnReset.TabIndex = 0;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(3, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by keywords ...";
            txtSearch.Size = new Size(766, 27);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnSearch.Location = new Point(775, 17);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(74, 29);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnRefresh.Location = new Point(935, 18);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(74, 27);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // frmPSSMain
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1280, 720);
            Controls.Add(tableMain);
            Name = "frmPSSMain";
            Text = "Integrated System";
            Load += frmPSSMain_Load;
            tableMain.ResumeLayout(false);
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProduct).EndInit();
            flowLayoutButton.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableMain;
        private TableLayoutPanel tableLayout;
        private Label lblheader;
        private TextBox txtSearch;
        private DataGridView dgvProduct;
        private FlowLayoutPanel flowLayoutButton;
        private Button btnCreate;
        private Button btnEdit;
        private Button btnDelete;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnReset;
        private Button btnSearch;
        private Button btnRefresh;
    }
}