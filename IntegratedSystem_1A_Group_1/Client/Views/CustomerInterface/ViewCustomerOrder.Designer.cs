namespace Client.Views.CustomerInterface
{
    partial class ViewCustomerOrder
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
            button_Refund = new Button();
            button_ViewOrderDetail = new Button();
            dataGridView_myOrder = new DataGridView();
            button_cancelOrder = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_myOrder).BeginInit();
            SuspendLayout();
            // 
            // label_systemTitle
            // 
            label_systemTitle.AutoSize = true;
            label_systemTitle.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Underline, GraphicsUnit.Point, 136);
            label_systemTitle.Location = new Point(252, 43);
            label_systemTitle.Margin = new Padding(2, 0, 2, 0);
            label_systemTitle.Name = "label_systemTitle";
            label_systemTitle.Size = new Size(121, 30);
            label_systemTitle.TabIndex = 43;
            label_systemTitle.Text = "My Order";
            // 
            // button_Refund
            // 
            button_Refund.BackColor = Color.Yellow;
            button_Refund.Location = new Point(247, 289);
            button_Refund.Margin = new Padding(2, 2, 2, 2);
            button_Refund.Name = "button_Refund";
            button_Refund.Size = new Size(73, 23);
            button_Refund.TabIndex = 41;
            button_Refund.Text = "Refund";
            button_Refund.UseVisualStyleBackColor = false;
            button_Refund.Click += button_Refund_Click;
            // 
            // button_ViewOrderDetail
            // 
            button_ViewOrderDetail.BackColor = Color.LightGreen;
            button_ViewOrderDetail.Location = new Point(39, 289);
            button_ViewOrderDetail.Margin = new Padding(2, 2, 2, 2);
            button_ViewOrderDetail.Name = "button_ViewOrderDetail";
            button_ViewOrderDetail.Size = new Size(112, 23);
            button_ViewOrderDetail.TabIndex = 40;
            button_ViewOrderDetail.Text = "View Order Detail";
            button_ViewOrderDetail.UseVisualStyleBackColor = false;
            button_ViewOrderDetail.Click += button_ViewOrderDetail_Click;
            // 
            // dataGridView_myOrder
            // 
            dataGridView_myOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_myOrder.Location = new Point(39, 88);
            dataGridView_myOrder.Margin = new Padding(2, 2, 2, 2);
            dataGridView_myOrder.Name = "dataGridView_myOrder";
            dataGridView_myOrder.ReadOnly = true;
            dataGridView_myOrder.RowHeadersWidth = 51;
            dataGridView_myOrder.Size = new Size(544, 182);
            dataGridView_myOrder.TabIndex = 39;
            // 
            // button_cancelOrder
            // 
            button_cancelOrder.BackColor = Color.Red;
            button_cancelOrder.Location = new Point(156, 289);
            button_cancelOrder.Margin = new Padding(2, 2, 2, 2);
            button_cancelOrder.Name = "button_cancelOrder";
            button_cancelOrder.Size = new Size(87, 23);
            button_cancelOrder.TabIndex = 44;
            button_cancelOrder.Text = "Cancel Order";
            button_cancelOrder.UseVisualStyleBackColor = false;
            button_cancelOrder.Click += button_cancelOrder_Click;
            // 
            // ViewCustomerOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 355);
            Controls.Add(button_cancelOrder);
            Controls.Add(label_systemTitle);
            Controls.Add(button_Refund);
            Controls.Add(button_ViewOrderDetail);
            Controls.Add(dataGridView_myOrder);
            Margin = new Padding(2, 2, 2, 2);
            Name = "ViewCustomerOrder";
            Text = "View My Order";
            Load += ViewCustomerOrder_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_myOrder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_systemTitle;
        private Button button_Refund;
        private Button button_ViewOrderDetail;
        private DataGridView dataGridView_myOrder;
        private Button button_cancelOrder;
    }
}