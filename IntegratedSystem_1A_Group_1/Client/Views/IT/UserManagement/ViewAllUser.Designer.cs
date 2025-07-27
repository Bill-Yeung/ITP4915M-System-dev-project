namespace Client.Views.UserManagement
{
    partial class ViewAllUser
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
            dgvAllUserTable = new DataGridView();
            btnCreateStaff = new Button();
            rbtnCustomer = new RadioButton();
            rbtnStaff = new RadioButton();
            btnCreateCustomer = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAllUserTable).BeginInit();
            SuspendLayout();
            // 
            // dgvAllUserTable
            // 
            dgvAllUserTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllUserTable.Location = new Point(9, 112);
            dgvAllUserTable.Margin = new Padding(2);
            dgvAllUserTable.Name = "dgvAllUserTable";
            dgvAllUserTable.RowHeadersWidth = 62;
            dgvAllUserTable.Size = new Size(862, 261);
            dgvAllUserTable.TabIndex = 0;
            // 
            // btnCreateStaff
            // 
            btnCreateStaff.BackColor = Color.Lime;
            btnCreateStaff.Location = new Point(764, 77);
            btnCreateStaff.Margin = new Padding(2);
            btnCreateStaff.Name = "btnCreateStaff";
            btnCreateStaff.Size = new Size(107, 32);
            btnCreateStaff.TabIndex = 2;
            btnCreateStaff.Text = "Create Staff";
            btnCreateStaff.UseVisualStyleBackColor = false;
            btnCreateStaff.Click += btnCreateStaff_Click;
            // 
            // rbtnCustomer
            // 
            rbtnCustomer.AutoSize = true;
            rbtnCustomer.Location = new Point(9, 84);
            rbtnCustomer.Margin = new Padding(2);
            rbtnCustomer.Name = "rbtnCustomer";
            rbtnCustomer.Size = new Size(109, 19);
            rbtnCustomer.TabIndex = 3;
            rbtnCustomer.TabStop = true;
            rbtnCustomer.Text = "View Customer";
            rbtnCustomer.UseVisualStyleBackColor = true;
            rbtnCustomer.CheckedChanged += rbtnCustomer_CheckedChanged;
            // 
            // rbtnStaff
            // 
            rbtnStaff.AutoSize = true;
            rbtnStaff.Location = new Point(141, 84);
            rbtnStaff.Margin = new Padding(2);
            rbtnStaff.Name = "rbtnStaff";
            rbtnStaff.Size = new Size(81, 19);
            rbtnStaff.TabIndex = 4;
            rbtnStaff.TabStop = true;
            rbtnStaff.Text = "View Staff";
            rbtnStaff.UseVisualStyleBackColor = true;
            rbtnStaff.CheckedChanged += rbtnStaff_CheckedChanged;
            // 
            // btnCreateCustomer
            // 
            btnCreateCustomer.BackColor = Color.Lime;
            btnCreateCustomer.Location = new Point(654, 77);
            btnCreateCustomer.Margin = new Padding(2);
            btnCreateCustomer.Name = "btnCreateCustomer";
            btnCreateCustomer.Size = new Size(107, 32);
            btnCreateCustomer.TabIndex = 5;
            btnCreateCustomer.Text = "Create Customer";
            btnCreateCustomer.UseVisualStyleBackColor = false;
            btnCreateCustomer.Click += btnCreateCustomer_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Yellow;
            btnUpdate.Location = new Point(516, 77);
            btnUpdate.Margin = new Padding(2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(135, 32);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update Selected User";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Location = new Point(384, 77);
            btnDelete.Margin = new Padding(2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(128, 32);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete Selected User";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 20F);
            label1.Location = new Point(215, 22);
            label1.Name = "label1";
            label1.Size = new Size(458, 35);
            label1.TabIndex = 8;
            label1.Text = "User Account Management System";
            // 
            // ViewAllUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(879, 384);
            Controls.Add(label1);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreateCustomer);
            Controls.Add(rbtnStaff);
            Controls.Add(rbtnCustomer);
            Controls.Add(btnCreateStaff);
            Controls.Add(dgvAllUserTable);
            Margin = new Padding(2);
            Name = "ViewAllUser";
            Text = "User Account Management System";
            Load += ViewAllUser_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAllUserTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAllUserTable;
        private Button btnCreateStaff;
        private RadioButton rbtnCustomer;
        private RadioButton rbtnStaff;
        private Button btnCreateCustomer;
        private Button btnUpdate;
        private Button btnDelete;
        private Label label1;
    }
}