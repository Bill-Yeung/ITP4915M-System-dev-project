using Client.Common;

namespace Client.Views.RnD.PSS
{
    partial class frmCreateProduct
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
            tableMain = new TableLayoutPanel();
            tableLayout = new TableLayoutPanel();
            lblheader = new Label();
            flowLayoutButton = new FlowLayoutPanel();
            btnCancel = new Button();
            btnSubmit = new Button();
            panelCreate = new Panel();
            tableLayoutCreate = new TableLayoutPanel();
            lblFunctionHeader = new Label();
            tableForm = new TableLayoutPanel();
            lblProductID = new Label();
            txtProductID = new TextBox();
            lblProductName = new Label();
            lblProductType = new Label();
            txtProductName = new TextBox();
            gbProductType = new GroupBox();
            rbExternal = new RadioButton();
            rbInternal = new RadioButton();
            lblProductSponsor = new Label();
            lblTeamAssignment = new Label();
            lblProductCategory = new Label();
            lblProductVersion = new Label();
            lblProductInherited = new Label();
            lblProductDescription = new Label();
            txtVersion = new TextBox();
            txtProductDescription = new RichTextBox();
            cbProductCategory = new ComboBox();
            cbProductInherited = new ComboBox();
            tableLayoutTeam = new TableLayoutPanel();
            lblLeader = new Label();
            lblRnD = new Label();
            lblDesign = new Label();
            lblEngineering = new Label();
            lblSnM = new Label();
            cbLeader = new ComboBox();
            cbRnD = new ComboBox();
            cbDesign = new ComboBox();
            cbEngineering = new ComboBox();
            cbSnM = new ComboBox();
            cbProductSponsor = new ComboBox();
            tableMain.SuspendLayout();
            tableLayout.SuspendLayout();
            flowLayoutButton.SuspendLayout();
            panelCreate.SuspendLayout();
            tableLayoutCreate.SuspendLayout();
            tableForm.SuspendLayout();
            gbProductType.SuspendLayout();
            tableLayoutTeam.SuspendLayout();
            SuspendLayout();
            // 
            // tableMain
            // 
            tableMain.ColumnCount = 3;
            tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableMain.Controls.Add(tableLayout, 1, 1);
            tableMain.Dock = DockStyle.Fill;
            tableMain.Location = new Point(0, 0);
            tableMain.Margin = new Padding(0);
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
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayout.Controls.Add(lblheader, 0, 0);
            tableLayout.Controls.Add(flowLayoutButton, 0, 2);
            tableLayout.Controls.Add(panelCreate, 0, 1);
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.Location = new Point(130, 74);
            tableLayout.Margin = new Padding(2);
            tableLayout.Name = "tableLayout";
            tableLayout.RowCount = 3;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            tableLayout.Size = new Size(1020, 572);
            tableLayout.TabIndex = 0;
            // 
            // lblheader
            // 
            lblheader.AutoSize = true;
            lblheader.Dock = DockStyle.Fill;
            lblheader.Font = new Font("Arial", 16.2F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblheader.Location = new Point(2, 0);
            lblheader.Margin = new Padding(2, 0, 2, 0);
            lblheader.Name = "lblheader";
            lblheader.Size = new Size(1016, 69);
            lblheader.TabIndex = 0;
            lblheader.Text = "Research && Development - Product Specification";
            lblheader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutButton
            // 
            flowLayoutButton.Anchor = AnchorStyles.Right;
            flowLayoutButton.Controls.Add(btnCancel);
            flowLayoutButton.Controls.Add(btnSubmit);
            flowLayoutButton.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutButton.Location = new Point(102, 515);
            flowLayoutButton.Margin = new Padding(2);
            flowLayoutButton.Name = "flowLayoutButton";
            flowLayoutButton.Size = new Size(916, 45);
            flowLayoutButton.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.None;
            btnCancel.BackColor = Color.Moccasin;
            btnCancel.Location = new Point(768, 2);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(146, 36);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.None;
            btnSubmit.BackColor = Color.Moccasin;
            btnSubmit.Location = new Point(573, 2);
            btnSubmit.Margin = new Padding(2, 2, 20, 2);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(173, 36);
            btnSubmit.TabIndex = 13;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // panelCreate
            // 
            panelCreate.BorderStyle = BorderStyle.FixedSingle;
            panelCreate.Controls.Add(tableLayoutCreate);
            panelCreate.Dock = DockStyle.Fill;
            panelCreate.Location = new Point(2, 71);
            panelCreate.Margin = new Padding(2);
            panelCreate.Name = "panelCreate";
            panelCreate.Size = new Size(1016, 430);
            panelCreate.TabIndex = 2;
            // 
            // tableLayoutCreate
            // 
            tableLayoutCreate.ColumnCount = 1;
            tableLayoutCreate.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutCreate.Controls.Add(lblFunctionHeader, 0, 0);
            tableLayoutCreate.Controls.Add(tableForm, 0, 1);
            tableLayoutCreate.Dock = DockStyle.Fill;
            tableLayoutCreate.Location = new Point(0, 0);
            tableLayoutCreate.Margin = new Padding(2);
            tableLayoutCreate.Name = "tableLayoutCreate";
            tableLayoutCreate.RowCount = 2;
            tableLayoutCreate.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            tableLayoutCreate.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutCreate.Size = new Size(1014, 428);
            tableLayoutCreate.TabIndex = 0;
            // 
            // lblFunctionHeader
            // 
            lblFunctionHeader.AutoSize = true;
            lblFunctionHeader.Dock = DockStyle.Fill;
            lblFunctionHeader.Font = new Font("Arial", 12F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblFunctionHeader.Location = new Point(2, 0);
            lblFunctionHeader.Margin = new Padding(2, 0, 2, 0);
            lblFunctionHeader.Name = "lblFunctionHeader";
            lblFunctionHeader.Size = new Size(1010, 69);
            lblFunctionHeader.TabIndex = 0;
            lblFunctionHeader.Text = "Create Product";
            lblFunctionHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableForm
            // 
            tableForm.ColumnCount = 5;
            tableForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.5F));
            tableForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.5F));
            tableForm.Controls.Add(lblProductID, 0, 0);
            tableForm.Controls.Add(txtProductID, 1, 0);
            tableForm.Controls.Add(lblProductName, 0, 1);
            tableForm.Controls.Add(lblProductType, 0, 2);
            tableForm.Controls.Add(txtProductName, 1, 1);
            tableForm.Controls.Add(gbProductType, 1, 2);
            tableForm.Controls.Add(lblProductSponsor, 0, 3);
            tableForm.Controls.Add(lblTeamAssignment, 0, 4);
            tableForm.Controls.Add(lblProductCategory, 3, 0);
            tableForm.Controls.Add(lblProductVersion, 3, 1);
            tableForm.Controls.Add(lblProductInherited, 3, 2);
            tableForm.Controls.Add(lblProductDescription, 3, 3);
            tableForm.Controls.Add(txtVersion, 4, 1);
            tableForm.Controls.Add(txtProductDescription, 4, 3);
            tableForm.Controls.Add(cbProductCategory, 4, 0);
            tableForm.Controls.Add(cbProductInherited, 4, 2);
            tableForm.Controls.Add(tableLayoutTeam, 1, 4);
            tableForm.Controls.Add(cbProductSponsor, 1, 3);
            tableForm.Dock = DockStyle.Fill;
            tableForm.Location = new Point(2, 71);
            tableForm.Margin = new Padding(2);
            tableForm.Name = "tableForm";
            tableForm.RowCount = 5;
            tableForm.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableForm.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableForm.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableForm.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableForm.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableForm.Size = new Size(1010, 355);
            tableForm.TabIndex = 1;
            // 
            // lblProductID
            // 
            lblProductID.AutoSize = true;
            lblProductID.Location = new Point(2, 0);
            lblProductID.Margin = new Padding(2, 0, 2, 0);
            lblProductID.Name = "lblProductID";
            lblProductID.Size = new Size(86, 19);
            lblProductID.TabIndex = 0;
            lblProductID.Text = "Product ID:";
            // 
            // txtProductID
            // 
            txtProductID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtProductID.Enabled = false;
            txtProductID.Location = new Point(204, 2);
            txtProductID.Margin = new Padding(2);
            txtProductID.Name = "txtProductID";
            txtProductID.ReadOnly = true;
            txtProductID.Size = new Size(273, 27);
            txtProductID.TabIndex = 1;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(2, 53);
            lblProductName.Margin = new Padding(2, 0, 2, 0);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(113, 19);
            lblProductName.TabIndex = 2;
            lblProductName.Text = "Product Name:";
            // 
            // lblProductType
            // 
            lblProductType.AutoSize = true;
            lblProductType.Location = new Point(2, 106);
            lblProductType.Margin = new Padding(2, 0, 2, 0);
            lblProductType.Name = "lblProductType";
            lblProductType.Size = new Size(104, 19);
            lblProductType.TabIndex = 3;
            lblProductType.Text = "Product Type:";
            // 
            // txtProductName
            // 
            txtProductName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtProductName.Location = new Point(204, 55);
            txtProductName.Margin = new Padding(2);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(273, 27);
            txtProductName.TabIndex = 1;
            // 
            // gbProductType
            // 
            gbProductType.Controls.Add(rbExternal);
            gbProductType.Controls.Add(rbInternal);
            gbProductType.Dock = DockStyle.Fill;
            gbProductType.Location = new Point(202, 106);
            gbProductType.Margin = new Padding(0);
            gbProductType.Name = "gbProductType";
            gbProductType.Padding = new Padding(0);
            gbProductType.Size = new Size(277, 53);
            gbProductType.TabIndex = 2;
            gbProductType.TabStop = false;
            // 
            // rbExternal
            // 
            rbExternal.AutoSize = true;
            rbExternal.Location = new Point(95, 12);
            rbExternal.Margin = new Padding(2);
            rbExternal.Name = "rbExternal";
            rbExternal.Size = new Size(85, 23);
            rbExternal.TabIndex = 0;
            rbExternal.TabStop = true;
            rbExternal.Text = "External";
            rbExternal.UseVisualStyleBackColor = true;
            rbExternal.CheckedChanged += rbExternal_CheckedChanged;
            // 
            // rbInternal
            // 
            rbInternal.AutoSize = true;
            rbInternal.Location = new Point(7, 12);
            rbInternal.Margin = new Padding(2);
            rbInternal.Name = "rbInternal";
            rbInternal.Size = new Size(83, 23);
            rbInternal.TabIndex = 1;
            rbInternal.TabStop = true;
            rbInternal.Text = "Internal";
            rbInternal.UseVisualStyleBackColor = true;
            rbInternal.CheckedChanged += rbInternal_CheckedChanged;
            // 
            // lblProductSponsor
            // 
            lblProductSponsor.AutoSize = true;
            lblProductSponsor.Location = new Point(2, 159);
            lblProductSponsor.Margin = new Padding(2, 0, 2, 0);
            lblProductSponsor.Name = "lblProductSponsor";
            lblProductSponsor.Size = new Size(129, 19);
            lblProductSponsor.TabIndex = 6;
            lblProductSponsor.Text = "Product Sponsor:";
            // 
            // lblTeamAssignment
            // 
            lblTeamAssignment.AutoSize = true;
            lblTeamAssignment.Location = new Point(2, 212);
            lblTeamAssignment.Margin = new Padding(2, 0, 2, 0);
            lblTeamAssignment.Name = "lblTeamAssignment";
            lblTeamAssignment.Size = new Size(137, 19);
            lblTeamAssignment.TabIndex = 7;
            lblTeamAssignment.Text = "Team Assignment:";
            // 
            // lblProductCategory
            // 
            lblProductCategory.AutoSize = true;
            lblProductCategory.Location = new Point(531, 0);
            lblProductCategory.Margin = new Padding(2, 0, 2, 0);
            lblProductCategory.Name = "lblProductCategory";
            lblProductCategory.Size = new Size(135, 19);
            lblProductCategory.TabIndex = 8;
            lblProductCategory.Text = "Product Category:";
            // 
            // lblProductVersion
            // 
            lblProductVersion.AutoSize = true;
            lblProductVersion.Location = new Point(531, 53);
            lblProductVersion.Margin = new Padding(2, 0, 2, 0);
            lblProductVersion.Name = "lblProductVersion";
            lblProductVersion.Size = new Size(124, 19);
            lblProductVersion.TabIndex = 9;
            lblProductVersion.Text = "Product Version:";
            // 
            // lblProductInherited
            // 
            lblProductInherited.AutoSize = true;
            lblProductInherited.Location = new Point(531, 106);
            lblProductInherited.Margin = new Padding(2, 0, 2, 0);
            lblProductInherited.Name = "lblProductInherited";
            lblProductInherited.Size = new Size(134, 19);
            lblProductInherited.TabIndex = 10;
            lblProductInherited.Text = "Product Inherited:";
            // 
            // lblProductDescription
            // 
            lblProductDescription.AutoSize = true;
            lblProductDescription.Location = new Point(531, 159);
            lblProductDescription.Margin = new Padding(2, 0, 2, 0);
            lblProductDescription.Name = "lblProductDescription";
            lblProductDescription.Size = new Size(150, 19);
            lblProductDescription.TabIndex = 11;
            lblProductDescription.Text = "Product Description:";
            // 
            // txtVersion
            // 
            txtVersion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtVersion.Location = new Point(733, 55);
            txtVersion.Margin = new Padding(2);
            txtVersion.Name = "txtVersion";
            txtVersion.Size = new Size(275, 27);
            txtVersion.TabIndex = 10;
            // 
            // txtProductDescription
            // 
            txtProductDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtProductDescription.Font = new Font("Arial", 10F);
            txtProductDescription.Location = new Point(733, 161);
            txtProductDescription.Margin = new Padding(2);
            txtProductDescription.Name = "txtProductDescription";
            tableForm.SetRowSpan(txtProductDescription, 2);
            txtProductDescription.Size = new Size(275, 192);
            txtProductDescription.TabIndex = 12;
            txtProductDescription.Text = "";
            // 
            // cbProductCategory
            // 
            cbProductCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbProductCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbProductCategory.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbProductCategory.FormattingEnabled = true;
            cbProductCategory.Location = new Point(733, 2);
            cbProductCategory.Margin = new Padding(2);
            cbProductCategory.Name = "cbProductCategory";
            cbProductCategory.Size = new Size(275, 27);
            cbProductCategory.TabIndex = 9;
            // 
            // cbProductInherited
            // 
            cbProductInherited.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbProductInherited.FormattingEnabled = true;
            cbProductInherited.Location = new Point(733, 108);
            cbProductInherited.Margin = new Padding(2);
            cbProductInherited.Name = "cbProductInherited";
            cbProductInherited.Size = new Size(275, 27);
            cbProductInherited.TabIndex = 11;
            // 
            // tableLayoutTeam
            // 
            tableLayoutTeam.ColumnCount = 2;
            tableLayoutTeam.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutTeam.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutTeam.Controls.Add(lblLeader, 0, 0);
            tableLayoutTeam.Controls.Add(lblRnD, 0, 1);
            tableLayoutTeam.Controls.Add(lblDesign, 0, 2);
            tableLayoutTeam.Controls.Add(lblEngineering, 0, 3);
            tableLayoutTeam.Controls.Add(lblSnM, 0, 4);
            tableLayoutTeam.Controls.Add(cbLeader, 1, 0);
            tableLayoutTeam.Controls.Add(cbRnD, 1, 1);
            tableLayoutTeam.Controls.Add(cbDesign, 1, 2);
            tableLayoutTeam.Controls.Add(cbEngineering, 1, 3);
            tableLayoutTeam.Controls.Add(cbSnM, 1, 4);
            tableLayoutTeam.Dock = DockStyle.Fill;
            tableLayoutTeam.Location = new Point(204, 214);
            tableLayoutTeam.Margin = new Padding(2);
            tableLayoutTeam.Name = "tableLayoutTeam";
            tableLayoutTeam.RowCount = 5;
            tableLayoutTeam.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutTeam.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutTeam.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutTeam.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutTeam.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutTeam.Size = new Size(273, 139);
            tableLayoutTeam.TabIndex = 16;
            // 
            // lblLeader
            // 
            lblLeader.Anchor = AnchorStyles.Left;
            lblLeader.AutoSize = true;
            lblLeader.Location = new Point(2, 4);
            lblLeader.Margin = new Padding(2, 0, 2, 0);
            lblLeader.Name = "lblLeader";
            lblLeader.Size = new Size(57, 19);
            lblLeader.TabIndex = 0;
            lblLeader.Text = "Leader";
            // 
            // lblRnD
            // 
            lblRnD.Anchor = AnchorStyles.Left;
            lblRnD.AutoSize = true;
            lblRnD.Location = new Point(2, 31);
            lblRnD.Margin = new Padding(2, 0, 2, 0);
            lblRnD.Name = "lblRnD";
            lblRnD.Size = new Size(51, 19);
            lblRnD.TabIndex = 1;
            lblRnD.Text = "R && D";
            // 
            // lblDesign
            // 
            lblDesign.Anchor = AnchorStyles.Left;
            lblDesign.AutoSize = true;
            lblDesign.Location = new Point(2, 58);
            lblDesign.Margin = new Padding(2, 0, 2, 0);
            lblDesign.Name = "lblDesign";
            lblDesign.Size = new Size(58, 19);
            lblDesign.TabIndex = 2;
            lblDesign.Text = "Design";
            // 
            // lblEngineering
            // 
            lblEngineering.Anchor = AnchorStyles.Left;
            lblEngineering.AutoSize = true;
            lblEngineering.Location = new Point(2, 85);
            lblEngineering.Margin = new Padding(2, 0, 2, 0);
            lblEngineering.Name = "lblEngineering";
            lblEngineering.Size = new Size(94, 19);
            lblEngineering.TabIndex = 3;
            lblEngineering.Text = "Engineering";
            // 
            // lblSnM
            // 
            lblSnM.Anchor = AnchorStyles.Left;
            lblSnM.AutoSize = true;
            lblSnM.Location = new Point(2, 114);
            lblSnM.Margin = new Padding(2, 0, 2, 0);
            lblSnM.Name = "lblSnM";
            lblSnM.Size = new Size(53, 19);
            lblSnM.TabIndex = 4;
            lblSnM.Text = "S && M";
            // 
            // cbLeader
            // 
            cbLeader.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbLeader.FormattingEnabled = true;
            cbLeader.Location = new Point(111, 2);
            cbLeader.Margin = new Padding(2);
            cbLeader.Name = "cbLeader";
            cbLeader.Size = new Size(160, 27);
            cbLeader.TabIndex = 4;
            // 
            // cbRnD
            // 
            cbRnD.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbRnD.FormattingEnabled = true;
            cbRnD.Location = new Point(111, 29);
            cbRnD.Margin = new Padding(2);
            cbRnD.Name = "cbRnD";
            cbRnD.Size = new Size(160, 27);
            cbRnD.TabIndex = 5;
            // 
            // cbDesign
            // 
            cbDesign.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbDesign.FormattingEnabled = true;
            cbDesign.Location = new Point(111, 56);
            cbDesign.Margin = new Padding(2);
            cbDesign.Name = "cbDesign";
            cbDesign.Size = new Size(160, 27);
            cbDesign.TabIndex = 6;
            // 
            // cbEngineering
            // 
            cbEngineering.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbEngineering.FormattingEnabled = true;
            cbEngineering.Location = new Point(111, 83);
            cbEngineering.Margin = new Padding(2);
            cbEngineering.Name = "cbEngineering";
            cbEngineering.Size = new Size(160, 27);
            cbEngineering.TabIndex = 7;
            // 
            // cbSnM
            // 
            cbSnM.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbSnM.FormattingEnabled = true;
            cbSnM.Location = new Point(111, 110);
            cbSnM.Margin = new Padding(2);
            cbSnM.Name = "cbSnM";
            cbSnM.Size = new Size(160, 27);
            cbSnM.TabIndex = 7;
            // 
            // cbProductSponsor
            // 
            cbProductSponsor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbProductSponsor.FormattingEnabled = true;
            cbProductSponsor.Location = new Point(204, 161);
            cbProductSponsor.Margin = new Padding(2);
            cbProductSponsor.Name = "cbProductSponsor";
            cbProductSponsor.Size = new Size(273, 27);
            cbProductSponsor.TabIndex = 3;
            // 
            // frmCreateProduct
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1280, 720);
            Controls.Add(tableMain);
            Margin = new Padding(2);
            Name = "frmCreateProduct";
            Text = "Integrated System";
            Load += frmCreateProduct_Load;
            tableMain.ResumeLayout(false);
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
            flowLayoutButton.ResumeLayout(false);
            panelCreate.ResumeLayout(false);
            tableLayoutCreate.ResumeLayout(false);
            tableLayoutCreate.PerformLayout();
            tableForm.ResumeLayout(false);
            tableForm.PerformLayout();
            gbProductType.ResumeLayout(false);
            gbProductType.PerformLayout();
            tableLayoutTeam.ResumeLayout(false);
            tableLayoutTeam.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableMain;
        private TableLayoutPanel tableLayout;
        private Label lblheader;
        private FlowLayoutPanel flowLayoutButton;
        private Button btnCancel;
        private Button btnSubmit;
        private Panel panelCreate;
        private TableLayoutPanel tableLayoutCreate;
        private Label lblFunctionHeader;
        private TableLayoutPanel tableForm;
        private Label lblProductID;
        private TextBox txtProductID;
        private Label lblProductCategory;
        private Label lblProductName;
        private Label lblProductVersion;
        private Label lblProductType;
        private TextBox txtProductName;
        private GroupBox gbProductType;
        private RadioButton rbExternal;
        private RadioButton rbInternal;
        private Label lblProductInherited;
        private Label lblProductSponsor;
        private Label lblProductDescription;
        private Label lblTeamAssignment;
        private TextBox txtVersion;
        private RichTextBox txtProductDescription;
        private ComboBox cbProductCategory;
        private ComboBox cbProductInherited;
        private TableLayoutPanel tableLayoutTeam;
        private Label lblLeader;
        private Label lblRnD;
        private Label lblDesign;
        private Label lblEngineering;
        private Label lblSnM;
        private ComboBox cbLeader;
        private ComboBox cbProductSponsor;
        private ComboBox cbRnD;
        private ComboBox cbDesign;
        private ComboBox cbEngineering;
        private ComboBox cbSnM;
    }
}