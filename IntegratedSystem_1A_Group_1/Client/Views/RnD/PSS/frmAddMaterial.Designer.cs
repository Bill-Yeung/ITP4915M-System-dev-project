namespace Client.Views.RnD.PSS
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
            backgroundPanel = new TableLayoutPanel();
            tableAddMaterial = new TableLayoutPanel();
            lblMaterialName = new Label();
            lblQuantity = new Label();
            cbMaterialName = new ComboBox();
            txtQuantity = new TextBox();
            lblUnit = new Label();
            panelButton = new FlowLayoutPanel();
            btnOK = new Button();
            btnCancel = new Button();
            backgroundPanel.SuspendLayout();
            tableAddMaterial.SuspendLayout();
            panelButton.SuspendLayout();
            SuspendLayout();
            // 
            // backgroundPanel
            // 
            backgroundPanel.BackColor = SystemColors.GradientInactiveCaption;
            backgroundPanel.ColumnCount = 3;
            backgroundPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            backgroundPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            backgroundPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            backgroundPanel.Controls.Add(tableAddMaterial, 1, 1);
            backgroundPanel.Dock = DockStyle.Fill;
            backgroundPanel.Location = new Point(0, 0);
            backgroundPanel.Name = "backgroundPanel";
            backgroundPanel.RowCount = 3;
            backgroundPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            backgroundPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            backgroundPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            backgroundPanel.Size = new Size(625, 283);
            backgroundPanel.TabIndex = 0;
            // 
            // tableAddMaterial
            // 
            tableAddMaterial.ColumnCount = 3;
            tableAddMaterial.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableAddMaterial.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableAddMaterial.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            tableAddMaterial.Controls.Add(lblMaterialName, 0, 0);
            tableAddMaterial.Controls.Add(lblQuantity, 0, 1);
            tableAddMaterial.Controls.Add(cbMaterialName, 1, 0);
            tableAddMaterial.Controls.Add(txtQuantity, 1, 1);
            tableAddMaterial.Controls.Add(lblUnit, 2, 1);
            tableAddMaterial.Controls.Add(panelButton, 1, 2);
            tableAddMaterial.Dock = DockStyle.Fill;
            tableAddMaterial.Location = new Point(65, 31);
            tableAddMaterial.Name = "tableAddMaterial";
            tableAddMaterial.RowCount = 4;
            tableAddMaterial.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableAddMaterial.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableAddMaterial.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableAddMaterial.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableAddMaterial.Size = new Size(494, 220);
            tableAddMaterial.TabIndex = 0;
            // 
            // lblMaterialName
            // 
            lblMaterialName.Anchor = AnchorStyles.Left;
            lblMaterialName.AutoSize = true;
            lblMaterialName.Location = new Point(3, 18);
            lblMaterialName.Name = "lblMaterialName";
            lblMaterialName.Size = new Size(115, 19);
            lblMaterialName.TabIndex = 1;
            lblMaterialName.Text = "Material Name:";
            // 
            // lblQuantity
            // 
            lblQuantity.Anchor = AnchorStyles.Left;
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(3, 73);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(72, 19);
            lblQuantity.TabIndex = 2;
            lblQuantity.Text = "Quantity:";
            // 
            // cbMaterialName
            // 
            cbMaterialName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbMaterialName.FormattingEnabled = true;
            cbMaterialName.Location = new Point(214, 14);
            cbMaterialName.Name = "cbMaterialName";
            cbMaterialName.Size = new Size(205, 27);
            cbMaterialName.TabIndex = 5;
            cbMaterialName.SelectedIndexChanged += cbMaterialName_SelectedIndexChanged;
            // 
            // txtQuantity
            // 
            txtQuantity.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtQuantity.Location = new Point(214, 69);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(205, 27);
            txtQuantity.TabIndex = 6;
            // 
            // lblUnit
            // 
            lblUnit.Anchor = AnchorStyles.Left;
            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(425, 73);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(46, 19);
            lblUnit.TabIndex = 3;
            lblUnit.Text = "(unit)";
            // 
            // panelButton
            // 
            panelButton.Anchor = AnchorStyles.Left;
            panelButton.Controls.Add(btnOK);
            panelButton.Controls.Add(btnCancel);
            panelButton.Location = new Point(214, 119);
            panelButton.Name = "panelButton";
            panelButton.Size = new Size(205, 36);
            panelButton.TabIndex = 7;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Left;
            btnOK.BackColor = Color.Moccasin;
            btnOK.Location = new Point(3, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 26);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Moccasin;
            btnCancel.Location = new Point(103, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 26);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmAddMaterial
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(625, 283);
            Controls.Add(backgroundPanel);
            Name = "frmAddMaterial";
            Text = "Add Material to the List";
            Load += frmAddMaterial_Load;
            backgroundPanel.ResumeLayout(false);
            tableAddMaterial.ResumeLayout(false);
            tableAddMaterial.PerformLayout();
            panelButton.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel backgroundPanel;
        private TableLayoutPanel tableAddMaterial;
        private Label lblMaterialName;
        private Label lblQuantity;
        private Label lblUnit;
        private ComboBox cbMaterialName;
        private TextBox txtQuantity;
        private FlowLayoutPanel panelButton;
        private Button btnOK;
        private Button btnCancel;
    }
}