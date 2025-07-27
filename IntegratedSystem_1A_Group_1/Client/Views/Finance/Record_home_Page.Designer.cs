namespace Client.Views.Finance
{
    partial class Record_home_Page
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
            CashFlowBtn = new Button();
            CashFlowLbl = new Label();
            ViewRecordLbl = new Label();
            UpdateBtn = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.5090122F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.2998352F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6.062261F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.0852F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(CashFlowBtn, 3, 2);
            tableLayoutPanel1.Controls.Add(CashFlowLbl, 3, 3);
            tableLayoutPanel1.Controls.Add(ViewRecordLbl, 1, 3);
            tableLayoutPanel1.Controls.Add(UpdateBtn, 1, 2);
            tableLayoutPanel1.Location = new Point(-6, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.4360137F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 43.94111F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25.821064F));
            tableLayoutPanel1.Size = new Size(1831, 883);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // CashFlowBtn
            // 
            CashFlowBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CashFlowBtn.Location = new Point(1026, 270);
            CashFlowBtn.Name = "CashFlowBtn";
            CashFlowBtn.Size = new Size(435, 381);
            CashFlowBtn.TabIndex = 1;
            CashFlowBtn.Click += CashFlowBtn_Click;
            // 
            // CashFlowLbl
            // 
            CashFlowLbl.Anchor = AnchorStyles.Top;
            CashFlowLbl.AutoSize = true;
            CashFlowLbl.Font = new Font("Segoe UI", 15F);
            CashFlowLbl.Location = new Point(1187, 654);
            CashFlowLbl.Name = "CashFlowLbl";
            CashFlowLbl.Size = new Size(112, 41);
            CashFlowLbl.TabIndex = 2;
            CashFlowLbl.Text = "Inflows";
            // 
            // ViewRecordLbl
            // 
            ViewRecordLbl.Anchor = AnchorStyles.Top;
            ViewRecordLbl.AutoSize = true;
            ViewRecordLbl.Font = new Font("Segoe UI", 15F);
            ViewRecordLbl.Location = new Point(625, 654);
            ViewRecordLbl.Name = "ViewRecordLbl";
            ViewRecordLbl.Size = new Size(183, 41);
            ViewRecordLbl.TabIndex = 3;
            ViewRecordLbl.Text = "View Record";
            // 
            // UpdateBtn
            // 
            UpdateBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            UpdateBtn.Location = new Point(525, 270);
            UpdateBtn.Name = "UpdateBtn";
            UpdateBtn.Size = new Size(384, 381);
            UpdateBtn.TabIndex = 0;
            UpdateBtn.Click += UpdateBtn_Click;
            // 
            // Record_home_Page
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1819, 882);
            Controls.Add(tableLayoutPanel1);
            Name = "Record_home_Page";
            Text = "Record_home_Page";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private Button UpdateBtn;
        private Button CashFlowBtn;
        private Label CashFlowLbl;
        private Label ViewRecordLbl;
    }
}