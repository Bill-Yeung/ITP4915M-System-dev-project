using Client.GenaralMethod;
using System.Data;
using System.Threading.Tasks;
using static EntityModels.Supplier;

namespace Client.Views.SupplyChain
{
    partial class frmDelivery
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "frmDelivery";
        }
        private DataGridView dgvDelivery;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnInboundRecord;
        private Button btnOutboundRecord;
        private Button btnView,btnGenerate;
        private Button btnBack;
        private Label lblTitle;
        private int selectedRowIndex = -1;

        private void InitializeDynamicComponents()
        {
            this.Text = "Delivery Request Management";
            this.ClientSize = new Size(1500, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10F);

            lblTitle = new Label
            {
                Text = "DELIVERY REQUEST MANAGEMENT",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                AutoSize = true
            };
            lblTitle.Location = new Point((this.ClientSize.Width - lblTitle.Width) / 2 - 100, 25);
            this.Controls.Add(lblTitle);

            txtSearch = new TextBox
            {
                Location = new Point(40, 90),
                Size = new Size(600, 40),
                PlaceholderText = "Search by item ID or name...",
                Font = new Font("Segoe UI", 11F)
            };
            this.Controls.Add(txtSearch);

            btnSearch = new Button
            {
                Text = "SEARCH",
                Location = new Point(650, 90),
                Size = new Size(120, 40),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            this.Controls.Add(btnSearch);
            btnSearch.Click += (s, e) => searchData(txtSearch.Text, new[] { "requestID", "orderID", "requestStatus" });

            Button btnShowAll = new Button
            {
                Text = "SHOW ALL",
                Size = new Size(150, 40),
                Location = new Point(this.ClientSize.Width - 190, 90),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnShowAll.Click += (s, e) => new frmDelivery().Show();
            this.Controls.Add(btnShowAll);

            dgvDelivery = new DataGridView
            {
                Location = new Point(40, 150),
                Size = new Size(1420, 550),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeight = 40,
                RowTemplate = { Height = 35 },
                ScrollBars = ScrollBars.Both,
                Font = new Font("Segoe UI", 10F)
            };
            
            this.Controls.Add(dgvDelivery);
            AddActionButtons();
            dgvDelivery.CellClick += dgvDelivery_CellClick;
        }

        private void addDgvButtonColumn()
        {
            if (!dgvDelivery.Columns.Contains("btnAction"))
            {
                DataGridViewButtonColumn btnProcess = new DataGridViewButtonColumn
                {
                    Name = "btnProcess",
                    HeaderText = "Action",
                    Text = "Delivery",
                    UseColumnTextForButtonValue = true
                };
                dgvDelivery.Columns.Add(btnProcess);
                DataGridViewButtonColumn btnCancel = new DataGridViewButtonColumn
                {
                    Name = "btnCancel",
                    HeaderText = "Action",
                    Text = "Cancel",
                    UseColumnTextForButtonValue = true
                };
                dgvDelivery.Columns.Add(btnCancel);
            }
        }

        private async void dgvDelivery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDelivery.Rows[e.RowIndex];

                selectedRowIndex = e.RowIndex;
            }

            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvDelivery.Columns[e.ColumnIndex].Name != "btnProcess" &&
                dgvDelivery.Columns[e.ColumnIndex].Name != "btnCancel")
            {
                return;
            }
            var statusCell = dgvDelivery.Rows[e.RowIndex].Cells["requestStatus"];
            if (statusCell?.Value == null)
            {
                MessageBox.Show("Status information not available.");
                return;
            }
            var status = dgvDelivery.Rows[e.RowIndex].Cells["requestStatus"].Value?.ToString();
            if (status == "Completed" || status == "Cancelled")
            {
                MessageBox.Show($"This record is {status}.");
                return;
            }
            if(dgvDelivery.Columns[e.ColumnIndex].Name == "btnCancel")
            {
                var confirmResult = MessageBox.Show("Are you sure you want to cancel this delivery request?", "Confirm Cancel", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    string requestID = dgvDelivery.Rows[e.RowIndex].Cells["requestID"].Value.ToString();
                    ProcessDelivery data = new ProcessDelivery
                    {
                        requestID = requestID
                    };
                    string result = await apiCaller.PostAPIResponse("/Supply/ProcessDeliveryRequest?action=cancel", data);
                    if (result == "0")
                    {
                        MessageBox.Show("Failed to cancel delivery request.");
                    }
                    else
                    {
                        MessageBox.Show("Delivery request cancelled successfully.");
                        //await frmDelivery_Load();
                    }
                }
                return;
            }
            if (dgvDelivery.Columns[e.ColumnIndex].Name == "btnProcess")          
                await ProcessDelivery(e.RowIndex);
        }

        private void AddActionButtons()
        {
            int buttonY = dgvDelivery.Bottom + 20;
            int buttonWidth = 180;
            int buttonSpacing = 15;

            btnView = CreateStyledButton("View Processed Delivery", 50 + buttonSpacing, buttonY, buttonWidth+80);
            this.Controls.Add(btnView);
            btnView.Click += BtnView_Click;           

            btnBack = CreateStyledButton("BACK", btnView.Right + buttonSpacing + 560, buttonY, buttonWidth - 40);
            FormDesign.ClickEvent(btnBack, this);
            this.Controls.Add(btnBack);
        }

        private async void BtnView_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "PROCESSED DELIVERY REQUESTS";
            dgvDelivery.DataSource = null; // Clear previous data
            dgvDelivery.Columns.Clear(); // Clear columns
            DataTable dt = await apiCaller.GetAPIResponse("Supply/GetData?tableName=deliveryorder&columns=*&null");
            dgvDelivery.DataSource = dt;
            btnGenerate = CreateStyledButton("Generate Delivery Notes", 400, dgvDelivery.Bottom+20,260);
            this.Controls.Add(btnGenerate);
            btnGenerate.Click += BtnGenerate_Click;

        }
        private async void BtnGenerate_Click(object sender, EventArgs e)
        {

            if (selectedRowIndex <0)
            {
                MessageBox.Show("Please select a delivery request to generate notes.");
                return;
            }
            var selectedRow = dgvDelivery.Rows[selectedRowIndex];
            string deliveryOrderId = selectedRow.Cells["deliveryOrderID"].Value.ToString();
            //MessageBox.Show($"{deliveryOrderId}");
            DataTable dt = await apiCaller.GetAPIResponse($"Supply/GenerateNotes?deliveryOrderID={deliveryOrderId}");
            if(dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                string orderId = row["orderID"].ToString();
                string customerName = row["customerName"].ToString();
                string customerPhone = row["customerPhone"].ToString();
                string courierName = row["courierName"].ToString();
                string trackingId = row["trackingID"].ToString();
                string createDate = Convert.ToDateTime(row["createDate"]).ToString("yyyy-MM-dd");

                Form form = new Form
            {   
                Text = "Delivery Details",
                Size = new Size(500, 500),
                StartPosition = FormStartPosition.CenterScreen,
                Font = new Font("Segoe UI", 10)
            };


            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 2,
                Padding = new Padding(30, 20, 30, 30)
            };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));

            // 用字段生成行
            AddField(layout, "Delivery Order ID", deliveryOrderId);
            AddField(layout, "Order ID", orderId);
            AddField(layout, "Customer Name", customerName);
            AddField(layout, "Customer Phone", customerPhone);
            AddField(layout, "Courier Name", courierName);
            AddField(layout, "Tracking ID", trackingId);
            AddField(layout, "Created Date", createDate);

            // 按钮面板
            var btnPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Bottom,
                Padding = new Padding(10),
                Height = 60,
                AutoSize = true

            };

            Button btnGenerate = new Button
            {
                Text = "Generate",
                Width = 100,
                Height =40,
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnGenerate.Click += (s, e) =>
            {
                MessageBox.Show("🎉 Delivery notes generated successfully!");
                form.Close();
            };

            Button btnCancel = new Button
            {
                Text = "Cancel",
                Width = 100,
                Height=40
            };
            btnCancel.Click += (s, e) => form.Close();

            btnPanel.Controls.Add(btnGenerate);
            btnPanel.Controls.Add(btnCancel);

            // 外层面板包裹内容
            var wrapper = new Panel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill
            };
            wrapper.Controls.Add(layout);

            form.Controls.Add(wrapper);
            form.Controls.Add(btnPanel);
            form.ShowDialog();
        

      
    }
            //string trackingId = selectedRow.Cells["trackingID"].Value.ToString();
            // Call API to generate delivery notes
            //string result = await apiCaller.PostAPIResponse($"/Supply/GenerateDeliveryNotes?deliveryOrderID={deliveryOrderId}&trackingID={trackingId}", null);
            //if (result == "0")
            //{
            //    MessageBox.Show("Failed to generate delivery notes.");
            //}
            //else
            //{
            //    MessageBox.Show("Delivery notes generated successfully!");
            //    // Optionally, refresh the data grid view

            //}
        }
        private void AddField(TableLayoutPanel layout, string label, string value)
        {
            Label lbl = new Label
            {
                Text = label + ":",
                Anchor = AnchorStyles.Right,
                AutoSize = true
            };

            TextBox txt = new TextBox
            {
                Text = value,
                ReadOnly = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Width = 250
            };

            int rowIndex = layout.RowCount++;
            layout.Controls.Add(lbl, 0, rowIndex);
            layout.Controls.Add(txt, 1, rowIndex);
        }
        private Button CreateStyledButton(string text, int x, int y, int width = 180, int height = 40)
        {
            return new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = Color.LightSteelBlue,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
        }
        private async Task ProcessDelivery(int rowIndex)
        {
            var currentRow = dgvDelivery.Rows[rowIndex];
            string requestID = currentRow.Cells["requestID"].Value.ToString();
            string orderID = currentRow.Cells["orderID"].Value.ToString();
            string customerID = currentRow.Cells["customerID"].Value.ToString();
            string customerName = currentRow.Cells["customerName"].Value.ToString();
            string companyAddress = currentRow.Cells["companyAddress"].Value.ToString();
            string customerPhone = currentRow.Cells["customerPhone"].Value.ToString();
            string status = currentRow.Cells["requestStatus"].Value.ToString();

            // Generate IDs
            DataTable allID = await apiCaller.GetAPIResponse($"/Supply/GetMaxID?tableName=deliveryorder&fieldName=deliveryOrderID");
            string deliveryOrderId = FormData.GenerateID("DO", allID, "deliveryOrderID");

            DataTable allID2 = await apiCaller.GetAPIResponse($"/Supply/GetMaxID?tableName=deliveryorder&fieldName=trackingID");
            string trackingId = FormData.GenerateID("T", allID2, "trackingID");

            // Load couriers for combobox
            var couriersDt = await apiCaller.GetAPIResponse("Supply/GetData?tableName=courier&columns=*&null");

            using (var deliveryForm = new Form())
            {
                deliveryForm.Text = "Process Delivery";
                deliveryForm.StartPosition = FormStartPosition.CenterParent;
                deliveryForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                deliveryForm.ClientSize = new Size(550, 500);
                deliveryForm.MinimizeBox = false;
                deliveryForm.MaximizeBox = false;

                // Title with Delivery Order ID
                var lblTitle = new Label
                {
                    Text = $"Delivery Order: {deliveryOrderId}",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.DarkBlue,
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Width = 450,
                    Height = 40,
                    Location = new Point((deliveryForm.ClientSize.Width - 450) / 2, 20)
                };

                // Field layout (two columns)
                int leftCol1 = 50;
                int leftCol2 = 300;
                int topStart = 70;
                int rowHeight = 30;

                // Delivery Order ID (read-only)
                var lblDeliveryRequestId = new Label
                {
                    Text = "Delivery Request ID:",
                    Location = new Point(leftCol1, topStart),
                    AutoSize = true
                };
                var txtDeliveryRequestId = new TextBox
                {
                    Location = new Point(leftCol1, topStart + rowHeight),
                    Width = 200,
                    Text = requestID,
                    ReadOnly = true,
                    BackColor = SystemColors.Control
                };

                // Courier Selection (combobox)
                var lblCourier = new Label
                {
                    Text = "Courier:",
                    Location = new Point(leftCol2, topStart),
                    AutoSize = true
                };
                var cmbCourier = new ComboBox
                {
                    Location = new Point(leftCol2, topStart + rowHeight),
                    Width = 200,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };

                // Populate courier combobox
                foreach (DataRow row in couriersDt.Rows)
                {
                    cmbCourier.Items.Add(new KeyValuePair<string, string>(
                        row["courierID"].ToString(),
                        row["courierName"].ToString()));
                    cmbCourier.DisplayMember = "Value";
                    cmbCourier.ValueMember = "Key";
                }
                if (cmbCourier.Items.Count > 0)
                    cmbCourier.SelectedIndex = 0;

                // Tracking ID (read-only)
                var lblTrackingId = new Label
                {
                    Text = "Tracking ID:",
                    Location = new Point(leftCol1, topStart + rowHeight * 3),
                    AutoSize = true
                };
                var txtTrackingId = new TextBox
                {
                    Location = new Point(leftCol1, topStart + rowHeight * 4),
                    Width = 200,
                    Text = trackingId,
                    ReadOnly = true,
                    BackColor = SystemColors.Control
                };

                // Customer Information (read-only fields)
                var lblCustomerName = new Label
                {
                    Text = "Customer Name:",
                    Location = new Point(leftCol1, topStart + rowHeight * 6),
                    AutoSize = true
                };
                var txtCustomerName = new TextBox
                {
                    Location = new Point(leftCol1, topStart + rowHeight * 7),
                    Width = 450,
                    Text = customerName,
                    ReadOnly = true,
                    BackColor = SystemColors.Control
                };

                var lblCompanyAddress = new Label
                {
                    Text = "Company Address:",
                    Location = new Point(leftCol1, topStart + rowHeight * 9),
                    AutoSize = true
                };
                var txtCompanyAddress = new TextBox
                {
                    Location = new Point(leftCol1, topStart + rowHeight * 10),
                    Width = 450,
                    Text = companyAddress,
                    //ReadOnly = true,
                    BackColor = SystemColors.Control,
                    Multiline = true,
                    Height = 50
                };

                var lblCustomerPhone = new Label
                {
                    Text = "Phone:",
                    Location = new Point(leftCol1, topStart + rowHeight * 13),
                    AutoSize = true
                };
                var txtCustomerPhone = new TextBox
                {
                    Location = new Point(leftCol1, topStart + rowHeight * 14),
                    Width = 200,
                    Text = customerPhone,
                    ReadOnly = true,
                    BackColor = SystemColors.Control
                };

                // Buttons (bottom center)
                var btnConfirm = new Button
                {
                    Text = "Confirm Delivery",
                    Size = new Size(150, 30),
                    Location = new Point(deliveryForm.ClientSize.Width / 2 - 160, deliveryForm.ClientSize.Height - 60),
                    DialogResult = DialogResult.OK
                };

                var btnCancel = new Button
                {
                    Text = "Cancel",
                    Size = new Size(100, 30),
                    Location = new Point(deliveryForm.ClientSize.Width / 2 + 10, deliveryForm.ClientSize.Height - 60),
                    DialogResult = DialogResult.Cancel
                };

                // Add all controls
                deliveryForm.Controls.AddRange(new Control[] {
            lblTitle,
            lblDeliveryRequestId, txtDeliveryRequestId,
            lblCourier, cmbCourier,
            lblTrackingId, txtTrackingId,
            lblCustomerName, txtCustomerName,
            lblCompanyAddress, txtCompanyAddress,
            lblCustomerPhone, txtCustomerPhone,
            btnConfirm, btnCancel
        });


                deliveryForm.AcceptButton = btnConfirm;
                deliveryForm.CancelButton = btnCancel;

                if (deliveryForm.ShowDialog(this) == DialogResult.OK)
                {
                    var selectedCourier = (KeyValuePair<string, string>)cmbCourier.SelectedItem;

                    var deliveryData = new ProcessDelivery
                    {
                        deliveryOrderID = deliveryOrderId,
                        requestID = requestID,
                        courierID = selectedCourier.Key,
                        trackingID = trackingId
                     
                    };

                    // Call API to process delivery
                    string result = await apiCaller.PostAPIResponse("/Supply/ProcessDeliveryRequest?action=process", deliveryData);

                    if (result != "0")
                    {
                        MessageBox.Show("Delivery processed successfully!", "Success");
                        //await RefreshDeliveryRequests();
                    }
                    else
                    {
                        MessageBox.Show("Failed to process delivery.", "Error");
                    }
                }
            }
        }

      
    

    
        #endregion
    }
}