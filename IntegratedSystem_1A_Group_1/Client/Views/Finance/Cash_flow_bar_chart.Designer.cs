namespace Client.Views.Finance
{
   partial class Cash_flow_bar_chart
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
            LblTitle = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            tableLayoutPanel2 = new TableLayoutPanel();
            BtnSet = new Button();
            txtWarningValue = new TextBox();
            Lbl = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // LblTitle
            // 
            LblTitle.Anchor = AnchorStyles.None;
            LblTitle.AutoSize = true;
            LblTitle.Font = new Font("Segoe UI", 20F);
            LblTitle.Location = new Point(370, 28);
            LblTitle.Margin = new Padding(2, 0, 2, 0);
            LblTitle.Name = "LblTitle";
            LblTitle.Size = new Size(262, 37);
            LblTitle.TabIndex = 0;
            LblTitle.Text = "Past Finance Records";
            LblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6.033519F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 87.93297F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6.03351974F));
            tableLayoutPanel1.Controls.Add(LblTitle, 1, 0);
            tableLayoutPanel1.Controls.Add(formsPlot1, 1, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Location = new Point(1, 0);
            tableLayoutPanel1.Margin = new Padding(2, 2, 2, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.2619133F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 4.76190472F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 78.97618F));
            tableLayoutPanel1.Size = new Size(1005, 578);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // formsPlot1
            // 
            formsPlot1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            formsPlot1.DisplayScale = 1.5F;
            formsPlot1.Location = new Point(62, 122);
            formsPlot1.Margin = new Padding(2, 2, 2, 2);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(879, 454);
            formsPlot1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(BtnSet, 2, 0);
            tableLayoutPanel2.Controls.Add(txtWarningValue, 1, 0);
            tableLayoutPanel2.Controls.Add(Lbl, 0, 0);
            tableLayoutPanel2.Location = new Point(62, 95);
            tableLayoutPanel2.Margin = new Padding(2, 2, 2, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(879, 23);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // BtnSet
            // 
            BtnSet.Anchor = AnchorStyles.Top;
            BtnSet.Location = new Point(692, 2);
            BtnSet.Margin = new Padding(2, 2, 2, 2);
            BtnSet.Name = "BtnSet";
            BtnSet.Size = new Size(78, 19);
            BtnSet.TabIndex = 0;
            BtnSet.Text = "Set";
            BtnSet.UseVisualStyleBackColor = true;
            BtnSet.Click += BtnSet_Click;
            // 
            // txtWarningValue
            // 
            txtWarningValue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtWarningValue.Location = new Point(294, 2);
            txtWarningValue.Margin = new Padding(2, 2, 2, 2);
            txtWarningValue.Name = "txtWarningValue";
            txtWarningValue.Size = new Size(288, 23);
            txtWarningValue.TabIndex = 1;
            // 
            // Lbl
            // 
            Lbl.Anchor = AnchorStyles.None;
            Lbl.AutoSize = true;
            Lbl.Location = new Point(60, 4);
            Lbl.Margin = new Padding(2, 0, 2, 0);
            Lbl.Name = "Lbl";
            Lbl.Size = new Size(172, 15);
            Lbl.TabIndex = 2;
            Lbl.Text = "Change the Warring Line Value:";
            // 
            // Cash_flow_bar_chart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1014, 595);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Cash_flow_bar_chart";
            Text = "Cash_flow_bar_chart";
            Load += Cash_flow_bar_chart_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        //private ScottPlot.WinForms.FormsPlot BarChart;
        private Label LblTitle;
        private TableLayoutPanel tableLayoutPanel1;
        private DateTimePicker DTPEndDate;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnSet;
        private TextBox txtWarningValue;
        private Label Lbl;
    }
}