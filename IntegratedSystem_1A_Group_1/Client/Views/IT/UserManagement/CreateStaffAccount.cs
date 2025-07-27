using Client.Controllers;
using Client.Views.Login;
using EntityModels;

namespace Client.Views.UserManagement
{
    public partial class CreateStaffAccount : Form
    {
        public CreateStaffAccount()
        {
            InitializeComponent();
        }

        private List<ComboBox> systemComboBoxes = new List<ComboBox>();

        private void dgvAllUserTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CreateStaffAccount_Load(object sender, EventArgs e)
        {
            if (Session.CurrentStaff == null || Session.CurrentStaff.departmentID != "D00007")
            {
                MessageBox.Show("Only for IT Department staff", "No Access Right", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //set default department list
            comboBox_dept.Items.Clear();
            comboBox_dept.Items.AddRange(new string[] {
                "D00001 - Research and Development Department",
                "D00002 - Sales & Marketing Department",
                "D00003 - Production Department",
                "D00004 - Supply Chain Department",
                "D00005 - Customer Service Department",
                "D00006 - Finance Department",
                "D00007 - IT Department"
            });
            comboBox_dept.SelectedIndex = 0;
            comboBox_dept.SelectedIndexChanged += comboBox_dept_SelectedIndexChanged;

            //set default it system list
            checkedListBox_system.Items.Clear();
            checkedListBox_system.Items.AddRange(new string[] {
    "General System",
    "Project Management System",
    "Product Specification System",
    "Order Management System",
    "Production Monitoring System",
    "Raw Material Management System",
    "Inventory Management System",
    "Delivery System",
    "Supplier Control System",
    "Customer Feedback System",
    "Product Refund System",
    "Finance Analysis Tool",
    "Payment Gateway",
    "User Management System",
    "Support Request System",
    "System Learning Platform",
    "Software Feedback Collection System"
});

        }

        private void comboBox_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSystemListByDept(comboBox_dept.SelectedIndex);
        }

        private void UpdateSystemListByDept(int deptIndex)
        {
            checkedListBox_system.Items.Clear();

            switch (deptIndex)
            {
                case 0: // D00001 - Research and Development Department
                    checkedListBox_system.Items.AddRange(new string[] {
                        "General System",
                        "Project Management System",
                        "Product Specification System"
                    });
                    break;
                case 1: // D00002 - Sales & Marketing Department
                    checkedListBox_system.Items.AddRange(new string[] {
                        "General System",
                        "Order Management System",
                        "Product Refund System"
                    });
                    break;
                case 2: // D00003 - Production Department
                    checkedListBox_system.Items.AddRange(new string[] {
                        "General System",
                        "Production Monitoring System",
                        "Raw Material Management System",
                        "Inventory Management System"
                    });
                    break;
                case 3: // D00004 - Supply Chain Department
                    checkedListBox_system.Items.AddRange(new string[] {
                        "General System",
                        "Production Monitoring System",
                        "Raw Material Management System",
                        "Inventory Management System",
                        "Delivery System"
                    });
                    break;
                case 4: // D00005 - Customer Service Department
                    checkedListBox_system.Items.AddRange(new string[] {
                        "General System",
                        "Customer Feedback System",
                        "Product Refund System"
                    });
                    break;
                case 5: // D00006 - Finance Department
                    checkedListBox_system.Items.AddRange(new string[] {
                        "General System",
                        "Production Monitoring System",
                        "Finance Analysis Tool",
                        "Payment Gateway",
                        "Product Refund System"
                    });
                    break;
                case 6: // D00007 - IT Department
                    checkedListBox_system.Items.AddRange(new string[] {
                        "General System",
                        "User Management System",
                        "Support Request System",
                        "System Learning Platform",
                        "Software Feedback Collection System"
                    });
                    break;
                default:
                    checkedListBox_system.Items.Add("General System");
                    break;
            }
        }


        private async void btnCreate_Click(object sender, EventArgs e)
        {
            string jsonString = "";
            StringContent content;
            String result = "";

            switch (true)
            {
                //case true when string.IsNullOrEmpty(tbStaffID.Text):
                //  MessageBox.Show("Please input ID!");
                //return;
                case true when string.IsNullOrEmpty(tbStaffName.Text):
                    MessageBox.Show("Please input staff name!");
                    return;
                case true when string.IsNullOrEmpty(tbStaffPassword.Text):
                    MessageBox.Show("Please input password!");
                    return;
                //case true when string.IsNullOrEmpty(tbDept.Text):
                //  MessageBox.Show("Please input department!");
                //return;
                case true when string.IsNullOrEmpty(tbStaffPosition.Text):
                    MessageBox.Show("Please input position!");
                    return;
                case true when string.IsNullOrEmpty(tbStaffEmail.Text):
                    MessageBox.Show("Please input email!");
                    return;
                case true when string.IsNullOrEmpty(tbStaffPhone.Text):
                    MessageBox.Show("Please input phone!");
                    return;
                default:
                    break;
            }

            Staff staff = new Staff();
            //staff.staffID = tbStaffID.Text;
            staff.staffName = tbStaffName.Text;
            staff.staffPassword = APIController.HashPassword(tbStaffPassword.Text);

            string selectedDept = comboBox_dept.Text;
            string departmentID = selectedDept.Split(' ')[0];
            staff.departmentID = departmentID;

            staff.position = tbStaffPosition.Text;
            staff.staffEmail = tbStaffEmail.Text;
            staff.staffPhone = tbStaffPhone.Text;

            // get the selected system name
            string[] selectedSystems = checkedListBox_system.CheckedItems
                .OfType<string>()
                .ToArray();

            // create a dictionary for mapping system name with function id
            Dictionary<string, List<string>> systemFunctionMap = new Dictionary<string, List<string>>
{
    { "General System", new List<string> { "SF00001", "SF00002" } },
    { "Project Management System", new List<string> { "SF00101", "SF00102", "SF00103", "SF00104" } },
    { "Product Specification System", new List<string> { "SF00105","SF00106","SF00107","SF00108" } },
    { "Order Management System", new List<string> { "SF00201", "SF00202", "SF00203", "SF00204", "SF00205", "SF00206", "SF00207", "SF00208", "SF00209", "SF00210" } },
    { "Production Monitoring System", new List<string> { "SF00301", "SF00302" } },
    { "Raw Material Management System", new List<string> { "SF00401", "SF00402", "SF00403", "SF00404", "SF00405", "SF00406", "SF00407", "SF00408" } },
    { "Inventory Management System", new List<string> { "SF00501", "SF00502" } },
    { "Delivery System", new List<string> { "SF00601", "SF00602", "SF00603" } },
    { "Supplier Control System", new List<string> { "SF00701", "SF00702", "SF00703", "SF00704" } },
    { "Customer Feedback System", new List<string> { "SF00801", "SF00802", "SF00803", "SF00804" } },
    { "Product Refund System", new List<string> { "SF00901", "SF00902", "SF00903", "SF00904" } },
    { "Finance Analysis Tool", new List<string> { "SF01001", "SF01002" } },
    { "Payment Gateway", new List<string> { "SF01101" } },
    { "User Management System", new List<string> { "SF01201", "SF01202", "SF01203" } },
    { "Support Request System", new List<string> { "SF01301", "SF01302", "SF01303", "SF01304", "SF01305", "SF01306", "SF01307" } },
    { "System Learning Platform", new List<string> { "SF01401", "SF01402", "SF01403", "SF01404", "SF01405" } },
    { "Software Feedback Collection System", new List<string> { "SF01501", "SF01502", "SF01503" } },
};

            // assign values to selectedFunctionIds base on selected system name and systemFunctionMap
            List<string> selectedFunctionIds = new List<string>();
            foreach (string system in selectedSystems)
            {
                if (systemFunctionMap.TryGetValue(system, out List<string> functionIds))
                {
                    selectedFunctionIds.AddRange(functionIds);
                }
            }
            staff.systemFunctionIds = selectedFunctionIds;

            result = await APIController.ApiRequest("POST", "/UserManagement/CreateStaff", staff);

            if (result == "1")
            {
                MessageBox.Show("Staff account created successfully.");
                this.Close();
                PanelController.openForm(Program.homeForm.panelRight, new ViewAllUser());
            }
            else
            {
                MessageBox.Show("Failed to create customer account.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
