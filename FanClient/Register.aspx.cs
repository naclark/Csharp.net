using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //Instantiate service.
        RegistrationLoginService.FanRegistrationServiceClient rc =
            new RegistrationLoginService.FanRegistrationServiceClient();

        RegistrationLoginService.FanLite fanLite = new RegistrationLoginService.FanLite();

        //Put form values into VenueLite properties.
        fanLite.email = txtEmail.Text;
        fanLite.fanName = txtFanName.Text;
        fanLite.password = txtConfirm.Text;
        fanLite.userName = txtUserName.Text;

        //Register via the service.
        bool result = rc.RegisterFan(fanLite);
        if (result)
        {
            lblResult.Text = "Registration successful.";
        }
        else
        {
            lblResult.Text = "Registration failed.";
        }
    }
}