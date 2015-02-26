using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        RegistrationLoginService.VenueRegistrationServiceClient rc =
            new RegistrationLoginService.VenueRegistrationServiceClient();
        int id = rc.VenueLogin(txtUserName.Text, txtPassword.Text);
        if (id != 0)
        {
            Session["id"] = id;
            Response.Redirect("NewShow.aspx");
        }
        else
        {
            lblMessage.Text = "Invalid login.";
        }
    }
}