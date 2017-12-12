using Dopravio.Helpers;
using Dopravio_Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dopravio_Web.manager
{
    public partial class HomeForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAccess();

            OverviewConnector oc = new OverviewConnector();
            var overview = oc.getOverview();
            string s = overview.vehicleCount.ToString();
            lbAcceptedRequests.Text = overview.acceptedRequests.ToString();
            lbDeclinedRquests.Text = overview.declinedRequests.ToString();
            lbNewRequests.Text = overview.newRequests.ToString();
            lbDispatchers.Text = overview.dispatcherCount.ToString();
            lbDrivers.Text = overview.driverCount.ToString();
            lbFailures.Text = overview.failures.ToString();
            lbFaliresLastMonth.Text = overview.failurestInLastMonth.ToString();
            lbSalaries.Text = overview.monthSalary.ToString("# ###.00");
            lbVehicles.Text = overview.vehicleCount.ToString();
        }
        protected void CheckAccess()
        {

            if (!Authorization.CheckUser(Request.FilePath))
            {
                Response.Redirect("../LoginForm.aspx");
            }
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            var result = Authorization.Logout();
            if (result == "\"LOGOUT_SUCCESS\"")
            {
                Response.Redirect("../LoginForm.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}