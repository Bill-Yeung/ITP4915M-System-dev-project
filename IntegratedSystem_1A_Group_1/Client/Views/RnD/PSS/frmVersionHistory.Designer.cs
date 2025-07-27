namespace Client.Views.RnD.PSS
{
    partial class frmVersionHistory
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
            dgvProductAttribute = new DataGridView();
            dgvMaterial = new DataGridView();
            lblProductAttribute = new Label();
            lblMaterial = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductAttribute).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMaterial).BeginInit();
            SuspendLayout();
            // 
            // dgvProductAttribute
            // 
            dgvProductAttribute.AllowUserToAddRows = false;
            dgvProductAttribute.AllowUserToDeleteRows = false;
            dgvProductAttribute.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductAttribute.Location = new Point(39, 65);
            dgvProductAttribute.Name = "dgvProductAttribute";
            dgvProductAttribute.ReadOnly = true;
            dgvProductAttribute.RowHeadersWidth = 51;
            dgvProductAttribute.Size = new Size(1271, 280);
            dgvProductAttribute.TabIndex = 0;
            // 
            // dgvMaterial
            // 
            dgvMaterial.AllowUserToAddRows = false;
            dgvMaterial.AllowUserToDeleteRows = false;
            dgvMaterial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterial.Location = new Point(39, 416);
            dgvMaterial.Name = "dgvMaterial";
            dgvMaterial.ReadOnly = true;
            dgvMaterial.RowHeadersWidth = 51;
            dgvMaterial.Size = new Size(1271, 317);
            dgvMaterial.TabIndex = 1;
            // 
            // lblProductAttribute
            // 
            lblProductAttribute.AutoSize = true;
            lblProductAttribute.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 136);
            lblProductAttribute.Location = new Point(39, 30);
            lblProductAttribute.Name = "lblProductAttribute";
            lblProductAttribute.Size = new Size(129, 19);
            lblProductAttribute.TabIndex = 2;
            lblProductAttribute.Text = "Product Attribute";
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 136);
            lblMaterial.Location = new Point(39, 371);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(66, 19);
            lblMaterial.TabIndex = 3;
            lblMaterial.Text = "Material";
            // 
            // frmVersionHistory
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1349, 774);
            Controls.Add(lblMaterial);
            Controls.Add(lblProductAttribute);
            Controls.Add(dgvMaterial);
            Controls.Add(dgvProductAttribute);
            Name = "frmVersionHistory";
            Text = "frmVersionHistory";
            Load += frmVersionHistory_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductAttribute).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMaterial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProductAttribute;
        private DataGridView dgvMaterial;
        private Label lblProductAttribute;
        private Label lblMaterial;
    }
}