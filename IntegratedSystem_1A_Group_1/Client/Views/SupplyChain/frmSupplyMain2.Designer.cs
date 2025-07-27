using Client.Controllers;

namespace Client.Views.SupplyChain
{
    partial class frmSupplyMain2
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
            SuspendLayout();
            // 
            // frmSupplyMain
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 542);
            Name = "frmSupplyMain";
            Text = "frmSupplyMain";
            ResumeLayout(false);
        }
        private void InitializeCustomComponent()
        {

            this.Text = "SupplyChain Management - Main Menu";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1000, 700);
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            var mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 3,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                BackColor = Color.LightSteelBlue,
                Padding = new Padding(20)
            };

            // Configure columns and rows
            for (int i = 0; i < 3; i++)
            {
                mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            }
            for (int i = 0; i < 3; i++)
            {
                mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            }

            // Create buttons for all 9 modules (button size slightly reduced)
            CreateModuleButton(mainPanel, "1. Delivery Request", "Confirm and process shipments(Order Fulfillment Workbench)", 0, 0);
            CreateModuleButton(mainPanel, "2. Delivery Management", "Arrange and Monitor delivery status", 1, 0);
            this.Controls.Add(mainPanel);
        }

        private void CreateModuleButton(TableLayoutPanel panel, string title, string tooltip, int column, int row)
        {
            var button = new Button
            {
                Text = title,
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(10),
                Cursor = Cursors.Hand,
                TabStop = true
            };
            switch (title)
            {
                case "1. Delivery Request":
                    button.Click += (sender, e) => PanelController.openForm(Program.homeForm.panelRight, new frmShipmentRequest());
                    break;
                case "2. Delivery Management":
                    button.Click += (sender, e) => PanelController.openForm(Program.homeForm.panelRight, new frmDelivery());
                    break;
            }

            // Button appearance
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.DarkSlateBlue;
            button.FlatAppearance.MouseOverBackColor = Color.RoyalBlue;
            button.FlatAppearance.MouseDownBackColor = Color.DodgerBlue;

            // Tooltip
            var tip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true
            };
            tip.SetToolTip(button, tooltip);

            panel.Controls.Add(button, column, row);
        }

        #endregion
    }
}