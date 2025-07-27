using Client.Common;
using Client.Controllers;
using EntityModels;
using Newtonsoft.Json;
using ScottPlot.MultiplotLayouts;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.IO;
using EntityFile = EntityModels.File;
using System.Net.Http.Headers;

namespace Client.Views.RnD.PSS
{
    public partial class frmEditProduct : Form
    {

        private Product product { get; set; }
        private List<RawMaterial> rawMaterialList { get; set; }
        private List<ProductAttributeVersion> productAttributeList { get; set; }
        private List<ProductMaterialVersion> productMaterialList { get; set; }
        private List<Staff> staffList { get; set; }
        private List<Customer> customerList { get; set; }
        private List<ProductTeam> teamList { get; set; }
        private TabPage currentPage { get; set; }

        public frmEditProduct(Product product, List<ProductAttributeVersion> productAttributeList)
        {
            InitializeComponent();
            this.product = product;
            this.productAttributeList = productAttributeList.OrderByDescending(p => p.versionID).ToList();
        }

        private async void frmEditProduct_Load(object sender, EventArgs e)
        {

            // Load product
            txtProductID.Text = product.productID;
            txtProductName.Text = product.productName;

            // Load staff, customer, team, materials, product material lists
            string result = await APIController.ApiRequest("POST", "/Common/GetData/Staff/true", null);
            staffList = JsonConvert.DeserializeObject<List<Staff>>(result);

            string result5 = await APIController.ApiRequest("POST", "/Common/GetData/Customer/true", null);
            customerList = JsonConvert.DeserializeObject<List<Customer>>(result5);

            var productKey = new
            {
                productID = product.productID
            };

            string result2 = await APIController.ApiRequest("POST", "/Common/GetData/ProductTeam/false", Helper.ToDictionary(productKey));
            teamList = JsonConvert.DeserializeObject<List<ProductTeam>>(result2);
            string result3 = await APIController.ApiRequest("POST", "/Common/GetData/ProductMaterialVersion/false", Helper.ToDictionary(productKey));
            productMaterialList = (JsonConvert.DeserializeObject<List<ProductMaterialVersion>>(result3)).OrderByDescending(p => p.versionID).ToList() ?? new List<ProductMaterialVersion>();

            string result4 = await APIController.ApiRequest("POST", "/Common/GetData/RawMaterial/true", null);
            rawMaterialList = JsonConvert.DeserializeObject<List<RawMaterial>>(result4);

            // Set basic tab
            currentPage = tabBasic;
            TabBasic_Initialization();

        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            if (currentPage != null && currentPage != tabControl.SelectedTab)
            {
                foreach (Control control in currentPage.Controls)
                {
                    control.Dispose();
                }
                currentPage.Controls.Clear();
            }
            currentPage = tabControl.SelectedTab;

            switch(tabControl.SelectedTab.Name)
            {
                case "tabBasic":
                    TabBasic_Initialization();
                    break;
                case "tabProductTeam":
                    TabProductTeam_Initialization();
                    break;
                case "tabProductDetails":
                    TabProductDetails_Initialization();
                    break;
                case "tabManufacturing":
                    TabManufacturing_Initialization();
                    break;
                case "tabPackaging":
                    TabPackaging_Initialization();
                    break;
                case "tabVersionHistory":
                    TabHistory_Initialization();
                    break;
            }

        }

        private async void TabBasic_Initialization()
        {

            // Scroll panel

            var scroll = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            tabBasic.Controls.Add(scroll);

            // Basic table setting

            var tableBasic = new TableLayoutPanel();
            tableBasic.ColumnCount = 1;
            tableBasic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableBasic.Dock = DockStyle.Top;
            tableBasic.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            tableBasic.Location = new Point(4, 4);
            tableBasic.Margin = Padding.Empty;
            tableBasic.Name = "tableBasic";
            tableBasic.RowCount = 1;
            tableBasic.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableBasic.AutoSize = true;
            tableBasic.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableBasic.Size = new Size(996, 410);
            tableBasic.TabIndex = 0;
            scroll.Controls.Add(tableBasic);

            // Table structure

            tableBasic.RowCount = 25;
            tableBasic.RowStyles.Clear();
            for (int i = 0; i < tableBasic.RowCount; i++)
            {
                int height = (i == 7 || i == 13) ? 200 : 30;
                tableBasic.RowStyles.Add(new RowStyle(SizeType.Absolute, height));
            }

            tableBasic.ColumnCount = 8;
            tableBasic.ColumnStyles.Clear();
            tableBasic.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
            for (int i = 1; i < 7; i++)
            {
                tableBasic.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            }
            tableBasic.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));

            // Header
            createHeaderRow(tableBasic, new string[] { "", "Latest Value", "Last Edit Time", "Last Edit Person", "Suggested Edit", "Action" }, 1);

            /* Data sections */

            // Product ID
            createNonEditRow(tableBasic, "Product ID:", product.productID, 3);

            // Product Name
            createStandardLabelRow(tableBasic, "Product Name:", "ProductAttributeVersion", product.productName, "A00005", "ProductLeader", 5, 30);

            // Product Image
            await createStandardPictureRow(tableBasic, "Product Image:", "ProductAttributeVersion", "A00002", "ProductLeader", 7);

            // Product Type
            createNonEditRow(tableBasic, "Product Type:", product.productType, 9);

            // Product Category
            createNonEditRow(tableBasic, "Product Category:", product.productCategory, 11);

            // Product Description
            createStandardLabelRow(tableBasic, "Product Description:", "ProductAttributeVersion", 
                getLatestApprovedVersion("ProductAttributeVersion", "value", "A00001"), "A00001", "ProductLeader", 13, 200);

            // Product Version
            createNonEditRow(tableBasic, "Product Version:", product.productVersion, 15);

            // Product Inherited
            createNonEditRow(tableBasic, "Product Inherited:", product.parentProductID, 17);

            // Product Price
            createStandardLabelRow(tableBasic, "Product Price:", "ProductAttributeVersion", 
                getLatestApprovedVersion("ProductAttributeVersion", "value", "A00003"), "A00003", "ProductLeader", 19, 30);

            // Minimum Order Quantity
            createStandardLabelRow(tableBasic, "Minimum Order Qty:", "ProductAttributeVersion", 
                getLatestApprovedVersion("ProductAttributeVersion", "value", "A00004"), "A00004", "ProductLeader", 21, 30);

