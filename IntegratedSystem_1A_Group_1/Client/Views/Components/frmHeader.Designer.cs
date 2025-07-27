namespace Client.Views.Components
{
    partial class frmHeader
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
            header = new TableLayoutPanel();
            lblCompanyName = new Label();
            logo = new PictureBox();
            lblSystemDateTime = new Label();
            timer = new System.Windows.Forms.Timer(components);
            header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // header
            // 
            header.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            header.BackColor = Color.SteelBlue;
            header.ColumnCount = 4;
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 450F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            header.Controls.Add(lblCompanyName, 1, 0);
            header.Controls.Add(logo, 0, 0);
            header.Controls.Add(lblSystemDateTime, 3, 0);
            header.Location = new Point(0, 0);
            header.Name = "header";
            header.RowCount = 1;
            header.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            header.Size = new Size(1280, 90);
            header.TabIndex = 2;
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Dock = DockStyle.Left;
            lblCompanyName.Font = new Font("Arial", 16.2F, FontStyle.Bold);
            lblCompanyName.ForeColor = Color.White;
            lblCompanyName.Location = new Point(103, 0);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(423, 90);
            lblCompanyName.TabIndex = 1;
            lblCompanyName.Text = "Smile && Sunshine Toy Co, Ltd.";
            lblCompanyName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // logo
            // 
            logo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logo.Location = new Point(12, 12);
            logo.Margin = new Padding(12);
            logo.Name = "logo";
            logo.Size = new Size(76, 66);
            logo.TabIndex = 0;
            logo.TabStop = false;
            // 
            // lblSystemDateTime
            // 
            lblSystemDateTime.AutoSize = true;
            lblSystemDateTime.Dock = DockStyle.Right;
            lblSystemDateTime.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSystemDateTime.ForeColor = Color.White;
            lblSystemDateTime.Location = new Point(910, 10);
            lblSystemDateTime.Margin = new Padding(10);
            lblSystemDateTime.Name = "lblSystemDateTime";
            lblSystemDateTime.Size = new Size(160, 70);
            lblSystemDateTime.TabIndex = 2;
            lblSystemDateTime.Text = "SystemDateTime";
            lblSystemDateTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // frmHeader
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 90);
            Controls.Add(header);
            Name = "frmHeader";
            Text = "frmHeader";
            Load += frmHeader_Load;
            header.ResumeLayout(false);
            header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public TableLayoutPanel header;
        private PictureBox logo;
        private Label lblCompanyName;
        private System.Windows.Forms.Timer timer;
        private Label lblSystemDateTime;
    }
}