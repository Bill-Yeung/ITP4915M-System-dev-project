using EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views.SupplyChain
{
  
    public partial class frmForSupplier : Form
    {
        public enum FormMode { SupplierView, ManagerView }

        private readonly FormMode _currentMode;
        private static DataTable originalData = new DataTable();

        public frmForSupplier(FormMode mode)
        {
            _currentMode = mode;
            InitializeComponent();
            InitializeUI();
            this.Load += async (sender, e) =>
            {
                await LoadRequestsAsync();
            };
            //LoadRequestsAsync();
           
        }

        private async void SearchData(string searchTerm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    MessageBox.Show("Please enter a search term.");
                    return;
                }
                DataTable dt = await apiCaller.GetAPIResponse($"/Supply/SearchRestockData?term={searchTerm}");
                dgvRequests.DataSource = dt;

                dgvRequests.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search failed: {ex.Message}");
                Debug.WriteLine($"Full error: {ex}");
            }
        }
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";

            dgvRequests.DataSource = originalData; 

            dgvRequests.Refresh();
        }
    }
}
