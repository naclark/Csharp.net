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
        if (!(Session["Id"] == null))
        {
            Response.Redirect("FanHome.aspx");
        }
        Button logout = (Button)Master.FindControl("btnLogout");
        logout.Visible = false;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        RegistrationLoginService.FanRegistrationServiceClient rc = new RegistrationLoginService.FanRegistrationServiceClient();
        int id = rc.FanLogin(txtUserName.Text, txtPassword.Text);
        if (id != 0)
        {
            Session["id"] = id;
            Response.Redirect("FanHome.aspx");
        }
        else
        {
            lblMessage.Text = "Invalid Login";
        }
    }
}