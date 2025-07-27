using Client.Controllers;
using Client.GenaralMethod;
using System.Data;

namespace Client.Views.SupplyChain
{
    partial class frmShipmentRequest
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
            label1 = new Label();
            lblDeliveryOrderID = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(553, 32);
            label1.Name = "label1";
            label1.Size = new Size(134, 19);
            label1.TabIndex = 0;
            label1.Text = "Delivery Request ID:";
            // 
            // lblDeliveryOrderID
            // 
            lblDeliveryOrderID.AutoSize = true;
            lblDeliveryOrderID.Location = new Point(711, 32);
            lblDeliveryOrderID.Name = "lblDeliveryRequestID";
            lblDeliveryOrderID.Size = new Size(0, 19);
            lblDeliveryOrderID.TabIndex = 1;
            // 
            // frmShipmentRequest
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblDeliveryOrderID);
            Controls.Add(label1);
            Name = "frmShipmentRequest";
            Text = "frmShipmentRequest";
            ResumeLayout(false);
            PerformLayout();

        }



        private void InitializeForm()
        {
            // Form settings
            this.Text = "Shipping Request System";
            this.ClientSize = new Size(1000, 800); // Adjusted height
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10F);
            this.BackColor = Color.White;

            // Header
            var lblHeader = new Label
            {
                Text = "SHIPPING REQUEST FORM",
                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.SteelBlue
            };
            this.Controls.Add(lblHeader);

            // Top section - 2 rows x 3 columns grid
            int startY = 60;
            int rowHeight = 60;
            int col1X = 30, col2X = 360, col3X = 690;
            int controlWidth = 300;

            // Row 1
            // Column 1 - Department
            var lblDepartment = new Label
            {
                Text = "Department:",
                Location = new Point(col1X, startY),
                AutoSize = true
            };
            this.Controls.Add(lblDepartment);

            cmbDepartment = new ComboBox
            {
                Location = new Point(col1X, startY + 25),
                Size = new Size(controlWidth, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbDepartment.Items.AddRange(new object[] { "Production", "Finance", "Sales", "Procurement" });
            this.Controls.Add(cmbDepartment);

            // Column 2 - Order ID
            var lblOrderID = new Label
            {
                Text = "Order ID:",
                Location = new Point(col2X, startY),
                AutoSize = true
            };
            this.Controls.Add(lblOrderID);

            cmbOrderID = new ComboBox
            {
                Location = new Point(col2X, startY + 25),
                Size = new Size(controlWidth, 28),
                DropDownStyle = ComboBoxStyle.DropDownList,
              
            };
            this.Controls.Add(cmbOrderID);
          

            // Column 3 - Customer
            //var lblCustomerID = new Label
            //{
            //    Text = "Customer:",
            //    Location = new Point(col3X, startY),
            //    AutoSize = true
            //};
            //this.Controls.Add(lblCustomerID);

            //lblCustomerID = new Label
            //{
            //    Location = new Point(col3X, startY + 25),
            //    Size = new Size(controlWidth, 28),

            //};
            //this.Controls.Add(lblCustomerID);

            // Row 2
            startY += rowHeight;

            // Column 1 - Requester
            var lblRequester = new Label
            {
                Text = "Requester:",
                Location = new Point(col1X, startY),
                AutoSize = true
            };
            this.Controls.Add(lblRequester);

            txtRequester = new TextBox
            {
                Location = new Point(col1X, startY + 25),
                Size = new Size(controlWidth, 28),
                Tag = "Required"
            };
            this.Controls.Add(txtRequester);

            // Column 2 - Request Date
            var lblRequestDate = new Label
            {
                Text = "Request Date:",
                Location = new Point(col2X, startY),
                AutoSize = true
            };
            this.Controls.Add(lblRequestDate);

            dtpRequestDate = new DateTimePicker
            {
                Location = new Point(col2X, startY + 25),
                Size = new Size(controlWidth, 28),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today
            };
            this.Controls.Add(dtpRequestDate);

            // Column 3 - Priority
            var lblUrgency = new Label
            {
                Text = "Priority:",
                Location = new Point(col3X, startY),
                AutoSize = true
            };
            this.Controls.Add(lblUrgency);

            cmbUrgency = new ComboBox
            {
                Location = new Point(col3X, startY + 25),
                Size = new Size(controlWidth, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbUrgency.Items.AddRange(new object[] { "Normal", "Urgent", "Critical" });
            cmbUrgency.SelectedIndex = 0;
            this.Controls.Add(cmbUrgency);

            // Items grid
            var lblItems = new Label
            {
                Text = "ITEMS TO SHIP",
                Location = new Point(30, startY + rowHeight),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            this.Controls.Add(lblItems);

            dgvItems = new DataGridView
            {
                Location = new Point(30, startY + rowHeight + 30),
                Size = new Size(940, 350),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = SystemColors.Window,
                BorderStyle = BorderStyle.Fixed3D,
                CellBorderStyle = DataGridViewCellBorderStyle.Single,
                ScrollBars = ScrollBars.Both
            };
            this.Controls.Add(dgvItems);

            // Special Instructions
            var lblNotes = new Label
            {
                Text = "Special Instructions:",
                Location = new Point(30, startY + rowHeight + 400),
                AutoSize = true
            };
            this.Controls.Add(lblNotes);

            txtNotes = new TextBox
            {
                Location = new Point(30, startY + rowHeight + 430),
                Size = new Size(940, 80),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            this.Controls.Add(txtNotes);

            // Buttons (now below special instructions)
            int buttonY = startY + rowHeight + 530;
            int buttonWidth = 120;
            int buttonSpacing = 15;

            // Add Item button
            btnAddItem = new Button
            {
                Text = "Add Item",
                Location = new Point(30, buttonY),
                Size = new Size(buttonWidth, 35),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
            };
            this.Controls.Add(btnAddItem);

            // Back button
            btnBack = new Button
            {
                Text = "Back",
                Location = new Point(30 + buttonWidth + buttonSpacing, buttonY),
                Size = new Size(buttonWidth, 35),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
            };
            this.Controls.Add(btnBack);
            btnBack.Click += (s, e) => PanelController.openForm(Program.homeForm.panelRight, new frmSupplyMain2());

            // Show All button
            btnShowAll = new Button
            {
                Text = "Show All",
                Location = new Point(30 + (buttonWidth + buttonSpacing) * 2, buttonY),
                Size = new Size(buttonWidth, 35),
                BackColor = Color.LightSteelBlue,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
            };
            this.Controls.Add(btnShowAll);

            // Submit button
            btnSubmit = new Button
            {
                Text = "Submit",
                Location = new Point(850, buttonY),
                Size = new Size(buttonWidth, 35),
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
            };
            this.Controls.Add(btnSubmit);
            btnSubmit.Click += (s,e)=>submitDelivery();
        }
        private Label label1;
        private Label lblDeliveryOrderID;
    }
}
#endregion