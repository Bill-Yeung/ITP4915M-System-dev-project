using Client.Controllers;
using Client.Views.Login;
using Client.Views.RnD.PSS;
using EntityModels;
using Svg;

namespace Client.Views.Components
{
    public partial class frmNavigation : Form
    {
        public frmNavigation()
        {
            InitializeComponent();
        }

        private void frmNavigation_Load(object sender, EventArgs e)
        {

            // Load menu header
            Button btnMenu = new Button();
            btnMenu.Text = "  Menu";
            SvgDocument svgMenu = SvgDocument.Open(Path.Combine(Application.StartupPath, "Assets", "menu.svg"));
            svgMenu.Width = 20;
            svgMenu.Height = 20;
            btnMenu.Image = svgMenu.Draw();
            btnMenu.Width = 200;
            btnMenu.Height = 60;
            btnMenu.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.FlatAppearance.BorderSize = 0;
            navMenu.Controls.Add(btnMenu, 0, 0);

            // Load functions
            if (Program.user is Staff)
            {

                var deptIds = new List<string>();
                var seenDepts = new HashSet<string>();
                foreach (var ar in Program.accessRights)
                {
                    if (ar.systemAccessRight != 2)
                    {
                        continue;
                    }
                    foreach (var sf in Program.systemFunctions)
                    {
                        if (sf.systemFunctionID != ar.systemFunctionID)
                        {
                            continue;
                        }
                        var deptId = sf.deptID;
                        if (string.IsNullOrEmpty(deptId))
                        {
                            continue;
                        }
                        if (seenDepts.Add(deptId))
                        {
                            deptIds.Add(deptId);
                        }
                    }
                }
                deptIds.Sort();

                foreach (var id in deptIds)
                {

                    string deptName = "";
                    string deptLogo = "";

                    switch (id)
                    {
                        case "D00001":
                            deptName = "   R && D";
                            deptLogo = "dept-rd.svg";
                            break;
                        case "D00002":
                            deptName = "   Sales && Marketing";
                            deptLogo = "dept-sales.svg";
                            break;
                        case "D00003":
                            deptName = "   Production";
                            deptLogo = "dept-production.svg";
                            break;
                        case "D00004":
                            deptName = "   Supply Chain";
                            deptLogo = "dept-supply-chain.svg";
                            break;
                        case "D00005":
                            deptName = "   Customer Service";
                            deptLogo = "dept-cs.svg";
                            break;
                        case "D00006":
                            deptName = "   Finance";
                            deptLogo = "dept-finance.svg";
                            break;
                        case "D00007":
                            deptName = "   IT";
                            deptLogo = "dept-it.svg";
                            break;
                    }

                    Button btnDept = new Button();
                    btnDept.Text = deptName;
                    btnDept.Tag = id;
                    SvgDocument svgDept = SvgDocument.Open(Path.Combine(Application.StartupPath, "Assets", deptLogo));
                    svgDept.Width = 20;
                    svgDept.Height = 20;
                    btnDept.Image = svgDept.Draw();
                    btnDept.Width = 200;
                    btnDept.Height = 60;
                    btnDept.ImageAlign = ContentAlignment.MiddleLeft;
                    btnDept.TextImageRelation = TextImageRelation.ImageBeforeText;
                    btnDept.FlatStyle = FlatStyle.Flat;
                    btnDept.FlatAppearance.BorderSize = 0;
                    btnDept.FlatAppearance.MouseOverBackColor = Color.DarkCyan;
                    btnDept.Click += new EventHandler(btnDept_Click);
                    menuPanel.Controls.Add(btnDept);

                }

            }

            Button btnLogout = new Button();
            btnLogout.Text = "   Logout";
            SvgDocument svgLogout = SvgDocument.Open(Path.Combine(Application.StartupPath, "Assets", "logout.svg"));
            svgLogout.Width = 20;
            svgLogout.Height = 20;
            btnLogout.Image = svgLogout.Draw();
            btnLogout.Width = 200;
            btnLogout.Height = 60;
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += new EventHandler(btnLogout_Click);

            navMenu.Controls.Add(btnLogout, 0, 2);

        }

        private void btnDept_Click(object? sender, EventArgs e)
        {
            var btn = (Button)sender;
            var deptId = btn.Tag.ToString();
            switch (deptId)
            {
                case "D00001":
                    PanelController.openForm(Program.homeForm.panelRight, new frmSystem(deptId, "Research && Development"));
                    break;
                case "D00002":
                    PanelController.openForm(Program.homeForm.panelRight, new frmSystem(deptId, "Sales && Marketing"));
                    break;
                case "D00003":
                    PanelController.openForm(Program.homeForm.panelRight, new frmSystem(deptId, "Production"));
                    break;
                case "D00004":
                    PanelController.openForm(Program.homeForm.panelRight, new frmSystem(deptId, "Supply Chain"));
                    break;
                case "D00005":
                    PanelController.openForm(Program.homeForm.panelRight, new frmSystem(deptId, "Customer Service"));
                    break;
                case "D00006":
                    PanelController.openForm(Program.homeForm.panelRight, new frmSystem(deptId, "Finance"));
                    break;
                case "D00007":
                    PanelController.openForm(Program.homeForm.panelRight, new frmSystem(deptId, "IT"));
                    break;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            var tbl = Program.header.header;
            var ctrl = tbl.GetControlFromPosition(2, 0);
            if (ctrl != null)
            {
                tbl.Controls.Remove(ctrl);
            }

            Program.homeForm = new frmHome();
            Program.user = null;
            Program.accessRights = null;
            Program.systemFunctions = null;
            Program.departments = null;
            PanelController.openForm(Program.mainForm.panelContent, new frmLogin());

        }

    }
}
