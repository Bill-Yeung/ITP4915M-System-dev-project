using Client.Controllers;
using Client.Views.Components;
using EntityModels;

namespace Client.Views.SupplyChain
{
    partial class frmViewSupplier
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
            // frmViewSupplier
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "frmViewSupplier";
            Text = "frmViewSupplier";
            Load += frmViewSupplier_Load;
            ResumeLayout(false);

        }
        private void InitializeCustomComponents()
        {
            tableLayout = new TableLayoutPanel();
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.RowCount = 4;
            tableLayout.ColumnCount = 1;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // DataGridView 占满剩余空间
            tableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));     // 按钮行自适应高度
            this.Controls.Add(tableLayout);
            // 2. 添加标题 Label（第1行）
            Label titleLabel = new Label();
            titleLabel.Text = "Supplier Overview";
            titleLabel.Font = new Font("Microsoft YaHei", 14, FontStyle.Bold);
            titleLabel.Dock = DockStyle.Left;
            titleLabel.AutoSize = true;
            tableLayout.Controls.Add(titleLabel, 0, 0);

            // 3. 添加搜索栏（第2行：TextBox + Button）
            Panel searchPanel = new Panel();
            searchPanel.Dock = DockStyle.Fill;
            searchPanel.Height = 40;

            TextBox searchBox = new TextBox();
            searchBox.Width = 300;
            searchBox.Location = new Point(10, 5);
            searchBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SearchData(searchBox.Text);
                    e.Handled = e.SuppressKeyPress = true;
                }
            };

            Button searchButton = new Button();
            searchButton.Text = "Search";
            searchButton.Width = 80;
            searchButton.Location = new Point(320, 5);
            searchButton.Click += (s, e) => SearchData(searchBox.Text); // 绑定搜索事件

            searchPanel.Controls.AddRange(new Control[] { searchBox, searchButton });
            tableLayout.Controls.Add(searchPanel, 0, 1);
            dataGridView1 = new DataGridView();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Dock = DockStyle.Fill;
            tableLayout.Controls.Add(dataGridView1, 0, 2);
            InitializeColumns();
            Panel buttonPanel = new Panel();
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.Height = 50; // 设置按钮行高度
            tableLayout.Controls.Add(buttonPanel, 0, 3);

            // 添加列


            Button btnSendRequest = new Button { Text = "Send Restock Request", Width = 150 };
            frmRestock sendRequest = new frmRestock(); 
            btnSendRequest.Click+=(s,e) =>sendRequest.Show(); 
            Button btnAddSupplier = new Button { Text = "Add New Supplier", Width = 150 };
            frmAddSupplier addSupplier = new frmAddSupplier(); 
            btnAddSupplier.Click += (s, e) => addSupplier.Show(); 
            Button btnViewDetail = new Button { Text = "View/Edit Detail", Width = 150 };
            Button btnBack = new Button { Text = "Back", Width = 150 };
            //btnBack.Click += (s, e) => frmViewSupplier_Load(s,e);
            btnBack.Click += (s, e) =>
            {
                PanelController.openForm(Program.homeForm.panelRight, new frmWellcome());
            };

            btnViewDetail.Click += async (s, e) => supplierDetail();


                // 设置按钮位置（水平排列）
                btnSendRequest.Location = new Point(10, 10);
            btnAddSupplier.Location = new Point(170, 10);
            btnViewDetail.Location = new Point(330, 10);
            btnBack.Location = new Point(490, 10);

            // 将按钮添加到 Panel
            buttonPanel.Controls.AddRange(new[] { btnSendRequest, btnAddSupplier, btnViewDetail, btnBack });
        }
        private void InitializeColumns()
        {
            dataGridView1.Columns.Clear();
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Select";
            checkBoxColumn.Name = "IsSelected";
            checkBoxColumn.DataPropertyName = "IsSelected";
            dataGridView1.Columns.Add(checkBoxColumn);
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Supplier ID",
                Name = "Id",
                DataPropertyName = "supplierID"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Supplier Name",
                Name = "Name",
                DataPropertyName = "supplierName"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Phone",
                Name = "Phone",
                DataPropertyName = "supplierPhone"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Email",
                Name = "Email",
                DataPropertyName = "supplierEmail"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Address",               // 代码中使用的名称
                HeaderText = "Address",      // 显示标题
                DataPropertyName = "supplierAddress"  // 必须与DataTable中的列名完全一致
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Contact",
                HeaderText = "Contact Person",
                DataPropertyName = "ContactPerson"
            });
        }

        #endregion
    }
}