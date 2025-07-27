namespace Client.Views.SnM.OrderManagement
{
    partial class ViewAllOrder
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
            button_delete = new Button();
            label_systemTitle = new Label();
            button_generateInvoice = new Button();
            button_sendToFinance = new Button();
            button_ViewOrderDetail = new Button();
            dataGridView_allOrder = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView_allOrder).BeginInit();
            SuspendLayout();
            // 
            // button_delete
            // 
            button_delete.BackColor = Color.Red;
            button_delete.Location = new Point(212, 366);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(112, 29);
            button_delete.TabIndex = 50;
            button_delete.Text = "Delete Order";
            button_delete.UseVisualStyleBackColor = false;
            button_delete.Click += button_delete_Click;
            // 
            // label_systemTitle
            // 
            label_systemTitle.AutoSize = true;
            label_systemTitle.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Underline, GraphicsUnit.Point, 136);
            label_systemTitle.Location = new Point(134, 49);
            label_systemTitle.Margin = new Padding(2, 0, 2, 0);
            label_systemTitle.Name = "label_systemTitle";
            label_systemTitle.Size = new Size(611, 38);
            label_systemTitle.TabIndex = 49;
            label_systemTitle.Text = "Sales and Marketing - Order Management";
            // 
            // button_generateInvoice
            // 
            button_generateInvoice.BackColor = Color.Cyan;
            button_generateInvoice.Location = new Point(515, 366);
            button_generateInvoice.Name = "button_generateInvoice";
            button_generateInvoice.Size = new Size(137, 29);
            button_generateInvoice.TabIndex = 48;
            button_generateInvoice.Text = "Generate Invoice";
            button_generateInvoice.UseVisualStyleBackColor = false;
            button_generateInvoice.Click += button_generateInvoice_Click;
            // 
            // button_sendToFinance
            // 
            button_sendToFinance.BackColor = Color.Yellow;
            button_sendToFinance.Location = new Point(330, 366);
            button_sendToFinance.Name = "button_sendToFinance";
            button_sendToFinance.Size = new Size(179, 29);
            button_sendToFinance.TabIndex = 47;
            button_sendToFinance.Text = "Send Order To Finance";
            button_sendToFinance.UseVisualStyleBackColor = false;
            button_sendToFinance.Click += button_sendToFinance_Click;
            // 
            // button_ViewOrderDetail
            // 
            button_ViewOrderDetail.BackColor = Color.PaleGreen;
            button_ViewOrderDetail.Location = new Point(62, 366);
            button_ViewOrderDetail.Name = "button_ViewOrderDetail";
            button_ViewOrderDetail.Size = new Size(144, 29);
            button_ViewOrderDetail.TabIndex = 46;
            button_ViewOrderDetail.Text = "View Order Detail";
            button_ViewOrderDetail.UseVisualStyleBackColor = false;
            button_ViewOrderDetail.Click += button_ViewOrderDetail_Click;
            // 
            // dataGridView_allOrder
            // 
            dataGridView_allOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_allOrder.Location = new Point(62, 105);
            dataGridView_allOrder.Name = "dataGridView_allOrder";
            dataGridView_allOrder.ReadOnly = true;
            dataGridView_allOrder.RowHeadersWidth = 51;
            dataGridView_allOrder.Size = new Size(763, 231);
            dataGridView_allOrder.TabIndex = 45;
            // 
            // ViewAllOrder
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 450);
            Controls.Add(button_delete);
            Controls.Add(label_systemTitle);
            Controls.Add(button_generateInvoice);
            Controls.Add(button_sendToFinance);
            Controls.Add(button_ViewOrderDetail);
            Controls.Add(dataGridView_allOrder);
            Name = "ViewAllOrder";
            Text = "Sales & Marketing - Order Management";
            Load += ViewAllOrder_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_allOrder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_delete;
        private Label label_systemTitle;
        private Button button_generateInvoice;
        private Button button_sendToFinance;
        private Button button_ViewOrderDetail;
        private DataGridView dataGridView_allOrder;
    }
}