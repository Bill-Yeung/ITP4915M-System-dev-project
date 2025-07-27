using Client.Controllers;
using Client.GenaralMethod;

namespace Client.Views.SupplyChain
{
    partial class frmMaterialDemand
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
            this.Text = "frmMaterialDemand";
            Load += frmMaterialDemand_Load;
        }
        protected BindingSource bindingSource = new BindingSource();
        private void initializeCustomComponents()
        {
            this.lblDemandIDTitle = new Label();
            this.lblDemandID = new Label();
            this.lblTitle = new Label();

            this.lblReceiver = new Label();
            this.txtReceiver = new TextBox();
            this.lblExpectReceiveDate = new Label();
            this.dtpExpectReceiveDate = new DateTimePicker();
            txtReceiver.Text = "Production DPT";

            this.lblDeliveryAddress = new Label();
            this.txtDeliveryAddress = new TextBox();

            this.grpMaterialEntry = new GroupBox();

            this.lblMaterial = new Label();
            this.cmbMaterial = new ComboBox();
            this.lblQuantity = new Label();
            this.txtQuantity = new TextBox();
            this.btnAddMaterial = new Button();
            btnAddMaterial.Click += (s, e) => addMaterialDemand();
            this.dgvMaterials = new DataGridView();

            // Action Buttons
            this.btnView = new Button();
            this.btnSendRequest = new Button();
            this.btnBack = new Button();
            this.SuspendLayout();

            this.ClientSize = new Size(800, 650);
            this.Text = "Request Material Demand For Production";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.lblDemandIDTitle.AutoSize = true;
            this.lblDemandIDTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblDemandIDTitle.Location = new Point(570, 40);
            this.lblDemandIDTitle.Text = "Demand ID:";
            this.lblDemandID.AutoSize = true;
            this.lblDemandID.Font = new Font("Segoe UI", 9F);
            this.lblDemandID.Location = new Point(700, 40);
            //this.lblRequestID.Text = GenerateRequestID(); // 调用生成ID的方法
            this.lblDemandID.Text = "";

            this.Controls.Add(this.lblDemandIDTitle);
            this.Controls.Add(this.lblDemandID);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Size = new Size(200, 30);
            this.lblTitle.Text = "Request Material Demand";
            this.Controls.Add(this.lblTitle);

            int yPos = 80;
            int labelWidth = 120;
            int fieldWidth = 200;
            AddLabeledControl(ref yPos, this.lblReceiver, "Receiver:", this.txtReceiver);
            AddLabeledControl(ref yPos, this.lblExpectReceiveDate, "Expect Receive Date:", this.dtpExpectReceiveDate);

            this.grpMaterialEntry.Location = new Point(20, yPos + 20);
            this.grpMaterialEntry.Size = new Size(750, 100);
            this.grpMaterialEntry.Text = "Material Entry";

            int xPos = 10;
            int fieldYPos = 30;
            AddMaterialField(ref xPos, fieldYPos, this.lblMaterial, "Material:", this.cmbMaterial, 250);
            AddMaterialField(ref xPos, fieldYPos, this.lblQuantity, "Quantity:", this.txtQuantity, 80);
            txtQuantity.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    addMaterialDemand();
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

            this.btnView.Location = new Point(20, yPos);
            this.btnView.Size = new Size(200, 30);
            this.btnView.Text = "View All Demand Request";

            this.btnBack.Location = new Point(670, yPos);
            this.btnBack.Size = new Size(100, 30);
            this.btnBack.Text = "Back";

            this.btnSendRequest.Location = new Point(560, yPos);
            this.btnSendRequest.Size = new Size(100, 30);
            this.btnSendRequest.Text = "Send Request";

            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSendRequest);
            btnSendRequest.Click += (s, e) => sendMaterialDemand();
            btnBack.Click += (s, e) => { this.Close(); PanelController.openForm(Program.homeForm.panelRight, new frmSupplyMain()); };
            FormDesign.ClickEvent(btnBack, this);
            btnView.Click += (s, e) => new frmDemandOverview(frmDemandOverview.FormMode.ProductionView).ShowDialog();
         

            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Label lblDemandIDTitle, lblDemandID, lblTitle, lblReceiver, lblDeliveryAddress, lblExpectReceiveDate;
        private Label lblMaterial, lblQuantity;
        private TextBox txtReceiver, txtDeliveryAddress,txtQuantity;
        private DateTimePicker dtpExpectReceiveDate;
        private Button btnAddMaterial,btnSendRequest,btnBack,btnView;
        private ComboBox cmbMaterial;
        private GroupBox grpMaterialEntry;
        private DataGridView dgvMaterials;
        private void AddLabeledControl(ref int yPos, Label label, string labelText, Control control)
        {
            label.AutoSize = true;
            label.Location = new Point(20, yPos);
            label.Text = labelText;

            control.Location = new Point(200, yPos);
            control.Size = new Size(200, 20);

            this.Controls.Add(label);
            this.Controls.Add(control);

            yPos += 40;
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
                DataPropertyName = "materialID",
                ReadOnly = true
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
                DataPropertyName = "quantity",
                ReadOnly = true
            });
            //var editColumn = new DataGridViewButtonColumn
            //{
            //    Name = "Update",
            //    HeaderText = "Action",
            //    Text = "Update",
            //    UseColumnTextForButtonValue = true
            //};
            //dgvMaterials.Columns.Add(editColumn);

            var deleteColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Action",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            dgvMaterials.Columns.Add(deleteColumn);
            dgvMaterials.CellContentClick += DgvMaterials_CellContentClick;
        }
            #endregion
        }
}