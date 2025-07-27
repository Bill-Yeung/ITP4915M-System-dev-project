using Client.Controllers;
using Svg;
using System.Reflection.PortableExecutable;

namespace Client.Views.Login
{
    public partial class frmForgetPassword : Form
    {

        public frmForgetPassword()
        {
            InitializeComponent();
            SvgDocument svgReturn = SvgDocument.Open(Path.Combine(Application.StartupPath, "Assets", "return.svg"));
            svgReturn.Width = 80;
            svgReturn.Height = 80;
            btnReturn.BackgroundImage = svgReturn.Draw();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            PanelController.openForm(Program.mainForm.panelContent, new frmLogin());
        }
    }
}
