namespace Client.Views.SupplyChain
{
    partial class frmAddSupplier
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtSupplierID = new TextBox();
            txtSupplierName = new TextBox();
            txtPhoneNumber = new TextBox();
            txtEmail = new TextBox();
            txtAddress = new TextBox();
            label6 = new Label();
            txtContactPerson = new TextBox();
            btnAdd = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(113, 180);
            label1.Name = "label1";
            label1.Size = new Size(86, 19);
            label1.TabIndex = 0;
            label1.Text = "Supplier ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(113, 235);
            label2.Name = "label2";
            label2.Size = new Size(113, 19);
            label2.TabIndex = 1;
            label2.Text = "Supplier Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(113, 279);
            label3.Name = "label3";
            label3.Size = new Size(115, 19);
            label3.TabIndex = 2;
            label3.Text = "Phone Number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(417, 177);
            label4.Name = "label4";
            label4.Size = new Size(47, 19);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(417, 227);
            label5.Name = "label5";
            label5.Size = new Size(67, 19);
            label5.TabIndex = 4;
            label5.Text = "Address";
            // 
            // txtSupplierID
            // 
            txtSupplierID.Location = new Point(240, 177);
            txtSupplierID.Name = "txtSupplierID";
            txtSupplierID.Size = new Size(125, 27);
            txtSupplierID.TabIndex = 5;
            // 
            // txtSupplierName
            // 
            txtSupplierName.Location = new Point(240, 227);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.Size = new Size(125, 27);
            txtSupplierName.TabIndex = 6;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(240, 275);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(125, 27);
            txtPhoneNumber.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(544, 177);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 8;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(544, 227);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(125, 27);
            txtAddress.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(417, 278);
            label6.Name = "label6";
            label6.Size = new Size(114, 19);
            label6.TabIndex = 10;
            label6.Text = "Contact Person";
            // 
            // txtContactPerson
            // 
            txtContactPerson.Location = new Point(544, 275);
            txtContactPerson.Name = "txtContactPerson";
            txtContactPerson.Size = new Size(125, 27);
            txtContactPerson.TabIndex = 11;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(234, 364);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(446, 364);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 13;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;

            // 
            // frmAddSupplier
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 458);
            Controls.Add(btnBack);
            Controls.Add(btnAdd);
            Controls.Add(txtContactPerson);
            Controls.Add(label6);
            Controls.Add(txtAddress);
            Controls.Add(txtEmail);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtSupplierName);
            Controls.Add(txtSupplierID);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmAddSupplier";
            Text = "frmAddSupplier";
            Load += frmAddSupplier_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtSupplierID;
        private TextBox txtSupplierName;
        private TextBox txtPhoneNumber;
        private TextBox txtEmail;
        private TextBox txtAddress;
        private Label label6;
        private TextBox txtContactPerson;
        private Button btnAdd;
        private Button btnBack;
    }
}