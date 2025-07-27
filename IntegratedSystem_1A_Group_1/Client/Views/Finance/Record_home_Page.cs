using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Client.Controllers;
using Svg;

namespace Client.Views.Finance
{
    public partial class Record_home_Page : Form
    {
        public Record_home_Page()
        {
            InitializeComponent();

            SvgDocument svgDocument = SvgDocument.Open(Path.Combine(Application.StartupPath, "Assets", "UpdateOrder.svg"));
            svgDocument.Width = 200;
            svgDocument.Height = 200;
            UpdateBtn.Image = svgDocument.Draw();

            SvgDocument svgDocument2 = SvgDocument.Open(Path.Combine(Application.StartupPath, "Assets", "BarChart.svg"));
            svgDocument2.Width = 200;
            svgDocument2.Height = 200;
            CashFlowBtn.Image = svgDocument2.Draw();

        }

        private void CashFlowBtn_Click(object sender, EventArgs e)
        {
            PanelController.openForm(Program.homeForm.panelRight, new Cash_flow_bar_chart());
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            PanelController.openForm(Program.homeForm.panelRight, new View_Finance_Record());
        }

    }
}
