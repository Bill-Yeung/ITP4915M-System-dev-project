using Client.Controllers;
using Client.Views.Components;
using System.Diagnostics;

namespace Client.Views.Login
{
    public partial class frmHome : Form
    {

        public frmHome()
        {
            InitializeComponent();
            PanelController.openForm(panelLeft, new frmNavigation());
            PanelController.openForm(panelRight, new frmWellcome());
        }

    }
}
