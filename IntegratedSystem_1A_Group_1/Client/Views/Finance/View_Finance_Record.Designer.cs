using System.Windows.Forms;

namespace Client.Views.Finance
{
    partial class View_Finance_Record
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            LblStartDate = new Label();
            DTPStartDate = new DateTimePicker();
            LblEndDate = new Label();
            DTPEndDate = new DateTimePicker();
            BtnSearch = new Button();
            BtnReset = new Button();
            LblTitle = new Label();
            financeDatadgv = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)financeDatadgv).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.846154F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 92.30769F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.84615374F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(LblTitle, 1, 0);
            tableLayoutPanel1.Controls.Add(financeDatadgv, 1, 2);
            tableLayoutPanel1.Location = new Point(8, 0);
            tableLayoutPanel1.Margin = new Padding(1, 2, 1, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.Size = new Size(1033, 607);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 6;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.0829544F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.13826F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.0829563F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.13826F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.0553036F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.502263F));
            tableLayoutPanel2.Controls.Add(LblStartDate, 0, 0);
            tableLayoutPanel2.Controls.Add(DTPStartDate, 1, 0);
            tableLayoutPanel2.Controls.Add(LblEndDate, 2, 0);
            tableLayoutPanel2.Controls.Add(DTPEndDate, 3, 0);
            tableLayoutPanel2.Controls.Add(BtnSearch, 4, 0);
            tableLayoutPanel2.Controls.Add(BtnReset, 5, 0);
            tableLayoutPanel2.Location = new Point(40, 93);
            tableLayoutPanel2.Margin = new Padding(1, 2, 1, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(951, 26);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // LblStartDate
            // 
            LblStartDate.Anchor = AnchorStyles.None;
            LblStartDate.AutoSize = true;
            LblStartDate.Location = new Point(41, 5);
            LblStartDate.Margin = new Padding(1, 0, 1, 0);
            LblStartDate.Name = "LblStartDate";
            LblStartDate.Size = new Size(61, 15);
            LblStartDate.TabIndex = 0;
            LblStartDate.Text = "Start Date:";
            // 
            // DTPStartDate
            // 
            DTPStartDate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DTPStartDate.Location = new Point(144, 2);
            DTPStartDate.Margin = new Padding(1, 2, 1, 2);
            DTPStartDate.Name = "DTPStartDate";
            DTPStartDate.Size = new Size(237, 23);
            DTPStartDate.TabIndex = 2;
            // 
            // LblEndDate
            // 
            LblEndDate.Anchor = AnchorStyles.None;
            LblEndDate.AutoSize = true;
            LblEndDate.Location = new Point(425, 5);
            LblEndDate.Margin = new Padding(1, 0, 1, 0);
            LblEndDate.Name = "LblEndDate";
            LblEndDate.Size = new Size(57, 15);
            LblEndDate.TabIndex = 1;
            LblEndDate.Text = "End Date:";
            // 
            // DTPEndDate
            // 
            DTPEndDate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DTPEndDate.Location = new Point(526, 2);
            DTPEndDate.Margin = new Padding(1, 2, 1, 2);
            DTPEndDate.Name = "DTPEndDate";
            DTPEndDate.Size = new Size(237, 23);
            DTPEndDate.TabIndex = 3;
            // 
            // BtnSearch
            // 
            BtnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BtnSearch.Location = new Point(765, 2);
            BtnSearch.Margin = new Padding(1, 2, 1, 2);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(93, 22);
            BtnSearch.TabIndex = 4;
            BtnSearch.Text = "Search";
            BtnSearch.UseVisualStyleBackColor = true;
            BtnSearch.Click += BtnSearch_Click;
            // 
            // BtnReset
            // 
            BtnReset.Location = new Point(862, 3);
            BtnReset.Name = "BtnReset";
            BtnReset.Size = new Size(76, 20);
            BtnReset.TabIndex = 5;
            BtnReset.Text = "Reset";
            BtnReset.UseVisualStyleBackColor = true;
            BtnReset.Click += BtnReset_Click;
            // 
            // LblTitle
            // 
            LblTitle.Anchor = AnchorStyles.None;
            LblTitle.AutoSize = true;
            LblTitle.Font = new Font("Segoe UI", 20F);
            LblTitle.Location = new Point(376, 27);
            LblTitle.Margin = new Padding(1, 0, 1, 0);
            LblTitle.Name = "LblTitle";
            LblTitle.Size = new Size(279, 37);
            LblTitle.TabIndex = 1;
            LblTitle.Text = "View Finance Records ";
            LblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // financeDatadgv
            // 
            financeDatadgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            financeDatadgv.Location = new Point(40, 123);
            financeDatadgv.Margin = new Padding(1, 2, 1, 2);
            financeDatadgv.Name = "financeDatadgv";
            financeDatadgv.RowHeadersWidth = 62;
            financeDatadgv.Size = new Size(948, 482);
            financeDatadgv.TabIndex = 2;
            // 
            // View_Finance_Record
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1042, 614);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(1, 2, 1, 2);
            Name = "View_Finance_Record";
            Text = "View_Finance_Record";
            Load += View_Finance_Record_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)financeDatadgv).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label LblTitle;
        private DataGridView financeDatadgv;
        private Label LblStartDate;
        private Label LblEndDate;
        private DateTimePicker DTPEndDate;
        private DateTimePicker DTPStartDate;
        private Button BtnSearch;
        private Button BtnReset;
    }
}