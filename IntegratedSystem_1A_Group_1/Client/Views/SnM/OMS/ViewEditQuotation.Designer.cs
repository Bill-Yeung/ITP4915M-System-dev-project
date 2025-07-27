namespace Client.Views.SnM.OrderManagement
{
    partial class ViewEditQuotation
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
            comboBox_paymentTerm = new ComboBox();
            label4 = new Label();
            label_remark = new Label();
            textBox_remarks = new TextBox();
            label_deposit = new Label();
            textBox_deposit = new TextBox();
            label_total = new Label();
            button_remove = new Button();
            flowLayoutPanel_products = new FlowLayoutPanel();
            button_add = new Button();
            btnCancel = new Button();
            btnUpate = new Button();
            textBox_total = new TextBox();
            label1 = new Label();
            label_subTotal = new Label();
            label_unitPrice = new Label();
            label_qty = new Label();
            label_product = new Label();
            label_customerInfo = new Label();
            dataGridView_customerInfo = new DataGridView();
            label_customerID = new Label();
            comboBox_customer = new ComboBox();
            label_systemTitle = new Label();
            label_quotationID = new Label();
            textBox_quotationID = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView_customerInfo).BeginInit();
            SuspendLayout();
            // 
            // comboBox_paymentTerm
            // 
            comboBox_paymentTerm.FormattingEnabled = true;
            comboBox_paymentTerm.Location = new Point(222, 642);
            comboBox_paymentTerm.Name = "comboBox_paymentTerm";
            comboBox_paymentTerm.Size = new Size(189, 27);
            comboBox_paymentTerm.TabIndex = 100;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(83, 645);
            label4.Name = "label4";
            label4.Size = new Size(113, 19);
            label4.TabIndex = 99;
            label4.Text = "Payment Term:";
            // 
            // label_remark
            // 
            label_remark.AutoSize = true;
            label_remark.Location = new Point(83, 696);
            label_remark.Name = "label_remark";
            label_remark.Size = new Size(136, 19);
            label_remark.TabIndex = 98;
            label_remark.Text = "Remark(Optional):";
            // 
            // textBox_remarks
            // 
            textBox_remarks.Location = new Point(83, 718);
            textBox_remarks.Multiline = true;
            textBox_remarks.Name = "textBox_remarks";
            textBox_remarks.Size = new Size(328, 60);
            textBox_remarks.TabIndex = 97;
            // 
            // label_deposit
            // 
            label_deposit.AutoSize = true;
            label_deposit.Location = new Point(422, 696);
            label_deposit.Name = "label_deposit";
            label_deposit.Size = new Size(184, 19);
            label_deposit.TabIndex = 96;
            label_deposit.Text = "Required Deposit($HKD):";
            // 
            // textBox_deposit
            // 
            textBox_deposit.Location = new Point(609, 688);
            textBox_deposit.Name = "textBox_deposit";
            textBox_deposit.Size = new Size(124, 27);
            textBox_deposit.TabIndex = 95;
            // 
            // label_total
            // 
            label_total.AutoSize = true;
            label_total.Location = new Point(510, 653);
            label_total.Name = "label_total";
            label_total.Size = new Size(96, 19);
            label_total.TabIndex = 94;
            label_total.Text = "Total($HKD):";
            // 
            // button_remove
            // 
            button_remove.Location = new Point(37, 421);
            button_remove.Name = "button_remove";
            button_remove.Size = new Size(34, 29);
            button_remove.TabIndex = 93;
            button_remove.Text = "-";
            button_remove.UseVisualStyleBackColor = true;
            button_remove.Click += button_remove_Click;
            // 
            // flowLayoutPanel_products
            // 
            flowLayoutPanel_products.Location = new Point(83, 375);
            flowLayoutPanel_products.Name = "flowLayoutPanel_products";
            flowLayoutPanel_products.Size = new Size(650, 255);
            flowLayoutPanel_products.TabIndex = 92;
            // 
            // button_add
            // 
            button_add.Location = new Point(37, 373);
            button_add.Name = "button_add";
            button_add.Size = new Size(34, 29);
            button_add.TabIndex = 91;
            button_add.Text = "+";
            button_add.UseVisualStyleBackColor = true;
            button_add.Click += button_add_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Crimson;
            btnCancel.Location = new Point(446, 738);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(137, 41);
            btnCancel.TabIndex = 90;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnUpate
            // 
            btnUpate.BackColor = Color.Lime;
            btnUpate.Location = new Point(596, 738);
            btnUpate.Margin = new Padding(2);
            btnUpate.Name = "btnUpate";
            btnUpate.Size = new Size(137, 41);
            btnUpate.TabIndex = 89;
            btnUpate.Text = "Update";
            btnUpate.UseVisualStyleBackColor = false;
            btnUpate.Click += btnUpate_Click;
            // 
            // textBox_total
            // 
            textBox_total.Location = new Point(609, 645);
            textBox_total.Name = "textBox_total";
            textBox_total.ReadOnly = true;
            textBox_total.Size = new Size(124, 27);
            textBox_total.TabIndex = 88;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(596, 481);
            label1.Name = "label1";
            label1.Size = new Size(93, 19);
            label1.TabIndex = 87;
            label1.Text = "Total($HKD)";
            // 
            // label_subTotal
            // 
            label_subTotal.AutoSize = true;
            label_subTotal.Location = new Point(609, 351);
            label_subTotal.Name = "label_subTotal";
            label_subTotal.Size = new Size(124, 19);
            label_subTotal.TabIndex = 86;
            label_subTotal.Text = "Sub Total($HKD)";
            // 
            // label_unitPrice
            // 
            label_unitPrice.AutoSize = true;
            label_unitPrice.Location = new Point(436, 351);
            label_unitPrice.Name = "label_unitPrice";
            label_unitPrice.Size = new Size(126, 19);
            label_unitPrice.TabIndex = 85;
            label_unitPrice.Text = "Unit Price($HKD)";
            // 
            // label_qty
            // 
            label_qty.AutoSize = true;
            label_qty.Location = new Point(304, 351);
            label_qty.Name = "label_qty";
            label_qty.Size = new Size(69, 19);
            label_qty.TabIndex = 84;
            label_qty.Text = "Quantity";
            // 
            // label_product
            // 
            label_product.AutoSize = true;
            label_product.Location = new Point(83, 351);
            label_product.Name = "label_product";
            label_product.Size = new Size(160, 19);
            label_product.TabIndex = 83;
            label_product.Text = "Product ID and Name";
            // 
            // label_customerInfo
            // 
            label_customerInfo.AutoSize = true;
            label_customerInfo.Location = new Point(83, 153);
            label_customerInfo.Name = "label_customerInfo";
            label_customerInfo.Size = new Size(166, 19);
            label_customerInfo.TabIndex = 82;
            label_customerInfo.Text = "Customer Information:";
            // 
            // dataGridView_customerInfo
            // 
            dataGridView_customerInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_customerInfo.Location = new Point(83, 175);
            dataGridView_customerInfo.Name = "dataGridView_customerInfo";
            dataGridView_customerInfo.ReadOnly = true;
            dataGridView_customerInfo.RowHeadersWidth = 51;
            dataGridView_customerInfo.Size = new Size(650, 156);
            dataGridView_customerInfo.TabIndex = 81;
            // 
            // label_customerID
            // 
            label_customerID.AutoSize = true;
            label_customerID.Location = new Point(83, 118);
            label_customerID.Name = "label_customerID";
            label_customerID.Size = new Size(176, 19);
            label_customerID.TabIndex = 80;
            label_customerID.Text = "Customer ID and Name:";
            // 
            // comboBox_customer
            // 
            comboBox_customer.FormattingEnabled = true;
            comboBox_customer.Location = new Point(275, 110);
            comboBox_customer.Name = "comboBox_customer";
            comboBox_customer.Size = new Size(185, 27);
            comboBox_customer.TabIndex = 79;
            comboBox_customer.SelectedIndexChanged += comboBox_customer_SelectedIndexChanged;
            // 
            // label_systemTitle
            // 
            label_systemTitle.AutoSize = true;
            label_systemTitle.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Underline, GraphicsUnit.Point, 136);
            label_systemTitle.Location = new Point(94, 26);
            label_systemTitle.Margin = new Padding(2, 0, 2, 0);
            label_systemTitle.Name = "label_systemTitle";
            label_systemTitle.Size = new Size(612, 38);
            label_systemTitle.TabIndex = 78;
            label_systemTitle.Text = "Order Management - View/Edit Quotation";
            // 
            // label_quotationID
            // 
            label_quotationID.AutoSize = true;
            label_quotationID.Location = new Point(83, 80);
            label_quotationID.Name = "label_quotationID";
            label_quotationID.Size = new Size(101, 19);
            label_quotationID.TabIndex = 102;
            label_quotationID.Text = "Quotation ID:";
            // 
            // textBox_quotationID
            // 
            textBox_quotationID.Location = new Point(275, 72);
            textBox_quotationID.Name = "textBox_quotationID";
            textBox_quotationID.ReadOnly = true;
            textBox_quotationID.Size = new Size(185, 27);
            textBox_quotationID.TabIndex = 101;
            // 
            // ViewEditQuotation
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 790);
            Controls.Add(label_quotationID);
            Controls.Add(textBox_quotationID);
            Controls.Add(comboBox_paymentTerm);
            Controls.Add(label4);
            Controls.Add(label_remark);
            Controls.Add(textBox_remarks);
            Controls.Add(label_deposit);
            Controls.Add(textBox_deposit);
            Controls.Add(label_total);
            Controls.Add(button_remove);
            Controls.Add(flowLayoutPanel_products);
            Controls.Add(button_add);
            Controls.Add(btnCancel);
            Controls.Add(btnUpate);
            Controls.Add(textBox_total);
            Controls.Add(label1);
            Controls.Add(label_subTotal);
            Controls.Add(label_unitPrice);
            Controls.Add(label_qty);
            Controls.Add(label_product);
            Controls.Add(label_customerInfo);
            Controls.Add(dataGridView_customerInfo);
            Controls.Add(label_customerID);
            Controls.Add(comboBox_customer);
            Controls.Add(label_systemTitle);
            Name = "ViewEditQuotation";
            Text = "Order Management - View/Edit Quotation";
            Load += ViewEditQuotation_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_customerInfo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox_paymentTerm;
        private Label label4;
        private Label label_remark;
        private TextBox textBox_remarks;
        private Label label_deposit;
        private TextBox textBox_deposit;
        private Label label_total;
        private Button button_remove;
        private FlowLayoutPanel flowLayoutPanel_products;
        private Button button_add;
        private Button btnCancel;
        private Button btnUpate;
        private TextBox textBox_total;
        private Label label1;
        private Label label_subTotal;
        private Label label_unitPrice;
        private Label label_qty;
        private Label label_product;
        private Label label_customerInfo;
        private DataGridView dataGridView_customerInfo;
        private Label label_customerID;
        private ComboBox comboBox_customer;
        private Label label_systemTitle;
        private Label label_quotationID;
        public TextBox textBox_quotationID;
    }
}