using Dopravio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dopravio_Web
{
    public partial class RequestsForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CheckAccess();
            RequestsConnector rc = new RequestsConnector();
            var list = rc.get();
            foreach (var item in list)
            {
                TableRow tr = new TableRow();
                TableCell tc1 = new TableCell();
                TableCell tc2 = new TableCell();
                TableCell tc3 = new TableCell();
                TableCell tc4 = new TableCell();
                TableCell tc5 = new TableCell();
                TableCell tc6 = new TableCell();
                TableCell tc7 = new TableCell();
                tc1.Text = item.created.ToString();
                tc2.Text = item.state.ToString();
                tc3.Text = item.type.ToString();
                tc4.Text = item.priority.ToString();
                tc5.Text = item.message;
                tc6.Text = item.resultMessage != null ? item.resultMessage : "";
                tr.Cells.Add(tc1);
                tr.Cells.Add(tc2);
                tr.Cells.Add(tc3);
                tr.Cells.Add(tc4);
                tr.Cells.Add(tc5);
                tr.Cells.Add(tc6);
                if (item.state == Dopravio.Models.RequestState.NEW)
                {
                    var half = new Style();
                    half.Width = new Unit(40, UnitType.Percentage);
                    Button b = new Button();
                    b.ApplyStyle(half);
                    // b.OnClientClick = "$('#myModal').modal('show'); ";
                    b.ID = "decline" + item.id;
                    b.OnClientClick = "return openModal('decline', '" + item.id + "');";
                    b.CssClass = "btn btn-danger";
                    b.Text = "Zamietnuť";
                    b.Click += new EventHandler(decline_item);

                    Button b1 = new Button();

                    b1.ApplyStyle(half);
                    b1.CssClass = "btn btn-success buttonLeft";
                    b1.OnClientClick = "return openModal('accept', '" + item.id + "');";
                    b1.ID = "accept" + item.id;
                    b1.Text = "Akceptovať";
                    b1.Click += new EventHandler(accept_item);


                    tc7.Controls.Add(b1);
                    tc7.Controls.Add(b);
                }
                tr.Cells.Add(tc7);
                tableRequests.Rows.Add(tr);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            var id = int.Parse( lbId.Value);
            RequestsConnector rc = new RequestsConnector();
            var request = rc.get(id);
            var action = lbAction.Value;
            if( action == "decline")
            {
                request.state = Dopravio.Models.RequestState.DECLINED;
            }
            else
            {
                request.state = Dopravio.Models.RequestState.ACCEPTED;
            }
            request.resultMessage =  txtMessage.Text;
           var result =  rc.update(request);
            if ( result == "\"OK\"")
            {
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void decline_item(object sender, EventArgs e)
        {

        }

        protected void accept_item(object sender, EventArgs e)
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