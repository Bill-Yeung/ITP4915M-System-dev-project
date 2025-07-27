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
    public partial class frmDelivery : Form
    {
        private BindingSource bindingSource = new BindingSource();
        DatabaseApicaller apiCaller =new DatabaseApicaller();
        public frmDelivery()
        {
            InitializeComponent();
            InitializeDynamicComponents();
            Load += (s, e) => frmDelivery_Load();
        }

        private async void frmDelivery_Load()
        {

            this.Cursor = Cursors.WaitCursor;

            txtSearch.PlaceholderText = "Search by request id, order id or status...";
            DataTable dt = await apiCaller.GetAPIResponse($"/Supply/GetDeliveryRequestData");
            dgvDelivery.AutoGenerateColumns = true;
          
            if (dt == null) MessageBox.Show("no data");
            bindingSource.DataSource = dt;  
            dgvDelivery.DataSource = dt;
            dgvDelivery.ClearSelection();
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

    }
}
