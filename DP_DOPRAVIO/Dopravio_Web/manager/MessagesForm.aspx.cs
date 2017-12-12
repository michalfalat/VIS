using Dopravio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dopravio_Web.manager
{
    public partial class MessagesForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAccess();
            MessagesConnector mc = new MessagesConnector();
            var list = mc.getForManager().OrderByDescending(obj => obj.created);
            foreach (var item in list)
            {
                TableRow tr = new TableRow();
                TableCell tc1 = new TableCell();
                TableCell tc2 = new TableCell();
                TableCell tc3 = new TableCell();
                TableCell tc4 = new TableCell();
                tc1.Text = item.created.ToString();
                tc2.Text = item.dispatcher.fullName;
                tc3.Text = item.text;
                tr.Cells.Add(tc1);
                tr.Cells.Add(tc2);
                tr.Cells.Add(tc3);
                if(!item.isRead.Value)
                {
                    tc4.Text = "Nová správa";
                    tc4.CssClass = "bold";
                    tr.CssClass = "greenRow";
                }
                tr.Cells.Add(tc4);
                tableMessages.Rows.Add(tr);
            }
        }
        

        protected void btnSave_Click(object sender, EventArgs e)
        {

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