namespace Client.Views.UserManagement
{
    partial class CreateStaffAccount
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
            btnCreate = new Button();
            lblUserAccountManagementSystem = new Label();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            tbStaffName = new TextBox();
            tbStaffPassword = new TextBox();
            tbStaffPosition = new TextBox();
            tbStaffEmail = new TextBox();
            tbStaffPhone = new TextBox();
            comboBox_dept = new ComboBox();
            label_systemName = new Label();
            checkedListBox_system = new CheckedListBox();
            SuspendLayout();
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.Lime;
            btnCreate.Location = new Point(717, 438);
            btnCreate.Margin = new Padding(2);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(137, 41);
            btnCreate.TabIndex = 11;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // lblUserAccountManagementSystem
            // 
            lblUserAccountManagementSystem.AutoSize = true;
            lblUserAccountManagementSystem.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 136);
            lblUserAccountManagementSystem.Location = new Point(22, 34);
            lblUserAccountManagementSystem.Margin = new Padding(2, 0, 2, 0);
            lblUserAccountManagementSystem.Name = "lblUserAccountManagementSystem";
            lblUserAccountManagementSystem.Size = new Size(832, 38);
            lblUserAccountManagementSystem.TabIndex = 7;
            lblUserAccountManagementSystem.Text = "User Account Management System - Create Staff Account";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Crimson;
            btnCancel.Location = new Point(565, 438);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(137, 41);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 149);
            label1.Name = "label1";
            label1.Size = new Size(87, 19);
            label1.TabIndex = 15;
            label1.Text = "Staff Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 208);
            label2.Name = "label2";
            label2.Size = new Size(77, 19);
            label2.TabIndex = 17;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 265);
            label3.Name = "label3";
            label3.Size = new Size(92, 19);
            label3.TabIndex = 19;
            label3.Text = "Department";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(60, 321);
            label4.Name = "label4";
            label4.Size = new Size(65, 19);
            label4.TabIndex = 21;
            label4.Text = "Position";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(76, 378);
            label5.Name = "label5";
            label5.Size = new Size(47, 19);
            label5.TabIndex = 23;
            label5.Text = "Email";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(70, 425);
            label6.Name = "label6";
            label6.Size = new Size(53, 19);
            label6.TabIndex = 25;
            label6.Text = "Phone";
            // 
            // tbStaffName
            // 
            tbStaffName.Location = new Point(131, 141);
            tbStaffName.Name = "tbStaffName";
            tbStaffName.Size = new Size(358, 27);
            tbStaffName.TabIndex = 26;
            // 
            // tbStaffPassword
            // 
            tbStaffPassword.Location = new Point(131, 200);
            tbStaffPassword.Name = "tbStaffPassword";
            tbStaffPassword.Size = new Size(358, 27);
            tbStaffPassword.TabIndex = 27;
            // 
            // tbStaffPosition
            // 
            tbStaffPosition.Location = new Point(131, 313);
            tbStaffPosition.Name = "tbStaffPosition";
            tbStaffPosition.Size = new Size(358, 27);
            tbStaffPosition.TabIndex = 29;
            // 
            // tbStaffEmail
            // 
            tbStaffEmail.Location = new Point(131, 370);
            tbStaffEmail.Name = "tbStaffEmail";
            tbStaffEmail.Size = new Size(358, 27);
            tbStaffEmail.TabIndex = 30;
            // 
            // tbStaffPhone
            // 
            tbStaffPhone.Location = new Point(131, 425);
            tbStaffPhone.Name = "tbStaffPhone";
            tbStaffPhone.Size = new Size(358, 27);
            tbStaffPhone.TabIndex = 31;
            // 
            // comboBox_dept
            // 
            comboBox_dept.Location = new Point(131, 262);
            comboBox_dept.Name = "comboBox_dept";
            comboBox_dept.Size = new Size(358, 27);
            comboBox_dept.TabIndex = 0;
            // 
            // label_systemName
            // 
            label_systemName.AutoSize = true;
            label_systemName.Location = new Point(528, 86);
            label_systemName.Name = "label_systemName";
            label_systemName.Size = new Size(226, 38);
            label_systemName.TabIndex = 34;
            label_systemName.Text = "Authorize System Access Right:\r\n(Select System Below)";
            // 
            // checkedListBox_system
            // 
            checkedListBox_system.FormattingEnabled = true;
            checkedListBox_system.Location = new Point(528, 141);
            checkedListBox_system.Name = "checkedListBox_system";
            checkedListBox_system.Size = new Size(266, 114);
            checkedListBox_system.TabIndex = 35;
            // 
            // CreateStaffAccount
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(876, 490);
            Controls.Add(checkedListBox_system);
            Controls.Add(label_systemName);
            Controls.Add(comboBox_dept);
            Controls.Add(tbStaffPhone);
            Controls.Add(tbStaffEmail);
            Controls.Add(tbStaffPosition);
            Controls.Add(tbStaffPassword);
            Controls.Add(tbStaffName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnCreate);
            Controls.Add(lblUserAccountManagementSystem);
            Name = "CreateStaffAccount";
            Text = "User Account Management System - Create Staff Account";
            Load += CreateStaffAccount_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreate;
        private Label lblUserAccountManagementSystem;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox tbStaffName;
        private TextBox tbStaffPassword;
        private TextBox tbStaffPosition;
        private TextBox tbStaffEmail;
        private TextBox tbStaffPhone;
        private ComboBox comboBox_dept;
        private Label label7;
        private Label label_systemName;
        private CheckedListBox checkedListBox_system;
    }
}