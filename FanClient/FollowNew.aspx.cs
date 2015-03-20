using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FollowNew : System.Web.UI.Page
{
    FanShowService.FanShowServiceClient fc = new FanShowService.FanShowServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Id"] == null) {
            Response.Redirect("Default.aspx");
        }
        if (!IsPostBack)
        {
            FillArtists();
            FillGenres();
        }
        
    }

    private void FillArtists()
    {
        List<FanShowService.Artist> myArts = fc.GetMyArtists((int)Session["Id"]).ToList();
        grdArtists.DataSource = myArts;
        grdArtists.DataBind();
        List<FanShowService.Artist> notMyArts = fc.GetArtists().Where(n => !myArts.Select(p => p.ArtistKey).Contains(n.ArtistKey)).ToList();
        ddlArtists.DataSource = notMyArts;
        ddlArtists.DataTextField = "ArtistName";
        ddlArtists.DataValueField = "ArtistKey";
        ddlArtists.DataBind();
    }

    private void FillGenres()
    {
        List<FanShowService.Genre> myGens = fc.GetMyGenres((int)Session["Id"]).ToList();
        grdGenres.DataSource = myGens;
        grdGenres.DataBind();
        List<FanShowService.Genre> notMyGens = fc.GetGenres().Where(n => !myGens.Select(p => p.GenreKey).Contains(n.GenreKey)).ToList();
        ddlGenres.DataSource = notMyGens;
        ddlGenres.DataTextField = "GenreName";
        ddlGenres.DataValueField = "GenreKey";
        ddlGenres.DataBind();
    }
    protected void btnFollow_Click(object sender, EventArgs e)
    {
        int key = (int)Session["Id"];
        if (!(ddlArtists.SelectedIndex == 0)) {
            //Artist is selected.
            if (!(ddlGenres.SelectedIndex == 0))
            {
                //Whoops! Genre is selected, too.
                lblResult.Text = "Please only select one at a time.";
            }
            else
            {
                bool result = fc.FollowArtist(Int32.Parse(ddlArtists.SelectedValue), key);
                if (result)
                {
                    lblResult.Text = "Successfully followed artist!";
                    FillArtists();
                }
                else
                {
                    lblResult.Text = "Could not follow artist.";
                }
            }
        }
        else if (!(ddlGenres.SelectedIndex == 0))
        {
            //Genre is selected, artist is not.
            bool result = fc.FollowGenre(Int32.Parse(ddlGenres.SelectedValue), key);
            if (result)
            {
                lblResult.Text = "Successfully followed genre!";
                FillGenres();
            }
            else
            {
                lblResult.Text = "Could not follow genre.";
            }
        }
        else
        {
            lblResult.Text = "Please select a genre or artist.";
        }
    }
}