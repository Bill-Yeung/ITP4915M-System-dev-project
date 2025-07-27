namespace Client.Views.CS.Refund
{
    partial class OrderRefundApplicationForm
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
            components = new System.ComponentModel.Container();
            formTitle = new Label();
            label_orderID = new Label();
            dataGridView_orderDetail = new DataGridView();
            comboBox_refundReason = new ComboBox();
            label_refundReason = new Label();
            textBox_orderID = new TextBox();
            label_orderDetail = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            label_description = new Label();
            textBox_refundDescription = new TextBox();
            btnCancel = new Button();
            btnApply = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_orderDetail).BeginInit();
            SuspendLayout();
            // 
            // formTitle
            // 
            formTitle.AutoSize = true;
            formTitle.Font = new Font("Microsoft JhengHei UI", 16.2F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 136);
            formTitle.Location = new Point(202, 34);
            formTitle.Name = "formTitle";
            formTitle.Size = new Size(442, 36);
            formTitle.TabIndex = 0;
            formTitle.Text = "Order Refund Application Form";
            // 
            // label_orderID
            // 
            label_orderID.AutoSize = true;
            label_orderID.Location = new Point(535, 108);
            label_orderID.Name = "label_orderID";
            label_orderID.Size = new Size(73, 19);
            label_orderID.TabIndex = 1;
            label_orderID.Text = "Order ID:";
            // 
            // dataGridView_orderDetail
            // 
            dataGridView_orderDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_orderDetail.Location = new Point(50, 160);
            dataGridView_orderDetail.Name = "dataGridView_orderDetail";
            dataGridView_orderDetail.ReadOnly = true;
            dataGridView_orderDetail.RowHeadersWidth = 51;
            dataGridView_orderDetail.Size = new Size(774, 174);
            dataGridView_orderDetail.TabIndex = 3;
            // 
            // comboBox_refundReason
            // 
            comboBox_refundReason.FormattingEnabled = true;
            comboBox_refundReason.Location = new Point(412, 343);
            comboBox_refundReason.Name = "comboBox_refundReason";
            comboBox_refundReason.Size = new Size(412, 27);
            comboBox_refundReason.TabIndex = 5;
            // 
            // label_refundReason
            // 
            label_refundReason.AutoSize = true;
            label_refundReason.Location = new Point(233, 351);
            label_refundReason.Name = "label_refundReason";
            label_refundReason.Size = new Size(163, 19);
            label_refundReason.TabIndex = 4;
            label_refundReason.Text = "Select Refund Reason:";
            // 
            // textBox_orderID
            // 
            textBox_orderID.Location = new Point(614, 100);
            textBox_orderID.Name = "textBox_orderID";
            textBox_orderID.ReadOnly = true;
            textBox_orderID.Size = new Size(210, 27);
            textBox_orderID.TabIndex = 6;
            // 
            // label_orderDetail
            // 
            label_orderDetail.AutoSize = true;
            label_orderDetail.Location = new Point(50, 138);
            label_orderDetail.Name = "label_orderDetail";
            label_orderDetail.Size = new Size(105, 19);
            label_orderDetail.TabIndex = 7;
            label_orderDetail.Text = "Order Details:";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // label_description
            // 
            label_description.AutoSize = true;
            label_description.Location = new Point(305, 389);
            label_description.Name = "label_description";
            label_description.Size = new Size(91, 19);
            label_description.TabIndex = 9;
            label_description.Text = "Description:";
            // 
            // textBox_refundDescription
            // 
            textBox_refundDescription.Location = new Point(412, 386);
            textBox_refundDescription.Multiline = true;
            textBox_refundDescription.Name = "textBox_refundDescription";
            textBox_refundDescription.Size = new Size(412, 76);
            textBox_refundDescription.TabIndex = 10;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Crimson;
            btnCancel.Location = new Point(528, 470);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(137, 41);
            btnCancel.TabIndex = 41;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnApply
            // 
            btnApply.BackColor = Color.Lime;
            btnApply.Location = new Point(687, 470);
            btnApply.Margin = new Padding(2);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(137, 41);
            btnApply.TabIndex = 40;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Click += btnApply_Click;
            // 
            // OrderRefundApplicationForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 522);
            Controls.Add(btnCancel);
            Controls.Add(btnApply);
            Controls.Add(textBox_refundDescription);
            Controls.Add(label_description);
            Controls.Add(label_orderDetail);
            Controls.Add(textBox_orderID);
            Controls.Add(comboBox_refundReason);
            Controls.Add(label_refundReason);
            Controls.Add(dataGridView_orderDetail);
            Controls.Add(label_orderID);
            Controls.Add(formTitle);
            Name = "OrderRefundApplicationForm";
            Text = "Order Refund Application Form";
            Load += OrderRefundApplicationForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_orderDetail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label formTitle;
        private Label label_orderID;
        private DataGridView dataGridView_orderDetail;
        private ComboBox comboBox_refundReason;
        private Label label_refundReason;
        private TextBox textBox_orderID;
        private Label label_orderDetail;
        private ContextMenuStrip contextMenuStrip1;
        private Label label_description;
        private TextBox textBox_refundDescription;
        private Button btnCancel;
        private Button btnApply;
    }
}