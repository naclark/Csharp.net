using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    ShowTrackerEntities showentities = new ShowTrackerEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var artists = from a in showentities.Artists
                          orderby a.ArtistName
                          select new { a.ArtistName, a.ArtistKey };
            DropDownList1.DataSource = artists.ToList();
            DropDownList1.DataTextField = "ArtistName";
            DropDownList1.DataValueField = "ArtistKey";
            DropDownList1.DataBind();
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int artist_key = Convert.ToInt32(DropDownList1.SelectedValue);
        var shows = from s in showentities.Shows
                  from d in showentities.ShowDetails
                  from a in showentities.Artists
                  from q in showentities.Venues
                  where a.ArtistName == DropDownList1.SelectedItem.Text && d.ArtistKey == artist_key && d.ShowKey == s.ShowKey && s.VenueKey == q.VenueKey
                    select new { a.ArtistName, q.VenueCity, q.VenueName, s.ShowName, s.ShowDate, d.ShowDetailArtistStartTime };
        GridView1.DataSource = shows.ToList();
        GridView1.DataBind();
    }
}