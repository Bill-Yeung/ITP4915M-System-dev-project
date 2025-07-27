using Client.GenaralMethod;
using System.ComponentModel;

namespace Client.Views.SupplyChain
{
    partial class frmRestock
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
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Text = "frmRestock";
            Load += frmRestock_Load;
        }
        private void initializeCustomComponents()
        {
            this.lblRequestIDTitle = new Label();
            this.lblRequestID = new Label();
            this.lblTitle = new Label();

            this.lblSupplier = new Label();
            this.cmbSupplier = new ComboBox();
            this.lblContactInfo = new Label();
            this.txtContactInfo = new TextBox();
            this.lblOrderDate = new Label();
            this.dtpOrderDate = new DateTimePicker();
            this.lblDeliveryDate = new Label();
            this.dtpDeliveryDate = new DateTimePicker();
            this.lblDeliveryAddress = new Label();
            this.txtDeliveryAddress = new TextBox();

            // Material Entry Group
            this.grpMaterialEntry = new GroupBox();
            
            this.lblMaterial = new Label();
            this.cmbMaterial = new ComboBox();
            this.lblQuantity = new Label();
            this.txtQuantity = new TextBox();
          
            this.lblUnitPrice = new Label();
            this.txtUnitPrice = new TextBox();
            this.btnAddMaterial = new Button();
            btnAddMaterial.Click += (s, e) => addMaterialRestock();

            // Materials Grid
            this.dgvMaterials = new DataGridView();

            // Action Buttons
            this.btnViewAll = new Button();
            this.btnBack = new Button();
            this.btnSendRequest = new Button();
            btnBack.Click += (s, e) => FormDesign.ClickEvent(btnBack,this);
            btnSendRequest.Click += (s, e) => sendRestockRequest();

            // Total Amount
            this.lblTotalAmount = new Label();
            this.txtTotalAmount = new TextBox();

            // Send Via Group
            this.grpSendVia = new GroupBox();
            this.chkEmail = new CheckBox();
            this.chkFax = new CheckBox();
            this.chkPostalMail = new CheckBox();

            // Suspend Layout
            this.SuspendLayout();

            // 
            // Main Form
            // 
            this.ClientSize = new Size(800, 700);
            this.Text = "Restock Request Form";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.lblRequestIDTitle.AutoSize = true;
            this.lblRequestIDTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblRequestIDTitle.Location = new Point(550, 40);
            this.lblRequestIDTitle.Text = "Request ID:";

            this.lblRequestID.AutoSize = true;
            this.lblRequestID.Font = new Font("Segoe UI", 9F);
            this.lblRequestID.Location = new Point(680, 40);
            //this.lblRequestID.Text = GenerateRequestID(); // 调用生成ID的方法
            this.lblRequestID.Text = "";

            this.Controls.Add(this.lblRequestIDTitle);
            this.Controls.Add(this.lblRequestID);

            // Title Label
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Size = new Size(200, 30);
            this.lblTitle.Text = "Restock Request";
            this.Controls.Add(this.lblTitle);

            // Order Information Fields (simplified layout)
            int yPos = 60;
            int labelWidth = 120;
            int fieldWidth = 200;


            AddLabeledControl(ref yPos, this.lblSupplier, "Supplier:", this.cmbSupplier);
            AddLabeledControl(ref yPos, this.lblContactInfo, "Contact Info:", this.txtContactInfo);
            AddLabeledControl(ref yPos, this.lblOrderDate, "Created Date:", this.dtpOrderDate);
            AddLabeledControl(ref yPos, this.lblDeliveryDate, "Expected Delivery Date:", this.dtpDeliveryDate);
            AddLabeledControl(ref yPos, this.lblDeliveryAddress, "Delivery Address:", this.txtDeliveryAddress);
            //AddLabeledControl(ref yPos, this.lblDeliveryAddress, "Delivery Address:", this.txtDeliveryAddress);

            // Material Entry Group
            this.grpMaterialEntry.Location = new Point(20, yPos + 20);
            this.grpMaterialEntry.Size = new Size(750, 100);
            this.grpMaterialEntry.Text = "Material Entry";

            int xPos = 10;
            int fieldYPos = 30;

            // 修改AddMaterialField调用，使用统一的fieldYPos
            //AddMaterialField(ref xPos, fieldYPos, this.lblMaterialID, "Material ID:", this.txtMaterialID, 100);
            //AddMaterialField(ref xPos, fieldYPos, this.lblMaterialName, "Name:", this.txtMaterialName, 150);
            AddMaterialField(ref xPos, fieldYPos, this.lblMaterial, "Material:", this.cmbMaterial, 250);
            AddMaterialField(ref xPos, fieldYPos, this.lblQuantity, "Quantity:", this.txtQuantity, 80);
            AddMaterialField(ref xPos, fieldYPos, this.lblUnitPrice, "Unit Price:", this.txtUnitPrice, 80);
            txtUnitPrice.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    addMaterialRestock();
                    e.Handled = e.SuppressKeyPress = true;
                }
            };


            this.btnAddMaterial.Location = new Point(xPos + 10, fieldYPos + 15);
            this.btnAddMaterial.Size = new Size(100, 32);
            this.btnAddMaterial.Text = "Add Material";

            this.Controls.Add(this.grpMaterialEntry);
            yPos += 130;

            // Materials DataGridView
            this.dgvMaterials.Location = new Point(20, yPos);
            this.dgvMaterials.Size = new Size(750, 200);
            this.dgvMaterials.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(this.dgvMaterials);
            yPos += 220;

            // Total Amount
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new Point(580, yPos);
            this.lblTotalAmount.Text = "Total Amount:";
            this.txtTotalAmount.Location = new Point(700, yPos);
            this.txtTotalAmount.Size = new Size(90, 20);
            this.txtTotalAmount.ReadOnly = true;
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.txtTotalAmount);
            yPos += 30;

            // Send Via Group
            this.grpSendVia.Location = new Point(20, yPos);
            this.grpSendVia.Size = new Size(400, 50);
            this.grpSendVia.Text = "Send Via";

            this.chkEmail.Location = new Point(10, 20);
            this.chkEmail.Text = "Email";

            this.chkFax.Location = new Point(120, 20);
            this.chkFax.Text = "Fax";

            this.chkPostalMail.Location = new Point(220, 20);
            this.chkPostalMail.Text = "Postal Mail";

            this.grpSendVia.Controls.Add(this.chkEmail);
            this.grpSendVia.Controls.Add(this.chkFax);
            this.grpSendVia.Controls.Add(this.chkPostalMail);
            this.Controls.Add(this.grpSendVia);

            // Action Buttons
            this.btnViewAll.Location = new Point(450, yPos);
            this.btnViewAll.Size = new Size(100, 30);
            this.btnViewAll.Text = "View all restock request";
            this.btnViewAll.Click += (s, e) => new frmForSupplier(frmForSupplier.FormMode.ManagerView).ShowDialog();

            this.btnBack.Location = new Point(560, yPos);
            this.btnBack.Size = new Size(100, 30);
            this.btnBack.Text = "Back";

            this.btnSendRequest.Location = new Point(670, yPos);
            this.btnSendRequest.Size = new Size(100, 30);
            this.btnSendRequest.Text = "Send Request";

            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSendRequest);

            // Resume Layout
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Helper methods to simplify control addition
        private void AddLabeledControl(ref int yPos, Label label, string labelText, Control control)
        {
            label.AutoSize = true;
            label.Location = new Point(20, yPos);
            label.Text = labelText;

            control.Location = new Point(200, yPos);
            control.Size = new Size(200, 20);

            this.Controls.Add(label);
            this.Controls.Add(control);

            yPos += 35;
        }

        private void AddMaterialField(ref int xPos, int yPos, Label label, string labelText, Control control, int width)
        {
            label.AutoSize = true;
            label.Location = new Point(xPos, yPos);
            label.Text = labelText;

            control.Location = new Point(xPos, yPos + 20);
            control.Size = new Size(width, 20);

            this.grpMaterialEntry.Controls.Add(label);
            this.grpMaterialEntry.Controls.Add(control);
            this.grpMaterialEntry.Controls.Add(this.btnAddMaterial);

            xPos += width + 20;
        }
        private Label lblRequestIDTitle;
        private Label lblRequestID;
        private Label lblTitle;
     
    
        private Label lblSupplier;
        private ComboBox cmbSupplier;
        private Label lblContactInfo;
        private TextBox txtContactInfo;
        private Label lblOrderDate;
        private DateTimePicker dtpOrderDate;
        private Label lblDeliveryDate;
        private DateTimePicker dtpDeliveryDate;
        private Label lblDeliveryAddress;
        private TextBox txtDeliveryAddress;

        // Material Entry Group
        private GroupBox grpMaterialEntry;
        private Label lblMaterial;
        private ComboBox cmbMaterial;
        //private Label lblMaterialID;
        //private TextBox txtMaterialID;
        private Label lblQuantity;
        private TextBox txtQuantity;
        //private Label lblMaterialName;
        //private TextBox txtMaterialName;
        private Label lblUnitPrice;
        private TextBox txtUnitPrice;
        private Button btnAddMaterial;

        // Materials Grid
        private DataGridView dgvMaterials;

        // Action Buttons
        private Button btnViewAll;
        private Button btnBack;
        private Button btnSendRequest;
        
        // Total Amount
        private Label lblTotalAmount;
        private TextBox txtTotalAmount;

        // Send Via Group
        private GroupBox grpSendVia;
        private CheckBox chkEmail;
        private CheckBox chkFax;
        private CheckBox chkPostalMail;
        private void InitializeDataGridView()
        {
            // Configure the DataGridView for materials
            dgvMaterials.AutoGenerateColumns = false;
            //dgvMaterials.AllowUserToAddRows = false;

            // Add columns
            dgvMaterials.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaterialID",
                HeaderText = "Material ID",
                DataPropertyName = "materialID"
            });
            dgvMaterials.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaterialName",
                HeaderText = "Material Name",
                DataPropertyName = "materialName",
                ReadOnly = true
            });
            dgvMaterials.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Quantity",
                DataPropertyName = "restockQuantity"
            });
            dgvMaterials.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UnitPrice",
                HeaderText = "Unit Price",
                DataPropertyName = "UnitPrice",
                ReadOnly = true
            });
            dgvMaterials.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "totalPrice",
                HeaderText = "Total Price",
                DataPropertyName = "totalPrice",
                ReadOnly = true
            });

            // Add action buttons
            var editColumn = new DataGridViewButtonColumn
            {
                Name = "Update",
                HeaderText ="Action",
                Text = "Update",
                UseColumnTextForButtonValue = true
            };
            dgvMaterials.Columns.Add(editColumn);

            var deleteColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Action",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            dgvMaterials.Columns.Add(deleteColumn);
            dgvMaterials.CellContentClick += DgvMaterials_CellContentClick;
          //  dgvMaterials.CellEndEdit += DgvMaterials_CellEndEdit; 如果想编辑时实时更新数据就增加这个功能

        }

        private void InitializeDateTimePickers()
        {
            dtpOrderDate.Format = DateTimePickerFormat.Short;
            dtpDeliveryDate.Format = DateTimePickerFormat.Short;
            dtpOrderDate.Value = DateTime.Today;
            dtpDeliveryDate.MinDate = DateTime.Today;
            dtpDeliveryDate.Value = DateTime.Today.AddDays(7);
          
        }


        #endregion
    }
}