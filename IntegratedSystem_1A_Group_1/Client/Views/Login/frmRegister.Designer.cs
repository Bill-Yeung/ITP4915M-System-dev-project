namespace Client.Views.Login
{
    partial class frmRegister
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblWelcomeMsg = new Label();
            lblPassword = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtPassword = new TextBox();
            table = new TableLayoutPanel();
            lblCustomerName = new Label();
            txtCustomerName = new TextBox();
            lblContact = new Label();
            txtPhone = new TextBox();
            lblAddress = new Label();
            llLogin = new LinkLabel();
            btnRegister = new Button();
            txtAddress = new TextBox();
            lblCountry = new Label();
            txtCountry = new TextBox();
            btnReturn = new Button();
            table.SuspendLayout();
            SuspendLayout();
            // 
            // lblWelcomeMsg
            // 
            table.SetColumnSpan(lblWelcomeMsg, 2);
            lblWelcomeMsg.Dock = DockStyle.Fill;
            lblWelcomeMsg.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcomeMsg.Location = new Point(290, 20);
            lblWelcomeMsg.Margin = new Padding(0);
            lblWelcomeMsg.Name = "lblWelcomeMsg";
            lblWelcomeMsg.Size = new Size(700, 120);
            lblWelcomeMsg.TabIndex = 0;
            lblWelcomeMsg.Text = "Register as Customer";
            lblWelcomeMsg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.Left;
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(292, 218);
            lblPassword.Margin = new Padding(2, 0, 2, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(104, 23);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password:";
            lblPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Left;
            txtEmail.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(492, 275);
            txtEmail.Margin = new Padding(2, 2, 2, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Please input company email";
            txtEmail.Size = new Size(494, 30);
            txtEmail.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.Anchor = AnchorStyles.Left;
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(292, 278);
            lblEmail.Margin = new Padding(2, 0, 2, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(64, 23);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email:";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Left;
            txtPassword.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(492, 215);
            txtPassword.Margin = new Padding(2, 2, 2, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Please input your password";
            txtPassword.Size = new Size(494, 30);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // table
            // 
            table.ColumnCount = 4;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            table.Controls.Add(lblWelcomeMsg, 1, 1);
            table.Controls.Add(lblEmail, 1, 4);
            table.Controls.Add(txtEmail, 2, 4);
            table.Controls.Add(lblPassword, 1, 3);
            table.Controls.Add(txtPassword, 2, 3);
            table.Controls.Add(lblCustomerName, 1, 2);
            table.Controls.Add(txtCustomerName, 2, 2);
            table.Controls.Add(lblContact, 1, 5);
            table.Controls.Add(txtPhone, 2, 5);
            table.Controls.Add(lblAddress, 1, 6);
            table.Controls.Add(llLogin, 1, 9);
            table.Controls.Add(btnRegister, 1, 8);
            table.Controls.Add(txtAddress, 2, 6);
            table.Controls.Add(lblCountry, 1, 7);
            table.Controls.Add(txtCountry, 2, 7);
            table.Controls.Add(btnReturn, 0, 1);
            table.Dock = DockStyle.Fill;
            table.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            table.Location = new Point(0, 0);
            table.Margin = new Padding(0);
            table.Name = "table";
            table.RowCount = 11;
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            table.Size = new Size(1280, 720);
            table.TabIndex = 0;
            // 
            // lblCustomerName
            // 
            lblCustomerName.Anchor = AnchorStyles.Left;
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerName.Location = new Point(292, 158);
            lblCustomerName.Margin = new Padding(2, 0, 2, 0);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(67, 23);
            lblCustomerName.TabIndex = 5;
            lblCustomerName.Text = "Name:";
            lblCustomerName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Anchor = AnchorStyles.Left;
            txtCustomerName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCustomerName.Location = new Point(492, 155);
            txtCustomerName.Margin = new Padding(2, 2, 2, 2);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.PlaceholderText = "Please input your company name";
            txtCustomerName.Size = new Size(494, 30);
            txtCustomerName.TabIndex = 1;
            // 
            // lblContact
            // 
            lblContact.Anchor = AnchorStyles.Left;
            lblContact.AutoSize = true;
            lblContact.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContact.Location = new Point(292, 338);
            lblContact.Margin = new Padding(2, 0, 2, 0);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(84, 23);
            lblContact.TabIndex = 7;
            lblContact.Text = "Contact:";
            lblContact.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPhone
            // 
            txtPhone.Anchor = AnchorStyles.Left;
            txtPhone.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhone.Location = new Point(492, 335);
            txtPhone.Margin = new Padding(2, 2, 2, 2);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Please input contact number";
            txtPhone.Size = new Size(494, 30);
            txtPhone.TabIndex = 4;
            // 
            // lblAddress
            // 
            lblAddress.Anchor = AnchorStyles.Left;
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddress.Location = new Point(292, 398);
            lblAddress.Margin = new Padding(2, 0, 2, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(89, 23);
            lblAddress.TabIndex = 9;
            lblAddress.Text = "Address:";
            lblAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // llLogin
            // 
            llLogin.Anchor = AnchorStyles.Left;
            llLogin.AutoSize = true;
            table.SetColumnSpan(llLogin, 2);
            llLogin.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            llLogin.LinkArea = new LinkArea(23, 43);
            llLogin.Location = new Point(293, 637);
            llLogin.Name = "llLogin";
            llLogin.Size = new Size(298, 25);
            llLogin.TabIndex = 10;
            llLogin.TabStop = true;
            llLogin.Text = "Remember your account? Login Here";
            llLogin.UseCompatibleTextRendering = true;
            llLogin.LinkClicked += llLogin_LinkClicked;
            // 
            // btnRegister
            // 
            btnRegister.Anchor = AnchorStyles.None;
            btnRegister.AutoEllipsis = true;
            btnRegister.BackColor = Color.FromArgb(255, 128, 128);
            table.SetColumnSpan(btnRegister, 2);
            btnRegister.FlatAppearance.BorderColor = Color.Blue;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegister.Location = new Point(469, 526);
            btnRegister.Margin = new Padding(2, 2, 2, 2);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(342, 48);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtAddress
            // 
            txtAddress.Anchor = AnchorStyles.Left;
            txtAddress.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAddress.Location = new Point(492, 395);
            txtAddress.Margin = new Padding(2, 2, 2, 2);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Please input company address";
            txtAddress.Size = new Size(494, 30);
            txtAddress.TabIndex = 5;
            // 
            // lblCountry
            // 
            lblCountry.Anchor = AnchorStyles.Left;
            lblCountry.AutoSize = true;
            lblCountry.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCountry.Location = new Point(292, 458);
            lblCountry.Margin = new Padding(2, 0, 2, 0);
            lblCountry.Name = "lblCountry";
            lblCountry.Size = new Size(84, 23);
            lblCountry.TabIndex = 13;
            lblCountry.Text = "Country:";
            lblCountry.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCountry
            // 
            txtCountry.Anchor = AnchorStyles.Left;
            txtCountry.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCountry.Location = new Point(492, 455);
            txtCountry.Margin = new Padding(2, 2, 2, 2);
            txtCountry.Name = "txtCountry";
            txtCountry.PlaceholderText = "Please input country of company address";
            txtCountry.Size = new Size(494, 30);
            txtCountry.TabIndex = 6;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(3, 23);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(75, 56);
            btnReturn.TabIndex = 14;
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // frmRegister
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1280, 720);
            Controls.Add(table);
            Margin = new Padding(2, 2, 2, 2);
            Name = "frmRegister";
            Text = "Integrated System";
            table.ResumeLayout(false);
            table.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblWelcomeMsg;
        private Label lblPassword;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtPassword;
        private TableLayoutPanel table;
        private Button btnRegister;
        private Label lblCustomerName;
        private LinkLabel llLogin;
        private TextBox txtCustomerName;
        private Label lblContact;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblCountry;
        private TextBox txtCountry;
        private Button btnReturn;
    }
}
