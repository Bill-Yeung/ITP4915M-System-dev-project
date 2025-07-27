using System.Data;
using Client.GenaralMethod;

namespace Client.Views.SupplyChain
{
    partial class frmRestock2
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "frmRestock2";
            Load +=  frmRestock2_Load;
            ResumeLayout(false);
        }

    
      

        private void SetupUI()
        {

            // Form settings
            this.Text = "Restock Request";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(1000, 700); // Increased form size
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9);
            this.Padding = new Padding(20);

            // Title label
            Label lblTitle = new Label
            {
                Text = "RESTOCK REQUEST",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                AutoSize = true,
                Top = 20,
                Left = 20
            };

            // Request ID label and textbox (top right)
            Label lblRequestId = new Label
            {
                Text = "Request ID:",
                Top = 30,
                Left = this.ClientSize.Width - 380,
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            txtRequestId = new TextBox
            {
                Top = 28,
                Left = lblRequestId.Right + 10,
                Width = 150,
                ReadOnly = true,
                BackColor = Color.WhiteSmoke,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            // Horizontal line separator
            Panel separator1 = new Panel
            {
                Height = 2,
                BackColor = Color.LightGray,
                Top = 70,
                Left = 20,
                Width = this.ClientSize.Width - 40
            };

            // Supplier selection
            Label lblSupplier = new Label
            {
                Text = "Supplier:",
                Top = 90,
                Left = 20,
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            //suppliersData.Columns.Add("DisplayText", typeof(string), "supplierID + ' - ' + supplierName");
            cmbSupplier = new ComboBox
            {
                Top = 88,
                Left = 120,
                Width = 300,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = suppliersData,
                //DisplayMember = "DisplayText",
                DisplayMember = "supplierName",
                ValueMember = "supplierID"
            };
            
            // Expected delivery date
            Label lblDeliveryDate = new Label
            {
                Text = "Expected Delivery:",
                Top = 90,
                Left = 500,
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            dtpDeliveryDate = new DateTimePicker
            {
                Top = 88,
                Left = 650,
                Width = 200,
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now.AddDays(7)
            };

            // Delivery address
            Label lblDeliveryAddress = new Label
            {
                Text = "Delivery Address:",
                Top = 130,
                Left = 20,
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            txtDeliveryAddress = new TextBox
            {
                Top = 128,
                Left = 155,
                Width = this.ClientSize.Width - 160,
                Height = 60,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };

            // Horizontal line separator
            Panel separator2 = new Panel
            {
                Height = 2,
                BackColor = Color.LightGray,
                Top = 210,
                Left = 20,
                Width = this.ClientSize.Width - 40
            };

            // Materials selection panel
            GroupBox gbMaterials = new GroupBox
            {
                Text = "Add Materials to Request",
                Top = 220,
                Left = 20,
                Width = this.ClientSize.Width - 40,
                Height = 100,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            Label lblMaterial = new Label
            {
                Text = "Material:",
                Top = 50,
                Left = 20,
                AutoSize = true
            };
            //materialsData.Columns.Add("DisplayText", typeof(string), "materialID + ' - ' + materialName");
            cmbMaterial = new ComboBox
            {
                Top = 48,
                Left = 100,
                Width = 250,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = materialsData,
                //DisplayMember = "DisplayText",
                DisplayMember = "materialName",
                ValueMember = "materialID"
            };

            Label lblQuantity = new Label
            {
                Text = "Quantity:",
                Top = 50,
                Left = 380,
                AutoSize = true
            };

            nudQuantity = new NumericUpDown
            {
                Top = 50,
                Left = 470,
                Width = 80,
                Minimum = 1,
                Maximum = 1000,
                Value = 1
            };

            Label lblUnitPrice = new Label
            {
                Text = "Unit Price:",
                Top = 50,
                Left = 580,
                AutoSize = true
            };

            txtUnitPrice = new TextBox
            {
                Top = 48,
                Left = 680,
                Width = 100,
              
                TextAlign = HorizontalAlignment.Right
            };

            Button btnAdd = new Button
            {
                Text = "ADD",
                Top = 50,
                Left = 830,
                Width = 100,
                Height = 26,
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            // Set unit price when material is selected
            cmbMaterial.SelectedIndexChanged += (s, e) =>
            {
                if (cmbMaterial.SelectedValue != null)
                {
                    var selectedRow = materialsData.AsEnumerable()
                        .FirstOrDefault(row => row.Field<int>("materialID") == (int)cmbMaterial.SelectedValue);

                    if (selectedRow != null)
                    {
                        txtUnitPrice.Text = selectedRow.Field<decimal>("price").ToString("N2");
                    }
                }
            };

            // Add button click event
            btnAdd.Click += (s, e) => AddRequestItem();

            // Add controls to materials group box
            gbMaterials.Controls.AddRange(new Control[]
            {
                lblMaterial, cmbMaterial,
                lblQuantity, nudQuantity,
                lblUnitPrice, txtUnitPrice,
                btnAdd
            });

            // Request items DataGridView
            dgvRequestItems = new DataGridView
            {
                Top = 340,
                Left = 20,
                Width = this.ClientSize.Width - 40,
                Height = 200,
                AllowUserToAddRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D,
                RowHeadersVisible = false,
                AutoGenerateColumns = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill // Auto-resize columns
            };

            // Configure columns with fill weights
            dgvRequestItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "materialID",
                HeaderText = "Material ID"
                //Visible = false
            });

            var nameColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "materialName",
                HeaderText = "Material Name",
                FillWeight = 30 // Relative width
            };
            dgvRequestItems.Columns.Add(nameColumn);

            var qtyColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "restockQuantity",
                HeaderText = "Quantity",
                FillWeight = 15,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            };
            dgvRequestItems.Columns.Add(qtyColumn);

            var unitPriceColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "price",
                HeaderText = "Unit Price",
                FillWeight = 20,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N2",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            };
            dgvRequestItems.Columns.Add(unitPriceColumn);

            var totalPriceColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalPrice",
                HeaderText = "Total Price",
                FillWeight = 20,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N2",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            };
            dgvRequestItems.Columns.Add(totalPriceColumn);

            // Add action buttons column
            var updateColumn = new DataGridViewButtonColumn
            {
                Text = "Update",
                HeaderText="Action",
                UseColumnTextForButtonValue = true,
                FillWeight = 10,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.LightBlue,
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            var deleteColumn = new DataGridViewButtonColumn
            {
                Text = "Delete",
                HeaderText = "Action",
                UseColumnTextForButtonValue = true,
                FillWeight = 10,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.LightCoral,
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            dgvRequestItems.Columns.Add(updateColumn);
            dgvRequestItems.Columns.Add(deleteColumn);

            // Handle button clicks in DataGridView
            dgvRequestItems.CellContentClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 5) // Action buttons columns
                {
                    if (e.ColumnIndex == 5) // Update
                    {
                        UpdateRequestItem(e.RowIndex);
                    }
                    else if (e.ColumnIndex == 6) // Delete
                    {
                        DeleteRequestItem(e.RowIndex);
                    }
                }
            };

            // Horizontal line separator
            Panel separator3 = new Panel
            {
                Height = 2,
                BackColor = Color.LightGray,
                Top = 550,
                Left = 20,
                Width = this.ClientSize.Width - 40
            };

            // Total amount label
            Label lblTotal = new Label
            {
                Text = "TOTAL AMOUNT:",
                Top = 560,
                Left = this.ClientSize.Width - 300,
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            lblTotalAmount = new Label
            {
                Text = "0.00",
                Top = 560,
                Left = lblTotal.Right + 10,
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };

            // Bottom buttons
            Button btnViewAll = new Button
            {
                Text = "VIEW ALL RESTOCK REQUESTS",
                Top = 600,
                Left = 20,
                Width = 220,
                Height = 35,
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            Button btnSend = new Button
            {
                Text = "SEND REQUEST",
                Top = 600,
                Left = this.ClientSize.Width - 220,
                Width = 100,
                Height = 35,
                BackColor = Color.Green,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            Button btnBack = new Button
            {
                Text = "BACK",
                Top = 600,
                Left = this.ClientSize.Width - 110,
                Width = 90,
                Height = 35,
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            // Button events
            btnSend.Click += (s, e) => SendRequest();
            btnBack.Click += (s, e) => this.Close();
            btnViewAll.Click += (s, e) => new frmForSupplier(frmForSupplier.FormMode.ManagerView);

            // Add controls to form
            this.Controls.AddRange(new Control[]
            {
                lblTitle, lblRequestId, txtRequestId,
                separator1,
                lblSupplier, cmbSupplier,
                lblDeliveryDate, dtpDeliveryDate,
                lblDeliveryAddress, txtDeliveryAddress,
                separator2,
                gbMaterials, dgvRequestItems,
                separator3,
                lblTotal, lblTotalAmount,
                btnViewAll, btnSend, btnBack
            });

            // Bind data
            dgvRequestItems.DataSource = requestItemsData;
        }

        private void AddRequestItem()
        {

            if (cmbMaterial.SelectedValue == null) return;

            string materialID = cmbMaterial.SelectedValue.ToString();
            string materialName = cmbMaterial.Text;
            int restockQuantity = (int)nudQuantity.Value;
            decimal price = materialsData.AsEnumerable()
                .First(row => row.Field<string>("materialID") == materialID)
                .Field<decimal>("price");
            decimal totalPrice = restockQuantity * price;

            // Check if material already exists in request
            var existingRow = requestItemsData.AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("materialID") == materialID);

            if (existingRow != null)
            {
                // Update existing row
                existingRow.SetField("restockQuantity", existingRow.Field<int>("restockQuantity") + restockQuantity);
                existingRow.SetField("TotalPrice", existingRow.Field<int>("restockQuantity") * price);
            }
            else
            {
                // Add new row
                requestItemsData.Rows.Add(materialID, materialName, restockQuantity, price, totalPrice);
            }

            UpdateTotalAmount();
            ResetMaterialSelection();
        }

        private void ResetMaterialSelection()
        {
            cmbMaterial.SelectedIndex = -1;
            txtUnitPrice.Text = "";
            nudQuantity.Value = 1;
        }

        private void UpdateRequestItem(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= requestItemsData.Rows.Count) return;

            DataRow row = requestItemsData.Rows[rowIndex];
            int currentQty = row.Field<int>("restockQuantity");

            // Show dialog to edit quantity
            using (var form = new Form())
            {
                form.Text = "Update Quantity";
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.ClientSize = new Size(300, 120);

                var lbl = new Label { Text = "New Quantity:", Left = 20, Top = 20, AutoSize = true };
                var nud = new NumericUpDown { Left = 120, Top = 18, Width = 100, Minimum = 1, Value = currentQty };
                var btnOK = new Button { Text = "OK", Left = 60, Top = 60, Width = 80, DialogResult = DialogResult.OK };
                var btnCancel = new Button { Text = "Cancel", Left = 160, Top = 60, Width = 80, DialogResult = DialogResult.Cancel };

                form.Controls.AddRange(new Control[] { lbl, nud, btnOK, btnCancel });
                form.AcceptButton = btnOK;
                form.CancelButton = btnCancel;

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    int newQty = (int)nud.Value;
                    decimal price = row.Field<decimal>("price");

                    row.SetField("restockQuantity", newQty);
                    row.SetField("TotalPrice", newQty * price);

                    UpdateTotalAmount();
                    dgvRequestItems.Refresh();
                }
            }
        }

        private void DeleteRequestItem(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= requestItemsData.Rows.Count) return;

            if (MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                requestItemsData.Rows.RemoveAt(rowIndex);
                UpdateTotalAmount();
            }
        }

        private void UpdateTotalAmount()
        {
            decimal total = requestItemsData.AsEnumerable()
                .Sum(row => row.Field<decimal>("TotalPrice"));

            lblTotalAmount.Text = total.ToString("N2");
        }

        private void SendRequest()
        {
            if (cmbSupplier.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a supplier.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSupplier.Focus();
                return;
            }

            if (requestItemsData.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one material to the request.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaterial.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDeliveryAddress.Text))
            {
                MessageBox.Show("Please enter a delivery address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDeliveryAddress.Focus();
                return;
            }

            // In a real application, this would save to a database
            MessageBox.Show("Restock request has been sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset form
            requestItemsData.Rows.Clear();
            UpdateTotalAmount();
            //GenerateRequestId();
            dtpDeliveryDate.Value = DateTime.Now.AddDays(7);
            txtDeliveryAddress.Clear();
            cmbSupplier.SelectedIndex = -1;
        }

        private void ViewAllRequests()
        {
            // In a real application, this would show a list of all restock requests
            MessageBox.Show("This would display a list of all restock requests in a real application.",
                "View All Requests", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
#endregion
