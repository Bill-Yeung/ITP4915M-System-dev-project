using EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views.SupplyChain
{
    public partial class frmSupplierDetail : Form
    {
        public Supplier UpdatedSupplier { get; private set; }

        private TextBox txtID, txtName, txtPhone, txtEmail, txtAddress, txtContact;
        private ComboBox cmbStatus;

        public frmSupplierDetail(Supplier supplier)
        {
            InitializeComponent();

            this.Text = "Supplier Detail";
            this.Size = new Size(700, 600);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(30),
                ColumnCount = 2,
                RowCount = 8, // 7项 + 按钮
                AutoSize = true
            };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));

            var labelFont = new Font("Segoe UI", 12F, FontStyle.Regular);
            var textFont = new Font("Segoe UI", 12F, FontStyle.Regular);

            // 📌 Title
            var title = new Label
            {
                Text = "Supplier Information",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Anchor = AnchorStyles.Left,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 20)
            };
            layout.Controls.Add(title, 0, 0);
            layout.SetColumnSpan(title, 2);

            int row = 1;

            // 字段输入区
            layout.Controls.Add(new Label { Text = "ID", Anchor = AnchorStyles.Right, Font = labelFont }, 0, row);
            layout.Controls.Add(txtID = new TextBox { Text = supplier.supplierID, ReadOnly = true, Font = textFont, Dock = DockStyle.Fill }, 1, row++);

            layout.Controls.Add(new Label { Text = "Name", Anchor = AnchorStyles.Right, Font = labelFont }, 0, row);
            layout.Controls.Add(txtName = new TextBox { Text = supplier.supplierName, Font = textFont, Dock = DockStyle.Fill }, 1, row++);

            layout.Controls.Add(new Label { Text = "Phone", Anchor = AnchorStyles.Right, Font = labelFont }, 0, row);
            layout.Controls.Add(txtPhone = new TextBox { Text = supplier.supplierPhone, Font = textFont, Dock = DockStyle.Fill }, 1, row++);

            layout.Controls.Add(new Label { Text = "Email", Anchor = AnchorStyles.Right, Font = labelFont }, 0, row);
            layout.Controls.Add(txtEmail = new TextBox { Text = supplier.supplierEmail, Font = textFont, Dock = DockStyle.Fill }, 1, row++);

            layout.Controls.Add(new Label { Text = "Address", Anchor = AnchorStyles.Right, Font = labelFont }, 0, row);
            layout.Controls.Add(txtAddress = new TextBox { Text = supplier.supplierAddress, Font = textFont, Dock = DockStyle.Fill }, 1, row++);

            layout.Controls.Add(new Label { Text = "Contact", Anchor = AnchorStyles.Right, Font = labelFont }, 0, row);
            layout.Controls.Add(txtContact = new TextBox { Text = supplier.contactPerson, Font = textFont, Dock = DockStyle.Fill }, 1, row++);

            layout.Controls.Add(new Label { Text = "Status", Anchor = AnchorStyles.Right, Font = labelFont }, 0, row);
            cmbStatus = new ComboBox
            {
                Font = textFont,
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbStatus.Items.AddRange(new string[] { "Valid", "Invalid", "Suspended" });
            cmbStatus.SelectedItem = supplier.status ?? "Valid";
            layout.Controls.Add(cmbStatus, 1, row++);

            // 🎯 按钮区域（占两列）
            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(0, 20, 0, 10),
                AutoSize = true
             

            };

            var btnSave = new Button
            {
                Text = "💾 Save",
                Width = 120,
                Height=40,
                Font = textFont,
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            var btnCancel = new Button
            {
                Text = "Cancel",
                Width = 120,
                Height=40,
                Font = textFont,
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnSave.Click += (s, e) =>
            {
                UpdatedSupplier = new Supplier
                {
                    supplierID = txtID.Text,
                    supplierName = txtName.Text,
                    supplierPhone = txtPhone.Text,
                    supplierEmail = txtEmail.Text,
                    supplierAddress = txtAddress.Text,
                    contactPerson = txtContact.Text,
                    status = cmbStatus.SelectedItem?.ToString() ?? "Valid"
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
                InitializeComponent();
            };

            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            buttonPanel.Controls.AddRange(new[] { btnSave, btnCancel });
            layout.Controls.Add(buttonPanel, 0, row);
            layout.SetColumnSpan(buttonPanel, 2); // 按钮跨两列

            this.Controls.Add(layout);
        }
    }
}