            // Central settings
            foreach (Control ctrl in tableBasic.Controls)
            {
                ctrl.Margin = new Padding(0);
                ctrl.Padding = new Padding(0);
            }
            tableBasic.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tabBasic.AutoScroll = true;

        }

        private async void TabProductTeam_Initialization()
        {

            // Scroll panel

            var scroll = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            tabProductTeam.Controls.Add(scroll);

            // Basic table setting

            var tableProductTeam = new TableLayoutPanel();
            tableProductTeam.ColumnCount = 1;
            tableProductTeam.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableProductTeam.Dock = DockStyle.Top;
            tableProductTeam.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            tableProductTeam.Location = new Point(4, 4);
            tableProductTeam.Margin = Padding.Empty;
            tableProductTeam.Name = "tableProductTeam";
            tableProductTeam.RowCount = 1;
            tableProductTeam.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableProductTeam.AutoSize = true;
            tableProductTeam.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableProductTeam.Size = new Size(996, 410);
            tableProductTeam.TabIndex = 0;
            scroll.Controls.Add(tableProductTeam);

            // Table structure

            tableProductTeam.RowCount = 3;
            tableProductTeam.RowStyles.Clear();
            for (int i = 0; i < tableProductTeam.RowCount; i++)
            {
                tableProductTeam.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            }

            tableProductTeam.ColumnCount = 8;
            tableProductTeam.ColumnStyles.Clear();
            tableProductTeam.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
            for (int i = 1; i < 7; i++)
            {
                tableProductTeam.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            }
            tableProductTeam.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));

            // Header
            createHeaderRow(tableProductTeam, new string[] { "", "Latest Value", "Last Edit Time", "Last Edit Person", "Suggested Edit", "Action" }, 1);

            /* Data */
            foreach (var person in teamList)
            {
                tableProductTeam.RowCount += 2;
                tableProductTeam.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                tableProductTeam.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                createNonEditRow(tableProductTeam, person.role, 
                    (staffList.Find(p => p.staffID == person.personID))?.staffName ?? (customerList.Find(p => p.customerID == person.personID))?.customerName, 
                    tableProductTeam.RowCount - 1);
            }

            // Central settings
            foreach (Control ctrl in tableProductTeam.Controls)
            {
                ctrl.Margin = new Padding(0);
                ctrl.Padding = new Padding(0);
            }
            tableProductTeam.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tableProductTeam.AutoScroll = true;

        }

        private async void TabProductDetails_Initialization()
        {

            // Scroll panel

            var scroll = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            tabProductDetails.Controls.Add(scroll);

            // Basic table setting

            var tableProductDetails = new TableLayoutPanel();
            tableProductDetails.ColumnCount = 1;
            tableProductDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableProductDetails.Dock = DockStyle.Top;
            tableProductDetails.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            tableProductDetails.Location = new Point(4, 4);
            tableProductDetails.Margin = Padding.Empty;
            tableProductDetails.Name = "tableProductDetails";
            tableProductDetails.RowCount = 1;
            tableProductDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableProductDetails.AutoSize = true;
            tableProductDetails.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableProductDetails.Size = new Size(996, 410);
            tableProductDetails.TabIndex = 0;
            scroll.Controls.Add(tableProductDetails);

            // Table structure

            tableProductDetails.RowCount = 39;
            tableProductDetails.RowStyles.Clear();
            for (int i = 0; i < tableProductDetails.RowCount; i++)
            {
                int height = (i == 25) ? 200 : (i == 13 || i == 15 || i == 17 || i == 19 || i == 21 || i == 23) ? 100 : 30;
                tableProductDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, height));
            }

            tableProductDetails.ColumnCount = 8;
            tableProductDetails.ColumnStyles.Clear();
            tableProductDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
            for (int i = 1; i < 7; i++)
            {
                tableProductDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            }
            tableProductDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));

            // Header
            createHeaderRow(tableProductDetails, new string[] { "", "Latest Value", "Last Edit Time", "Last Edit Person", "Suggested Edit", "Action" }, 1);

            // Dimension

            createStandardLabelRow(tableProductDetails, "Dimension (Length):", "ProductAttributeVersion",
                getLatestApprovedVersion("ProductAttributeVersion", "value", "A00006"), "A00006", "ProductLeader", 3, 30);
            createStandardLabelRow(tableProductDetails, "Dimension (Width):", "ProductAttributeVersion",
                getLatestApprovedVersion("ProductAttributeVersion", "value", "A00007"), "A00007", "ProductLeader", 5, 30);
            createStandardLabelRow(tableProductDetails, "Dimension (Height):", "ProductAttributeVersion",
                getLatestApprovedVersion("ProductAttributeVersion", "value", "A00008"), "A00008", "ProductLeader", 7, 30);
            createStandardLabelRow(tableProductDetails, "Dimension (Weight):", "ProductAttributeVersion",
                getLatestApprovedVersion("ProductAttributeVersion", "value", "A00025"), "A00025", "ProductLeader", 9, 30);

            // Age Range
            createStandardLabelRow(tableProductDetails, "Age Range:", "ProductAttributeVersion",
                getLatestApprovedVersion("ProductAttributeVersion", "value", "A00009"), "A00009", "ProductLeader", 11, 30);

            // Product Features
            createStandardLabelRow(tableProductDetails, "Product Features:", "ProductAttributeVersion",
                getLatestApprovedVersion("ProductAttributeVersion", "value", "A00010"), "A00010", "ProductLeader", 13, 100);

            // Play Features
            createStandardLabelRow(tableProductDetails, "Play Features:", "ProductAttributeVersion",
                getLatestApprovedVersion("ProductAttributeVersion", "value", "A00011"), "A00011", "ProductLeader", 15, 100);

            // Color Options
            createStandardLabelRow(tableProductDetails, "Color Options:", "ProductAttributeVersion",
                getLatestApprovedVersion("ProductAttributeVersion", "value", "A00012"), "A00012", "ProductLeader", 17, 100);

            // Language Options
            createStandardLabelRow(tableProductDetails, "Language Options:", "ProductAttributeVersion",
                getLatestApprovedVersion("ProductAttributeVersion", "value", "A00013"), "A00013", "ProductLeader", 19, 100);

            // Battery Required
            createStandardLabelRow(tableProductDetails, "Battery Required:", "ProductAttributeVersion",
                getLatestApprovedVersion("ProductAttributeVersion", "value", "A00014"), "A00014", "ProductLeader", 21, 100);

            // Safety Warnings
            createStandardLabelRow(tableProductDetails, "Safety Warnings:", "ProductAttributeVersion",
                getLatestApprovedVersion("ProductAttributeVersion", "value", "A00015"), "A00015", "ProductLeader", 23, 100);

            // Design Prototype
            await createStandardPictureRow(tableProductDetails, "Design Prototype:", "ProductAttributeVersion", "A00016", "ProductLeader", 25);

            // Production Manuals
            await createStandardDocumentRow(tableProductDetails, "Production Manuals:", "ProductAttributeVersion", "A00017", "ProductLeader", 27);

            // Performance Criteria
            await createStandardDocumentRow(tableProductDetails, "Performance Criteria:", "ProductAttributeVersion", "A00018", "ProductLeader", 29);

            // Quality Standards
            await createStandardDocumentRow(tableProductDetails, "Quality Standards:", "ProductAttributeVersion", "A00019", "ProductLeader", 31);

            // Testing Procedures
            await createStandardDocumentRow(tableProductDetails, "Testing Procedures:", "ProductAttributeVersion", "A00020", "ProductLeader", 33);

            // Compliance Checklist
            await createStandardDocumentRow(tableProductDetails, "Compliance Checklist:", "ProductAttributeVersion", "A00021", "ProductLeader", 35);

            // First Compliance Report
            await createStandardDocumentRow(tableProductDetails, "First Compliance Report:", "ProductAttributeVersion", "A00022", "ProductLeader", 37);

            // Central settings
            foreach (Control ctrl in tableProductDetails.Controls)
            {
                ctrl.Margin = new Padding(0);
                ctrl.Padding = new Padding(0);
            }
            tableProductDetails.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tableProductDetails.AutoScroll = true;

        }

        private async void TabManufacturing_Initialization()
        {

            // Scroll panel

            var scroll = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            tabManufacturing.Controls.Add(scroll);

            // Basic table setting

            var tableManufacturing = new TableLayoutPanel();
            tableManufacturing.ColumnCount = 1;
            tableManufacturing.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableManufacturing.Dock = DockStyle.Top;
            tableManufacturing.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            tableManufacturing.Location = new Point(4, 4);
            tableManufacturing.Margin = Padding.Empty;
            tableManufacturing.Name = "tableManufacturing";
            tableManufacturing.RowCount = 1;
            tableManufacturing.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableManufacturing.AutoSize = true;
            tableManufacturing.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableManufacturing.Size = new Size(996, 410);
            tableManufacturing.TabIndex = 0;
            scroll.Controls.Add(tableManufacturing);

            // Table structure

            tableManufacturing.RowCount = 4;
            tableManufacturing.RowStyles.Clear();
            for (int i = 0; i < tableManufacturing.RowCount; i++)
            {
                tableManufacturing.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            }

            tableManufacturing.ColumnCount = 8;
            tableManufacturing.ColumnStyles.Clear();
            tableManufacturing.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
            for (int i = 1; i < 7; i++)
            {
                tableManufacturing.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            }
            tableManufacturing.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));

            // Button to add material to the list => become submitted status
            var btnAddMaterial = new Button
            {
                Text = "Add Material",
                BackColor = Color.Moccasin,
                Width = 120,
                Height = 30,
                Margin = new Padding(5, 0, 5, 0),
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };

            btnAddMaterial.Click += async (sender, e) =>
            {
                using (frmAddMaterial dialog = new frmAddMaterial()) 
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {

                        var selectedMaterialID = dialog.selectedMaterialID;
                        var selectedMaterialName = dialog.selectedMaterialName;
                        var selectedMaterialQuantity = dialog.selectedMaterialQuantity;

                        // Add material to the list and database
                        List<ProductMaterialVersion> productMaterialVersionList = new List<ProductMaterialVersion>();
                        productMaterialVersionList.Add(new ProductMaterialVersion
                        {
                            versionID = (await Helper.GenerateNextId("ProductMaterialVersion", "versionID")) ?? "VM00001",
                            productID = product.productID,
                            materialID = selectedMaterialID,
                            quantity = selectedMaterialQuantity,
                            recordDate = DateTime.Now,
                            recordPerson = ((Staff)Program.user).staffID,
                            versionStatus = "Submitted"
                        });

                        string result = await APIController.ApiRequest("POST", "/Common/InsertData/ProductMaterialVersion", Helper.ToDictionaryList(productMaterialVersionList));

                        try
                        {
                            if (int.Parse(result) > 0)
                            {
                                productMaterialList.InsertRange(0, productMaterialVersionList);

                                // Add new lines to UI
                                tableManufacturing.RowCount += 2;
                                tableManufacturing.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                                tableManufacturing.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                                createStandardLabelRow(tableManufacturing, selectedMaterialName, "ProductMaterialVersion", 
                                    getLatestApprovedVersion("ProductMaterialVersion", "value", selectedMaterialID), selectedMaterialID, "ProductLeader", tableManufacturing.RowCount - 1, 40);

                                foreach (Control ctrl in tableManufacturing.Controls)
                                {
                                    ctrl.Margin = new Padding(0);
                                    ctrl.Padding = new Padding(0);
                                }
                                tableManufacturing.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
                                tableManufacturing.AutoScroll = true;

                                MessageBox.Show("Material inserted successfully!");
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
            };

            tableManufacturing.Controls.Add(btnAddMaterial, 1, 1);

            // Header
            createHeaderRow(tableManufacturing, new string[] { "", "Latest Value", "Last Edit Time", "Last Edit Person", "Suggested Edit", "Action" }, 3);

            /* Data sections */
            var materialIDs = productMaterialList.Select(x => x.materialID).Distinct().ToList();
            foreach (var materialID in materialIDs)
            {
                tableManufacturing.RowCount += 2;
                tableManufacturing.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                tableManufacturing.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                createStandardLabelRow(tableManufacturing, (rawMaterialList.Find(p => p.materialID == materialID).materialName) + " (" + (rawMaterialList.Find(p => p.materialID == materialID).unit) + ")",
                    "ProductMaterialVersion", getLatestApprovedVersion("ProductMaterialVersion", "value", materialID), materialID, "ProductLeader", tableManufacturing.RowCount - 1, 40);
            }

            // Central settings
            foreach (Control ctrl in tableManufacturing.Controls)
            {
                ctrl.Margin = new Padding(0);
                ctrl.Padding = new Padding(0);
            }
            tableManufacturing.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tableManufacturing.AutoScroll = true;

        }

        private async void TabPackaging_Initialization()
        {

            // Scroll panel

            var scroll = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            tabPackaging.Controls.Add(scroll);

            // Basic table setting

            var tablePackaging = new TableLayoutPanel();
            tablePackaging.ColumnCount = 1;
            tablePackaging.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablePackaging.Dock = DockStyle.Top;
            tablePackaging.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            tablePackaging.Location = new Point(4, 4);
            tablePackaging.Margin = Padding.Empty;
            tablePackaging.Name = "tablePackaging";
            tablePackaging.RowCount = 1;
            tablePackaging.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablePackaging.AutoSize = true;
            tablePackaging.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tablePackaging.Size = new Size(996, 410);
            tablePackaging.TabIndex = 0;
            scroll.Controls.Add(tablePackaging);

            // Table structure

            tablePackaging.RowCount = 7;
            tablePackaging.RowStyles.Clear();
            for (int i = 0; i < tablePackaging.RowCount; i++)
            {
                int height = (i == 3) ? 100 : 30;
                tablePackaging.RowStyles.Add(new RowStyle(SizeType.Absolute, height));
            }

            tablePackaging.ColumnCount = 8;
            tablePackaging.ColumnStyles.Clear();
            tablePackaging.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
            for (int i = 1; i < 7; i++)
            {
                tablePackaging.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            }
            tablePackaging.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));

            // Header
            createHeaderRow(tablePackaging, new string[] { "", "Latest Value", "Last Edit Time", "Last Edit Person", "Suggested Edit", "Action" }, 1);

            // Product Label
            createStandardLabelRow(tablePackaging, "Product Label:", "ProductAttributeVersion",
                getLatestApprovedVersion("ProductAttributeVersion", "value", "A00023"), "A00023", "ProductLeader", 3, 100);

            // Storage Guidelines
            await createStandardDocumentRow(tablePackaging, "Storage Guidelines:", "ProductAttributeVersion", "A00024", "ProductLeader", 5);

            // Central settings
            foreach (Control ctrl in tablePackaging.Controls)
            {
                ctrl.Margin = new Padding(0);
                ctrl.Padding = new Padding(0);
            }
            tablePackaging.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tablePackaging.AutoScroll = true;

        }

        private async void TabHistory_Initialization()
        {
            frmVersionHistory form = new frmVersionHistory(product.productID);
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            tabVersionHistory.Controls.Add(form);
            form.Show();
        }

        public string getLatestApprovedVersion(string tableName, string column, string attributeID)
        {

            string result = null;
            
            if (tableName == "ProductMaterialVersion")
            {

                ProductMaterialVersion? latest = null;
                foreach (var p in productMaterialList)
                {

                    if (p.materialID != attributeID || p.versionStatus != "Approved")
                    {
                        continue;
                    }

                    latest = p;
                    break;

                }

                if (latest != null)
                {

                    switch (column)
                    {
                        case "value":
                            result = latest.quantity.ToString();
                            break;
                        case "recordDate":
                            result = String.Format("{0:yyyy-MM-dd}", latest.recordDate);
                            break;
                        case "recordPerson":
                            result = latest.recordPerson;
                            break;
                        default:
                            throw new Exception();
                            break;
                    }

                }

            } 
            else
            {

                ProductAttributeVersion? latest = null;
                foreach (var p in productAttributeList)
                {

                    if (p.attributeID != attributeID || p.versionStatus != "Approved")
                    {
                        continue;
                    }

                    latest = p;
                    break;

                }

                if (latest != null)
                {

                    switch (column)
                    {
                        case "value":
                            result = latest.attributeValue;
                            break;
                        case "file":
                            result = latest.fileID;
                            break;
                        case "recordDate":
                            result = String.Format("{0:yyyy-MM-dd}", latest.recordDate);
                            break;
                        case "recordPerson":
                            result = latest.recordPerson;
                            break;
                        default:
                            throw new Exception();
                            break;
                    }

                }

                if (attributeID == "A00005" && string.IsNullOrEmpty(result))
                {
                    result = getFirstApprovedAttributeVersion(column, "A00001");
                }

            }

            return (string.IsNullOrEmpty(result) ? (column == "file" ? null : "NOT SET") : result);

        }

        public List<string> getLatestSubmittedVersion(string tableName, string column, string attributeID)
        {

            string result = null;

            if (tableName == "ProductMaterialVersion")
            {

                ProductMaterialVersion? latest = null;
                foreach (var p in productMaterialList)
                {

                    if (p.materialID == attributeID && p.versionStatus == "Deleted")
                    {
                        break;
                    }

                    if (p.materialID != attributeID || p.versionStatus != "Submitted")
                    {
                        continue;
                    }

                    latest = p;
                    break;

                }

                if (latest != null)
                {

                    switch (column)
                    {
                        case "value":
                            result = latest.quantity.ToString();
                            break;
                        case "recordDate":
                            result = String.Format("{0:yyyy-MM-dd}", latest.recordDate);
                            break;
                        case "recordPerson":
                            result = latest.recordPerson;
                            break;
                        default:
                            throw new Exception();
                            break;
                    }

                }

                return new List<string?> { string.IsNullOrEmpty(result) ? "" : result, latest != null ? latest.versionID : null };

            } 
            else
            {

                ProductAttributeVersion? latest = null;
                foreach (var p in productAttributeList)
                {

                    if (p.attributeID == attributeID && p.versionStatus == "Deleted")
                    {
                        break;
                    }

                    if (p.attributeID != attributeID || p.versionStatus != "Submitted")
                    {
                        continue;
                    }

                    latest = p;
                    break;

                }

                if (latest != null)
                {

                    switch (column)
                    {
                        case "value":
                            result = latest.attributeValue;
                            break;
                        case "file":
                            result = latest.fileID;
                            break;
                        case "recordDate":
                            result = String.Format("{0:yyyy-MM-dd}", latest.recordDate);
                            break;
                        case "recordPerson":
                            result = latest.recordPerson;
                            break;
                        default:
                            throw new Exception();
                            break;
                    }

                }

                return new List<string?> { string.IsNullOrEmpty(result) ? "" : result, latest != null ? latest.versionID : null };

            }

        }

        public string getFirstApprovedAttributeVersion(string column, string attributeID)
        {

            List<ProductAttributeVersion> reversedList = new List<ProductAttributeVersion>(productAttributeList);
            reversedList.Reverse();

            ProductAttributeVersion? first = null;
            string result = null;

            foreach (var p in reversedList)
            {

                if (p.attributeID != attributeID || p.versionStatus != "Approved")
                {
                    continue;
                }

                first = p;
                break;
                
            }

            if (first != null)
            {

                switch (column)
                {
                    case "value":
                        result = first.attributeValue;
                        break;
                    case "file":
                        result = first.fileID;
                        break;
                    case "recordDate":
                        result = String.Format("{0:yyyy-MM-dd}", first.recordDate);
                        break;
                    case "recordPerson":
                        result = first.recordPerson;
                        break;
                    default:
                        throw new Exception();
                        break;
                }

            }

            return string.IsNullOrEmpty(result) ? "NOT SET" : result;

        }

        public Label createNonEditCell()
        {
            return new Label
            {
                BackColor = Color.Gray,
                Dock = DockStyle.Fill
            };
        }

        public Label createStandardHeader(string text)
        {
            return new Label
            {
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.LightPink,
                Dock = DockStyle.Fill
            };
        }

        public Label createStandardLabel(string text)
        {
            return new Label
            {
                Text = text,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.White,
                BackColor = Color.Gray,
                Dock = DockStyle.Fill
            };
        }

        public void createHeaderRow(TableLayoutPanel panel, string[] header, int row)
        {

            panel.Controls.Add(createStandardHeader(header[0]), 1, row);
            panel.Controls.Add(createStandardHeader(header[1]), 2, row);
            panel.Controls.Add(createStandardHeader(header[2]), 3, row);
            panel.Controls.Add(createStandardHeader(header[3]), 4, row);
            panel.Controls.Add(createStandardHeader(header[4]), 5, row);
            panel.Controls.Add(createStandardHeader(header[5]), 6, row);

        }

        public void createNonEditRow(TableLayoutPanel panel, string header, string value, int row)
        {

            Label lblAttributeName = new Label
            {
                Text = header,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };

            panel.Controls.Add(lblAttributeName, 1, row);

            Label lblAttributeLatest = createStandardLabel(value);
            panel.Controls.Add(lblAttributeLatest, 2, row);

            panel.Controls.Add(createNonEditCell(), 3, row);
            panel.Controls.Add(createNonEditCell(), 4, row);
            panel.Controls.Add(createNonEditCell(), 5, row);
            panel.Controls.Add(createNonEditCell(), 6, row);

        }

        public void createStandardLabelRow(TableLayoutPanel panel, string header, string tableName, string value, string attributeID, string approvalRole, int row, int height)
        {

            Label lblAttributeName = new Label
            {
                Text = header,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };

            panel.Controls.Add(lblAttributeName, 1, row);

            Label lblAttributeNameLatest = createStandardLabel(value);
            panel.Controls.Add(lblAttributeNameLatest, 2, row);

            Label lblAttributeNameEditTime = createStandardLabel(getLatestApprovedVersion(tableName, "recordDate", attributeID));
            panel.Controls.Add(lblAttributeNameEditTime, 3, row);

            Label lblAttributeNameEditPerson = createStandardLabel(staffList.Find(p => p.staffID == getLatestApprovedVersion(tableName, "recordPerson", attributeID))?.staffName ?? "NOT SET");
            panel.Controls.Add(lblAttributeNameEditPerson, 4, row);

            var suggestedEditControl = createSuggestEditTextPanel(tableName, "value", attributeID, height);
            panel.Controls.Add((FlowLayoutPanel)suggestedEditControl[0], 5, row);

            panel.Controls.Add(createTextActionButtons(lblAttributeNameLatest, lblAttributeNameEditTime, lblAttributeNameEditPerson,
                (TextBox)suggestedEditControl[1], (Button)suggestedEditControl[2], tableName,
                "value", attributeID, approvalRole), 6, row);

        }

        public async Task createStandardPictureRow(TableLayoutPanel panel, string header, string tableName, string attributeID, string approvalRole, int row)
        {

            Label lblAttributeName = new Label
            {
                Text = header,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };
            
            panel.Controls.Add(lblAttributeName, 1, row);

            PictureBox pbProductImageLatest = new PictureBox
            {
                BackColor = Color.Gray,
                Dock = DockStyle.Fill
            };

            var fileKeyValue = getLatestApprovedVersion("ProductAttributeVersion", "file", attributeID);
            if (fileKeyValue != null)
            {

                var fileKey = new
                {
                    fileID = fileKeyValue
                };

                string result = await APIController.ApiRequest("POST", "/Common/GetData/File/false", Helper.ToDictionary(fileKey));
                List<EntityFile> file = JsonConvert.DeserializeObject<List<EntityFile>>(result);

                pbProductImageLatest.SizeMode = PictureBoxSizeMode.Zoom;
                pbProductImageLatest.ImageLocation = String.Format("{0}/{1}", ConfigurationManager.AppSettings["FileDirectory"], file[0].filePath);
                pbProductImageLatest.LoadAsync();

            }

            panel.Controls.Add(pbProductImageLatest, 2, row);

            Label lblAttributeNameEditTime = createStandardLabel(getLatestApprovedVersion("ProductAttributeVersion", "recordDate", attributeID));
            panel.Controls.Add(lblAttributeNameEditTime, 3, row);

            Label lblAttributeNameEditPerson = createStandardLabel(staffList.Find(p => p.staffID == getLatestApprovedVersion("ProductAttributeVersion", "recordPerson", attributeID))?.staffName ?? "NOT SET");
            panel.Controls.Add(lblAttributeNameEditPerson, 4, row);

            var suggestedEditControl = await createSuggestEditPicturePanel(tableName, "file", attributeID);
            panel.Controls.Add((FlowLayoutPanel)suggestedEditControl[0], 5, row);

            panel.Controls.Add(createPictureActionButtons(pbProductImageLatest, lblAttributeNameEditTime, lblAttributeNameEditPerson,
                (PictureBox)suggestedEditControl[1], (Button)suggestedEditControl[2], tableName,
                "value", attributeID, approvalRole), 6, row);

        }

        public async Task createStandardDocumentRow(TableLayoutPanel panel, string header, string tableName, string attributeID, string approvalRole, int row)
        {

            Label lblAttributeName = new Label
            {
                Text = header,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };

            panel.Controls.Add(lblAttributeName, 1, row);

            var btnDownload = new Button
            {
                Text = "",
                BackColor = Color.Moccasin,
                Width = 220,
                Height = 30,
                Margin = new Padding(5, 0, 5, 0),
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };

            var fileKeyValue = getLatestApprovedVersion("ProductAttributeVersion", "file", attributeID);
            if (fileKeyValue != null)
            {

                var fileKey = new
                {
                    fileID = fileKeyValue
                };

                string result = await APIController.ApiRequest("POST", "/Common/GetData/File/false", Helper.ToDictionary(fileKey));
                List<EntityFile> file = JsonConvert.DeserializeObject<List<EntityFile>>(result);

                string filePath = String.Format("{0}/{1}", ConfigurationManager.AppSettings["FileDirectory"], file[0].filePath);
                string fileName = file[0].fileName;

                btnDownload.Text = file[0].fileName;
                var fileInfo = new FileDownloadInfo
                {
                    FilePath = filePath,
                    FileName = fileName
                };
                btnDownload.Tag = fileInfo;
                btnDownload.Click += btnDownload_Click;

            }
            panel.Controls.Add(btnDownload, 2, row);

            Label lblAttributeNameEditTime = createStandardLabel(getLatestApprovedVersion("ProductAttributeVersion", "recordDate", attributeID));
            panel.Controls.Add(lblAttributeNameEditTime, 3, row);

            Label lblAttributeNameEditPerson = createStandardLabel(staffList.Find(p => p.staffID == getLatestApprovedVersion("ProductAttributeVersion", "recordPerson", attributeID))?.staffName ?? "NOT SET");
            panel.Controls.Add(lblAttributeNameEditPerson, 4, row);

            var suggestedEditControl = await createSuggestEditDocumentPanel(tableName, "file", attributeID);
            panel.Controls.Add((FlowLayoutPanel)suggestedEditControl[0], 5, row);

            panel.Controls.Add(createDocumentActionButtons(btnDownload, lblAttributeNameEditTime, lblAttributeNameEditPerson,
                (Button)suggestedEditControl[1], (Button)suggestedEditControl[2], tableName,
                "value", attributeID, approvalRole), 6, row);

        }

        public List<Object> createSuggestEditTextPanel(string tableName, string column, string attributeID, int height = 30)
        {
            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(0)
            };

            var txt = new TextBox
            {
                Text = getLatestSubmittedVersion(tableName, column, attributeID)[0],
                Width = 220,
                Multiline = (height == 30) ? false : true,
                Height = height,
                Margin = new Padding(5, 0, 5, 0),
                ReadOnly = true,
                Enabled = false,
                BorderStyle = BorderStyle.FixedSingle
            };

            var btn = new Button
            {
                Text = "X",
                BackColor = Color.Moccasin,
                Width = 40,
                Height = 30,
                Margin = new Padding(5, 0, 5, 0),
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };

            btn.Click += async (sender, e) =>
            {

                if (!string.IsNullOrEmpty(txt.Text))
                {
                    txt.Text = "";
                    var latestVersionID = getLatestSubmittedVersion(tableName, column, attributeID)[1];

                    if (tableName == "ProductMaterialVersion")
                    {

                        // Remove submitted attribute in the database
                        List<ProductMaterialVersion> productMaterialVersionKey = new List<ProductMaterialVersion>();
                        productMaterialVersionKey.Add(new ProductMaterialVersion
                        {
                            versionID = latestVersionID
                        });

                        List<ProductMaterialVersion> productMaterialVersionData = new List<ProductMaterialVersion>();
                        productMaterialVersionData.Add(new ProductMaterialVersion
                        {
                            recordDate = DateTime.Now,
                            recordPerson = ((Staff)Program.user).staffID,
                            versionStatus = "Deleted"
                        });

                        UpdateDataRequest productMaterialVersionRequest = new UpdateDataRequest();
                        productMaterialVersionRequest.KeyList = Helper.ToDictionaryList(productMaterialVersionKey);
                        productMaterialVersionRequest.DataList = Helper.ToDictionaryList(productMaterialVersionData);

                        string result = await APIController.ApiRequest("POST", "/Common/UpdateData/ProductMaterialVersion", productMaterialVersionRequest);

                        try
                        {
                            if (int.Parse(result) > 0)
                            {
                                productMaterialList.Find(p => p.versionID == latestVersionID).versionStatus = "Deleted";
                                MessageBox.Show("Attribute removed successfully!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    } 
                    else
                    {

                        // Remove submitted attribute in the database
                        List<ProductAttributeVersion> productAttributeVersionKey = new List<ProductAttributeVersion>();
                        productAttributeVersionKey.Add(new ProductAttributeVersion
                        {
                            versionID = latestVersionID
                        });

                        List<ProductAttributeVersion> productAttributeVersionData = new List<ProductAttributeVersion>();
                        productAttributeVersionData.Add(new ProductAttributeVersion
                        {
                            recordDate = DateTime.Now,
                            recordPerson = ((Staff)Program.user).staffID,
                            versionStatus = "Deleted"
                        });

                        UpdateDataRequest productAttributeVersionRequest = new UpdateDataRequest();
                        productAttributeVersionRequest.KeyList = Helper.ToDictionaryList(productAttributeVersionKey);
                        productAttributeVersionRequest.DataList = Helper.ToDictionaryList(productAttributeVersionData);

                        string result = await APIController.ApiRequest("POST", "/Common/UpdateData/ProductAttributeVersion", productAttributeVersionRequest);

                        try
                        {
                            if (int.Parse(result) > 0)
                            {
                                productAttributeList.Find(p => p.versionID == latestVersionID).versionStatus = "Deleted";
                                MessageBox.Show("Attribute removed successfully!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }

                }

            };

            panel.Controls.Add(txt);
            panel.Controls.Add(btn);

            return new List<Object> { panel, txt, btn };

        }

        public async Task<List<Object>> createSuggestEditPicturePanel(string tableName, string column, string attributeID)
        {
            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(0)
            }; 

            var pb = new PictureBox
            {
                Width = 220,
                Height = 200,
                Margin = new Padding(5, 0, 5, 0),
                BorderStyle = BorderStyle.FixedSingle
            };

            var fileKeyValue = getLatestSubmittedVersion(tableName, column, attributeID)[0];
            if (fileKeyValue != "")
            {

                var fileKey = new
                {
                    fileID = fileKeyValue
                };

                string result = await APIController.ApiRequest("POST", "/Common/GetData/File/false", Helper.ToDictionary(fileKey));
                List<EntityFile> file = JsonConvert.DeserializeObject<List<EntityFile>>(result);

                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.ImageLocation = String.Format("{0}/{1}", ConfigurationManager.AppSettings["FileDirectory"], file[0].filePath);
                pb.LoadAsync();

            }

            var btn = new Button
            {
                Text = "X",
                BackColor = Color.Moccasin,
                Width = 40,
                Height = 30,
                Margin = new Padding(5, 0, 5, 0),
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };

            btn.Click += async (sender, e) =>
            {

                if (pb.Image != null)
                {

                    pb.Image.Dispose();
                    pb.Image = null;
                    var latestVersionID = getLatestSubmittedVersion(tableName, column, attributeID)[1];

                    if (tableName == "ProductMaterialVersion")
                    {

                        // Remove submitted attribute in the database
                        List<ProductMaterialVersion> productMaterialVersionKey = new List<ProductMaterialVersion>();
                        productMaterialVersionKey.Add(new ProductMaterialVersion
                        {
                            versionID = latestVersionID
                        });

                        List<ProductMaterialVersion> productMaterialVersionData = new List<ProductMaterialVersion>();
                        productMaterialVersionData.Add(new ProductMaterialVersion
                        {
                            recordDate = DateTime.Now,
                            recordPerson = ((Staff)Program.user).staffID,
                            versionStatus = "Deleted"
                        });

                        UpdateDataRequest productMaterialVersionRequest = new UpdateDataRequest();
                        productMaterialVersionRequest.KeyList = Helper.ToDictionaryList(productMaterialVersionKey);
                        productMaterialVersionRequest.DataList = Helper.ToDictionaryList(productMaterialVersionData);

                        string result = await APIController.ApiRequest("POST", "/Common/UpdateData/ProductMaterialVersion", productMaterialVersionRequest);

                        try
                        {
                            if (int.Parse(result) > 0)
                            {
                                productMaterialList.Find(p => p.versionID == latestVersionID).versionStatus = "Deleted";
                                MessageBox.Show("Attribute removed successfully!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    } 
                    else
                    {

                        // Remove submitted attribute in the database
                        List<ProductAttributeVersion> productAttributeVersionKey = new List<ProductAttributeVersion>();
                        productAttributeVersionKey.Add(new ProductAttributeVersion
                        {
                            versionID = latestVersionID
                        });

                        List<ProductAttributeVersion> productAttributeVersionData = new List<ProductAttributeVersion>();
                        productAttributeVersionData.Add(new ProductAttributeVersion
                        {
                            recordDate = DateTime.Now,
                            recordPerson = ((Staff)Program.user).staffID,
                            versionStatus = "Deleted"
                        });

                        UpdateDataRequest productAttributeVersionRequest = new UpdateDataRequest();
                        productAttributeVersionRequest.KeyList = Helper.ToDictionaryList(productAttributeVersionKey);
                        productAttributeVersionRequest.DataList = Helper.ToDictionaryList(productAttributeVersionData);

                        string result = await APIController.ApiRequest("POST", "/Common/UpdateData/ProductAttributeVersion", productAttributeVersionRequest);

                        try
                        {
                            if (int.Parse(result) > 0)
                            {
                                productAttributeList.Find(p => p.versionID == latestVersionID).versionStatus = "Deleted";
                                MessageBox.Show("Attribute removed successfully!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }

                }

            };

            panel.Controls.Add(pb);
            panel.Controls.Add(btn);

            return new List<Object> { panel, pb, btn };

        }

        public async Task<List<Object>> createSuggestEditDocumentPanel(string tableName, string column, string attributeID)
        {

            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(0)
            };

            var btnDownload = new Button
            {
                Text = "",
                BackColor = Color.Moccasin,
                Width = 220,
                Height = 30,
                Margin = new Padding(5, 0, 5, 0),
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };

            var fileKeyValue = getLatestSubmittedVersion(tableName, column, attributeID)[0];
            if (fileKeyValue != "")
            {

                var fileKey = new
                {
                    fileID = fileKeyValue
                };

                string result = await APIController.ApiRequest("POST", "/Common/GetData/File/false", Helper.ToDictionary(fileKey));
                List<EntityFile> file = JsonConvert.DeserializeObject<List<EntityFile>>(result);

                string filePath = String.Format("{0}/{1}", ConfigurationManager.AppSettings["FileDirectory"], file[0].filePath);
                string fileName = file[0].fileName;

                btnDownload.Text = file[0].fileName;
                var fileInfo = new FileDownloadInfo
                {
                    FilePath = filePath,
                    FileName = fileName
                };
                btnDownload.Tag = fileInfo;
                btnDownload.Click += btnDownload_Click;

            }

            var btn = new Button
            {
                Text = "X",
                BackColor = Color.Moccasin,
                Width = 40,
                Height = 30,
                Margin = new Padding(5, 0, 5, 0),
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };

            btn.Click += async (sender, e) =>
            {

                if (btnDownload.Text != "")
                {

                    var latestVersionID = getLatestSubmittedVersion(tableName, column, attributeID)[1];

                    if (tableName == "ProductAttributeVersion")
                    {

                        // Remove submitted attribute in the database
                        List<ProductAttributeVersion> productAttributeVersionKey = new List<ProductAttributeVersion>();
                        productAttributeVersionKey.Add(new ProductAttributeVersion
                        {
                            versionID = latestVersionID
                        });

                        List<ProductAttributeVersion> productAttributeVersionData = new List<ProductAttributeVersion>();
                        productAttributeVersionData.Add(new ProductAttributeVersion
                        {
                            recordDate = DateTime.Now,
                            recordPerson = ((Staff)Program.user).staffID,
                            versionStatus = "Deleted"
                        });

                        UpdateDataRequest productAttributeVersionRequest = new UpdateDataRequest();
                        productAttributeVersionRequest.KeyList = Helper.ToDictionaryList(productAttributeVersionKey);
                        productAttributeVersionRequest.DataList = Helper.ToDictionaryList(productAttributeVersionData);

                        string result = await APIController.ApiRequest("POST", "/Common/UpdateData/ProductAttributeVersion", productAttributeVersionRequest);

                        try
                        {
                            if (int.Parse(result) > 0)
                            {
                                productAttributeList.Find(p => p.versionID == latestVersionID).versionStatus = "Deleted";
                                btnDownload.Text = "";
                                btnDownload.Tag = "";
                                btnDownload.Click -= btnDownload_Click;
                                MessageBox.Show("Attribute removed successfully!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }

                }

            };

            panel.Controls.Add(btnDownload);
            panel.Controls.Add(btn);

            return new List<Object> { panel, btnDownload, btn };

        }

        public FlowLayoutPanel createTextActionButtons(Label latestValue, Label latestTime, Label latestPerson, 
            TextBox suggestedEdit, Button changeButton, string tableName,
            string column, string attributeID, string approvalRole)
        {
            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(5, 0, 5, 0)
            };

            var editButton = new Button
            {
                Text = "Edit",
                BackColor = Color.Moccasin,
                Width = 130,
                Height = 30,
                Margin = new Padding(5, 0, 5, 0),
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };

            var approveButton = new Button
            {
                Text = "Approve",
                BackColor = Color.Moccasin,
                Dock = DockStyle.Fill,
                Width = 130,
                Height = 30,
                Margin = new Padding(5, 0, 5, 0),
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };

            editButton.Click += async (sender, e) =>
            {

                if (editButton.Text == "Edit" && string.IsNullOrEmpty(suggestedEdit.Text))
                {
                    editButton.Text = "OK";
                    changeButton.Enabled = false;
                    approveButton.Enabled = false;
                    suggestedEdit.Enabled = true;
                    suggestedEdit.ReadOnly = false;

                }
                else
                {

                    if (editButton.Text == "OK")
                    {

                        if (!string.IsNullOrEmpty(suggestedEdit.Text))
                        {

                            if (tableName == "ProductMaterialVersion")
                            {

                                List<ProductMaterialVersion> productMaterialVersionList = new List<ProductMaterialVersion>();
                                productMaterialVersionList.Add(new ProductMaterialVersion
                                {
                                    versionID = (await Helper.GenerateNextId("ProductMaterialVersion", "versionID")) ?? "VM00001",
                                    productID = product.productID,
                                    materialID = attributeID,
                                    quantity = decimal.Parse(suggestedEdit.Text),
                                    recordDate = DateTime.Now,
                                    recordPerson = ((Staff)Program.user).staffID,
                                    versionStatus = "Submitted"
                                });

                                string result = await APIController.ApiRequest("POST", "/Common/InsertData/ProductMaterialVersion", Helper.ToDictionaryList(productMaterialVersionList));

                                try
                                {
                                    if (int.Parse(result) > 0)
                                    {
                                        productMaterialList.InsertRange(0, productMaterialVersionList);
                                        MessageBox.Show("Attribute inserted successfully!");
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                            }
                            else
                            {

                                List<ProductAttributeVersion> productAttributeVersionList = new List<ProductAttributeVersion>();
                                productAttributeVersionList.Add(new ProductAttributeVersion
                                {
                                    versionID = (await Helper.GenerateNextId("ProductAttributeVersion", "versionID")) ?? "VA00001",
                                    productID = product.productID,
                                    attributeID = attributeID,
                                    attributeValue = suggestedEdit.Text,
                                    recordDate = DateTime.Now,
                                    recordPerson = ((Staff)Program.user).staffID,
                                    versionStatus = "Submitted"
                                });

                                string result = await APIController.ApiRequest("POST", "/Common/InsertData/ProductAttributeVersion", Helper.ToDictionaryList(productAttributeVersionList));

                                try
                                {
                                    if (int.Parse(result) > 0)
                                    {
                                        productAttributeList.InsertRange(0, productAttributeVersionList);
                                        MessageBox.Show("Attribute inserted successfully!");
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                            }

                        }

                        editButton.Text = "Edit";
                        changeButton.Enabled = true;
                        approveButton.Enabled = true;
                        suggestedEdit.Enabled = false;
                        suggestedEdit.ReadOnly = true;

                    }
                    else
                    {
                        MessageBox.Show("Please remove the existing suggested edit first!");
                    }

                }
                
            };

            approveButton.Click += async (sender, e) =>
            {

                if (((Staff)Program.user).staffID == teamList.Find(p => p.role == approvalRole).personID) {

                    if (!string.IsNullOrEmpty(suggestedEdit.Text))
                    {

                        var latestVersionID = getLatestSubmittedVersion(tableName, column, attributeID)[1];

                        if (tableName == "ProductMaterialVersion")
                        {

                            List<ProductMaterialVersion> productMaterialVersionKey = new List<ProductMaterialVersion>();
                            productMaterialVersionKey.Add(new ProductMaterialVersion
                            {
                                versionID = latestVersionID
                            });

                            var time = DateTime.Now;
                            List<ProductMaterialVersion> productMaterialVersionData = new List<ProductMaterialVersion>();
                            productMaterialVersionData.Add(new ProductMaterialVersion
                            {
                                recordDate = time,
                                recordPerson = ((Staff)Program.user).staffID,
                                versionStatus = "Approved"
                            });

                            UpdateDataRequest productMaterialVersionRequest = new UpdateDataRequest();
                            productMaterialVersionRequest.KeyList = Helper.ToDictionaryList(productMaterialVersionKey);
                            productMaterialVersionRequest.DataList = Helper.ToDictionaryList(productMaterialVersionData);

                            string result = await APIController.ApiRequest("POST", "/Common/UpdateData/ProductMaterialVersion", productMaterialVersionRequest);

                            try
                            {
                                if (int.Parse(result) > 0)
                                {

                                    latestValue.Text = suggestedEdit.Text;
                                    suggestedEdit.Text = "";
                                    latestTime.Text = String.Format("{0:yyyy-MM-dd}", time);
                                    latestPerson.Text = ((Staff)Program.user).staffName;
                                    productMaterialList.Find(p => p.versionID == latestVersionID).versionStatus = "Approved";
                                    MessageBox.Show("Amendment approved successfully!");

                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                        else
                        {

                            List<ProductAttributeVersion> productAttributeVersionKey = new List<ProductAttributeVersion>();
                            productAttributeVersionKey.Add(new ProductAttributeVersion
                            {
                                versionID = latestVersionID
                            });

                            var time = DateTime.Now;
                            List<ProductAttributeVersion> productAttributeVersionData = new List<ProductAttributeVersion>();
                            productAttributeVersionData.Add(new ProductAttributeVersion
                            {
                                recordDate = time,
                                recordPerson = ((Staff)Program.user).staffID,
                                versionStatus = "Approved"
                            });

                            UpdateDataRequest productAttributeVersionRequest = new UpdateDataRequest();
                            productAttributeVersionRequest.KeyList = Helper.ToDictionaryList(productAttributeVersionKey);
                            productAttributeVersionRequest.DataList = Helper.ToDictionaryList(productAttributeVersionData);

                            string result = await APIController.ApiRequest("POST", "/Common/UpdateData/ProductAttributeVersion", productAttributeVersionRequest);
                            string result2 = null;

                            if (attributeID == "A00005")
                            {

                                List<Product> productKey = new List<Product>();
                                productKey.Add(new Product
                                {
                                    productID = product.productID
                                });

                                List<Product> productData = new List<Product>();
                                productData.Add(new Product
                                {
                                    productName = suggestedEdit.Text
                                });

                                UpdateDataRequest productRequest = new UpdateDataRequest();
                                productRequest.KeyList = Helper.ToDictionaryList(productKey);
                                productRequest.DataList = Helper.ToDictionaryList(productData);

                                result2 = await APIController.ApiRequest("POST", "/Common/UpdateData/Product", productRequest);

                            }

                            try
                            {
                                if (int.Parse(result) > 0)
                                {

                                    if (result2 != null && int.Parse(result2) > 0)
                                    {
                                        product.productName = suggestedEdit.Text;
                                    }

                                    latestValue.Text = suggestedEdit.Text;
                                    suggestedEdit.Text = "";
                                    latestTime.Text = String.Format("{0:yyyy-MM-dd}", time);
                                    latestPerson.Text = ((Staff)Program.user).staffName;
                                    productAttributeList.Find(p => p.versionID == latestVersionID).versionStatus = "Approved";
                                    MessageBox.Show("Attribute approved successfully!");

                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("There is no suggested edit for the item!");
                    }

                }
                else
                {
                    MessageBox.Show("You don't have the rights to approve the changes!");
                }

            };

            panel.Controls.Add(editButton);
            panel.Controls.Add(approveButton);

            return panel;

        }

        public FlowLayoutPanel createPictureActionButtons(PictureBox latestPicture, Label latestTime, Label latestPerson,
            PictureBox suggestedEdit, Button changeButton, string tableName,
            string column, string attributeID, string approvalRole)
        {

            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(5, 0, 5, 0)
            };

            var editButton = new Button
            {
                Text = "Upload",
                BackColor = Color.Moccasin,
                Width = 130,
                Height = 30,
                Margin = new Padding(5, 0, 5, 0),
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };

            var approveButton = new Button
            {
                Text = "Approve",
                BackColor = Color.Moccasin,
                Dock = DockStyle.Fill,
                Width = 130,
                Height = 30,
                Margin = new Padding(5, 0, 5, 0),
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };

            editButton.Click += async (sender, e) =>
            {

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {

                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All files|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;
                    var nextFileID = await Helper.GenerateNextId("File", "fileID") ?? "F00001";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        string filePath = openFileDialog.FileName;
                        string result = await APIController.UploadFile(filePath, nextFileID);

                        if (result == "true")
                        {

                            // Upload database

                            List<EntityFile> fileList = new List<EntityFile>();
                            fileList.Add(new EntityFile
                            {
                                fileID = nextFileID,
                                fileName = $"{nextFileID}_{Path.GetFileName(filePath)}",
                                filePath = $"{nextFileID}_{Path.GetFileName(filePath)}",
                                fileType = Path.GetExtension(filePath),
                                recordDate = DateTime.Now,
                                recordPerson = ((Staff)Program.user).staffID
                            });

                            string result2 = await APIController.ApiRequest("POST", "/Common/InsertData/File", Helper.ToDictionaryList(fileList));

                            List <ProductAttributeVersion> productAttributeVersionList = new List<ProductAttributeVersion>();
                            productAttributeVersionList.Add(new ProductAttributeVersion
                            {
                                versionID = (await Helper.GenerateNextId("ProductAttributeVersion", "versionID")) ?? "VA00001",
                                productID = product.productID,
                                attributeID = attributeID,
                                fileID = nextFileID,
                                recordDate = DateTime.Now,
                                recordPerson = ((Staff)Program.user).staffID,
                                versionStatus = "Submitted"
                            });

                            string result3 = await APIController.ApiRequest("POST", "/Common/InsertData/ProductAttributeVersion", Helper.ToDictionaryList(productAttributeVersionList));

                            try
                            {
                                if (int.Parse(result2) > 0 && int.Parse(result3) > 0)
                                {
                                    productAttributeList.InsertRange(0, productAttributeVersionList);
                                    suggestedEdit.ImageLocation = filePath;
                                    suggestedEdit.SizeMode = PictureBoxSizeMode.Zoom;
                                    suggestedEdit.LoadAsync();
                                    MessageBox.Show("Upload successfully!");
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        } else
                        {
                            MessageBox.Show("Error occurred during upload!");
                        }

                    } else
                    {
                        MessageBox.Show("Upload action cancelled!");
                    }

                }

            };

            approveButton.Click += async (sender, e) =>
            {

                if (((Staff)Program.user).staffID == teamList.Find(p => p.role == approvalRole).personID)
                {

                    if (suggestedEdit.Image != null)
                    {

                        var latestVersionID = getLatestSubmittedVersion(tableName, column, attributeID)[1];

                        List<ProductAttributeVersion> productAttributeVersionKey = new List<ProductAttributeVersion>();
                        productAttributeVersionKey.Add(new ProductAttributeVersion
                        {
                            versionID = latestVersionID
                        });

                        var time = DateTime.Now;
                        List<ProductAttributeVersion> productAttributeVersionData = new List<ProductAttributeVersion>();
                        productAttributeVersionData.Add(new ProductAttributeVersion
                        {
                            recordDate = time,
                            recordPerson = ((Staff)Program.user).staffID,
                            versionStatus = "Approved"
                        });

                        UpdateDataRequest productAttributeVersionRequest = new UpdateDataRequest();
                        productAttributeVersionRequest.KeyList = Helper.ToDictionaryList(productAttributeVersionKey);
                        productAttributeVersionRequest.DataList = Helper.ToDictionaryList(productAttributeVersionData);

                        string result = await APIController.ApiRequest("POST", "/Common/UpdateData/ProductAttributeVersion", productAttributeVersionRequest);
                        string result2 = null;

                        if (attributeID == "A00005")
                        {

                            List<Product> productKey = new List<Product>();
                            productKey.Add(new Product
                            {
                                productID = product.productID
                            });

                            List<Product> productData = new List<Product>();
                            productData.Add(new Product
                            {
                                productName = suggestedEdit.Text
                            });

                            UpdateDataRequest productRequest = new UpdateDataRequest();
                            productRequest.KeyList = Helper.ToDictionaryList(productKey);
                            productRequest.DataList = Helper.ToDictionaryList(productData);

                            result2 = await APIController.ApiRequest("POST", "/Common/UpdateData/Product", productRequest);

                        }

                        try
                        {
                            if (int.Parse(result) > 0)
                            {

                                if (result2 != null && int.Parse(result2) > 0)
                                {
                                    product.productName = suggestedEdit.Text;
                                }

                                latestPicture.Image = (Image)suggestedEdit.Image.Clone();
                                latestPicture.SizeMode = PictureBoxSizeMode.Zoom;
                                suggestedEdit.Image.Dispose();
                                suggestedEdit.Image = null;
                                latestTime.Text = String.Format("{0:yyyy-MM-dd}", time);
                                latestPerson.Text = ((Staff)Program.user).staffName;
                                productAttributeList.Find(p => p.versionID == latestVersionID).versionStatus = "Approved";
                                MessageBox.Show("Attribute approved successfully!");

                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else
                    {
                        MessageBox.Show("There is no suggested edit for the item!");
                    }

                }
                else
                {
                    MessageBox.Show("You don't have the rights to approve the changes!");
                }

            };

            panel.Controls.Add(editButton);
            panel.Controls.Add(approveButton);

            return panel;

        }

        public FlowLayoutPanel createDocumentActionButtons(Button latestDocument, Label latestTime, Label latestPerson,
            Button suggestedEdit, Button changeButton, string tableName,
            string column, string attributeID, string approvalRole)
        {

            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(5, 0, 5, 0)
            };

            var editButton = new Button
            {
                Text = "Upload",
                BackColor = Color.Moccasin,
                Width = 130,
                Height = 30,
                Margin = new Padding(5, 0, 5, 0),
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };

            var approveButton = new Button
            {
                Text = "Approve",
                BackColor = Color.Moccasin,
                Dock = DockStyle.Fill,
                Width = 130,
                Height = 30,
                Margin = new Padding(5, 0, 5, 0),
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false
            };

            editButton.Click += async (sender, e) =>
            {

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {

                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "Office and PDF Files|*.doc;*.docx;*.xls;*.xlsx;*.ppt;*.pptx;*.pdf|All Files|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;
                    var nextFileID = await Helper.GenerateNextId("File", "fileID") ?? "F00001";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        string filePath = openFileDialog.FileName;
                        string result = await APIController.UploadFile(filePath, nextFileID);

                        if (result == "true")
                        {

                            // Upload database

                            List<EntityFile> fileList = new List<EntityFile>();
                            fileList.Add(new EntityFile
                            {
                                fileID = nextFileID,
                                fileName = $"{nextFileID}_{Path.GetFileName(filePath)}",
                                filePath = $"{nextFileID}_{Path.GetFileName(filePath)}",
                                fileType = Path.GetExtension(filePath),
                                recordDate = DateTime.Now,
                                recordPerson = ((Staff)Program.user).staffID
                            });

                            string result2 = await APIController.ApiRequest("POST", "/Common/InsertData/File", Helper.ToDictionaryList(fileList));

                            List<ProductAttributeVersion> productAttributeVersionList = new List<ProductAttributeVersion>();
                            productAttributeVersionList.Add(new ProductAttributeVersion
                            {
                                versionID = (await Helper.GenerateNextId("ProductAttributeVersion", "versionID")) ?? "VA00001",
                                productID = product.productID,
                                attributeID = attributeID,
                                fileID = nextFileID,
                                recordDate = DateTime.Now,
                                recordPerson = ((Staff)Program.user).staffID,
                                versionStatus = "Submitted"
                            });

                            string result3 = await APIController.ApiRequest("POST", "/Common/InsertData/ProductAttributeVersion", Helper.ToDictionaryList(productAttributeVersionList));

                            try
                            {
                                if (int.Parse(result2) > 0 && int.Parse(result3) > 0)
                                {
                                    productAttributeList.InsertRange(0, productAttributeVersionList);
                                    suggestedEdit.Text = $"{nextFileID}_{Path.GetFileName(filePath)}";
                                    var fileInfo = new FileDownloadInfo
                                    {
                                        FilePath = String.Format("{0}/{1}", ConfigurationManager.AppSettings["FileDirectory"], $"{nextFileID}_{Path.GetFileName(filePath)}"),
                                        FileName = $"{nextFileID}_{Path.GetFileName(filePath)}"
                                    };
                                    suggestedEdit.Tag = fileInfo;
                                    suggestedEdit.Click += btnDownload_Click;
                                    MessageBox.Show("Upload successfully!");
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Error occurred during upload!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Upload action cancelled!");
                    }

                }

            };

            approveButton.Click += async (sender, e) =>
            {

                if (((Staff)Program.user).staffID == teamList.Find(p => p.role == approvalRole).personID)
                {

                    if (suggestedEdit.Text != "")
                    {

                        var latestVersionID = getLatestSubmittedVersion(tableName, column, attributeID)[1];

                        List<ProductAttributeVersion> productAttributeVersionKey = new List<ProductAttributeVersion>();
                        productAttributeVersionKey.Add(new ProductAttributeVersion
                        {
                            versionID = latestVersionID
                        });

                        var time = DateTime.Now;
                        List<ProductAttributeVersion> productAttributeVersionData = new List<ProductAttributeVersion>();
                        productAttributeVersionData.Add(new ProductAttributeVersion
                        {
                            recordDate = time,
                            recordPerson = ((Staff)Program.user).staffID,
                            versionStatus = "Approved"
                        });

                        UpdateDataRequest productAttributeVersionRequest = new UpdateDataRequest();
                        productAttributeVersionRequest.KeyList = Helper.ToDictionaryList(productAttributeVersionKey);
                        productAttributeVersionRequest.DataList = Helper.ToDictionaryList(productAttributeVersionData);

                        string result = await APIController.ApiRequest("POST", "/Common/UpdateData/ProductAttributeVersion", productAttributeVersionRequest);
                        string result2 = null;

                        if (attributeID == "A00005")
                        {

                            List<Product> productKey = new List<Product>();
                            productKey.Add(new Product
                            {
                                productID = product.productID
                            });

                            List<Product> productData = new List<Product>();
                            productData.Add(new Product
                            {
                                productName = suggestedEdit.Text
                            });

                            UpdateDataRequest productRequest = new UpdateDataRequest();
                            productRequest.KeyList = Helper.ToDictionaryList(productKey);
                            productRequest.DataList = Helper.ToDictionaryList(productData);

                            result2 = await APIController.ApiRequest("POST", "/Common/UpdateData/Product", productRequest);

                        }

                        try
                        {
                            if (int.Parse(result) > 0)
                            {

                                if (result2 != null && int.Parse(result2) > 0)
                                {
                                    product.productName = suggestedEdit.Text;
                                }

                                latestDocument.Text = suggestedEdit.Text;
                                latestDocument.Tag = suggestedEdit.Tag;
                                latestDocument.Click += btnDownload_Click;
                                suggestedEdit.Text = "";
                                suggestedEdit.Tag = "";
                                suggestedEdit.Click -= btnDownload_Click;
                                latestTime.Text = String.Format("{0:yyyy-MM-dd}", time);
                                latestPerson.Text = ((Staff)Program.user).staffName;
                                productAttributeList.Find(p => p.versionID == latestVersionID).versionStatus = "Approved";
                                MessageBox.Show("Attribute approved successfully!");

                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else
                    {
                        MessageBox.Show("There is no suggested edit for the item!");
                    }

                }
                else
                {
                    MessageBox.Show("You don't have the rights to approve the changes!");
                }

            };

            panel.Controls.Add(editButton);
            panel.Controls.Add(approveButton);

            return panel;

        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is FileDownloadInfo fileInfo)
            {
                await APIController.DownloadFile(fileInfo.FilePath, fileInfo.FileName);
            }
            else
            {
                MessageBox.Show("File information is not set.");
            }
        }

    }

}
