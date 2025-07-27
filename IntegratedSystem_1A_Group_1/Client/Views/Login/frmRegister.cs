using Client.Controllers;
using EntityModels;
using Newtonsoft.Json;
using Svg;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Client.Views.Login
{
    public partial class frmRegister : Form
    {

        public frmRegister()
        {
            InitializeComponent();
            SvgDocument svgReturn = SvgDocument.Open(Path.Combine(Application.StartupPath, "Assets", "return.svg"));
            svgReturn.Width = 80;
            svgReturn.Height = 80;
            btnReturn.BackgroundImage = svgReturn.Draw();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {

            string jsonString = "";
            StringContent content;
            String result = "";

            switch (true)
            {
                case true when string.IsNullOrEmpty(txtCustomerName.Text):
                    MessageBox.Show("Please input name!");
                    return;
                case true when string.IsNullOrEmpty(txtPassword.Text):
                    MessageBox.Show("Please input password!");
                    return;
                case true when string.IsNullOrEmpty(txtEmail.Text):
                    MessageBox.Show("Please input email!");
                    return;
                case true when string.IsNullOrEmpty(txtPhone.Text):
                    MessageBox.Show("Please input phone!");
                    return;
                case true when string.IsNullOrEmpty(txtAddress.Text):
                    MessageBox.Show("Please input address!");
                    return;
                case true when string.IsNullOrEmpty(txtCountry.Text):
                    MessageBox.Show("Please input country!");
                    return;
                default:
                    break;
            }


            Customer customer = new Customer();
            customer.customerName = txtCustomerName.Text;
            customer.customerPassword = APIController.HashPassword(txtPassword.Text);
            customer.customerEmail = txtEmail.Text;
            customer.customerPhone = txtPhone.Text;
            customer.companyAddress = txtAddress.Text;
            customer.country = txtCountry.Text;
            result = await APIController.ApiRequest("POST", "/UserLogin/RegisterCustomer", customer);

            // TO DO: Need to handle duplicate items

            if (result == "1")
            {
                MessageBox.Show("User registered successfully.");
                PanelController.openForm(Program.mainForm.panelContent, new frmLogin());
            }
            else
            {
                MessageBox.Show("Registration failed!");
            }

        }

        private void llLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelController.openForm(Program.mainForm.panelContent, new frmLogin());
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            PanelController.openForm(Program.mainForm.panelContent, new frmLogin());
        }
    }

}
