using Client.Controllers;
using Client.Views.SnM.OrderManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views.SnM.OMS
{
    public partial class frmOMS : Form
    {
        public frmOMS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PanelController.openForm(Program.homeForm.panelRight, new frmQuotationMain());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanelController.openForm(Program.homeForm.panelRight, new ViewAllOrder());
        }

    }

}
