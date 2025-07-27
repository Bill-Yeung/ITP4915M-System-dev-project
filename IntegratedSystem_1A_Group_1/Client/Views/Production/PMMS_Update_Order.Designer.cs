namespace Client.Views.Production
{
    partial class PMMS_Update_Order
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
            TitleLbl = new Label();
            OrderIDtB = new TextBox();
            OrderIDLbl = new Label();
            ProductIDLbl = new Label();
            ProductNameLbl = new Label();
            QuantityLbl = new Label();
            ExpectedEndDateLbl = new Label();
            ExpectedEndDateDTP = new DateTimePicker();
            MaterialIDLbl = new Label();
            PerdictMaterialUsageLbl = new Label();
            StatusLbl = new Label();
            StartDateProductionLbl = new Label();
            EndDateProductionLbl = new Label();
            StartDateDTP = new DateTimePicker();
            EndDateDTP = new DateTimePicker();
            ProductIDTb = new TextBox();
            ProductNameTb = new TextBox();
            QuantityTb = new TextBox();
            MaterialIdTb = new TextBox();
            PerdictMaterialUsageTb = new TextBox();
            StatusCb = new ComboBox();
            BtnUpdate = new Button();
            ResetBtn = new Button();
            SuspendLayout();
            // 
            // TitleLbl
            // 
            TitleLbl.AutoSize = true;
            TitleLbl.Font = new Font("Segoe UI", 20F);
            TitleLbl.Location = new Point(479, 42);
            TitleLbl.Name = "TitleLbl";
            TitleLbl.Size = new Size(575, 54);
            TitleLbl.TabIndex = 0;
            TitleLbl.Text = "Start/Update Production Status";
            // 
            // OrderIDtB
            // 
            OrderIDtB.Location = new Point(753, 148);
            OrderIDtB.Name = "OrderIDtB";
            OrderIDtB.Size = new Size(150, 31);
            OrderIDtB.TabIndex = 1;
            OrderIDtB.TextChanged += OrderIDtB_TextChanged_1;
            // 
            // OrderIDLbl
            // 
            OrderIDLbl.AutoSize = true;
            OrderIDLbl.Font = new Font("Segoe UI", 10F);
            OrderIDLbl.Location = new Point(473, 148);
            OrderIDLbl.Name = "OrderIDLbl";
            OrderIDLbl.Size = new Size(91, 28);
            OrderIDLbl.TabIndex = 2;
            OrderIDLbl.Text = "Order ID:";
            // 
            // ProductIDLbl
            // 
            ProductIDLbl.AutoSize = true;
            ProductIDLbl.Font = new Font("Segoe UI", 10F);
            ProductIDLbl.Location = new Point(473, 205);
            ProductIDLbl.Name = "ProductIDLbl";
            ProductIDLbl.Size = new Size(114, 28);
            ProductIDLbl.TabIndex = 3;
            ProductIDLbl.Text = "Product ID: ";
            // 
            // ProductNameLbl
            // 
            ProductNameLbl.AutoSize = true;
            ProductNameLbl.Font = new Font("Segoe UI", 10F);
            ProductNameLbl.Location = new Point(473, 263);
            ProductNameLbl.Name = "ProductNameLbl";
            ProductNameLbl.Size = new Size(147, 28);
            ProductNameLbl.TabIndex = 4;
            ProductNameLbl.Text = "Product Name: ";
            ProductNameLbl.Click += ProductNameLbl_Click;
            // 
            // QuantityLbl
            // 
            QuantityLbl.AutoSize = true;
            QuantityLbl.Font = new Font("Segoe UI", 10F);
            QuantityLbl.Location = new Point(473, 328);
            QuantityLbl.Name = "QuantityLbl";
            QuantityLbl.Size = new Size(97, 28);
            QuantityLbl.TabIndex = 5;
            QuantityLbl.Text = "Quantity: ";
            // 
            // ExpectedEndDateLbl
            // 
            ExpectedEndDateLbl.AutoSize = true;
            ExpectedEndDateLbl.Font = new Font("Segoe UI", 10F);
            ExpectedEndDateLbl.Location = new Point(479, 691);
            ExpectedEndDateLbl.Name = "ExpectedEndDateLbl";
            ExpectedEndDateLbl.Size = new Size(184, 28);
            ExpectedEndDateLbl.TabIndex = 6;
            ExpectedEndDateLbl.Text = "Expected End Date: ";
            // 
            // ExpectedEndDateDTP
            // 
            ExpectedEndDateDTP.Location = new Point(754, 691);
            ExpectedEndDateDTP.Name = "ExpectedEndDateDTP";
            ExpectedEndDateDTP.Size = new Size(300, 31);
            ExpectedEndDateDTP.TabIndex = 7;
            ExpectedEndDateDTP.ValueChanged += ExpectedEndDateDTP_ValueChanged;
            // 
            // MaterialIDLbl
            // 
            MaterialIDLbl.AutoSize = true;
            MaterialIDLbl.Font = new Font("Segoe UI", 10F);
            MaterialIDLbl.Location = new Point(479, 407);
            MaterialIDLbl.Name = "MaterialIDLbl";
            MaterialIDLbl.Size = new Size(117, 28);
            MaterialIDLbl.TabIndex = 8;
            MaterialIDLbl.Text = "Material ID: ";
            // 
            // PerdictMaterialUsageLbl
            // 
            PerdictMaterialUsageLbl.AutoSize = true;
            PerdictMaterialUsageLbl.Font = new Font("Segoe UI", 10F);
            PerdictMaterialUsageLbl.Location = new Point(479, 486);
            PerdictMaterialUsageLbl.Name = "PerdictMaterialUsageLbl";
            PerdictMaterialUsageLbl.Size = new Size(212, 28);
            PerdictMaterialUsageLbl.TabIndex = 9;
            PerdictMaterialUsageLbl.Text = "Perdict Material Usage:";
            // 
            // StatusLbl
            // 
            StatusLbl.AutoSize = true;
            StatusLbl.Font = new Font("Segoe UI", 10F);
            StatusLbl.Location = new Point(479, 557);
            StatusLbl.Name = "StatusLbl";
            StatusLbl.Size = new Size(74, 28);
            StatusLbl.TabIndex = 11;
            StatusLbl.Text = "Status: ";
            // 
            // StartDateProductionLbl
            // 
            StartDateProductionLbl.AutoSize = true;
            StartDateProductionLbl.Font = new Font("Segoe UI", 10F);
            StartDateProductionLbl.Location = new Point(479, 620);
            StartDateProductionLbl.Name = "StartDateProductionLbl";
            StartDateProductionLbl.Size = new Size(232, 28);
            StartDateProductionLbl.TabIndex = 12;
            StartDateProductionLbl.Text = "Start date of production: ";
            // 
            // EndDateProductionLbl
            // 
            EndDateProductionLbl.AutoSize = true;
            EndDateProductionLbl.Font = new Font("Segoe UI", 10F);
            EndDateProductionLbl.Location = new Point(473, 764);
            EndDateProductionLbl.Name = "EndDateProductionLbl";
            EndDateProductionLbl.Size = new Size(224, 28);
            EndDateProductionLbl.TabIndex = 13;
            EndDateProductionLbl.Text = "End date of production: ";
            // 
            // StartDateDTP
            // 
            StartDateDTP.Location = new Point(759, 617);
            StartDateDTP.Name = "StartDateDTP";
            StartDateDTP.Size = new Size(300, 31);
            StartDateDTP.TabIndex = 14;
            StartDateDTP.ValueChanged += StartDateDTP_ValueChanged;
            // 
            // EndDateDTP
            // 
            EndDateDTP.Location = new Point(753, 764);
            EndDateDTP.Name = "EndDateDTP";
            EndDateDTP.Size = new Size(300, 31);
            EndDateDTP.TabIndex = 15;
            EndDateDTP.ValueChanged += EndDateDTP_ValueChanged;
            // 
            // ProductIDTb
            // 
            ProductIDTb.Location = new Point(753, 205);
            ProductIDTb.Name = "ProductIDTb";
            ProductIDTb.Size = new Size(150, 31);
            ProductIDTb.TabIndex = 16;
            // 
            // ProductNameTb
            // 
            ProductNameTb.Location = new Point(753, 263);
            ProductNameTb.Name = "ProductNameTb";
            ProductNameTb.Size = new Size(150, 31);
            ProductNameTb.TabIndex = 17;
            // 
            // QuantityTb
            // 
            QuantityTb.Location = new Point(753, 328);
            QuantityTb.Name = "QuantityTb";
            QuantityTb.Size = new Size(150, 31);
            QuantityTb.TabIndex = 18;
            // 
            // MaterialIdTb
            // 
            MaterialIdTb.Location = new Point(759, 404);
            MaterialIdTb.Name = "MaterialIdTb";
            MaterialIdTb.Size = new Size(150, 31);
            MaterialIdTb.TabIndex = 19;
            // 
            // PerdictMaterialUsageTb
            // 
            PerdictMaterialUsageTb.Location = new Point(759, 482);
            PerdictMaterialUsageTb.Name = "PerdictMaterialUsageTb";
            PerdictMaterialUsageTb.Size = new Size(150, 31);
            PerdictMaterialUsageTb.TabIndex = 20;
            // 
            // StatusCb
            // 
            StatusCb.FormattingEnabled = true;
            StatusCb.Location = new Point(759, 557);
            StatusCb.Name = "StatusCb";
            StatusCb.Size = new Size(183, 33);
            StatusCb.TabIndex = 22;
            StatusCb.SelectedIndexChanged += StatusCb_SelectedIndexChanged;
            // 
            // BtnUpdate
            // 
            BtnUpdate.BackColor = SystemColors.MenuHighlight;
            BtnUpdate.Location = new Point(527, 868);
            BtnUpdate.Margin = new Padding(4, 5, 4, 5);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(131, 67);
            BtnUpdate.TabIndex = 23;
            BtnUpdate.Text = "Update";
            BtnUpdate.UseVisualStyleBackColor = false;
            BtnUpdate.Click += BtnUpdate_Click;
            // 
            // ResetBtn
            // 
            ResetBtn.BackColor = SystemColors.MenuHighlight;
            ResetBtn.ForeColor = SystemColors.ControlText;
            ResetBtn.Location = new Point(753, 868);
            ResetBtn.Margin = new Padding(0);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(126, 67);
            ResetBtn.TabIndex = 24;
            ResetBtn.Text = "Reset";
            ResetBtn.UseVisualStyleBackColor = false;
            // 
            // PMMS_Update_Order
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1760, 1018);
            Controls.Add(ResetBtn);
            Controls.Add(BtnUpdate);
            Controls.Add(StatusCb);
            Controls.Add(PerdictMaterialUsageTb);
            Controls.Add(MaterialIdTb);
            Controls.Add(QuantityTb);
            Controls.Add(ProductNameTb);
            Controls.Add(ProductIDTb);
            Controls.Add(EndDateDTP);
            Controls.Add(StartDateDTP);
            Controls.Add(EndDateProductionLbl);
            Controls.Add(StartDateProductionLbl);
            Controls.Add(StatusLbl);
            Controls.Add(PerdictMaterialUsageLbl);
            Controls.Add(MaterialIDLbl);
            Controls.Add(ExpectedEndDateDTP);
            Controls.Add(ExpectedEndDateLbl);
            Controls.Add(QuantityLbl);
            Controls.Add(ProductNameLbl);
            Controls.Add(ProductIDLbl);
            Controls.Add(OrderIDLbl);
            Controls.Add(OrderIDtB);
            Controls.Add(TitleLbl);
            Name = "PMMS_Update_Order";
            Text = "PMMS_Update_Order";
            Load += PMMS_Update_Order_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLbl;
        private TextBox OrderIDtB;
        private Label OrderIDLbl;
        private Label ProductIDLbl;
        private Label ProductNameLbl;
        private Label QuantityLbl;
        private Label ExpectedEndDateLbl;
        private DateTimePicker ExpectedEndDateDTP;
        private Label MaterialIDLbl;
        private Label PerdictMaterialUsageLbl;
        private Label StatusLbl;
        private Label StartDateProductionLbl;
        private Label EndDateProductionLbl;
        private DateTimePicker StartDateDTP;
        private DateTimePicker EndDateDTP;
        private TextBox ProductIDTb;
        private TextBox ProductNameTb;
        private TextBox QuantityTb;
        private TextBox MaterialIdTb;
        private TextBox PerdictMaterialUsageTb;
        private ComboBox StatusCb;
        private Button BtnUpdate;
        private Button ResetBtn;
    }
}