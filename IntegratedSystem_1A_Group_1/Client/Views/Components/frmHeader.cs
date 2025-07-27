using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views.Components
{
    public partial class frmHeader : Form
    {
        public frmHeader()
        {
            InitializeComponent();
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.ImageLocation = Path.Combine(Application.StartupPath, "Assets", "logo.png");
        }

        private void frmHeader_Load(object sender, EventArgs e)
        {
            timer_Tick(sender, e);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblSystemDateTime.Text = String.Format(
                CultureInfo.CreateSpecificCulture("en-US"),
                "Date: {0:dd-MMM-yyyy}\r\nTime: {1:h:mm:sstt}",
                DateTime.Now,
                DateTime.Now
            );
        }

    }
}
