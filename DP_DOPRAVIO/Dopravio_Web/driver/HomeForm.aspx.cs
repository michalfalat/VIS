using Dopravio.Helpers;
using Dopravio.Models;
using Dopravio_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dopravio_Web.driver
{
    public partial class HomeForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAccess();

            FailuresConnector fc = new FailuresConnector();
            var list = fc.getDrivers().OrderByDescending(ff => ff.created);
            foreach (var item in list)
            {
                TableRow tr = new TableRow();
                TableCell tc1 = new TableCell();
                TableCell tc2 = new TableCell();
                TableCell tc3 = new TableCell();
                TableCell tc4 = new TableCell();
                TableCell tc5 = new TableCell();
                tc1.Text = item.created.ToString();
                tc2.Text = item.place.ToString();
                tc3.Text = item.message.ToString();
                tc4.Text = item.timetable.vehicle.name;
                tc5.Text = item.timetable.name + " (" + item.timetable.departure.ToShortTimeString() + " - " + item.timetable.arrival.ToShortTimeString() + ")";
                tr.Cells.Add(tc1);
                tr.Cells.Add(tc2);
                tr.Cells.Add(tc3);
                tr.Cells.Add(tc4);
                tr.Cells.Add(tc5);
                tableFailures.Rows.Add(tr);
            }

            TimetablesConnector tc = new TimetablesConnector();
            var listJourneys = tc.getDrivers();

            foreach( var item in listJourneys)
            {
                dlJourney.Items.Add(new ListItem(item.name + " (" + item.departure.ToShortTimeString() + " - " + item.arrival.ToShortTimeString() + ")", item.id.ToString()));
            }
           // dlType.DataSource = Enum.GetValues(typeof(FailureType));

            var itemValues = System.Enum.GetValues(typeof(FailureType));
            var itemNames = System.Enum.GetNames(typeof(FailureType));

            dlType.DataSource = Enum.GetNames(typeof(FailureType));
            dlType.DataBind();
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
             var result =    Authorization.Logout();
            if(result == "\"LOGOUT_SUCCESS\"")
            {
                Response.Redirect("../LoginForm.aspx"); 
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TimetablesConnector tc = new TimetablesConnector();
            var timetable = tc.get(int.Parse(dlJourney.SelectedValue));
            Failure f = new Failure();
            f.created = DateTime.Now;
            f.message = txtMessage.Text;
            f.place = txtPlace.Text;
            f.severity = int.Parse( txtSeverity.Text);
            f.resolved = null;
            f.timetable = timetable;
            f.type = (FailureType)Enum.Parse(typeof(FailureType), dlType.SelectedValue);

            FailuresConnector fc = new FailuresConnector();
            var result = fc.send(f);
            if(result == "\"OK\"")
            {
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                
            }

        }
    }
}