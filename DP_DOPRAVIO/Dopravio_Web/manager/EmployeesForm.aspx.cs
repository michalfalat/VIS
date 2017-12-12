using Dopravio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dopravio_Web.manager
{
    public partial class EmployeesForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAccess();

            DriversConnector dc = new DriversConnector();
            var list = dc.get();
            foreach (var item in list)
            {
                TableRow tr = new TableRow();
                TableCell tc1 = new TableCell();
                TableCell tc2 = new TableCell();
                TableCell tc3 = new TableCell();
                TableCell tc4 = new TableCell();
                TableCell tc5 = new TableCell();
                TableCell tc6 = new TableCell();
                tc1.Text = "Vodič";
                tc2.Text = item.name;
                tc3.Text = item.surname;
                tc4.Text = item.email;
                tc5.Text = item.phone;
                tc6.Text = item.salary.ToString();
                tr.Cells.Add(tc1);
                tr.Cells.Add(tc2);
                tr.Cells.Add(tc3);
                tr.Cells.Add(tc4);
                tr.Cells.Add(tc5);
                tr.Cells.Add(tc6);
                tableEmployees.Rows.Add(tr);
            }


            DispatchersConnector disc = new DispatchersConnector();
            var listDis = disc.get();
            foreach (var item in listDis)
            {
                TableRow tr = new TableRow();
                TableCell tc1 = new TableCell();
                TableCell tc2 = new TableCell();
                TableCell tc3 = new TableCell();
                TableCell tc4 = new TableCell();
                TableCell tc5 = new TableCell();
                TableCell tc6 = new TableCell();
                tc1.Text = "Dispečer";
                tc2.Text = item.name;
                tc3.Text = item.surname;
                tc4.Text = item.email;
                tc5.Text = item.phone;
                tc6.Text = item.salary.ToString();
                tr.Cells.Add(tc1);
                tr.Cells.Add(tc2);
                tr.Cells.Add(tc3);
                tr.Cells.Add(tc4);
                tr.Cells.Add(tc5);
                tr.Cells.Add(tc6);
                tableEmployees.Rows.Add(tr);
            }

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
    }
}