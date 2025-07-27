using Client.Controllers;
using EntityModels;
using Newtonsoft.Json;
using Client.Common;
using System.Threading.Tasks;

namespace Client.Views.RnD.PSS
{
    public partial class frmCreateProduct : Form
    {

        private string? staffString { get; set; }
        private string? customerString { get; set; }
        private string? productString { get; set; }
        private string? nextProductID { get; set; }

        public frmCreateProduct()
        {
            InitializeComponent();
        }

        private async void frmCreateProduct_Load(object sender, EventArgs e)
        {

            // Load next product ID
            nextProductID = await Helper.GenerateNextId("Product", "productID") ?? "P00001";
            txtProductID.Text = nextProductID;

            // Load current staff
            staffString = await APIController.ApiRequest("GET", "/UserLogin/GetAllStaff", null);
            ComboBox[] relevantCombox = [cbLeader, cbRnD, cbDesign, cbEngineering, cbSnM];
            Helper.FillComboBoxByDatabase<Staff>(staffString, relevantCombox, "staffID", "staffName");

            // Load product category
            string[] categoryOptions = new string[] {
                "Infant", "Children", "Adult",
                "Educational", "Figures", "Vehicle", "Musical", "Game",
                "Others"
            };
            Helper.FillComboBoxByArray([cbProductCategory], categoryOptions);

            // Load current products
            productString = await APIController.ApiRequest("POST", "/Common/GetData/Product/true", null);
            Helper.FillComboBoxByDatabase<Product>(productString, [cbProductInherited], "productID", "productName");

        }

        private void rbInternal_CheckedChanged(object sender, EventArgs e)
        {
            Helper.FillComboBoxByDatabase<Staff>(staffString, [cbProductSponsor], "staffID", "staffName");
        }
        
        private async void rbExternal_CheckedChanged(object sender, EventArgs e)
        {

            if (customerString == null) 
            {
                customerString = await APIController.ApiRequest("GET", "/UserLogin/GetAllCustomer", null);
            }

            Helper.FillComboBoxByDatabase<Customer>(customerString, [cbProductSponsor], "customerID", "customerName");

        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {

            switch (true)
            {
                case true when string.IsNullOrEmpty(txtProductName.Text):
                    MessageBox.Show("Please input product name!");
                    return;
                case true when (!rbInternal.Checked && !rbExternal.Checked):
                    MessageBox.Show("Please select product type!");
                    return;
                case true when (cbProductSponsor.Text == "Please select"):
                    MessageBox.Show("Please select product sponsor!");
                    return;
                case true when (cbLeader.Text == "Please select"):
                    MessageBox.Show("Please select product leader!");
                    return;
                case true when (rbInternal.Checked && (cbProductSponsor.Text != cbLeader.Text)):
                    MessageBox.Show("For internal projects, ProductSponsor should be the same as Product Leader!");
                    return;
                case true when (cbRnD.Text == "Please select"):
                    MessageBox.Show("Please select R&D leader!");
                    return;
                case true when (cbDesign.Text == "Please select"):
                    MessageBox.Show("Please select Design leader!");
                    return;
                case true when (cbEngineering.Text == "Please select"):
                    MessageBox.Show("Please select Engineering leader!");
                    return;
                case true when (cbSnM.Text == "Please select"):
                    MessageBox.Show("Please select S&M leader!");
                    return;
                case true when (cbProductCategory.Text == "Please select"):
                    MessageBox.Show("Please select product category!");
                    return;
                case true when string.IsNullOrEmpty(txtVersion.Text):
                    MessageBox.Show("Please input version!");
                    return;
                case true when string.IsNullOrEmpty(txtProductDescription.Text):
                    MessageBox.Show("Please input product description!");
                    return;
                default:
                    break;
            }

            List<Product> productList = new List<Product>();
            productList.Add(new Product
            {
                productID = nextProductID,
                parentProductID = cbProductInherited.SelectedValue?.ToString(),
                productName = txtProductName.Text,
                productType = rbInternal.Checked ? rbInternal.Text : rbExternal.Text,
                productCategory = cbProductCategory.Text,
                productVersion = txtVersion.Text,
                productStatus = "Pending approval"
            });

            Program.user = new Staff { staffID = "E00001", staffName = "Alice Johnson" };
            List<ProductAttributeVersion> productAttributeVersionList = new List<ProductAttributeVersion>();
            productAttributeVersionList.Add(new ProductAttributeVersion
            {
                versionID = (await Helper.GenerateNextId("ProductAttributeVersion", "versionID")) ?? "VA00001",
                productID = nextProductID,
                attributeID = "A00001",
                attributeValue = txtProductDescription.Text,
                recordDate = DateTime.Now,
                recordPerson = ((Staff)Program.user).staffID,
                versionStatus = "Submitted"
            });

            List<ProductTeam> teamList = new List<ProductTeam>();
            ComboBox[] relevantCombox = [cbProductSponsor, cbLeader, cbRnD, cbDesign, cbEngineering, cbSnM];
            foreach (ComboBox cb in relevantCombox)
            {

                string role = "";

                if (cb == cbProductSponsor)
                {
                    role = "ProductSponsor";
                    if (rbInternal.Checked && cbProductSponsor.Text == cbLeader.Text)
                    {
                        continue;
                    }
                }
                else if (cb == cbLeader)
                {
                    role = "ProductLeader";
                }
                else if (cb == cbRnD)
                {
                    role = "RnDLeader";
                }
                else if (cb == cbDesign)
                {
                    role = "DesignLeader";
                }
                else if (cb == cbEngineering)
                {
                    role = "EngineeringLeader";
                }
                else if (cb == cbSnM)
                {
                    role = "SnMLeader";
                }

                teamList.Add(new ProductTeam
                {
                    productID = nextProductID,
                    personID = cb.SelectedValue?.ToString(),
                    role = role
                });

            }

            string result = await APIController.ApiRequest("POST", "/Common/InsertData/Product", Helper.ToDictionaryList(productList));
            string result2 = await APIController.ApiRequest("POST", "/Common/InsertData/ProductAttributeVersion", Helper.ToDictionaryList(productAttributeVersionList));
            string result3 = await APIController.ApiRequest("POST", "/Common/InsertData/ProductTeam", Helper.ToDictionaryList(teamList));

            try
            {
                if (int.Parse(result) > 0 && int.Parse(result2) > 0 && int.Parse(result3) > 0)
                {
                    MessageBox.Show("Product created successfully!");
                    PanelController.openForm(Program.homeForm.panelRight, new frmPSSMain());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PanelController.openForm(Program.homeForm.panelRight, new frmPSSMain());
        }

    }
}
