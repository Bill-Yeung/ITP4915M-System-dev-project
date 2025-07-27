using Client.Controllers;
using EntityModels;
using Newtonsoft.Json;
using Client.Common;
using System.Threading.Tasks;

namespace Client.Views.RnD.PSS
{
    public partial class frmApproveProduct : Form
    {

        private Product product { get; set; }

        public frmApproveProduct(Product product)
        {
            InitializeComponent();
            this.product = product;
        }

        private async void frmApproveProduct_Load(object sender, EventArgs e)
        {

            // Load product
            txtProductID.Text = product.productID;
            txtProductName.Text = product.productName;
            txtProductType.Text = product.productType;
            txtProductCategory.Text = product.productCategory;
            txtVersion.Text = product.productVersion;
            txtProductInherited.Text = product.parentProductID;

            // Load product attribute
            var productKey = new
            {
                productID = product.productID,
                attributeID = "A00001"
            };
            string productAttributeString = await APIController.ApiRequest("POST", "/Common/GetData/ProductAttributeVersion/false", Helper.ToDictionary(productKey));
            List<ProductAttributeVersion> productAttributeList = JsonConvert.DeserializeObject<List<ProductAttributeVersion>>(productAttributeString);
            txtProductDescription.Text = productAttributeList[0].attributeValue;

            // Load product team
            var teamKey = new
            {
                productID = product.productID
            };
            string productTeamString = await APIController.ApiRequest("POST", "/Common/GetData/ProductTeam/false", Helper.ToDictionary(teamKey));
            List<ProductTeam> productTeamList = JsonConvert.DeserializeObject<List<ProductTeam>>(productTeamString);

            string staffString = await APIController.ApiRequest("POST", "/Common/GetData/Staff/true", null);
            List<Staff> staffList = JsonConvert.DeserializeObject<List<Staff>>(staffString);

            string customerString = await APIController.ApiRequest("POST", "/Common/GetData/Customer/true", null);
            List<Customer> customerList = JsonConvert.DeserializeObject<List<Customer>>(customerString);

            foreach (ProductTeam item in productTeamList)
            {
                var staffMatch = staffList.FirstOrDefault(s => s.staffID == item.personID);
                var customerMatch = customerList.FirstOrDefault(c => c.customerID == item.personID);

                if (staffMatch != null)
                {
                    item.personName = staffMatch.staffName;
                } 
                else if (customerMatch != null)
                {
                    item.personName = customerMatch.customerName;
                }

            }

            foreach (ProductTeam item in productTeamList)
            {
                switch(item.role)
                {
                    case "ProductSponsor":
                        txtProductSponsor.Text = item.personName;
                        break;
                    case "ProductLeader":
                        txtLeader.Text = item.personName;
                        break;
                    case "RnDLeader":
                        txtRnD.Text = item.personName;
                        break;
                    case "DesignLeader":
                        txtDesign.Text = item.personName;
                        break;
                    case "EngineeringLeader":
                        txtEngineering.Text = item.personName;
                        break;
                    case "SnMLeader":
                        txtSnM.Text = item.personName;
                        break;
                    default:
                        break;
                }
            }

            if (string.IsNullOrEmpty(txtProductSponsor.Text))
            {
                txtProductSponsor.Text = txtLeader.Text;
            }

        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {

            var user = (Staff)Program.user;
            var productTeamKey = new
            {
                productID = product.productID,
                role = "ProductLeader"
            };
            string leaderString = await APIController.ApiRequest("POST", "/Common/GetData/ProductTeam/false", productTeamKey);
            List<ProductTeam> leaderList = JsonConvert.DeserializeObject<List<ProductTeam>>(leaderString);

            if (leaderList.Count != 0 && leaderList[0].personID == user.staffID)
            {
                List<Product> productKey = new List<Product>();
                productKey.Add(new Product
                {
                    productID = product.productID
                });

                List<Product> productData = new List<Product>();
                productData.Add(new Product
                {
                    productStatus = "Approved"
                });

                UpdateDataRequest productRequest = new UpdateDataRequest();
                productRequest.KeyList = Helper.ToDictionaryList(productKey);
                productRequest.DataList = Helper.ToDictionaryList(productData);

                string result = await APIController.ApiRequest("POST", "/Common/UpdateData/Product", productRequest);

                List<ProductAttributeVersion> productAttributeVersionKey = new List<ProductAttributeVersion>();
                productAttributeVersionKey.Add(new ProductAttributeVersion
                {
                    productID = product.productID,
                    attributeID = "A00001"
                });

                List<ProductAttributeVersion> productAttributeVersionData = new List<ProductAttributeVersion>();
                productAttributeVersionData.Add(new ProductAttributeVersion
                {
                    versionStatus = "Approved"
                });

                UpdateDataRequest productAttributeVersionRequest = new UpdateDataRequest();
                productAttributeVersionRequest.KeyList = Helper.ToDictionaryList(productAttributeVersionKey);
                productAttributeVersionRequest.DataList = Helper.ToDictionaryList(productAttributeVersionData);

                string result2 = await APIController.ApiRequest("POST", "/Common/UpdateData/ProductAttributeVersion", productAttributeVersionRequest);

                try
                {
                    if (int.Parse(result) > 0 && int.Parse(result2) > 0)
                    {
                        MessageBox.Show("Product approved successfully!");
                        PanelController.openForm(Program.homeForm.panelRight, new frmPSSMain());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("You are not the leader of this product!");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PanelController.openForm(Program.homeForm.panelRight, new frmPSSMain());
        }

    }

}
