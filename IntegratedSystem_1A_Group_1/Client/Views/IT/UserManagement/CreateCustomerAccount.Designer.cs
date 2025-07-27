namespace Client.Views.UserManagement
{
    partial class CreateCustomerAccount
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
            tbCustomerPhone = new TextBox();
            tbCustomerEmail = new TextBox();
            tbCustomerCountry = new TextBox();
            tbCustomerName = new TextBox();
            label_customerPhone = new Label();
            label_customerEmail = new Label();
            label_country = new Label();
            label_companyAddress = new Label();
            label_customerPassword = new Label();
            label_customerName = new Label();
            btnCancel = new Button();
            btnCreate = new Button();
            lblUserAccountManagementSystem = new Label();
            tbCompanyAddress = new TextBox();
            tbCustomerPassword = new TextBox();
            radioButton_Yes = new RadioButton();
            label_receivePromotion = new Label();
            radioButton_No = new RadioButton();
            SuspendLayout();
            // 
            // checkedListBox_system
            // 
            checkedListBox_system.FormattingEnabled = true;
            checkedListBox_system.Location = new Point(613, 148);
            checkedListBox_system.Name = "checkedListBox_system";
            checkedListBox_system.Size = new Size(266, 114);
            checkedListBox_system.TabIndex = 52;
            // 
            // label_systemName
            // 
            label_systemName.AutoSize = true;
            label_systemName.Location = new Point(613, 97);
            label_systemName.Name = "label_systemName";
            label_systemName.Size = new Size(226, 38);
            label_systemName.TabIndex = 51;
            label_systemName.Text = "Authorize System Access Right:\r\n(Select System Below)";
            // 
            // tbCustomerPhone
            // 
            tbCustomerPhone.Location = new Point(150, 382);
            tbCustomerPhone.Name = "tbCustomerPhone";
            tbCustomerPhone.Size = new Size(358, 27);
            tbCustomerPhone.TabIndex = 50;
            // 
            // tbCustomerEmail
            // 
            tbCustomerEmail.Location = new Point(150, 327);
            tbCustomerEmail.Name = "tbCustomerEmail";
            tbCustomerEmail.Size = new Size(358, 27);
            tbCustomerEmail.TabIndex = 49;
            // 
            // tbCustomerCountry
            // 
            tbCustomerCountry.Location = new Point(150, 445);
            tbCustomerCountry.Name = "tbCustomerCountry";
            tbCustomerCountry.Size = new Size(358, 27);
            tbCustomerCountry.TabIndex = 48;
            // 
            // tbCustomerName
            // 
            tbCustomerName.Location = new Point(150, 148);
            tbCustomerName.Name = "tbCustomerName";
            tbCustomerName.Size = new Size(358, 27);
            tbCustomerName.TabIndex = 46;
            // 
            // label_customerPhone
            // 
            label_customerPhone.AutoSize = true;
            label_customerPhone.Location = new Point(89, 390);
            label_customerPhone.Name = "label_customerPhone";
            label_customerPhone.Size = new Size(53, 19);
            label_customerPhone.TabIndex = 45;
            label_customerPhone.Text = "Phone";
            // 
            // label_customerEmail
            // 
            label_customerEmail.AutoSize = true;
            label_customerEmail.Location = new Point(95, 335);
            label_customerEmail.Name = "label_customerEmail";
            label_customerEmail.Size = new Size(47, 19);
            label_customerEmail.TabIndex = 44;
            label_customerEmail.Text = "Email";
            // 
            // label_country
            // 
            label_country.AutoSize = true;
            label_country.Location = new Point(77, 453);
            label_country.Name = "label_country";
            label_country.Size = new Size(65, 19);
            label_country.TabIndex = 43;
            label_country.Text = "Country";
            // 
            // label_companyAddress
            // 
            label_companyAddress.AutoSize = true;
            label_companyAddress.Location = new Point(4, 277);
            label_companyAddress.Name = "label_companyAddress";
            label_companyAddress.Size = new Size(138, 19);
            label_companyAddress.TabIndex = 42;
            label_companyAddress.Text = "Company Address";
            // 
            // label_customerPassword
            // 
            label_customerPassword.AutoSize = true;
            label_customerPassword.Location = new Point(65, 220);
            label_customerPassword.Name = "label_customerPassword";
            label_customerPassword.Size = new Size(77, 19);
            label_customerPassword.TabIndex = 41;
            label_customerPassword.Text = "Password";
            // 
            // label_customerName
            // 
            label_customerName.AutoSize = true;
            label_customerName.Location = new Point(19, 156);
            label_customerName.Name = "label_customerName";
            label_customerName.Size = new Size(123, 19);
            label_customerName.TabIndex = 40;
            label_customerName.Text = "Customer Name";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Crimson;
            btnCancel.Location = new Point(590, 437);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(137, 41);
            btnCancel.TabIndex = 39;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.Lime;
            btnCreate.Location = new Point(742, 437);
            btnCreate.Margin = new Padding(2);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(137, 41);
            btnCreate.TabIndex = 38;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // lblUserAccountManagementSystem
            // 
            lblUserAccountManagementSystem.AutoSize = true;
            lblUserAccountManagementSystem.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 136);
            lblUserAccountManagementSystem.Location = new Point(8, 40);
            lblUserAccountManagementSystem.Margin = new Padding(2, 0, 2, 0);
            lblUserAccountManagementSystem.Name = "lblUserAccountManagementSystem";
            lblUserAccountManagementSystem.Size = new Size(906, 38);
            lblUserAccountManagementSystem.TabIndex = 37;
            lblUserAccountManagementSystem.Text = "User Account Management System - Create Customer Account";
            // 
            // tbCompanyAddress
            // 
            tbCompanyAddress.Location = new Point(148, 274);
            tbCompanyAddress.Name = "tbCompanyAddress";
            tbCompanyAddress.Size = new Size(358, 27);
            tbCompanyAddress.TabIndex = 53;
            // 
            // tbCustomerPassword
            // 
            tbCustomerPassword.Location = new Point(150, 212);
            tbCustomerPassword.Name = "tbCustomerPassword";
            tbCustomerPassword.Size = new Size(358, 27);
            tbCustomerPassword.TabIndex = 54;
            // 
            // radioButton_Yes
            // 
            radioButton_Yes.AutoSize = true;
            radioButton_Yes.Location = new Point(613, 333);
            radioButton_Yes.Name = "radioButton_Yes";
            radioButton_Yes.Size = new Size(54, 23);
            radioButton_Yes.TabIndex = 55;
            radioButton_Yes.TabStop = true;
            radioButton_Yes.Text = "Yes";
            radioButton_Yes.UseVisualStyleBackColor = true;
            // 
            // label_receivePromotion
            // 
            label_receivePromotion.AutoSize = true;
            label_receivePromotion.Location = new Point(613, 293);
            label_receivePromotion.Name = "label_receivePromotion";
            label_receivePromotion.Size = new Size(149, 19);
            label_receivePromotion.TabIndex = 56;
            label_receivePromotion.Text = "Receiver Promotion:";
            // 
            // radioButton_No
            // 
            radioButton_No.AutoSize = true;
            radioButton_No.Location = new Point(711, 333);
            radioButton_No.Name = "radioButton_No";
            radioButton_No.Size = new Size(51, 23);
            radioButton_No.TabIndex = 57;
            radioButton_No.TabStop = true;
            radioButton_No.Text = "No";
            radioButton_No.UseVisualStyleBackColor = true;
            // 
            // CreateCustomerAccount
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(922, 526);
            Controls.Add(radioButton_No);
            Controls.Add(label_receivePromotion);
            Controls.Add(radioButton_Yes);
            Controls.Add(tbCustomerPassword);
            Controls.Add(tbCompanyAddress);
            Controls.Add(checkedListBox_system);
            Controls.Add(label_systemName);
            Controls.Add(tbCustomerPhone);
            Controls.Add(tbCustomerEmail);
            Controls.Add(tbCustomerCountry);
            Controls.Add(tbCustomerName);
            Controls.Add(label_customerPhone);
            Controls.Add(label_customerEmail);
            Controls.Add(label_country);
            Controls.Add(label_companyAddress);
            Controls.Add(label_customerPassword);
            Controls.Add(label_customerName);
            Controls.Add(btnCancel);
            Controls.Add(btnCreate);
            Controls.Add(lblUserAccountManagementSystem);
            Name = "CreateCustomerAccount";
            Text = "User Account Management System - Create Customer Account";
            Load += CreateCustomerAccount_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBox_system;
        private Label label_systemName;
        private ComboBox comboBox_dept;
        private TextBox tbCustomerPhone;
        private TextBox tbCustomerEmail;
        private TextBox tbCustomerCountry;
        private TextBox tbStaffPassword;
        private TextBox tbCustomerName;
        private Label label_customerPhone;
        private Label label_customerEmail;
        private Label label_country;
        private Label label_companyAddress;
        private Label label_customerPassword;
        private Label label_customerName;
        private Button btnCancel;
        private Button btnCreate;
        private Label lblUserAccountManagementSystem;
        private TextBox tbCompanyAddress;
        private TextBox tbCustomerPassword;
        private RadioButton radioButton_Yes;
        private Label label_receivePromotion;
        private RadioButton radioButton_No;
    }
}