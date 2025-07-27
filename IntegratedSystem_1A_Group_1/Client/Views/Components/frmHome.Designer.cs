namespace Client.Views.Login
{
    partial class frmHome
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
            panelHome = new TableLayoutPanel();
            panelLeft = new Panel();
            panelRight = new Panel();
            panelHome.SuspendLayout();
            SuspendLayout();
            // 
            // panelHome
            // 
            panelHome.ColumnCount = 2;
            panelHome.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            panelHome.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelHome.Controls.Add(panelLeft, 0, 0);
            panelHome.Controls.Add(panelRight, 1, 0);
            panelHome.Dock = DockStyle.Fill;
            panelHome.Location = new Point(0, 0);
            panelHome.Margin = new Padding(0);
            panelHome.Name = "panelHome";
            panelHome.RowCount = 1;
            panelHome.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelHome.Size = new Size(1280, 720);
            panelHome.TabIndex = 0;
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.Transparent;
            panelLeft.Dock = DockStyle.Fill;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Margin = new Padding(0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(200, 720);
            panelLeft.TabIndex = 0;
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.Transparent;
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(200, 0);
            panelRight.Margin = new Padding(0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(1080, 720);
            panelRight.TabIndex = 1;
            // 
            // frmHome
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1280, 720);
            Controls.Add(panelHome);
            Name = "frmHome";
            Text = "Integrated System";
            panelHome.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel panelHome;
        private Panel panelLeft;
        public Panel panelRight;
    }
}
