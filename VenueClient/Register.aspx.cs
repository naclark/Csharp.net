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
        RegistrationLoginService.VenueRegistrationServiceClient rc =
            new RegistrationLoginService.VenueRegistrationServiceClient();

        RegistrationLoginService.VenueLite venLite = new RegistrationLoginService.VenueLite();

        //Put form values into VenueLite properties.
        venLite.Address = txtAddress.Text;
        venLite.AgeRestriction = Convert.ToInt32(ddlAge.SelectedValue);
        venLite.City = txtCity.Text;
        venLite.Email = txtEmail.Text;
        venLite.Password = txtConfirm.Text;
        venLite.Phone = txtPhone.Text;
        venLite.State = txtState.Text;
        venLite.UserName = txtUserName.Text;
        venLite.VenueName = txtVenueName.Text;
        venLite.WebPage = txtWebPage.Text;
        venLite.ZipCode = txtZip.Text;

        //Register via the service.
        bool result = rc.RegisterVenue(venLite);
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