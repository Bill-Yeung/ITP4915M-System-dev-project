namespace Client.Views.Components
{
    partial class frmSystem
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
            lblDepartmentName = new Label();
            flowPanelSystem = new FlowLayoutPanel();
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
            tableLayout.Controls.Add(lblDepartmentName, 0, 0);
            tableLayout.Controls.Add(flowPanelSystem, 0, 1);
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.Location = new Point(131, 75);
            tableLayout.Name = "tableLayout";
            tableLayout.RowCount = 2;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 19.2982464F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 80.70175F));
            tableLayout.Size = new Size(1018, 570);
            tableLayout.TabIndex = 0;
            // 
            // lblDepartmentName
            // 
            lblDepartmentName.AutoSize = true;
            lblDepartmentName.Dock = DockStyle.Fill;
            lblDepartmentName.Font = new Font("Arial", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblDepartmentName.Location = new Point(3, 0);
            lblDepartmentName.Name = "lblDepartmentName";
            lblDepartmentName.Size = new Size(1012, 110);
            lblDepartmentName.TabIndex = 0;
            lblDepartmentName.Text = "Department Name";
            lblDepartmentName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowPanelSystem
            // 
            flowPanelSystem.Dock = DockStyle.Fill;
            flowPanelSystem.Location = new Point(3, 113);
            flowPanelSystem.Name = "flowPanelSystem";
            flowPanelSystem.Size = new Size(1012, 454);
            flowPanelSystem.TabIndex = 1;
            // 
            // frmSystem
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1280, 720);
            Controls.Add(tableMain);
            Name = "frmSystem";
            Text = "Integrated System";
            Load += frmSystem_Load;
            tableMain.ResumeLayout(false);
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableMain;
        private TableLayoutPanel tableLayout;
        private Label lblDepartmentName;
        private FlowLayoutPanel flowPanelSystem;
    }
}