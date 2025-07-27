using Client.Controllers;
using Client.Views.CS.Refund;
using Client.Views.Finance;
using Client.Views.Production;
using Client.Views.RnD.PSS;
using Client.Views.UserManagement;
using Client.Views.SnM.OMS;
using EntityModels;
using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Views.SupplyChain;

namespace Client.Views.Components
{
    public partial class frmSystem : Form
    {

        private string deptId;

        public frmSystem(string deptId, string deptName)
        {
            InitializeComponent();
            this.deptId = deptId;
            lblDepartmentName.Text = deptName;
        }

        private void frmSystem_Load(object sender, EventArgs e)
        {

            var funcsSet = new HashSet<string>();
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
                    funcsSet.Add(sf.systemName);
                }
            }

            var funcs = funcsSet.ToList();

            foreach (var system in funcs)
            {

                Form form = new Form();
                string systemName = system;
                string systemLogo = "";

                switch(this.deptId)
                {
                    case "D00001":
                        switch (system)
                        {
                            case "Project Management System":
                                systemLogo = "pms-main.svg";
                                form = new frmDevelopment();
                                break;
                            case "Product Specification System":
                                systemLogo = "pss-main.svg";
                                form = new frmPSSMain();
                                break;
                            default:
                                continue;
                        }
                        break;
                    case "D00002":
                        switch (system)
                        {
                            case "Order Management System":
                                systemLogo = "oms-main.svg";
                                form = new frmOMS();
                                break;
                            default:
                                continue;
                        }
                        break;
                    case "D00003":
                        switch (system)
                        {
                            case "Production Monitoring System":
                                systemLogo = "prod-main.svg";
                                form = new PMMS_dashboard();
                                break;
                            default:
                                continue;
                        }
                        break;
                    case "D00004":
                        switch (system)
                        {
                            case "Raw Material Management System":
                                systemLogo = "rmms-main.svg";
                                form = new frmSupplyMain();
                                break;
                            case "Inventory Management System":
                                systemLogo = "ims-main.svg";
                                form = new frmInventory();
                                break;
                            case "Delivery System":
                                systemLogo = "ds-main.svg";
                                form = new frmSupplyMain2();
                                break;
                            case "Supplier Information System":
                                systemLogo = "sis-main.svg";
                                form = new frmViewSupplier();
                                break;
                            default:
                                continue;
                        }
                        break;
                    case "D00005":
                        switch (system)
                        {
                            case "Customer Feedback System":
                                systemLogo = "cfs-main.svg";
                                form = new frmDevelopment();
                                break;
                            case "Product Refund System":
                                systemLogo = "prs-main.svg";
                                form = new ViewAllRefundApplication();
                                break;
                            default:
                                continue;
                        }
                        break;
                    case "D00006":
                        switch (system)
                        {
                            case "Finance Analysis Tool":
                                systemLogo = "fat-main.svg";
                                form = new Record_home_Page();
                                break;
                            case "Payment Gateway":
                                systemLogo = "pg-main.svg";
                                form = new frmDevelopment();
                                break;
                            default:
                                continue;
                        }
                        break;
                    case "D00007":
                        switch (system)
                        {
                            case "User Management System":
                                systemLogo = "ums-main.svg";
                                form = new ViewAllUser();
                                break;
                            case "Support Request System":
                                systemLogo = "srs-main.svg";
                                form = new frmDevelopment();
                                break;
                            case "System Learning Platform":
                                systemLogo = "slp-main.svg";
                                form = new frmDevelopment();
                                break;
                            case "Software Feedback Collection System":
                                systemLogo = "sfcs-main.svg";
                                form = new frmDevelopment();
                                break;
                            default:
                                continue;
                        }
                        break;

                }

                Button btnSystem = new Button();
                btnSystem.Text = systemName;
                SvgDocument svgSystem = SvgDocument.Open(Path.Combine(Application.StartupPath, "Assets", systemLogo));
                svgSystem.Width = 80;
                svgSystem.Height = 80;
                btnSystem.Image = svgSystem.Draw();
                btnSystem.Width = 200;
                btnSystem.Height = 150;
                btnSystem.ImageAlign = ContentAlignment.MiddleCenter;
                btnSystem.TextImageRelation = TextImageRelation.ImageAboveText;
                btnSystem.Click += (sender, e) => { btnSystem_Click(sender, e, form); };
                btnSystem.FlatStyle = FlatStyle.Flat;
                btnSystem.Margin = new Padding(50);
                flowPanelSystem.Controls.Add(btnSystem);

            }

        }

        private void btnSystem_Click(object sender, EventArgs e, Form? form)
        {
            PanelController.openForm(Program.homeForm.panelRight, form);
        }

    }
}
