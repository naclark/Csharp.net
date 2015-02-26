using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewShow : System.Web.UI.Page
{
    NewShowService.NewShowServiceClient nssc =
        new NewShowService.NewShowServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Id"] == null) 
        {
            Response.Redirect("Default.aspx");
        }
        if (!IsPostBack)
        {
            FillArtistList();
        }
    }

    private void FillArtistList()
    {
        List<NewShowService.Artist> artists = new List<NewShowService.Artist>();
        artists = nssc.GetArtists().ToList();
        ddlArtist.DataSource = artists;
        ddlArtist.DataTextField = "ArtistName";
        ddlArtist.DataValueField = "ArtistKey";
        ddlArtist.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //get the session value (the users id)
        int key = (int)Session["Id"];

        //create a new instance of the Review class
        //we get to it through the ReviewService object
        NewShowService.Show shw = new NewShowService.Show();
        //if the text box is not empty use the text in the text box
        //create new ShowDetail and Artist objects
        NewShowService.ShowDetail shd = new NewShowService.ShowDetail();
        NewShowService.Artist a = new NewShowService.Artist();
        //Are they trying to put in a new artist?
        if (!txtArtistName.Text.Equals(""))
        {

            //Take form data and use it with service's AddArtist method.
            a.ArtistName = txtArtistName.Text;
            a.ArtistEmail = txtArtistEmail.Text;
            nssc.AddArtist(a);

        }
        else
        {
            //Get artist key from dropdown.
            a.ArtistKey = int.Parse(ddlArtist.SelectedValue.ToString());
        }
        
        //add all the values to the show object
        shw.ShowDate = showDate.SelectedDate;
        shw.VenueKey = key;
        shw.ShowDateEntered = DateTime.Now;
        shw.ShowName = txtTitle.Text;
        shw.ShowTicketInfo = txtTicketInfo.Text;
        shw.ShowTime = TimeSpan.Parse(txtShowTime.Text);

        //assign some values to ShowDetail
        shd.ShowDetailAdditional = txtShowDetails.Text;
        shd.ArtistKey = a.ArtistKey;
        shd.ShowDetailArtistStartTime = TimeSpan.Parse(txtArtistTime.Text);

        //pass the show to the AddShow method
        bool result = nssc.AddShow(shw, shd);
        //check the result to see if it wrote.
        if (result)
        {
            lbResult.Text = "Show Added";
        }
        else
        {
            lbResult.Text = "Show failed to save";
        }
    }
}