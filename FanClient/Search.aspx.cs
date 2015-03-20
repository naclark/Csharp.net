using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Id"] == null)
        {
            Button logout = (Button)Master.FindControl("btnLogout");
            logout.Visible = false;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtQuery.Text.Length < 3 || ddlSearchType.SelectedIndex == 0)
        {
            lblError.Text = "Please select a type of search and type in at least 3 characters.";
        }
        else
        {
            FanShowService.FanShowServiceClient fc = new FanShowService.FanShowServiceClient();
            FanShowService.ShowLite[] results = fc.SearchShows(txtQuery.Text, Int32.Parse(ddlSearchType.SelectedValue));
            grdShows.DataSource = results;
            grdShows.DataBind();
        }
    }
}