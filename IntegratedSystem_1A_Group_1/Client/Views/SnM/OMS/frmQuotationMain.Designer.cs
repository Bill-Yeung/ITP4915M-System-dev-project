namespace Client.Views.SnM.OMS
{
    partial class frmQuotationMain
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
            dgvQuotation = new DataGridView();
            flowLayoutButton = new FlowLayoutPanel();
            btnCreate = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnGenerate = new Button();
            btnConvert = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnReset = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnRefresh = new Button();
            tableMain.SuspendLayout();
            tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQuotation).BeginInit();
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
            tableMain.Size = new Size(1707, 985);
            tableMain.TabIndex = 0;
            // 
            // tableLayout
            // 
            tableLayout.ColumnCount = 1;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayout.Controls.Add(lblheader, 0, 0);
            tableLayout.Controls.Add(dgvQuotation, 0, 2);
            tableLayout.Controls.Add(flowLayoutButton, 0, 3);
            tableLayout.Controls.Add(tableLayoutPanel1, 0, 1);
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.Location = new Point(173, 101);
            tableLayout.Name = "tableLayout";
            tableLayout.RowCount = 4;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 95F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 95F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 95F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayout.Size = new Size(1359, 782);
            tableLayout.TabIndex = 0;
            // 
            // lblheader
            // 
            lblheader.AutoSize = true;
            lblheader.Dock = DockStyle.Fill;
            lblheader.Font = new Font("Arial", 16.2F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblheader.Location = new Point(3, 0);
            lblheader.Name = "lblheader";
            lblheader.Size = new Size(1353, 95);
            lblheader.TabIndex = 0;
            lblheader.Text = "Sales && Marketing - Quotation";
            lblheader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvQuotation
            // 
            dgvQuotation.AllowUserToAddRows = false;
            dgvQuotation.AllowUserToDeleteRows = false;
            dgvQuotation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuotation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQuotation.Dock = DockStyle.Fill;
            dgvQuotation.Location = new Point(3, 193);
            dgvQuotation.Name = "dgvQuotation";
            dgvQuotation.ReadOnly = true;
            dgvQuotation.RowHeadersWidth = 51;
            dgvQuotation.Size = new Size(1353, 491);
            dgvQuotation.TabIndex = 2;
            // 
            // flowLayoutButton
            // 
            flowLayoutButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutButton.AutoSize = true;
            flowLayoutButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutButton.Controls.Add(btnCreate);
            flowLayoutButton.Controls.Add(btnEdit);
            flowLayoutButton.Controls.Add(btnDelete);
            flowLayoutButton.Controls.Add(btnGenerate);
            flowLayoutButton.Controls.Add(btnConvert);
            flowLayoutButton.Location = new Point(3, 710);
            flowLayoutButton.Name = "flowLayoutButton";
            flowLayoutButton.Size = new Size(1353, 49);
            flowLayoutButton.TabIndex = 3;
            flowLayoutButton.WrapContents = false;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.Moccasin;
            btnCreate.Location = new Point(26, 0);
            btnCreate.Margin = new Padding(26, 0, 0, 0);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(201, 49);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Create Quotation";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Moccasin;
            btnEdit.Location = new Point(267, 0);
            btnEdit.Margin = new Padding(40, 0, 0, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(240, 49);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "View / Edit Quotation";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Moccasin;
            btnDelete.Location = new Point(547, 0);
            btnDelete.Margin = new Padding(40, 0, 0, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(207, 49);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete Quotation";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.Moccasin;
            btnGenerate.Location = new Point(794, 0);
            btnGenerate.Margin = new Padding(40, 0, 0, 0);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(228, 49);
            btnGenerate.TabIndex = 3;
            btnGenerate.Text = "Generate Quotation";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnConvert
            // 
            btnConvert.BackColor = Color.Moccasin;
            btnConvert.Location = new Point(1062, 0);
            btnConvert.Margin = new Padding(40, 0, 0, 0);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(295, 49);
            btnConvert.TabIndex = 4;
            btnConvert.Text = "Convert Quotation to Order";
            btnConvert.UseVisualStyleBackColor = false;
            btnConvert.Click += btnConvert_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 106F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 106F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 106F));
            tableLayoutPanel1.Controls.Add(btnReset, 2, 0);
            tableLayoutPanel1.Controls.Add(txtSearch, 0, 0);
            tableLayoutPanel1.Controls.Add(btnSearch, 1, 0);
            tableLayoutPanel1.Controls.Add(btnRefresh, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 98);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1353, 89);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnReset.Location = new Point(1144, 26);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(100, 36);
            btnReset.TabIndex = 0;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(3, 27);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by keywords ...";
            txtSearch.Size = new Size(1029, 34);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnSearch.Location = new Point(1038, 24);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 40);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnRefresh.Location = new Point(1250, 26);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 36);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // frmQuotationMain
            // 
            AutoScaleDimensions = new SizeF(12F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1707, 985);
            Controls.Add(tableMain);
            Name = "frmQuotationMain";
            Text = "Integrated System";
            Load += frmPSSMain_Load;
            tableMain.ResumeLayout(false);
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQuotation).EndInit();
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
        private DataGridView dgvQuotation;
        private FlowLayoutPanel flowLayoutButton;
        private Button btnCreate;
        private Button btnEdit;
        private Button btnDelete;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnReset;
        private Button btnSearch;
        private Button btnRefresh;
        private Button btnGenerate;
        private Button btnConvert;
    }
}