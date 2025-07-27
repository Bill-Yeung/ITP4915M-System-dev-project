namespace Client.Views.Login
{
    partial class frmForgetPassword
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
            tableMain = new TableLayoutPanel();
            tableLayout = new TableLayoutPanel();
            lblForgetPassword = new Label();
            lblHeader = new Label();
            btnReturn = new Button();
            tableMain.SuspendLayout();
            tableLayout.SuspendLayout();
            SuspendLayout();
            // 
            // tableMain
            // 
            tableMain.ColumnCount = 3;
            tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableMain.Controls.Add(tableLayout, 1, 1);
            tableMain.Controls.Add(btnReturn, 0, 0);
            tableMain.Dock = DockStyle.Fill;
            tableMain.Location = new Point(0, 0);
            tableMain.Name = "tableMain";
            tableMain.RowCount = 3;
            tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableMain.Size = new Size(1280, 720);
            tableMain.TabIndex = 0;
            // 
            // tableLayout
            // 
            tableLayout.ColumnCount = 1;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayout.Controls.Add(lblForgetPassword, 0, 1);
            tableLayout.Controls.Add(lblHeader, 0, 0);
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.Location = new Point(131, 75);
            tableLayout.Name = "tableLayout";
            tableLayout.RowCount = 2;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 19.2982464F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 80.70175F));
            tableLayout.Size = new Size(1018, 570);
            tableLayout.TabIndex = 0;
            // 
            // lblForgetPassword
            // 
            lblForgetPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblForgetPassword.AutoSize = true;
            lblForgetPassword.Font = new Font("Microsoft JhengHei UI", 18F);
            lblForgetPassword.Location = new Point(3, 110);
            lblForgetPassword.Name = "lblForgetPassword";
            lblForgetPassword.Size = new Size(1012, 460);
            lblForgetPassword.TabIndex = 1;
            lblForgetPassword.Text = "Please contact IT administrator to reset password !";
            lblForgetPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Arial", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(3, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(1012, 110);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Forget Password";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(3, 3);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(75, 62);
            btnReturn.TabIndex = 1;
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // frmForgetPassword
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1280, 720);
            Controls.Add(tableMain);
            Name = "frmForgetPassword";
            Text = "Integrated System";
            tableMain.ResumeLayout(false);
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableMain;
        private TableLayoutPanel tableLayout;
        private Label lblHeader;
        private Label lblForgetPassword;
        private Button btnReturn;
    }
}
