using Client.Controllers;
using Client.Views.Components;
using Client.Views.SnM.OMS;
using EntityModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views.SnM.OrderManagement
{
    public partial class ViewEditQuotation : Form
    {
        private string quotationID;
        private List<Product> availableProducts = new List<Product>();

        public ViewEditQuotation(string quotationID)
        {
            InitializeComponent();
            this.quotationID = quotationID;
            textBox_deposit.KeyPress += textBox_IntegerOnly_KeyPress;

        }

        private async void ViewEditQuotation_Load(object sender, EventArgs e)
        {
            if (Session.CurrentStaff == null || Session.CurrentStaff.departmentID != "D00002")
            {

                MessageBox.Show("Only for Sales & Marketing Department staff", "No Access Right", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BeginInvoke((Action)(() =>
                {
                    PanelController.openForm(Program.homeForm.panelRight, new frmWellcome());
                    this.Close();
                }));
            }

            //basic set up of data for comboBox_customer, comboBox_paymentTerm, availableProducts
            try
            {
                string jsonResponse = await APIController.ApiRequest("GET", "/OrderManagement/GetAllCustomer", null);
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                var customerList = new List<Customer>();
                foreach (DataRow row in dt.Rows)
                {
                    customerList.Add(new Customer
                    {
                        customerID = row["customerID"].ToString(),
                        customerName = row["customerName"].ToString(),
                    });
                }
                comboBox_customer.DataSource = customerList;
                comboBox_customer.DisplayMember = "DisplayName";
                comboBox_customer.ValueMember = "customerID";
                //comboBox_customer.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer data: {ex.Message}");
            }

            try
            {
                string jsonResponse = await APIController.ApiRequest("GET", "/OrderManagement/GetAllProduct", null);
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonResponse);
                availableProducts.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    availableProducts.Add(new Product
                    {
                        productID = row["productID"]?.ToString(),
                        productName = row["productName"]?.ToString(),
                        DisplayName = $"{row["productID"]?.ToString()} - {row["productName"]?.ToString()}"
                    });

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product data: {ex.Message}");
            }

            comboBox_paymentTerm.Items.Clear();
            comboBox_paymentTerm.Items.Add("30 days");
            comboBox_paymentTerm.Items.Add("60 days");
            //comboBox_paymentTerm.SelectedIndex = 0;


            //base on quotationID to load the corresponding information
            var response = await APIController.ApiRequest("GET", $"/OrderManagement/GetQuotationDetail?quotationID={quotationID}", null);
            var result = JsonConvert.DeserializeObject<QuotationDetailResult>(response);

            if (result.Quotation != null)
            {
                textBox_quotationID.Text = result.Quotation.quotationID;
                comboBox_customer.SelectedValue = result.Quotation.customerID;
                textBox_deposit.Text = result.Quotation.deposit?.ToString() ?? "";
                comboBox_paymentTerm.SelectedItem = result.Quotation.paymentTerm;
                textBox_remarks.Text = result.Quotation.remarks;
            }

            // load product details for this quotation
            flowLayoutPanel_products.Controls.Clear();
            foreach (var prod in result.QuotationProducts)
            {

                var comboBox_product = new ComboBox
                {
                    Width = 200,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Name = "comboBox_product"
                };
                comboBox_product.DataSource = availableProducts
                        .Select(p => new Product
                        {
                            productID = p.productID,
                            productName = p.productName,
                            DisplayName = p.DisplayName
                        }).ToList();
                //comboBox_product.DataSource = availableProducts;
                comboBox_product.DisplayMember = "DisplayName";
                comboBox_product.ValueMember = "productID";

                var textBox_qty = new TextBox
                {
                    Name = "textBox_qty",
                    Width = 70,
                    Text = prod.quantity?.ToString() ?? ""
                };
                textBox_qty.KeyPress += textBox_IntegerOnly_KeyPress;


                var textBox_unitPrice = new TextBox
                {
                    Name = "textBox_unitPrice",
                    Width = 125,
                    Text = prod.unitPrice?.ToString() ?? ""
                };
                textBox_unitPrice.KeyPress += textBox_IntegerOnly_KeyPress;


                var textBox_subTotal = new TextBox
                {
                    Name = "textBox_subTotal",
                    Width = 125,
                    ReadOnly = true
                };

                void calcSubTotal(object s, EventArgs args)
                {
                    if (int.TryParse(textBox_unitPrice.Text, out int unitPrice) && int.TryParse(textBox_qty.Text, out int qty))
                        textBox_subTotal.Text = (unitPrice * qty).ToString();
                    else
                        textBox_subTotal.Text = "0";
                    UpdateTotal();
                }
                textBox_qty.TextChanged += calcSubTotal;
                textBox_unitPrice.TextChanged += calcSubTotal;

                calcSubTotal(null, null);


                var panel = new Panel { Width = 1000, Height = 30 };
                panel.Controls.Add(comboBox_product);
                panel.Controls.Add(textBox_qty);
                panel.Controls.Add(textBox_unitPrice);
                panel.Controls.Add(textBox_subTotal);

                comboBox_product.Location = new Point(0, 0);
                textBox_qty.Location = new Point(220, 0);
                textBox_unitPrice.Location = new Point(350, 0);
                textBox_subTotal.Location = new Point(530, 0);

                flowLayoutPanel_products.Controls.Add(panel);

                if (!string.IsNullOrEmpty(prod.productID))
                {
                    comboBox_product.SelectedValue = prod.productID;
                }

            }
            UpdateTotal();

        }

        private async void comboBox_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_customer.SelectedItem is Customer selectedCustomer)
            {
                string customerID = selectedCustomer.customerID;
                string jsonResponse = await APIController.ApiRequest("GET", $"/OrderManagement/ViewCustomerInformation?customerID={customerID}", null);
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonResponse);
                dataGridView_customerInfo.DataSource = dt;
                dt.AcceptChanges();
            }
        }

        private void textBox_IntegerOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void UpdateTotal()
        {
            int total = 0;
            foreach (Control panel in flowLayoutPanel_products.Controls)
            {
                foreach (Control ctrl in panel.Controls)
                {

                    if (ctrl == null) continue;
                    if (ctrl is TextBox subTotalBox && subTotalBox.ReadOnly)
                    {
                        if (int.TryParse(subTotalBox.Text, out int sub))
                            total += sub;
                    }
                }
            }
            textBox_total.Text = total.ToString();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            var comboBox_product = new ComboBox
            {
                DataSource = new List<Product>(availableProducts),
                DisplayMember = "DisplayName",
                ValueMember = "productID",
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            var textBox_qty = new TextBox { Name = "textBox_qty", Width = 70 };
            var textBox_unitPrice = new TextBox { Name = "textBox_unitPrice", Width = 125 };
            var textBox_subTotal = new TextBox { Name = "textBox_subTotal", Width = 125, ReadOnly = true };

            textBox_qty.KeyPress += textBox_IntegerOnly_KeyPress;
            textBox_unitPrice.KeyPress += textBox_IntegerOnly_KeyPress;

            void calcSubTotal(object s, EventArgs args)
            {
                if (int.TryParse(textBox_unitPrice.Text, out int unitPrice) && int.TryParse(textBox_qty.Text, out int qty))
                    textBox_subTotal.Text = (unitPrice * qty).ToString();
                else
                    textBox_subTotal.Text = "0";
                UpdateTotal();
            }
            textBox_qty.TextChanged += calcSubTotal;
            textBox_unitPrice.TextChanged += calcSubTotal;

            var panel = new Panel { Width = 1000, Height = 30 };
            panel.Controls.Add(comboBox_product);
            panel.Controls.Add(textBox_qty);
            panel.Controls.Add(textBox_unitPrice);
            panel.Controls.Add(textBox_subTotal);

            comboBox_product.Location = new Point(0, 0);
            textBox_qty.Location = new Point(220, 0);
            textBox_unitPrice.Location = new Point(350, 0);
            textBox_subTotal.Location = new Point(530, 0);

            flowLayoutPanel_products.Controls.Add(panel);
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel_products.Controls.Count > 0)
            {
                var lastPanel = flowLayoutPanel_products.Controls[flowLayoutPanel_products.Controls.Count - 1];
                flowLayoutPanel_products.Controls.Remove(lastPanel);
                UpdateTotal();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            PanelController.openForm(Program.homeForm.panelRight, new frmOMS());
        }

        private async void btnUpate_Click(object sender, EventArgs e)
        {
            //check if there is duplicate product selected
            var selectedProductIDs = new List<string>();
            bool hasDuplicate = false;
            foreach (Control panel in flowLayoutPanel_products.Controls)
            {
                foreach (Control ctrl in panel.Controls)
                {
                    if (ctrl is ComboBox cb && cb.SelectedItem is Product prod)
                    {
                        if (selectedProductIDs.Contains(prod.productID))
                        {
                            hasDuplicate = true;
                            break;
                        }
                        selectedProductIDs.Add(prod.productID);
                    }
                }
                if (hasDuplicate) break;
            }

            if (hasDuplicate)
            {
                MessageBox.Show("Duplicate product selected, please modify and submit again");
                return;
            }

            // check if there is any empty subTotal field
            bool hasEmptySubTotal = false;
            foreach (Control panel in flowLayoutPanel_products.Controls)
            {
                foreach (Control ctrl in panel.Controls)
                {
                    if (ctrl is TextBox tb && tb.Name == "textBox_subTotal")
                    {
                        if (string.IsNullOrWhiteSpace(tb.Text) || tb.Text == "0")
                        {
                            hasEmptySubTotal = true;
                            break;
                        }
                    }
                }
                if (hasEmptySubTotal) break;
            }

            if (hasEmptySubTotal)
            {
                MessageBox.Show("Please fill in quantity or unit price");
                return;
            }

            // check if total price > 0
            if (string.IsNullOrWhiteSpace(textBox_total.Text) || textBox_total.Text == "0")
            {
                MessageBox.Show("Please selete at least one product for creating a quotation");
                return;
            }

            // check if deposit > total price
            if (decimal.TryParse(textBox_deposit.Text, out decimal deposit) && decimal.TryParse(textBox_total.Text, out decimal total))
            {
                if (deposit > total)
                {
                    MessageBox.Show("Amount of deposit cannot be greater than total.");
                    return;
                }
            }

            //collect information other than products
            var quotation = new Quotation
            {
                quotationID = textBox_quotationID.Text,
                quotationDate = DateTime.Now,
                customerID = ((Customer)comboBox_customer.SelectedItem).customerID,
                deposit = decimal.TryParse(textBox_deposit.Text, out var d) ? d : 0,
                paymentTerm = comboBox_paymentTerm.SelectedItem?.ToString(),
                remarks = textBox_remarks.Text,
                quotationStatus = "Edited"
            };

            // collect product information
            var quotationProducts = new List<QuotationProduct>();
            foreach (Control panel in flowLayoutPanel_products.Controls)
            {
                string productID = null;
                int quantity = 0;
                decimal unitPrice = 0;

                foreach (Control ctrl in panel.Controls)
                {

                    if (ctrl is ComboBox cb && cb.SelectedItem is Product prod)
                        productID = prod.productID;
                    else if (ctrl is TextBox tb)
                    {
                        if (tb.Name == "textBox_qty")
                            int.TryParse(tb.Text, out quantity);
                        else if (tb.Name == "textBox_unitPrice")
                            decimal.TryParse(tb.Text, out unitPrice);
                    }
                }

                if (!string.IsNullOrEmpty(productID))
                {
                    quotationProducts.Add(new QuotationProduct
                    {
                        //quotationID = quotation.quotationID,
                        productID = productID,
                        unitPrice = unitPrice,
                        quantity = quantity
                    });
                }
            }
            // create new quotation object with the collected data
            var postData = new
            {
                Quotation = quotation,
                QuotationProducts = quotationProducts
            };
            try
            {
                var response = await APIController.ApiRequest("POST", "/OrderManagement/UpdateQuotation", postData);
                if (int.TryParse(response, out int rowsAffected) && rowsAffected > 0)
                {
                    MessageBox.Show("Quotation updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update quotation, please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting quotation data: {ex.Message}");
            }
        }
    }

    public class QuotationDetailResult
    {
        public Quotation Quotation { get; set; }
        public List<QuotationProduct> QuotationProducts { get; set; }
    }
}
