namespace Client.Views.CustomerInterface
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
            label_systemTitle = new Label();
            button_back = new Button();
            dataGridView_customerInfo = new DataGridView();
            label_orderID = new Label();
            textBox_orderID = new TextBox();
            label_customerInformation = new Label();
            label_orderDetail = new Label();
            dataGridView_orderDetail = new DataGridView();
            textBox_totalAmount = new TextBox();
            label_totalAmount = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_customerInfo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_orderDetail).BeginInit();
            SuspendLayout();
            // 
            // label_systemTitle
            // 
            label_systemTitle.AutoSize = true;
            label_systemTitle.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Underline, GraphicsUnit.Point, 136);
            label_systemTitle.Location = new Point(305, 55);
            label_systemTitle.Margin = new Padding(2, 0, 2, 0);
            label_systemTitle.Name = "label_systemTitle";
            label_systemTitle.Size = new Size(190, 38);
            label_systemTitle.TabIndex = 48;
            label_systemTitle.Text = "Order Detail";
            // 
            // button_back
            // 
            button_back.Location = new Point(613, 64);
            button_back.Name = "button_back";
            button_back.Size = new Size(137, 29);
            button_back.TabIndex = 47;
            button_back.Text = "Back";
            button_back.UseVisualStyleBackColor = true;
            button_back.Click += button_back_Click;
            // 
            // dataGridView_customerInfo
            // 
            dataGridView_customerInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_customerInfo.Location = new Point(50, 161);
            dataGridView_customerInfo.Name = "dataGridView_customerInfo";
            dataGridView_customerInfo.ReadOnly = true;
            dataGridView_customerInfo.RowHeadersWidth = 51;
            dataGridView_customerInfo.Size = new Size(700, 116);
            dataGridView_customerInfo.TabIndex = 44;
            // 
            // label_orderID
            // 
            label_orderID.AutoSize = true;
            label_orderID.Location = new Point(50, 106);
            label_orderID.Name = "label_orderID";
            label_orderID.Size = new Size(73, 19);
            label_orderID.TabIndex = 49;
            label_orderID.Text = "Order ID:";
            // 
            // textBox_orderID
            // 
            textBox_orderID.Location = new Point(129, 98);
            textBox_orderID.Name = "textBox_orderID";
            textBox_orderID.ReadOnly = true;
            textBox_orderID.Size = new Size(125, 27);
            textBox_orderID.TabIndex = 50;
            // 
            // label_customerInformation
            // 
            label_customerInformation.AutoSize = true;
            label_customerInformation.Location = new Point(50, 139);
            label_customerInformation.Name = "label_customerInformation";
            label_customerInformation.Size = new Size(166, 19);
            label_customerInformation.TabIndex = 51;
            label_customerInformation.Text = "Customer Information:";
            // 
            // label_orderDetail
            // 
            label_orderDetail.AccessibleRole = AccessibleRole.TitleBar;
            label_orderDetail.AutoSize = true;
            label_orderDetail.Location = new Point(50, 292);
            label_orderDetail.Name = "label_orderDetail";
            label_orderDetail.Size = new Size(134, 19);
            label_orderDetail.TabIndex = 52;
            label_orderDetail.Text = "Products in order:";
            // 
            // dataGridView_orderDetail
            // 
            dataGridView_orderDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_orderDetail.Location = new Point(50, 314);
            dataGridView_orderDetail.Name = "dataGridView_orderDetail";
            dataGridView_orderDetail.ReadOnly = true;
            dataGridView_orderDetail.RowHeadersWidth = 51;
            dataGridView_orderDetail.Size = new Size(700, 160);
            dataGridView_orderDetail.TabIndex = 53;
            // 
            // textBox_totalAmount
            // 
            textBox_totalAmount.Location = new Point(625, 493);
            textBox_totalAmount.Name = "textBox_totalAmount";
            textBox_totalAmount.ReadOnly = true;
            textBox_totalAmount.Size = new Size(125, 27);
            textBox_totalAmount.TabIndex = 55;
            // 
            // label_totalAmount
            // 
            label_totalAmount.AutoSize = true;
            label_totalAmount.Location = new Point(513, 501);
            label_totalAmount.Name = "label_totalAmount";
            label_totalAmount.Size = new Size(103, 19);
            label_totalAmount.TabIndex = 54;
            label_totalAmount.Text = "Paid Amount:";
            // 
            // ViewOrderDetail
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 576);
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
            Text = "View Order Detail";
            Load += ViewOrderDetail_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_customerInfo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_orderDetail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_systemTitle;
        private Button button_back;
        private DataGridView dataGridView_customerInfo;
        private Label label_orderID;
        private TextBox textBox_orderID;
        private Label label_customerInformation;
        private Label label_orderDetail;
        private DataGridView dataGridView_orderDetail;
        private TextBox textBox_totalAmount;
        private Label label_totalAmount;
    }
}