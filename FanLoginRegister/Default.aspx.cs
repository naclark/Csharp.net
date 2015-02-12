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
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        ShowTrackerEntities stfan = new ShowTrackerEntities();
        if (stfan.FanLogins.Where(r=> r.FanLoginUserName.Equals(txtUserName.Text)).Count() > 0) {
            lblErrorSuccess.Text = "That username already exists.";
        } else {
            RandomSeed k = new RandomSeed();
            int seed = k.GetSeed();
            PasswordHash phash = new PasswordHash();
            byte[] pass = phash.HashIt(txtConfirm.Text, seed.ToString());
            Fan newfan = new Fan();
            newfan.FanEmail = txtEmail.Text;
            newfan.FanName = txtLastName.Text + " " + txtFirstName.Text;
            newfan.FanDateEntered = DateTime.Now;
            stfan.Fans.Add(newfan);
            FanLogin newfanlogin = new FanLogin();
            newfanlogin.Fan = newfan;
            newfanlogin.FanLoginUserName = txtUserName.Text;
            newfanlogin.FanLoginHashed = pass;
            newfanlogin.FanLoginPasswordPlain = txtConfirm.Text;
            newfanlogin.FanLoginRandom = seed;
            newfanlogin.FanLoginDateAdded = DateTime.Now;
            stfan.FanLogins.Add(newfanlogin);           
            stfan.SaveChanges();
            lblErrorSuccess.Text = "You were successfully registered";
        }
    }
}