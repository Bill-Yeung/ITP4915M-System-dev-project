namespace Client.Views.Login
{
    partial class frmLogin
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
            lblForgetPassword = new Label();
            lblWelcomeMsg = new Label();
            lblUserName = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUserName = new TextBox();
            table = new TableLayoutPanel();
            lblUserType = new Label();
            btnLogin = new Button();
            gbUserType = new GroupBox();
            rbStaff = new RadioButton();
            rbCustomer = new RadioButton();
            llRegister = new LinkLabel();
            table.SuspendLayout();
            gbUserType.SuspendLayout();
            SuspendLayout();
            // 
            // lblForgetPassword
            // 
            lblForgetPassword.Anchor = AnchorStyles.Right;
            lblForgetPassword.AutoSize = true;
            table.SetColumnSpan(lblForgetPassword, 2);
            lblForgetPassword.Font = new Font("Arial", 10.2F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblForgetPassword.ForeColor = Color.Blue;
            lblForgetPassword.Location = new Point(1058, 601);
            lblForgetPassword.Name = "lblForgetPassword";
            lblForgetPassword.Size = new Size(259, 27);
            lblForgetPassword.TabIndex = 7;
            lblForgetPassword.Text = "Forget your password?";
            lblForgetPassword.Click += lblForgetPassword_Click;
            // 
            // lblWelcomeMsg
            // 
            table.SetColumnSpan(lblWelcomeMsg, 2);
            lblWelcomeMsg.Dock = DockStyle.Fill;
            lblWelcomeMsg.Font = new Font("Arial", 15.8571434F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcomeMsg.Location = new Point(386, 90);
            lblWelcomeMsg.Margin = new Padding(0);
            lblWelcomeMsg.Name = "lblWelcomeMsg";
            lblWelcomeMsg.Size = new Size(934, 164);
            lblWelcomeMsg.TabIndex = 0;
            lblWelcomeMsg.Text = "Welcome to Smile && Sunshine Integrated System !";
            lblWelcomeMsg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserName
            // 
            lblUserName.Anchor = AnchorStyles.Left;
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(389, 401);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(162, 32);
            lblUserName.TabIndex = 3;
            lblUserName.Text = "User Name:";
            lblUserName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Left;
            txtPassword.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(656, 506);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Please input your password";
            txtPassword.Size = new Size(657, 40);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.Left;
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(389, 510);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(143, 32);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password:";
            lblPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.Left;
            txtUserName.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUserName.Location = new Point(656, 397);
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "Please input your user name";
            txtUserName.Size = new Size(657, 40);
            txtUserName.TabIndex = 4;
            // 
            // table
            // 
            table.ColumnCount = 4;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 267F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 667F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            table.Controls.Add(lblWelcomeMsg, 1, 1);
            table.Controls.Add(lblPassword, 1, 4);
            table.Controls.Add(txtPassword, 2, 4);
            table.Controls.Add(lblUserName, 1, 3);
            table.Controls.Add(txtUserName, 2, 3);
            table.Controls.Add(lblUserType, 1, 2);
            table.Controls.Add(btnLogin, 1, 6);
            table.Controls.Add(lblForgetPassword, 1, 5);
            table.Controls.Add(gbUserType, 2, 2);
            table.Controls.Add(llRegister, 1, 7);
            table.Dock = DockStyle.Fill;
            table.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            table.Location = new Point(0, 0);
            table.Margin = new Padding(0);
            table.Name = "table";
            table.RowCount = 9;
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 164F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 109F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 109F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 109F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 109F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 137F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            table.Size = new Size(1707, 985);
            table.TabIndex = 0;
            // 
            // lblUserType
            // 
            lblUserType.Anchor = AnchorStyles.Left;
            lblUserType.AutoSize = true;
            lblUserType.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUserType.Location = new Point(389, 292);
            lblUserType.Name = "lblUserType";
            lblUserType.Size = new Size(145, 32);
            lblUserType.TabIndex = 5;
            lblUserType.Text = "User Type:";
            lblUserType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.AutoEllipsis = true;
            btnLogin.BackColor = Color.FromArgb(255, 128, 128);
            table.SetColumnSpan(btnLogin, 2);
            btnLogin.FlatAppearance.BorderColor = Color.Blue;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(625, 670);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(456, 66);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // gbUserType
            // 
            gbUserType.Controls.Add(rbStaff);
            gbUserType.Controls.Add(rbCustomer);
            gbUserType.Dock = DockStyle.Fill;
            gbUserType.Location = new Point(653, 254);
            gbUserType.Margin = new Padding(0);
            gbUserType.Name = "gbUserType";
            gbUserType.Padding = new Padding(0);
            gbUserType.Size = new Size(667, 109);
            gbUserType.TabIndex = 1;
            gbUserType.TabStop = false;
            // 
            // rbStaff
            // 
            rbStaff.AutoSize = true;
            rbStaff.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbStaff.Location = new Point(257, 33);
            rbStaff.Margin = new Padding(5);
            rbStaff.Name = "rbStaff";
            rbStaff.Size = new Size(94, 36);
            rbStaff.TabIndex = 3;
            rbStaff.TabStop = true;
            rbStaff.Text = "Staff";
            rbStaff.UseVisualStyleBackColor = true;
            // 
            // rbCustomer
            // 
            rbCustomer.AutoSize = true;
            rbCustomer.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbCustomer.Location = new Point(47, 33);
            rbCustomer.Margin = new Padding(5);
            rbCustomer.Name = "rbCustomer";
            rbCustomer.Size = new Size(160, 36);
            rbCustomer.TabIndex = 2;
            rbCustomer.TabStop = true;
            rbCustomer.Text = "Customer";
            rbCustomer.UseVisualStyleBackColor = true;
            // 
            // llRegister
            // 
            llRegister.Anchor = AnchorStyles.Left;
            llRegister.AutoSize = true;
            table.SetColumnSpan(llRegister, 2);
            llRegister.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            llRegister.LinkArea = new LinkArea(29, 43);
            llRegister.Location = new Point(390, 809);
            llRegister.Margin = new Padding(4, 0, 4, 0);
            llRegister.Name = "llRegister";
            llRegister.Size = new Size(497, 34);
            llRegister.TabIndex = 8;
            llRegister.TabStop = true;
            llRegister.Text = "Don't have customer account? Register Here";
            llRegister.UseCompatibleTextRendering = true;
            llRegister.LinkClicked += llRegister_LinkClicked;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(12F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1707, 985);
            Controls.Add(table);
            Name = "frmLogin";
            Text = "Integrated System";
            table.ResumeLayout(false);
            table.PerformLayout();
            gbUserType.ResumeLayout(false);
            gbUserType.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblForgetPassword;
        private Label lblWelcomeMsg;
        private Label lblUserName;
        private TextBox txtPassword;
        private Label lblPassword;
        private TextBox txtUserName;
        private TableLayoutPanel table;
        private Button btnLogin;
        private Label lblUserType;
        private GroupBox gbUserType;
        private RadioButton rbCustomer;
        private RadioButton rbStaff;
        private LinkLabel llRegister;
    }
}
