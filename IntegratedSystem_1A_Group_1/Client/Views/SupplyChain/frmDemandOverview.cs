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
using Client.GenaralMethod;

namespace Client.Views.SupplyChain
{
    public partial class frmDemandOverview : Form
    {
        private BindingSource bindingSource = new BindingSource();
        public enum FormMode { ProductionView, ManagerView }

        private readonly FormMode _currentMode;
   
        public frmDemandOverview(FormMode mode)
        {
            _currentMode = mode;
            InitializeComponent();
            InitializeUI();
            this.Load += async (sender, e) =>
            {
                await LoadDemandsAsync();
            };


        }
 
        private void searchData(string term)

        {
            term = txtSearch.Text.Trim();

            // 多字段不区分大小写搜索
            bindingSource.Filter = $@"
                materialID LIKE '%{term}%' OR 
                materialName LIKE '%{term}%' OR
                receiver LIKE '%{term}%' OR
                status LIKE '%{term}%'
            ";
        }
    }
}
