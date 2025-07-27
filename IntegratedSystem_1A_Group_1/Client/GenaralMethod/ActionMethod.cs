using Client.Controllers;
using EntityModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GenaralMethod
{
    public class ActionMethod
    {
        DatabaseApicaller apiCaller= new DatabaseApicaller();
        public async Task SearchFromDt(DataGridView view, string searchTerm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    MessageBox.Show("Please enter a search term.");
                    return;
                }
                DataTable dt = await apiCaller.GetAPIResponse($"/Supply/SearchData?term={searchTerm}");
                view.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search failed: {ex.Message}");
                Debug.WriteLine($"Full error: {ex}");
            }
        }
        public void SearchFromView(string searchTerm)
        {


        }
    }
}