namespace Client.Views
{
    partial class frmMain
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
            window = new TableLayoutPanel();
            panelHeader = new Panel();
            panelContent = new Panel();
            window.SuspendLayout();
            SuspendLayout();
            // 
            // window
            // 
            window.ColumnCount = 1;
            window.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            window.Controls.Add(panelHeader, 0, 0);
            window.Controls.Add(panelContent, 0, 1);
            window.Dock = DockStyle.Fill;
            window.Location = new Point(0, 0);
            window.Margin = new Padding(0);
            window.Name = "window";
            window.RowCount = 2;
            window.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            window.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            window.Size = new Size(1280, 810);
            window.TabIndex = 2;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1280, 90);
            panelHeader.TabIndex = 0;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.Transparent;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 90);
            panelContent.Margin = new Padding(0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1280, 712);
            panelContent.TabIndex = 1;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1280, 810);
            Controls.Add(window);
            Name = "frmMain";
            Text = "Integrated System";
            Load += frmMain_Load;
            window.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel window;
        private Panel panelHeader;
        public Panel panelContent;
    }
}
