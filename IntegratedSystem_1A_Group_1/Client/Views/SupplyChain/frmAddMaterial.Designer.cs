 namespace Client.Views.SupplyChain
{
    partial class frmAddMaterial
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
            lblMID = new Label();
            lblMName = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtMID = new TextBox();
            txtMName = new TextBox();
            txtAlert = new TextBox();
            txtPrice = new TextBox();
            txtAlertUnit = new TextBox();
            pictureBox1 = new PictureBox();
            btnAddMaterial = new Button();
            btnCancel = new Button();
            btnPhoto = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblMID
            // 
            lblMID.AutoSize = true;
            lblMID.Location = new Point(75, 104);
            lblMID.Name = "lblMID";
            lblMID.Size = new Size(85, 19);
            lblMID.TabIndex = 0;
            lblMID.Text = "Material ID";
            lblMID.Click += label1_Click;
            // 
            // lblMName
            // 
            lblMName.AutoSize = true;
            lblMName.Location = new Point(494, 100);
            lblMName.Name = "lblMName";
            lblMName.Size = new Size(112, 19);
            lblMName.TabIndex = 1;
            lblMName.Text = "Material Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(75, 173);
            label4.Name = "label4";
            label4.Size = new Size(203, 19);
            label4.TabIndex = 3;
            label4.Text = "Low Level Alert Index Below";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(75, 293);
            label5.Name = "label5";
            label5.Size = new Size(50, 19);
            label5.TabIndex = 4;
            label5.Text = "Photo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(495, 173);
            label6.Name = "label6";
            label6.Size = new Size(43, 19);
            label6.TabIndex = 5;
            label6.Text = "Price";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(495, 238);
            label7.Name = "label7";
            label7.Size = new Size(112, 19);
            label7.TabIndex = 6;
            label7.Text = "Unit (Quantity)";
            // 
            // txtMID
            // 
            txtMID.Location = new Point(298, 95);
            txtMID.Name = "txtMID";
            txtMID.Size = new Size(118, 27);
            txtMID.TabIndex = 7;
            // 
            // txtMName
            // 
            txtMName.Location = new Point(627, 95);
            txtMName.Name = "txtMName";
            txtMName.Size = new Size(118, 27);
            txtMName.TabIndex = 8;
            // 
            // txtAlert
            // 
            txtAlert.Location = new Point(298, 169);
            txtAlert.Name = "txtAlert";
            txtAlert.Size = new Size(118, 27);
            txtAlert.TabIndex = 10;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(627, 164);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(118, 27);
            txtPrice.TabIndex = 11;
            // 
            // txtAlertUnit
            // 
            txtAlertUnit.Location = new Point(627, 237);
            txtAlertUnit.Name = "txtAlertUnit";
            txtAlertUnit.Size = new Size(118, 27);
            txtAlertUnit.TabIndex = 12;
            txtAlertUnit.TextChanged += txtAlertUnit_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(165, 277);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // btnAddMaterial
            // 
            btnAddMaterial.Location = new Point(285, 395);
            btnAddMaterial.Name = "btnAddMaterial";
            btnAddMaterial.Size = new Size(94, 29);
            btnAddMaterial.TabIndex = 14;
            btnAddMaterial.Text = "Add";
            btnAddMaterial.UseVisualStyleBackColor = true;
            btnAddMaterial.Click += btnAddMaterial_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(431, 395);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnPhoto
            // 
            btnPhoto.Location = new Point(196, 310);
            btnPhoto.Name = "btnPhoto";
            btnPhoto.Size = new Size(94, 29);
            btnPhoto.TabIndex = 16;
            btnPhoto.Text = "Upload";
            btnPhoto.UseVisualStyleBackColor = true;
            // 
            // frmAddMaterial
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPhoto);
            Controls.Add(btnCancel);
            Controls.Add(btnAddMaterial);
            Controls.Add(pictureBox1);
            Controls.Add(txtAlertUnit);
            Controls.Add(txtPrice);
            Controls.Add(txtAlert);
            Controls.Add(txtMName);
            Controls.Add(txtMID);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(lblMName);
            Controls.Add(lblMID);
            Name = "frmAddMaterial";
            Text = "frmAddMaterial";
            Load += frmAddMaterial_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMID;
        private Label lblMName;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtMID;
        private TextBox txtMName;
        private TextBox txtAlert;
        private TextBox txtPrice;
        private TextBox txtAlertUnit;
        private PictureBox pictureBox1;
        private Button btnAddMaterial;
        private Button btnCancel;
        private Button btnPhoto;
    }
}