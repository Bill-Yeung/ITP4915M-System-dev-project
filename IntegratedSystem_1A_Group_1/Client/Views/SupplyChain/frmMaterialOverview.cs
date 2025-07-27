using Client.Controllers;
using Client.GenaralMethod;
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
    public partial class frmMaterialOverview : Form
    {
        DatabaseApicaller apiCaller = new DatabaseApicaller();
       
        private BindingSource bindingSource = new BindingSource();
       

       

        public frmMaterialOverview()
        {
          
            InitializeComponent();
            InitializeDynamicComponents();
        }
        private async void frmMaterialOverview_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable dt = await apiCaller.GetAPIResponse("/Supply/GetMaterialData");
           
            bindingSource.DataSource = dt;
            dgvMaterials.DataSource = bindingSource;  //GRIDVIEW将会显示bindingsource而不是最原始的dt数据，如搜索时可以使用
            dgvMaterials.ClearSelection();
            this.Cursor = Cursors.Default;
        }
        private void searchData(string term)
    
        {
            term = txtSearch.Text.Trim();

            // 多字段不区分大小写搜索
            bindingSource.Filter = $@"
                materialID LIKE '%{term}%' OR 
                materialName LIKE '%{term}%' OR
                stockStatus LIKE '%{term}%'           
            ";
                }
        

    }
    }

