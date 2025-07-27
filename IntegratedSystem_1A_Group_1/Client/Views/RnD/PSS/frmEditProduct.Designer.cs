using Client.Common;

namespace Client.Views.RnD.PSS
{
    partial class frmEditProduct
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
            components = new System.ComponentModel.Container();
            tableMain = new TableLayoutPanel();
            tableLayout = new TableLayoutPanel();
            lblheader = new Label();
            flowLayoutPanelHeader = new FlowLayoutPanel();
            lblProductID = new Label();
            txtProductID = new TextBox();
            lblProductName = new Label();
            txtProductName = new TextBox();
            tabControl = new TabControl();
            tabBasic = new TabPage();
            tabProductTeam = new TabPage();
            tabProductDetails = new TabPage();
            tabManufacturing = new TabPage();
            tabPackaging = new TabPage();
            tabVersionHistory = new TabPage();
            tableBasic = new TableLayoutPanel();
            bindingSource1 = new BindingSource(components);
            tableMain.SuspendLayout();
            tableLayout.SuspendLayout();
            flowLayoutPanelHeader.SuspendLayout();
            tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // tableMain
            // 
            tableMain.ColumnCount = 3;
            tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0F));
            tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 105F));
            tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0F));
            tableMain.Controls.Add(tableLayout, 1, 1);
            tableMain.Dock = DockStyle.Fill;
            tableMain.Location = new Point(0, 0);
            tableMain.Margin = new Padding(0);
            tableMain.Name = "tableMain";
            tableMain.RowCount = 3;
            tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableMain.Size = new Size(996, 568);
            tableMain.TabIndex = 0;
            // 
            // tableLayout
            // 
            tableLayout.ColumnCount = 1;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayout.Controls.Add(lblheader, 0, 0);
            tableLayout.Controls.Add(flowLayoutPanelHeader, 0, 1);
            tableLayout.Controls.Add(tabControl, 0, 2);
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.Location = new Point(51, 58);
            tableLayout.Margin = new Padding(2);
            tableLayout.Name = "tableLayout";
            tableLayout.RowCount = 3;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayout.Size = new Size(892, 450);
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
            lblheader.Size = new Size(888, 54);
            lblheader.TabIndex = 0;
            lblheader.Text = "Research && Development - Product Specification";
            lblheader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelHeader
            // 
            flowLayoutPanelHeader.BackColor = Color.MediumSeaGreen;
            flowLayoutPanelHeader.Controls.Add(lblProductID);
            flowLayoutPanelHeader.Controls.Add(txtProductID);
            flowLayoutPanelHeader.Controls.Add(lblProductName);
            flowLayoutPanelHeader.Controls.Add(txtProductName);
            flowLayoutPanelHeader.Dock = DockStyle.Fill;
            flowLayoutPanelHeader.Location = new Point(3, 57);
            flowLayoutPanelHeader.Name = "flowLayoutPanelHeader";
            flowLayoutPanelHeader.Size = new Size(886, 30);
            flowLayoutPanelHeader.TabIndex = 1;
            // 
            // lblProductID
            // 
            lblProductID.Anchor = AnchorStyles.Left;
            lblProductID.AutoSize = true;
            lblProductID.Location = new Point(3, 7);
            lblProductID.Name = "lblProductID";
            lblProductID.Size = new Size(66, 15);
            lblProductID.TabIndex = 0;
            lblProductID.Text = "Product ID:";
            lblProductID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtProductID
            // 
            txtProductID.Enabled = false;
            txtProductID.Location = new Point(75, 3);
            txtProductID.Name = "txtProductID";
            txtProductID.ReadOnly = true;
            txtProductID.Size = new Size(168, 23);
            txtProductID.TabIndex = 1;
            // 
            // lblProductName
            // 
            lblProductName.Anchor = AnchorStyles.Left;
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(256, 7);
            lblProductName.Margin = new Padding(10, 0, 3, 0);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(87, 15);
            lblProductName.TabIndex = 2;
            lblProductName.Text = "Product Name:";
            lblProductName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtProductName
            // 
            txtProductName.Anchor = AnchorStyles.Left;
            txtProductName.Enabled = false;
            txtProductName.Location = new Point(349, 3);
            txtProductName.Name = "txtProductName";
            txtProductName.ReadOnly = true;
            txtProductName.Size = new Size(183, 23);
            txtProductName.TabIndex = 3;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabBasic);
            tabControl.Controls.Add(tabProductTeam);
            tabControl.Controls.Add(tabProductDetails);
            tabControl.Controls.Add(tabManufacturing);
            tabControl.Controls.Add(tabPackaging);
            tabControl.Controls.Add(tabVersionHistory);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            tabControl.Location = new Point(3, 93);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(886, 354);
            tabControl.TabIndex = 2;
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            // 
            // tabBasic
            // 
            tabBasic.AutoScroll = true;
            tabBasic.BackColor = SystemColors.GradientInactiveCaption;
            tabBasic.Location = new Point(4, 24);
            tabBasic.Name = "tabBasic";
            tabBasic.Padding = new Padding(3);
            tabBasic.Size = new Size(878, 326);
            tabBasic.TabIndex = 0;
            tabBasic.Text = "Basic Information";
            // 
            // tabProductTeam
            // 
            tabProductTeam.AutoScroll = true;
            tabProductTeam.BackColor = SystemColors.GradientInactiveCaption;
            tabProductTeam.Location = new Point(4, 24);
            tabProductTeam.Name = "tabProductTeam";
            tabProductTeam.Padding = new Padding(3);
            tabProductTeam.Size = new Size(878, 326);
            tabProductTeam.TabIndex = 1;
            tabProductTeam.Text = "Product Team";
            // 
            // tabProductDetails
            // 
            tabProductDetails.AutoScroll = true;
            tabProductDetails.BackColor = SystemColors.GradientInactiveCaption;
            tabProductDetails.Location = new Point(4, 24);
            tabProductDetails.Name = "tabProductDetails";
            tabProductDetails.Size = new Size(878, 326);
            tabProductDetails.TabIndex = 2;
            tabProductDetails.Text = "Product Details";
            // 
            // tabManufacturing
            // 
            tabManufacturing.AutoScroll = true;
            tabManufacturing.BackColor = SystemColors.GradientInactiveCaption;
            tabManufacturing.Location = new Point(4, 24);
            tabManufacturing.Name = "tabManufacturing";
            tabManufacturing.Size = new Size(878, 326);
            tabManufacturing.TabIndex = 3;
            tabManufacturing.Text = "Manufacturing";
            // 
            // tabPackaging
            // 
            tabPackaging.AutoScroll = true;
            tabPackaging.BackColor = SystemColors.GradientInactiveCaption;
            tabPackaging.Location = new Point(4, 24);
            tabPackaging.Name = "tabPackaging";
            tabPackaging.Size = new Size(878, 326);
            tabPackaging.TabIndex = 4;
            tabPackaging.Text = "Packaging";
            // 
            // tabVersionHistory
            // 
            tabVersionHistory.AutoScroll = true;
            tabVersionHistory.BackColor = SystemColors.GradientInactiveCaption;
            tabVersionHistory.Location = new Point(4, 24);
            tabVersionHistory.Name = "tabVersionHistory";
            tabVersionHistory.Size = new Size(878, 326);
            tabVersionHistory.TabIndex = 5;
            tabVersionHistory.Text = "Version History";
            // 
            // tableBasic
            // 
            tableBasic.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableBasic.Location = new Point(0, 0);
            tableBasic.Name = "tableBasic";
            tableBasic.Size = new Size(200, 100);
            tableBasic.TabIndex = 0;
            // 
            // frmEditProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(996, 568);
            Controls.Add(tableMain);
            Margin = new Padding(2);
            Name = "frmEditProduct";
            Text = "Integrated System";
            Load += frmEditProduct_Load;
            tableMain.ResumeLayout(false);
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
            flowLayoutPanelHeader.ResumeLayout(false);
            flowLayoutPanelHeader.PerformLayout();
            tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableMain;
        private TableLayoutPanel tableLayout;
        private Label lblheader;
        private FlowLayoutPanel flowLayoutPanelHeader;
        private Label lblProductID;
        private TextBox txtProductID;
        private Label lblProductName;
        private TextBox txtProductName;
        private TabControl tabControl;
        private TabPage tabBasic;
        private TabPage tabProductTeam;
        private TabPage tabProductDetails;
        private TabPage tabManufacturing;
        private TabPage tabPackaging;
        private TabPage tabVersionHistory;
        private BindingSource bindingSource1;
        private TableLayoutPanel tableBasic;
    }
}