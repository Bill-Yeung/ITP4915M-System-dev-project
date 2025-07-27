namespace Client.Views.UserManagement
{
    partial class ModifyStaffAccount
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
            checkedListBox_system = new CheckedListBox();
            label_systemName = new Label();
            comboBox_dept = new ComboBox();
            tbStaffPhone = new TextBox();
            tbStaffEmail = new TextBox();
            tbStaffPosition = new TextBox();
            tbStaffPassword = new TextBox();
            tbStaffName = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnCancel = new Button();
            btnUpdate = new Button();
            lblUserAccountManagementSystem = new Label();
            SuspendLayout();
            // 
            // checkedListBox_system
            // 
            checkedListBox_system.FormattingEnabled = true;
            checkedListBox_system.Location = new Point(532, 134);
            checkedListBox_system.Name = "checkedListBox_system";
            checkedListBox_system.Size = new Size(266, 114);
            checkedListBox_system.TabIndex = 53;
            // 
            // label_systemName
            // 
            label_systemName.AutoSize = true;
            label_systemName.Location = new Point(532, 79);
            label_systemName.Name = "label_systemName";
            label_systemName.Size = new Size(226, 38);
            label_systemName.TabIndex = 52;
            label_systemName.Text = "Authorize System Access Right:\r\n(Select System Below)";
            // 
            // comboBox_dept
            // 
            comboBox_dept.Location = new Point(135, 255);
            comboBox_dept.Name = "comboBox_dept";
            comboBox_dept.Size = new Size(358, 27);
            comboBox_dept.TabIndex = 36;
            comboBox_dept.SelectedIndexChanged += comboBox_dept_SelectedIndexChanged;
            // 
            // tbStaffPhone
            // 
            tbStaffPhone.Location = new Point(135, 418);
            tbStaffPhone.Name = "tbStaffPhone";
            tbStaffPhone.Size = new Size(358, 27);
            tbStaffPhone.TabIndex = 50;
            // 
            // tbStaffEmail
            // 
            tbStaffEmail.Location = new Point(135, 363);
            tbStaffEmail.Name = "tbStaffEmail";
            tbStaffEmail.Size = new Size(358, 27);
            tbStaffEmail.TabIndex = 49;
            // 
            // tbStaffPosition
            // 
            tbStaffPosition.Location = new Point(135, 306);
            tbStaffPosition.Name = "tbStaffPosition";
            tbStaffPosition.Size = new Size(358, 27);
            tbStaffPosition.TabIndex = 48;
            // 
            // tbStaffPassword
            // 
            tbStaffPassword.Location = new Point(135, 193);
            tbStaffPassword.Name = "tbStaffPassword";
            tbStaffPassword.Size = new Size(358, 27);
            tbStaffPassword.TabIndex = 47;
            // 
            // tbStaffName
            // 
            tbStaffName.Location = new Point(135, 134);
            tbStaffName.Name = "tbStaffName";
            tbStaffName.Size = new Size(358, 27);
            tbStaffName.TabIndex = 46;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(74, 418);
            label6.Name = "label6";
            label6.Size = new Size(53, 19);
            label6.TabIndex = 45;
            label6.Text = "Phone";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(80, 371);
            label5.Name = "label5";
            label5.Size = new Size(47, 19);
            label5.TabIndex = 44;
            label5.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(64, 314);
            label4.Name = "label4";
            label4.Size = new Size(65, 19);
            label4.TabIndex = 43;
            label4.Text = "Position";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 258);
            label3.Name = "label3";
            label3.Size = new Size(92, 19);
            label3.TabIndex = 42;
            label3.Text = "Department";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 201);
            label2.Name = "label2";
            label2.Size = new Size(77, 19);
            label2.TabIndex = 41;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 142);
            label1.Name = "label1";
            label1.Size = new Size(87, 19);
            label1.TabIndex = 40;
            label1.Text = "Staff Name";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Crimson;
            btnCancel.Location = new Point(569, 431);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(137, 41);
            btnCancel.TabIndex = 39;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Lime;
            btnUpdate.Location = new Point(721, 431);
            btnUpdate.Margin = new Padding(2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(137, 41);
            btnUpdate.TabIndex = 38;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // lblUserAccountManagementSystem
            // 
            lblUserAccountManagementSystem.AutoSize = true;
            lblUserAccountManagementSystem.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 136);
            lblUserAccountManagementSystem.Location = new Point(26, 28);
            lblUserAccountManagementSystem.Margin = new Padding(2, 0, 2, 0);
            lblUserAccountManagementSystem.Name = "lblUserAccountManagementSystem";
            lblUserAccountManagementSystem.Size = new Size(841, 38);
            lblUserAccountManagementSystem.TabIndex = 37;
            lblUserAccountManagementSystem.Text = "User Account Management System - Modify Staff Account";
            // 
            // ModifyStaffAccount
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 492);
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
            Controls.Add(btnUpdate);
            Controls.Add(lblUserAccountManagementSystem);
            Name = "ModifyStaffAccount";
            Text = "User Account Management System - Modify Staff Account";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBox_system;
        private Label label_systemName;
        private ComboBox comboBox_dept;
        private TextBox tbStaffPhone;
        private TextBox tbStaffEmail;
        private TextBox tbStaffPosition;
        private TextBox tbStaffPassword;
        private TextBox tbStaffName;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnCancel;
        private Button btnUpdate;
        private Label lblUserAccountManagementSystem;
    }
}