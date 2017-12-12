using Dopravio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dopravio_Web.driver
{
    public partial class MyJourneysForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Authorization.CheckUser(Request.FilePath))
            {
                Response.Redirect("../LoginForm.aspx");
            }

            TimetablesConnector tc = new TimetablesConnector();
            var list = tc.getDrivers();
            foreach(var item in list)
            {
                TableRow tr = new TableRow();
                TableCell tc1 = new TableCell();
                TableCell tc2 = new TableCell();
                TableCell tc3 = new TableCell();
                TableCell tc4 = new TableCell();
                tc1.Text = item.departure.ToShortTimeString();
                tc2.Text = item.arrival.ToShortTimeString();
                tc3.Text = item.vehicle.name;
                tc4.Text = item.route.start + " - " + item.route.finish;
                tr.Cells.Add(tc1);
                tr.Cells.Add(tc2);
                tr.Cells.Add(tc3);
                tr.Cells.Add(tc4);
                tableJourneys.Rows.Add(tr);
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
    }
}