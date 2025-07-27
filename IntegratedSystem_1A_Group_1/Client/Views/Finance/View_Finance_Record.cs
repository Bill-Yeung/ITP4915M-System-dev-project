using Client.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views.Finance
{
    public partial class View_Finance_Record : Form
    {
        public View_Finance_Record()
        {
            InitializeComponent();
        }

        private void View_Finance_Record_Load(object sender, EventArgs e)
        {

            LoadDashboardData();


        }
        private async void LoadDashboardData()
        {
            string response = await APIController.ApiRequest("POST", "/Common/GetData/payment/true", null);
            string response2 = await APIController.ApiRequest("POST", "/Common/GetData/paymentdetails/true", null);
            string response3 = await APIController.ApiRequest("POST", "/Common/GetData/paymentmethod/true", null);

            DataTable dt = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(response);
            DataTable dt2 = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(response2);
            DataTable dt3 = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(response3);

            // Merge the data tables 

            var payments = dt.AsEnumerable();        // Payment records
            var details = dt2.AsEnumerable();        // Payment details
            var methods = dt3.AsEnumerable();        // Payment methods 

            var joinedData = from p in dt.AsEnumerable()
                             join d in dt2.AsEnumerable()
                                on p["paymentMethodID"].ToString() equals d["paymentMethodID"].ToString() into pd
                             from d in pd.DefaultIfEmpty()
                             join m in dt3.AsEnumerable()
                                on p["paymentMethodID"].ToString() equals m["paymentMethodID"].ToString() into pm
                             from m in pm.DefaultIfEmpty()
                             select new
                             {
                                 paymentID = p["paymentID"],
                                 orderID = p["orderID"],
                                 paymentDate = p["paymentDate"],
                                 paymentAmount = p["paymentAmount"],
                                 paymentDescription = p["paymentDescription"],
                                 paymentStatus = p["paymentStatus"],
                                 approvalCode = p["approvalCode"],
                                 customerID = d?["customerID"] ?? DBNull.Value,
                                 accountName = d?["accountName"] ?? DBNull.Value,
                                 accountNumber = d?["accountNumber"] ?? DBNull.Value,
                                 paymentMethodName = m?["paymentMethodName"] ?? DBNull.Value
                             };


            DataTable mergedTable = new DataTable();

            // add columns to the merged table 
            mergedTable.Columns.Add("paymentID");
            mergedTable.Columns.Add("orderID");
            mergedTable.Columns.Add("paymentDate");
            mergedTable.Columns.Add("paymentAmount");
            mergedTable.Columns.Add("paymentDescription");
            mergedTable.Columns.Add("paymentStatus");
            mergedTable.Columns.Add("approvalCode");
            mergedTable.Columns.Add("customerID");
            mergedTable.Columns.Add("accountName");
            mergedTable.Columns.Add("accountNumber");
            mergedTable.Columns.Add("paymentMethodName");

            foreach (var row in joinedData)
            {
                mergedTable.Rows.Add(
                    row.paymentID,
                    row.orderID,
                    row.paymentDate,
                    row.paymentAmount,
                    row.paymentDescription,
                    row.paymentStatus,
                    row.approvalCode,
                    row.customerID,
                    row.accountName,
                    row.accountNumber,
                    row.paymentMethodName
                );
            }
            financeDatadgv.DataSource = mergedTable;
            // Apply the change
            dt.AcceptChanges();


        }



        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (DTPStartDate.Value > DateTime.Today)
            {
                MessageBox.Show("Start date cannot be in the future.", "Invalid date",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DTPStartDate.Value = DateTime.Today;
                return;
            }

            if (DTPStartDate.Value > DTPEndDate.Value)
            {
                MessageBox.Show("Start date cannot be later than end date.", "Invalid range",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime startDate = DTPStartDate.Value.Date;
            DateTime endDate = DTPEndDate.Value.Date;

            DataTable dt = (DataTable)financeDatadgv.DataSource;

            if (dt == null)
                return;

            var filteredRows = dt.AsEnumerable()
                .Where(row =>
                {
                    DateTime paymentDate;
                    if (DateTime.TryParse(row.Field<string>("paymentDate"), out paymentDate))
                    {
                        return paymentDate.Date >= startDate && paymentDate.Date <= endDate;
                    }
                    return false;
                });

            if (filteredRows.Any())
            {
                financeDatadgv.DataSource = filteredRows.CopyToDataTable();
            }
            else
            {
                financeDatadgv.DataSource = null;
                MessageBox.Show("No records found for the selected date range.", "Search Result",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            // Optionally reset date pickers to today's date
            DTPStartDate.Value = DateTime.Today;
            DTPEndDate.Value = DateTime.Today;

            // Reload all data
            LoadDashboardData();
        }
    }
}

