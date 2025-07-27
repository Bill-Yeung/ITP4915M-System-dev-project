namespace Client.Views.SnM.OMS
{
    partial class frmGenerateQuotation
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
            logo = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblCustomerName = new Label();
            lblAddress = new Label();
            label4 = new Label();
            label5 = new Label();
            lblQuotationID = new Label();
            lblQuotationDate = new Label();
            panel = new Panel();
            lblRemarks = new Label();
            label9 = new Label();
            label7 = new Label();
            table = new TableLayoutPanel();
            label8 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            panel.SuspendLayout();
            table.SuspendLayout();
            SuspendLayout();
            // 
            // logo
            // 
            logo.Location = new Point(31, 42);
            logo.Name = "logo";
            logo.Size = new Size(110, 96);
            logo.TabIndex = 0;
            logo.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label1.Location = new Point(147, 80);
            label1.Name = "label1";
            label1.Size = new Size(364, 30);
            label1.TabIndex = 1;
            label1.Text = "Smile && Sunshine Toy Co., Ltd.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 15.8571434F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label2.Location = new Point(580, 63);
            label2.Name = "label2";
            label2.Size = new Size(203, 47);
            label2.TabIndex = 2;
            label2.Text = "Quotation";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 192);
            label3.Name = "label3";
            label3.Size = new Size(46, 26);
            label3.TabIndex = 3;
            label3.Text = "TO:";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(100, 192);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(174, 26);
            lblCustomerName.TabIndex = 4;
            lblCustomerName.Text = "Customer Name";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(48, 237);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(193, 26);
            lblAddress.TabIndex = 5;
            lblAddress.Text = "Company Address";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(458, 192);
            label4.Name = "label4";
            label4.Size = new Size(146, 26);
            label4.TabIndex = 6;
            label4.Text = "Quotation ID:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(432, 237);
            label5.Name = "label5";
            label5.Size = new Size(172, 26);
            label5.TabIndex = 7;
            label5.Text = "Quotation Date:";
            // 
            // lblQuotationID
            // 
            lblQuotationID.AutoSize = true;
            lblQuotationID.Location = new Point(642, 192);
            lblQuotationID.Name = "lblQuotationID";
            lblQuotationID.Size = new Size(141, 26);
            lblQuotationID.TabIndex = 8;
            lblQuotationID.Text = "Quotation ID";
            // 
            // lblQuotationDate
            // 
            lblQuotationDate.AutoSize = true;
            lblQuotationDate.Location = new Point(616, 237);
            lblQuotationDate.Name = "lblQuotationDate";
            lblQuotationDate.Size = new Size(167, 26);
            lblQuotationDate.TabIndex = 9;
            lblQuotationDate.Text = "Quotation Date";
            // 
            // panel
            // 
            panel.Controls.Add(lblRemarks);
            panel.Controls.Add(label9);
            panel.Controls.Add(label7);
            panel.Controls.Add(table);
            panel.Controls.Add(logo);
            panel.Controls.Add(lblQuotationDate);
            panel.Controls.Add(label2);
            panel.Controls.Add(label5);
            panel.Controls.Add(lblQuotationID);
            panel.Controls.Add(label1);
            panel.Controls.Add(label3);
            panel.Controls.Add(label4);
            panel.Controls.Add(lblCustomerName);
            panel.Controls.Add(lblAddress);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(816, 1124);
            panel.TabIndex = 10;
            // 
            // lblRemarks
            // 
            lblRemarks.AutoSize = true;
            lblRemarks.Location = new Point(158, 778);
            lblRemarks.Name = "lblRemarks";
            lblRemarks.Size = new Size(97, 26);
            lblRemarks.TabIndex = 13;
            lblRemarks.Text = "Remarks";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(48, 778);
            label9.Name = "label9";
            label9.Size = new Size(102, 26);
            label9.TabIndex = 12;
            label9.Text = "Remarks:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(45, 293);
            label7.Name = "label7";
            label7.Size = new Size(723, 26);
            label7.TabIndex = 11;
            label7.Text = "_______________________________________________________________________________";
            // 
            // table
            // 
            table.BackColor = SystemColors.GradientInactiveCaption;
            table.ColumnCount = 4;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.4183655F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.5816345F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 167F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            table.Controls.Add(label8, 0, 0);
            table.Controls.Add(label10, 1, 0);
            table.Controls.Add(label11, 2, 0);
            table.Controls.Add(label12, 3, 0);
            table.Location = new Point(48, 356);
            table.Name = "table";
            table.RowCount = 1;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            table.Size = new Size(720, 39);
            table.TabIndex = 10;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label8.Location = new Point(3, 12);
            label8.Name = "label8";
            label8.Size = new Size(159, 26);
            label8.TabIndex = 0;
            label8.Text = "Product Name";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label10.Location = new Point(232, 12);
            label10.Name = "label10";
            label10.Size = new Size(157, 26);
            label10.TabIndex = 1;
            label10.Text = "Quantity";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label11.Location = new Point(395, 12);
            label11.Name = "label11";
            label11.Size = new Size(161, 26);
            label11.TabIndex = 2;
            label11.Text = "Unit Price";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label12.Location = new Point(562, 12);
            label12.Name = "label12";
            label12.Size = new Size(155, 26);
            label12.TabIndex = 3;
            label12.Text = "Total Price";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmGenerateQuotation
            // 
            AutoScaleDimensions = new SizeF(12F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(816, 1124);
            Controls.Add(panel);
            Name = "frmGenerateQuotation";
            Text = "frmGenerateQuotation";
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            panel.ResumeLayout(false);
            panel.PerformLayout();
            table.ResumeLayout(false);
            table.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox logo;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblCustomerName;
        private Label lblAddress;
        private Label label4;
        private Label label5;
        private Label lblQuotationID;
        private Label lblQuotationDate;
        public Panel panel;
        private Label label7;
        private TableLayoutPanel table;
        private Label label8;
        private Label label9;
        private Label lblRemarks;
        private Label label10;
        private Label label11;
        private Label label12;
    }
}