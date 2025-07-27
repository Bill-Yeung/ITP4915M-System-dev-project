using Client.Common;
using Client.Controllers;
using EntityModels;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client.Views.SnM.OMS
{
    public partial class frmGenerateQuotation : Form
    {

        private string quotationID { get; set; }
        private List<Customer> customerList { get; set; }
        private List<Product> productList { get; set; }
        private List<QuotationProduct> orderList { get; set; }
        private TaskCompletionSource<bool> _tcs = new();
        public Task LoadCompleted => _tcs.Task;


        public frmGenerateQuotation(string quotationID)
        {
            InitializeComponent();
            this.quotationID = quotationID;
            this.Load += async (s, e) =>
            {
                await frmGenerateQuotation_Load();
                _tcs.SetResult(true);
            };

        }

        private async Task frmGenerateQuotation_Load()
        {

            var quotationKey = new
            {
                quotationID = quotationID
            };

            string jsonString = await APIController.ApiRequest("POST", "/Common/GetData/Quotation/false", Helper.ToDictionary(quotationKey));
            List<Quotation> quotationList = JsonConvert.DeserializeObject<List<Quotation>>(jsonString);
            Quotation quotation = quotationList[0];

            string jsongString2 = await APIController.ApiRequest("POST", "/Common/GetData/Customer/true", null);
            customerList = JsonConvert.DeserializeObject<List<Customer>>(jsongString2);

            string jsongString3 = await APIController.ApiRequest("POST", "/Common/GetData/Product/true", null);
            productList = JsonConvert.DeserializeObject<List<Product>>(jsongString3);

            string jsongString4 = await APIController.ApiRequest("POST", "/Common/GetData/QuotationProduct/false", Helper.ToDictionary(quotationKey));
            orderList = JsonConvert.DeserializeObject<List<QuotationProduct>>(jsongString4);

            var path = Path.Combine(Application.StartupPath, "Assets", "logo.png");
            logo.Image = Image.FromFile(path);
            logo.SizeMode = PictureBoxSizeMode.Zoom;

            lblCustomerName.Text = (customerList.Find(c => c.customerID == quotation.customerID)).customerName;
            lblAddress.Text = (customerList.Find(c => c.customerID == quotation.customerID)).companyAddress;
            lblQuotationID.Text = quotation.quotationID;
            lblQuotationDate.Text = quotation.quotationDate?.ToString("yyyy-MM-dd") ?? String.Empty;
            decimal total = 0;

            foreach (var order in orderList)
            {

                table.RowCount += 1;
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

                Label lblProductName = new Label
                {
                    Text = (productList.Find(p => p.productID == order.productID)).productName,
                    TextAlign = ContentAlignment.MiddleLeft,
                    
                    Dock = DockStyle.Fill
                };

                table.Controls.Add(lblProductName, 0, table.RowCount - 1);

                Label lblQuantity = new Label
                {
                    Text = order.quantity.ToString(),
                    TextAlign = ContentAlignment.MiddleRight,
                    Dock = DockStyle.Fill
                };

                table.Controls.Add(lblQuantity, 1, table.RowCount - 1);

                Label lblUnitPrice = new Label
                {
                    Text = order.unitPrice.ToString(),
                    TextAlign = ContentAlignment.MiddleRight,
                    Dock = DockStyle.Fill
                };

                table.Controls.Add(lblUnitPrice, 2, table.RowCount - 1);
                total += (decimal)order.quantity * (decimal)order.unitPrice;

                Label lblSubTotal = new Label
                {
                    Text = (order.quantity * order.unitPrice).ToString(),
                    TextAlign = ContentAlignment.MiddleRight,
                    Dock = DockStyle.Fill
                };

                table.Controls.Add(lblSubTotal, 3, table.RowCount - 1);

            }

            table.RowCount += 1;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

            Label lblTotalLabel = new Label
            {
                Text = "Total: ",
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill
            };

            table.Controls.Add(lblTotalLabel, 2, table.RowCount - 1);

            Label lblTotalAmount = new Label
            {
                Text = total.ToString(),
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill
            };

            table.Controls.Add(lblTotalAmount, 3, table.RowCount - 1);

            table.Height = table.GetRowHeights().Sum();
            lblRemarks.Text = quotation.remarks;

        }

    }

}
