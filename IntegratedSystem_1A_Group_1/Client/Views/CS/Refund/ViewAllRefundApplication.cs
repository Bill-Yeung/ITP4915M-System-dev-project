using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Controllers;
using Client.Views.Components;
using Client.Views.UserManagement;
using EntityModels;
using Newtonsoft.Json;

namespace Client.Views.CS.Refund
{
    public partial class ViewAllRefundApplication : Form
    {
        public ViewAllRefundApplication()
        {
            InitializeComponent();
        }

        private async void ViewAllRefundApplication_Load(object sender, EventArgs e)
        {
            if (Session.CurrentStaff == null || (Session.CurrentStaff.departmentID != "D00005" && Session.CurrentStaff.departmentID != "D00006"))
            {
                MessageBox.Show("Only for CS & Finance Department staff", "No Access Right", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BeginInvoke((Action)(() =>
                {
                    PanelController.openForm(Program.homeForm.panelRight, new frmWellcome());
                    this.Close();
                }));
            }

            try
            {
                string jsonResponse = await APIController.ApiRequest("GET", "/OrderRefund/ViewAllRefund", null);


                DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonResponse);

                dgvAllRefundApplication.DataSource = dt;

                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}");
            }
        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvAllRefundApplication.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a refund application.");
                return;
            }

            string refundStatus = dgvAllRefundApplication.SelectedRows[0].Cells["Refund Status"].Value?.ToString();
            string refundID = dgvAllRefundApplication.SelectedRows[0].Cells["Refund ID"].Value.ToString();
            string staffID = Session.CurrentStaff.staffID;
            string deptID = Session.CurrentStaff.departmentID;

            if (deptID == "D00005") // CS Department
            {
                if (refundStatus == "Pending to Finance Department approval" || refundStatus == "Refunded")
                {
                    MessageBox.Show("This refund application is approved already");
                    return;
                }
                var confirmResult = MessageBox.Show("Confirm refund to customer?", "Confirm Refund", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }
                var result = await APIController.ApiRequest("POST", "/OrderRefund/ApproveRefundByCS", new { refundID, staffID });
                if (result == "1")
                {
                    MessageBox.Show("Refund approved. Pending to Finance Department's final approval");
                    ViewAllRefundApplication_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to approve this order refund");
                }
            }
            else if (deptID == "D00006") // Finance Department
            {
                if (refundStatus == "Rejected")
                {
                    MessageBox.Show("This refund application is rejected by CS Department.");
                    return;
                }
                else if (refundStatus == "Pending to CS department review")
                {
                    MessageBox.Show("This refund application is not approved by CS department yet.");
                    return;
                }
                else if (refundStatus == "Refunded")
                {
                    MessageBox.Show("This refund application is already refunded.");
                    return;
                }

                    var confirmResult = MessageBox.Show("Confirm refund to customer?", "Confirm Refund", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }
                var result = await APIController.ApiRequest("POST", "/OrderRefund/ApproveRefundByFinance", new { refundID, staffID });
                if (result == "1")
                {
                    MessageBox.Show("Refund completed.");
                    ViewAllRefundApplication_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to mark this order as refunded");
                }
            }

        }

        private async void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvAllRefundApplication.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a refund application.");
                return;
            }
            string refundStatus = dgvAllRefundApplication.SelectedRows[0].Cells["Refund Status"].Value?.ToString();
            if (refundStatus == "Rejected")
            {
                MessageBox.Show("This refund application is already rejected.");
                return;
            }
            string refundID = dgvAllRefundApplication.SelectedRows[0].Cells["Refund ID"].Value.ToString();
            string staffID = Session.CurrentStaff.staffID;

            string rejectReason = Microsoft.VisualBasic.Interaction.InputBox("Please enter the reject reason:", "Reject Reason", "");
            if (string.IsNullOrWhiteSpace(rejectReason))
            {
                MessageBox.Show("Reject reason is required.");
                return;
            }

            var result = await APIController.ApiRequest("POST", "/OrderRefund/RejectRefundByCS", new { refundID, staffID, rejectReason });

            if (result == "1")
            {
                MessageBox.Show("Refund application rejected.");
                ViewAllRefundApplication_Load(null, null);
            }
            else
            {
                MessageBox.Show("Failed to reject this order refund");
            }

        }
    }
}
