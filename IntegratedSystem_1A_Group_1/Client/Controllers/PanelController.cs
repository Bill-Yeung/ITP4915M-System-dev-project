using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public static class PanelController
    {

        public static void openForm(Panel panel, Form form)
        {

            // Remove any existing forms from the panel
            if (panel.Controls.Count > 0)
            {
                foreach (Control control in panel.Controls)
                {
                    control.Dispose();
                }
                panel.Controls.Clear();
            }

            // Set up the new form
            form.TopLevel = false; // for form to be embedded as child form
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panel.Controls.Add(form);
            panel.Tag = form;
            form.BringToFront();
            form.Show();

        }

    }

}
