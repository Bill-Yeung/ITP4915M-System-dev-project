namespace Client.Views.Components
{
    partial class frmNavigation
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
            navMenu = new TableLayoutPanel();
            menuPanel = new FlowLayoutPanel();
            navMenu.SuspendLayout();
            SuspendLayout();
            // 
            // navMenu
            // 
            navMenu.BackColor = SystemColors.AppWorkspace;
            navMenu.ColumnCount = 1;
            navMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            navMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            navMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            navMenu.Controls.Add(menuPanel, 0, 1);
            navMenu.Dock = DockStyle.Fill;
            navMenu.Location = new Point(0, 0);
            navMenu.Margin = new Padding(0);
            navMenu.Name = "navMenu";
            navMenu.RowCount = 3;
            navMenu.RowStyles.Add(new RowStyle());
            navMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            navMenu.RowStyles.Add(new RowStyle());
            navMenu.Size = new Size(200, 720);
            navMenu.TabIndex = 0;
            // 
            // menuPanel
            // 
            menuPanel.Dock = DockStyle.Fill;
            menuPanel.Location = new Point(3, 3);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(194, 714);
            menuPanel.TabIndex = 0;
            // 
            // frmNavigation
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(200, 720);
            Controls.Add(navMenu);
            Name = "frmNavigation";
            Text = "frmNavigation";
            Load += frmNavigation_Load;
            navMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel navMenu;
        private FlowLayoutPanel menuPanel;
    }
}