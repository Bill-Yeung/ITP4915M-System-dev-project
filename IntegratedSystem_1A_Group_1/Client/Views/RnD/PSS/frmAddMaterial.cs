using Client.Common;
using Client.Controllers;
using EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views.RnD.PSS
{
    public partial class frmAddMaterial : Form
    {

        public string selectedMaterialID { get; set; }
        public string selectedMaterialName { get; set; }
        public decimal selectedMaterialQuantity { get; set; }

        public frmAddMaterial()
        {
            InitializeComponent();
        }

        private async void frmAddMaterial_Load(object sender, EventArgs e)
        {

            // Load current materials
            string materialString = await APIController.ApiRequest("POST", "/Common/GetData/RawMaterial/true", null);
            Helper.FillComboBoxByDatabase<RawMaterial>(materialString, [cbMaterialName], "materialID", "materialName");

        }

        private void cbMaterialName_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbMaterialName.SelectedItem != null)
            {
                lblUnit.Text = ((RawMaterial)cbMaterialName.SelectedItem).unit;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (cbMaterialName.SelectedItem != null && txtQuantity != null)
            {
                selectedMaterialID = ((RawMaterial)cbMaterialName.SelectedItem).materialID;
                selectedMaterialName = ((RawMaterial)cbMaterialName.SelectedItem).materialName;
                selectedMaterialQuantity = decimal.Parse(txtQuantity.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            } 
            else
            {
                MessageBox.Show("Please select a material and input quantity!");
            }
                
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
    }

}
