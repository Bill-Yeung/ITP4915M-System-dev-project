namespace Client.Views.CS.Refund
{
    partial class ViewAllRefundApplication
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
            btnReject = new Button();
            btnApprove = new Button();
            label_systemTitle = new Label();
            dgvAllRefundApplication = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAllRefundApplication).BeginInit();
            SuspendLayout();
            // 
            // btnReject
            // 
            btnReject.BackColor = Color.Red;
            btnReject.Location = new Point(925, 86);
            btnReject.Margin = new Padding(2);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(97, 41);
            btnReject.TabIndex = 15;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = false;
            btnReject.Click += btnReject_Click;
            // 
            // btnApprove
            // 
            btnApprove.BackColor = Color.Lime;
            btnApprove.Location = new Point(1036, 86);
            btnApprove.Margin = new Padding(2);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(97, 41);
            btnApprove.TabIndex = 10;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // label_systemTitle
            // 
            label_systemTitle.AutoSize = true;
            label_systemTitle.Font = new Font("Microsoft JhengHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label_systemTitle.Location = new Point(390, 26);
            label_systemTitle.Margin = new Padding(2, 0, 2, 0);
            label_systemTitle.Name = "label_systemTitle";
            label_systemTitle.Size = new Size(364, 43);
            label_systemTitle.TabIndex = 9;
            label_systemTitle.Text = "Order Refund System";
            // 
            // dgvAllRefundApplication
            // 
            dgvAllRefundApplication.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllRefundApplication.Location = new Point(11, 131);
            dgvAllRefundApplication.Margin = new Padding(2);
            dgvAllRefundApplication.Name = "dgvAllRefundApplication";
            dgvAllRefundApplication.ReadOnly = true;
            dgvAllRefundApplication.RowHeadersWidth = 62;
            dgvAllRefundApplication.Size = new Size(1122, 330);
            dgvAllRefundApplication.TabIndex = 8;
            // 
            // ViewAllRefundApplication
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1144, 510);
            Controls.Add(btnReject);
            Controls.Add(btnApprove);
            Controls.Add(label_systemTitle);
            Controls.Add(dgvAllRefundApplication);
            Name = "ViewAllRefundApplication";
            Text = "Order Refund System";
            Load += ViewAllRefundApplication_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAllRefundApplication).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnReject;
        private Button btnApprove;
        private Label label_systemTitle;
        private DataGridView dgvAllRefundApplication;
    }
}