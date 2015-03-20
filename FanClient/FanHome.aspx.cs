using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FanHome : System.Web.UI.Page
{
    FanShowService.FanShowServiceClient fsc = new FanShowService.FanShowServiceClient();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Id"] == null)
        {
            Response.Redirect("Default.aspx");
        }

        if (!IsPostBack)
        {
            FanShowService.ShowLite[] myShows = fsc.HomepageShows((int)Session["Id"]);
            grdShows.DataSource = myShows;
            grdShows.DataBind();
        }
    }
}