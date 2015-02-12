using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Front : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        LoginClass log = new LoginClass(txtPassword.Text, txtUserName.Text);
        int key = log.ValidateLogin();
        if (key != 0)
        {
            Session["UserKey"] = key;
            Response.Redirect("Welcome.aspx");
        }
        else
        {
            lblError.Text = "Invalid login.";
        }
    }
}