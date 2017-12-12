using Dopravio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dopravio_Web
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var response =  Authorization.Login(txtEmail.Text, txtPassword.Text);
            if(response.token != null)
            {
                Response.Redirect(Authorization.GetURL("HomeForm.aspx"));
            }
            else
            {
                lbError.Text = response.type;
                lbError.Style.Add("color", "red");
            }
        }
    }
}