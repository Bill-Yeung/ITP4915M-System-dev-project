using Client.Common;
using Client.Controllers;
using Client.Views.CustomerInterface;
using EntityModels;
using Newtonsoft.Json;
using Svg;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Client.Views.Login
{
    public partial class frmLogin : Form
    {

        public bool isLogin = false;
        private string Name { get; set; }
        private string Position { get; set; }

        public frmLogin()
        {
            InitializeComponent();
            isLogin = false;
        }

        private void lblForgetPassword_Click(object sender, EventArgs e)
        {
            PanelController.openForm(Program.mainForm.panelContent, new frmForgetPassword());
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {

            string jsonString = "";
            StringContent content;
            String result = "";
            User? user = null;

            if (!rbCustomer.Checked && !rbStaff.Checked)
            {
                MessageBox.Show("Please select the user type!");
                return;
            }

            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please input user name!");
                return;
            }

            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please input password!");
                return;
            }

            if (rbCustomer.Checked)
            {
                user = new Customer();
                ((Customer)user).customerName = txtUserName.Text;
                ((Customer)user).customerPassword = APIController.HashPassword(txtPassword.Text);
                result = await APIController.ApiRequest("POST", "/UserLogin/ValidateCustomer", user);
            }
            else if (rbStaff.Checked)
            {
                user = new Staff();
                ((Staff)user).staffName = txtUserName.Text;
                ((Staff)user).staffPassword = APIController.HashPassword(txtPassword.Text);
                result = await APIController.ApiRequest("POST", "/UserLogin/ValidateStaff", user);
            }
            else
            {
                result = "false";
            }

            if (result == "true")
            {

                // Get user info from the database
                if (user is Customer)
                {
                    user = new Customer();
                    ((Customer)user).customerName = txtUserName.Text;
                    result = await APIController.ApiRequest("POST", "/UserLogin/GetCustomerInfo", user);

                    List<Customer> users = JsonConvert.DeserializeObject<List<Customer>>(result);
                    Program.user = users[0];
                    Session.CurrentCustomer = users[0];
                    Name = users[0].customerName;
                    Position = "Customer";

                }
                else if (user is Staff)
                {

                    user = new Staff();
                    ((Staff)user).staffName = txtUserName.Text;
                    result = await APIController.ApiRequest("POST", "/UserLogin/GetStaffInfo", user);
                    List<Staff> users = JsonConvert.DeserializeObject<List<Staff>>(result);
                    Program.user = users[0];
                    Session.CurrentStaff = users[0];
                    Name = users[0].staffName;
                    Position = users[0].position;

                    var staffKey = new
                    {
                        staffID = users[0].staffID
                    };
                    result = await APIController.ApiRequest("POST", "/Common/GetData/StaffSystemAccessRight/false", Helper.ToDictionary(staffKey));
                    Program.accessRights = JsonConvert.DeserializeObject<List<StaffSystemAccessRight>>(result);

                    result = await APIController.ApiRequest("POST", "/Common/GetData/SystemFunction/true", null);
                    Program.systemFunctions = JsonConvert.DeserializeObject<List<SystemFunction>>(result);

                    result = await APIController.ApiRequest("POST", "/Common/GetData/Department/true", null);
                    Program.departments = JsonConvert.DeserializeObject<List<Department>>(result);

                }
                else
                {
                    throw new Exception();
                }

                var userCard = new TableLayoutPanel
                {
                    Size = new Size(250, 70),
                    Margin = new Padding(5),
                    BackColor = Color.LightGray,
                    ColumnCount = 2,
                    RowCount = 2,
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                    Padding = new Padding(0),
                    Anchor = AnchorStyles.Right
                };

                userCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
                userCard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                userCard.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
                userCard.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));

                SvgDocument svgPerson = SvgDocument.Open(Path.Combine(Application.StartupPath, "Assets", "profile.svg"));
                svgPerson.Width = 50;
                svgPerson.Height = 50;
                var pic = new PictureBox
                {
                    Image = svgPerson.Draw(),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(4),
                    BackColor = Color.Transparent
                };
                userCard.Controls.Add(pic, 0, 0);
                userCard.SetRowSpan(pic, 2);

                var lblName = new Label
                {
                    Text = Name,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Color.Transparent
                };
                userCard.Controls.Add(lblName, 1, 0);

                var lblPos = new Label
                {
                    Text = Position,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Color.Transparent
                };
                userCard.Controls.Add(lblPos, 1, 1);

                Program.header.header.Controls.Add(userCard, 2, 0);

                if (user is Customer)
                {
                    PanelController.openForm(Program.mainForm.panelContent, Program.homeForm);
                    PanelController.openForm(Program.homeForm.panelRight, new ViewCustomerOrder());
                }
                else if (user is Staff)
                {
                    if (Program.homeForm == null || Program.homeForm.IsDisposed)
                    {
                        Program.homeForm = new frmHome();
                    }

                    PanelController.openForm(Program.mainForm.panelContent, Program.homeForm);
                }

            }
            else
            {
                MessageBox.Show("Login failed!");
            }

        }

        

        private void llRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelController.openForm(Program.mainForm.panelContent, new frmRegister());
        }

    }

}
