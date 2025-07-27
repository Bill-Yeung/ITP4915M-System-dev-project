using Client.Controllers;
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
    public partial class frmInventory : Form
    {
        DatabaseApicaller apiCaller = new DatabaseApicaller();

        private BindingSource bindingSource = new BindingSource();
        public frmInventory()
        {
            InitializeComponent();
            Load += (s, e) => frmInventoryManagement_Load(); 
        }
        private async void frmInventoryManagement_Load()
        {
           
            this.Cursor = Cursors.WaitCursor;
            bindingSource.Filter = "";
            txtSearch.PlaceholderText = "Search by Material ID , Name or Stock Status...";
            DataTable dt = await apiCaller.GetAPIResponse("/Supply/GetInventoryData");
            dgvInventory.AutoGenerateColumns = true;
            bindingSource.DataSource = dt;
            //dgvInventory.DataSource = bindingSource;  //GRIDVIEW将会显示bindingsource而不是最原始的dt数据，如搜索时可以使用
            dgvInventory.DataSource = dt;
            dgvInventory.ClearSelection();
            addDgvButtonColumn();
            
            this.Cursor = Cursors.Default;
        }
   
        private void searchData(string term, string[] fields)
        {

            if (string.IsNullOrWhiteSpace(term))
            {
                MessageBox.Show("Please enter search key word.");
                return;
            }
         
            term = txtSearch.Text.Trim();    
            bindingSource.Filter = string.Join(" OR ", fields.Select(f => $"{f} LIKE '%{term}%'"));

        }
    
        private async void ShowInboundRecords()
        {
            lblTitle.Text = "INBOUND RECORD";
            bindingSource.Filter = "";
            txtSearch.PlaceholderText = "Search by Material ID, Name, Supplier ID or Supplier Name...";
            DataTable dt = await apiCaller.GetAPIResponse("/Supply/GetInBoundData");
            dgvInventory.AutoGenerateColumns = true;
            bindingSource.DataSource = dt;
            dgvInventory.Columns["btnAction"].Visible = false;
            //dgvInventory.DataSource = bindingSource;  //GRIDVIEW将会显示bindingsource而不是最原始的dt数据，如搜索时可以使用
            dgvInventory.DataSource = dt;
            dgvInventory.ClearSelection();
            addDgvButtonColumn();
            this.Cursor = Cursors.Default;
        }

        private async void ShowOutboundRecords()
        {
            lblTitle.Text = "OUTBOUND RECORD";
            bindingSource.Filter = "";
            txtSearch.PlaceholderText = "Search by Material ID , Name or Destination...";
            DataTable dt = await apiCaller.GetAPIResponse("/Supply/GetOutBoundData");
            dgvInventory.AutoGenerateColumns = true;
            bindingSource.DataSource = dt;
            dgvInventory.Columns["btnAction"].Visible = false;
            //dgvInventory.DataSource = bindingSource;  //GRIDVIEW将会显示bindingsource而不是最原始的dt数据，如搜索时可以使用
            dgvInventory.DataSource = dt;
            dgvInventory.ClearSelection();
            addDgvButtonColumn();
            this.Cursor = Cursors.Default;
        }
    }
}
