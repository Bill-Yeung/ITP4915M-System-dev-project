namespace Client.Views.SnM.OrderManagement
{
    partial class ViewOrderDetail
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
            textBox_totalAmount = new TextBox();
            label_totalAmount = new Label();
            dataGridView_orderDetail = new DataGridView();
            label_orderDetail = new Label();
            label_customerInformation = new Label();
            textBox_orderID = new TextBox();
            label_orderID = new Label();
            label_systemTitle = new Label();
            button_back = new Button();
            dataGridView_customerInfo = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView_orderDetail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_customerInfo).BeginInit();
            SuspendLayout();
            // 
            // textBox_totalAmount
            // 
            textBox_totalAmount.Location = new Point(648, 491);
            textBox_totalAmount.Name = "textBox_totalAmount";
            textBox_totalAmount.ReadOnly = true;
            textBox_totalAmount.Size = new Size(125, 27);
            textBox_totalAmount.TabIndex = 65;
            // 
            // label_totalAmount
            // 
            label_totalAmount.AutoSize = true;
            label_totalAmount.Location = new Point(536, 499);
            label_totalAmount.Name = "label_totalAmount";
            label_totalAmount.Size = new Size(106, 19);
            label_totalAmount.TabIndex = 64;
            label_totalAmount.Text = "Total Amount:";
            // 
            // dataGridView_orderDetail
            // 
            dataGridView_orderDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_orderDetail.Location = new Point(73, 312);
            dataGridView_orderDetail.Name = "dataGridView_orderDetail";
            dataGridView_orderDetail.ReadOnly = true;
            dataGridView_orderDetail.RowHeadersWidth = 51;
            dataGridView_orderDetail.Size = new Size(700, 160);
            dataGridView_orderDetail.TabIndex = 63;
            // 
            // label_orderDetail
            // 
            label_orderDetail.AccessibleRole = AccessibleRole.TitleBar;
            label_orderDetail.AutoSize = true;
            label_orderDetail.Location = new Point(73, 290);
            label_orderDetail.Name = "label_orderDetail";
            label_orderDetail.Size = new Size(134, 19);
            label_orderDetail.TabIndex = 62;
            label_orderDetail.Text = "Products in order:";
            // 
            // label_customerInformation
            // 
            label_customerInformation.AutoSize = true;
            label_customerInformation.Location = new Point(73, 137);
            label_customerInformation.Name = "label_customerInformation";
            label_customerInformation.Size = new Size(166, 19);
            label_customerInformation.TabIndex = 61;
            label_customerInformation.Text = "Customer Information:";
            // 
            // textBox_orderID
            // 
            textBox_orderID.Location = new Point(152, 96);
            textBox_orderID.Name = "textBox_orderID";
            textBox_orderID.ReadOnly = true;
            textBox_orderID.Size = new Size(125, 27);
            textBox_orderID.TabIndex = 60;
            // 
            // label_orderID
            // 
            label_orderID.AutoSize = true;
            label_orderID.Location = new Point(73, 104);
            label_orderID.Name = "label_orderID";
            label_orderID.Size = new Size(73, 19);
            label_orderID.TabIndex = 59;
            label_orderID.Text = "Order ID:";
            // 
            // label_systemTitle
            // 
            label_systemTitle.AutoSize = true;
            label_systemTitle.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Underline, GraphicsUnit.Point, 136);
            label_systemTitle.Location = new Point(142, 41);
            label_systemTitle.Margin = new Padding(2, 0, 2, 0);
            label_systemTitle.Name = "label_systemTitle";
            label_systemTitle.Size = new Size(574, 38);
            label_systemTitle.TabIndex = 58;
            label_systemTitle.Text = "Order Management - View Order Detail";
            // 
            // button_back
            // 
            button_back.Location = new Point(636, 96);
            button_back.Name = "button_back";
            button_back.Size = new Size(137, 29);
            button_back.TabIndex = 57;
            button_back.Text = "Back";
            button_back.UseVisualStyleBackColor = true;
            button_back.Click += button_back_Click_1;
            // 
            // dataGridView_customerInfo
            // 
            dataGridView_customerInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_customerInfo.Location = new Point(73, 159);
            dataGridView_customerInfo.Name = "dataGridView_customerInfo";
            dataGridView_customerInfo.ReadOnly = true;
            dataGridView_customerInfo.RowHeadersWidth = 51;
            dataGridView_customerInfo.Size = new Size(700, 116);
            dataGridView_customerInfo.TabIndex = 56;
            // 
            // ViewOrderDetail
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(859, 577);
            Controls.Add(textBox_totalAmount);
            Controls.Add(label_totalAmount);
            Controls.Add(dataGridView_orderDetail);
            Controls.Add(label_orderDetail);
            Controls.Add(label_customerInformation);
            Controls.Add(textBox_orderID);
            Controls.Add(label_orderID);
            Controls.Add(label_systemTitle);
            Controls.Add(button_back);
            Controls.Add(dataGridView_customerInfo);
            Name = "ViewOrderDetail";
            Text = "Order Management - View Order Detail";
            Load += ViewOrderDetail_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_orderDetail).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_customerInfo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_totalAmount;
        private Label label_totalAmount;
        private DataGridView dataGridView_orderDetail;
        private Label label_orderDetail;
        private Label label_customerInformation;
        private TextBox textBox_orderID;
        private Label label_orderID;
        private Label label_systemTitle;
        private Button button_back;
        private DataGridView dataGridView_customerInfo;
    }
}