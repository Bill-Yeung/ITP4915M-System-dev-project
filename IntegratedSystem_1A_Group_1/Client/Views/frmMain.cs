using Client.Views.Components;
using Client.Views.Login;
using Client.Controllers;

namespace Client.Views
{
    public partial class frmMain : Form
    {

        public Form activeContentForm = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            PanelController.openForm(panelHeader, Program.header);
            PanelController.openForm(panelContent, new frmLogin());
        }

    }
}
