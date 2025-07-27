using Client.Controllers;
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
    public partial class frmViewSupplier : Form
    {   Supplier suppliers = new Supplier();
        private DataGridView dataGridView1;
        private TableLayoutPanel tableLayout;
        DatabaseApicaller apiCaller = new DatabaseApicaller();
        public frmViewSupplier()
        {
            InitializeComponent();
            InitializeCustomComponents();

        }
      
        private async void frmViewSupplier_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = await apiCaller.GetAPIResponse("/Supply/GetSupplierData");
              
                dataGridView1.DataSource = suppliers.dtToList(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load data: {ex.Message}");
          
                Debug.WriteLine($"Full error: {ex}");
            }
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
                DataTable dt = await apiCaller.GetAPIResponse($"/Supply/SearchSupplier?term={searchTerm}");            
                dataGridView1.DataSource = suppliers.dtToList(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search failed: {ex.Message}");
                Debug.WriteLine($"Full error: {ex}");
            }
        }
       private async void supplierDetail()
        {
           
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Please select a supplier row to view/edit.");
                    return;
                }

                var supplier = dataGridView1.CurrentRow.DataBoundItem as Supplier;
                if (supplier == null) return;

                var detailForm = new frmSupplierDetail(supplier);
                if (detailForm.ShowDialog() == DialogResult.OK)
                {
                    var updated = detailForm.UpdatedSupplier;

                    // 你可以选择在这里调用 API 保存更新：
                    string result = await apiCaller.PostAPIResponse("/Supply/UpdateSupplier", updated);
                    if (result != "0")
                    {
                        MessageBox.Show("Supplier updated successfully.");
                    }
              
                    else
                    {
                        MessageBox.Show("Update failed.");
                    }
                }
          
       
        }
      
        }
    
}
