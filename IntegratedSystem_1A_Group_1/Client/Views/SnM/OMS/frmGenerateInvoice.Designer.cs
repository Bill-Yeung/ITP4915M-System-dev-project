namespace Client.Views.SnM.OrderManagement
{
    partial class frmGenerateInvoice
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
            label8 = new Label();
            label10 = new Label();
            label12 = new Label();
            lblRemarks = new Label();
            label9 = new Label();
            label7 = new Label();
            table = new TableLayoutPanel();
            label11 = new Label();
            panel = new Panel();
            lblInvoiceID = new Label();
            label13 = new Label();
            logo = new PictureBox();
            lblInvoiceDate = new Label();
            label2 = new Label();
            label5 = new Label();
            lblQuotationID = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblCustomerName = new Label();
            lblAddress = new Label();
            table.SuspendLayout();
            panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label8.Location = new Point(2, 9);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(114, 19);
            label8.TabIndex = 0;
            label8.Text = "Product Name";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label10.Location = new Point(173, 9);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(118, 19);
            label10.TabIndex = 1;
            label10.Text = "Quantity";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label12.Location = new Point(420, 9);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(118, 19);
            label12.TabIndex = 3;
            label12.Text = "Total Price";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRemarks
            // 
            lblRemarks.AutoSize = true;
            lblRemarks.Location = new Point(118, 569);
            lblRemarks.Margin = new Padding(2, 0, 2, 0);
            lblRemarks.Name = "lblRemarks";
            lblRemarks.Size = new Size(70, 19);
            lblRemarks.TabIndex = 13;
            lblRemarks.Text = "Remarks";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(36, 569);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(73, 19);
            label9.TabIndex = 12;
            label9.Text = "Remarks:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(36, 225);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(562, 19);
            label7.TabIndex = 11;
            label7.Text = "_______________________________________________________________________________";
            // 
            // table
            // 
            table.BackColor = SystemColors.GradientInactiveCaption;
            table.ColumnCount = 4;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.4183655F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.5816345F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 121F));
            table.Controls.Add(label8, 0, 0);
            table.Controls.Add(label10, 1, 0);
            table.Controls.Add(label11, 2, 0);
            table.Controls.Add(label12, 3, 0);
            table.Location = new Point(38, 271);
            table.Margin = new Padding(2);
            table.Name = "table";
            table.RowCount = 1;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            table.Size = new Size(540, 28);
            table.TabIndex = 10;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label11.Location = new Point(295, 9);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(121, 19);
            label11.TabIndex = 2;
            label11.Text = "Unit Price";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel
            // 
            panel.Controls.Add(lblInvoiceID);
            panel.Controls.Add(label13);
            panel.Controls.Add(lblRemarks);
            panel.Controls.Add(label9);
            panel.Controls.Add(label7);
            panel.Controls.Add(table);
            panel.Controls.Add(logo);
            panel.Controls.Add(lblInvoiceDate);
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
            panel.Margin = new Padding(2);
            panel.Name = "panel";
            panel.Size = new Size(624, 754);
            panel.TabIndex = 11;
            // 
            // lblInvoiceID
            // 
            lblInvoiceID.AutoSize = true;
            lblInvoiceID.Location = new Point(458, 140);
            lblInvoiceID.Margin = new Padding(2, 0, 2, 0);
            lblInvoiceID.Name = "lblInvoiceID";
            lblInvoiceID.Size = new Size(77, 19);
            lblInvoiceID.TabIndex = 15;
            lblInvoiceID.Text = "Invoice ID";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(349, 140);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(80, 19);
            label13.TabIndex = 14;
            label13.Text = "Invoice ID:";
            // 
            // logo
            // 
            logo.Location = new Point(23, 31);
            logo.Margin = new Padding(2);
            logo.Name = "logo";
            logo.Size = new Size(82, 70);
            logo.TabIndex = 0;
            logo.TabStop = false;
            // 
            // lblInvoiceDate
            // 
            lblInvoiceDate.AutoSize = true;
            lblInvoiceDate.Location = new Point(458, 206);
            lblInvoiceDate.Margin = new Padding(2, 0, 2, 0);
            lblInvoiceDate.Name = "lblInvoiceDate";
            lblInvoiceDate.Size = new Size(94, 19);
            lblInvoiceDate.TabIndex = 9;
            lblInvoiceDate.Text = "Invoice Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 15.8571434F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label2.Location = new Point(435, 46);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(108, 35);
            label2.TabIndex = 2;
            label2.Text = "Invoice";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(332, 206);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(97, 19);
            label5.TabIndex = 7;
            label5.Text = "Invoice Date:";
            // 
            // lblQuotationID
            // 
            lblQuotationID.AutoSize = true;
            lblQuotationID.Location = new Point(458, 173);
            lblQuotationID.Margin = new Padding(2, 0, 2, 0);
            lblQuotationID.Name = "lblQuotationID";
            lblQuotationID.Size = new Size(98, 19);
            lblQuotationID.TabIndex = 8;
            lblQuotationID.Text = "Quotation ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 9.857143F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label1.Location = new Point(110, 58);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(259, 22);
            label1.TabIndex = 1;
            label1.Text = "Smile && Sunshine Toy Co., Ltd.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 140);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(32, 19);
            label3.TabIndex = 3;
            label3.Text = "TO:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(332, 173);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(101, 19);
            label4.TabIndex = 6;
            label4.Text = "Quotation ID:";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(75, 140);
            lblCustomerName.Margin = new Padding(2, 0, 2, 0);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(123, 19);
            lblCustomerName.TabIndex = 4;
            lblCustomerName.Text = "Customer Name";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(36, 173);
            lblAddress.Margin = new Padding(2, 0, 2, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(138, 19);
            lblAddress.TabIndex = 5;
            lblAddress.Text = "Company Address";
            // 
            // frmGenerateInvoice
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 754);
            Controls.Add(panel);
            Name = "frmGenerateInvoice";
            Text = "frmGenerateInvoice";
            table.ResumeLayout(false);
            table.PerformLayout();
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label8;
        private Label label10;
        private Label label12;
        private Label lblRemarks;
        private Label label9;
        private Label label7;
        private TableLayoutPanel table;
        private Label label11;
        public Panel panel;
        private PictureBox logo;
        private Label lblInvoiceDate;
        private Label label2;
        private Label label5;
        private Label lblQuotationID;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label lblCustomerName;
        private Label lblAddress;
        private Label lblInvoiceID;
        private Label label13;
    }
}