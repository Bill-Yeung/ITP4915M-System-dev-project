using Client.Common;
using Client.Controllers;
using Newtonsoft.Json;
using EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Views.Components;
using Client.Views.SnM.OMS;
using Client.Views.SnM.OrderManagement;

namespace Client.Views.SnM.OMS
{
    public partial class frmQuotationMain : Form
    {

        private DataTable dtQuotation { get; set; }
        private List<Quotation> quotationList { get; set; }
        private DataTable dtCustomer {  get; set; }

        public frmQuotationMain()
        {
            InitializeComponent();
        }

        private async void frmPSSMain_Load(object sender, EventArgs e)
        {

            dgvQuotation.RowHeadersVisible = false;
            dgvQuotation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuotation.AllowUserToResizeRows = false;
            dgvQuotation.AllowUserToResizeColumns = false;

            dgvQuotation.EnableHeadersVisualStyles = false;
            dgvQuotation.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dgvQuotation.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightGreen;
            dgvQuotation.ColumnHeadersHeight = 50;
            dgvQuotation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvQuotation.RowTemplate.Height = 40;
            dgvQuotation.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            string jsonString = await APIController.ApiRequest("POST", "/Common/GetData/Quotation/true", null);
            DataTable dtResult = JsonConvert.DeserializeObject<DataTable>(jsonString);
            quotationList = JsonConvert.DeserializeObject<List<Quotation>>(jsonString);
            dtQuotation = dtResult.Copy();

            string jsonString2 = await APIController.ApiRequest("POST", "/Common/GetData/Customer/true", null);
            DataTable dtResult2 = JsonConvert.DeserializeObject<DataTable>(jsonString2);
            dtCustomer = dtResult2.Copy();

            resetView();

            dgvQuotation.Columns["quotationID"].HeaderText = "Quotation ID";
            dgvQuotation.Columns["quotationID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvQuotation.Columns["quotationID"].FillWeight = 20;

            dgvQuotation.Columns["quotationDate"].HeaderText = "Quotation Date";
            dgvQuotation.Columns["quotationDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvQuotation.Columns["quotationDate"].FillWeight = 20;

            dgvQuotation.Columns["customerID"].HeaderText = "Customer ID";
            dgvQuotation.Columns["customerID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvQuotation.Columns["customerID"].FillWeight = 20;

            dgvQuotation.Columns["deposit"].Visible = false;
            dgvQuotation.Columns["paymentTerm"].Visible = false;
            dgvQuotation.Columns["remarks"].Visible = false;

            dgvQuotation.Columns["quotationStatus"].HeaderText = "Quotation Status";
            dgvQuotation.Columns["quotationStatus"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvQuotation.Columns["quotationStatus"].FillWeight = 20;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string searchText = txtSearch.Text.ToLower();

            DataView dv = dtQuotation.DefaultView;
            dv.RowFilter = $"(quotationID LIKE '%{searchText}%' OR " +
                $"Convert(quotationDate, 'System.String') LIKE '%{searchText}%' OR " +
                $"customerID LIKE '%{searchText}%' OR " +
                $"customerName LIKE '%{searchText}%' OR " +
                $"quotationStatus LIKE '%{searchText}%')" +
                $" AND quotationStatus <> 'Deleted'";
            dv.Sort = "quotationID ASC";
            dgvQuotation.DataSource = dv.ToTable();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetView();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            string jsonString = await APIController.ApiRequest("POST", "/Common/GetData/Quotation/true", null);
            DataTable dtResult = JsonConvert.DeserializeObject<DataTable>(jsonString);
            dtQuotation = dtResult.Copy();
            resetView();
        }

        private void resetView()
        {

            if (!dtQuotation.Columns.Contains("customerName"))
            {
                dtQuotation.Columns.Add("customerName", typeof(string));
                foreach (DataRow qRow in dtQuotation.Rows)
                {
                    string custId = qRow["customerID"].ToString();
                    DataRow[] foundRows = dtCustomer.Select($"customerID = '{custId}'");
                    if (foundRows.Length > 0)
                        qRow["customerName"] = foundRows[0]["customerName"];
                    else
                        qRow["customerName"] = DBNull.Value;
                }
            }

            DataView dv = dtQuotation.DefaultView;
            dv.RowFilter = "quotationStatus <> 'Deleted'";
            dv.Sort = "quotationID ASC";
            dgvQuotation.DataSource = dv;
            txtSearch.Text = "";

            if (dgvQuotation.Columns.Contains("customerName"))
            {
                dgvQuotation.Columns.Remove("customerName");
            }

            DataGridViewTextBoxColumn txtCol = new DataGridViewTextBoxColumn
            {
                Name = "customerName",
                HeaderText = "Customer Name",
                DataPropertyName = "customerName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 20
            };

            if (dgvQuotation.Columns.Contains("customerID"))
            {
                int custIDIndex = dgvQuotation.Columns["customerID"].Index;
                txtCol.DisplayIndex = custIDIndex + 1;
            }

            dgvQuotation.Columns.Add(txtCol);

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            PanelController.openForm(Program.homeForm.panelRight, new CreateQuotation());
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {

            if (dgvQuotation.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvQuotation.SelectedRows[0];
                string selectedQuotationID = selectedRow.Cells["quotationID"].Value.ToString();
                PanelController.openForm(Program.homeForm.panelRight, new ViewEditQuotation(selectedQuotationID));
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgvQuotation.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dgvQuotation.SelectedRows[0];
                string selectedQuotationID = selectedRow.Cells["quotationID"].Value.ToString();

                DialogResult dialogResult = MessageBox.Show("Are you sure that you want to delete the quotation?", "ACTION: DELETE quotation",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.OK)
                {

                    List<Quotation> quotationKey = new List<Quotation>();
                    quotationKey.Add(new Quotation
                    {
                        quotationID = selectedQuotationID
                    });

                    List<Quotation> quotationData = new List<Quotation>();
                    quotationData.Add(new Quotation
                    {
                        quotationStatus = "Deleted"
                    });

                    UpdateDataRequest quotationRequest = new UpdateDataRequest();
                    quotationRequest.KeyList = Helper.ToDictionaryList(quotationKey);
                    quotationRequest.DataList = Helper.ToDictionaryList(quotationData);

                    string result = await APIController.ApiRequest("POST", "/Common/UpdateData/Quotation", quotationRequest);

                    try
                    {
                        if (int.Parse(result) > 0)
                        {
                            MessageBox.Show("Quotation deleted successfully!");
                            PanelController.openForm(Program.homeForm.panelRight, new frmQuotationMain());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    MessageBox.Show("It has been cancelled!", "ACTION: DELETE quotation");
                }
                else
                {
                    return;
                }

            }
            else
            {
                MessageBox.Show("Please select an quotation to delete!");
            }

        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {

            if (dgvQuotation.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dgvQuotation.SelectedRows[0];
                string selectedQuotationID = selectedRow.Cells["quotationID"].Value.ToString();

                var save = new SaveFileDialog
                {
                    Filter = "PDF file|*.pdf",
                    FileName = $"quotation-{selectedQuotationID}.pdf"
                };

                if (save.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                var quoteForm = new frmGenerateQuotation(selectedQuotationID);
                quoteForm.CreateControl();
                foreach (Control c in quoteForm.Controls)
                {
                    c.CreateControl();
                }
                quoteForm.StartPosition = FormStartPosition.Manual;
                quoteForm.Location = new Point(-2000, -2000);
                quoteForm.Show();
                await quoteForm.LoadCompleted;

                quoteForm.Refresh();
                Application.DoEvents();

                Helper.SaveControlAsPdf(quoteForm.panel, save.FileName);

                quoteForm.Close();
                quoteForm.Dispose();

                MessageBox.Show("PDF generated at:\n" + save.FileName);

            }

        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {


            if (dgvQuotation.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dgvQuotation.SelectedRows[0];
                string selectedQuotationID = selectedRow.Cells["quotationID"].Value.ToString();
                string quotationStatus = selectedRow.Cells["quotationStatus"].Value.ToString();

                if (quotationStatus != "Finalized")
                {

                    Quotation quotation = quotationList.Find(q => q.quotationID == selectedQuotationID);

                    List<Quotation> quotationKey = new List<Quotation>();
                    quotationKey.Add(new Quotation
                    {
                        quotationID = selectedQuotationID
                    });

                    List<Quotation> quotationData = new List<Quotation>();
                    quotationData.Add(new Quotation
                    {
                        quotationStatus = "Finalized"
                    });

                    UpdateDataRequest quotationRequest = new UpdateDataRequest();
                    quotationRequest.KeyList = Helper.ToDictionaryList(quotationKey);
                    quotationRequest.DataList = Helper.ToDictionaryList(quotationData);

                    string result = await APIController.ApiRequest("POST", "/Common/UpdateData/Quotation", quotationRequest);

                    List<PlacedOrder> placedOrderList = new List<PlacedOrder>();
                    var orderID = await Helper.GenerateNextId("PlacedOrder", "orderID") ?? "O00001";
                    placedOrderList.Add(new PlacedOrder
                    {
                        orderID = orderID,
                        quotationID = selectedQuotationID,
                        orderDate = DateTime.Now,
                        customerID = quotation.customerID,
                        orderStatus = "Created",
                        remarks = quotation.remarks,
                    });

                    string result2 = await APIController.ApiRequest("POST", "/Common/InsertData/PlacedOrder", Helper.ToDictionaryList(placedOrderList));

                    var qKey = new
                    {
                        quotationID = selectedQuotationID
                    };

                    string result3 = await APIController.ApiRequest("POST", "/Common/GetData/QuotationProduct/false", Helper.ToDictionary(qKey));
                    List<QuotationProduct> quotationproductList = JsonConvert.DeserializeObject<List<QuotationProduct>>(result3);

                    List<OrderProduct> orderProductList = new List<OrderProduct>();

                    foreach (var quotationProduct in quotationproductList)
                    {
                        orderProductList.Add(new OrderProduct
                        {
                            orderID = orderID,
                            productID = quotationProduct.productID,
                            unitPrice = quotationProduct.unitPrice,
                            quantity = quotationProduct.quantity
                        });
                    }

                    string result4 = await APIController.ApiRequest("POST", "/Common/InsertData/OrderProduct", Helper.ToDictionaryList(orderProductList));

                    try
                    {
                        if (int.Parse(result) > 0 && int.Parse(result2) > 0 &&
                                int.Parse(result4) > 0)
                        {
                            MessageBox.Show("Quotation converted successfully!");
                            PanelController.openForm(Program.homeForm.panelRight, new frmQuotationMain());
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
                    MessageBox.Show("The quotation has already been converted! Please check!");
                }

            }


        }

    }

}
