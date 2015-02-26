using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity.Validation;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NewShowService" in code, svc and config file together.
public class NewShowService : INewShowService
{
    ShowTrackerEntities ste = new ShowTrackerEntities();
    public bool AddArtist(Artist a)
    {
        bool result = true;
        try
        {
            Artist ar = new Artist();
            ar.ArtistName = a.ArtistName;
            //ar.ArtistGenres = a.ArtistGenres;
            ar.ArtistDateEntered = DateTime.Now;
            ar.ArtistEmail = a.ArtistEmail;
            ar.ArtistWebPage = a.ArtistWebPage;
            ste.Artists.Add(ar);
            ste.SaveChanges();
        }
        catch
        {
            result = false;
        }

        return result;
    }

    public bool AddShow(Show s, ShowDetail sd)
    {
        bool result = true;
        //try
        //{
            int key;
            Show sh = new Show();
            ShowDetail shd = new ShowDetail();
            if (sd.ArtistKey == 0)
            {
                key = ste.Artists.Max(a => a.ArtistKey);
            }
            else
            {
                key = int.Parse(sd.ArtistKey.ToString());
            }
            sh.VenueKey = s.VenueKey;
            shd.ArtistKey = key;
            sh.ShowName = s.ShowName;
            sh.ShowDate = s.ShowDate;
            sh.ShowTicketInfo = s.ShowTicketInfo;
            sh.ShowTime = s.ShowTime;
            sh.ShowDateEntered = DateTime.Now;
            ste.Shows.Add(sh);
            ste.SaveChanges();
            shd.ShowKey = sh.ShowKey;
            shd.ShowDetailAdditional = sd.ShowDetailAdditional;
            shd.ShowDetailArtistStartTime = sd.ShowDetailArtistStartTime;
            ste.ShowDetails.Add(shd);
            ste.SaveChanges();
        //}

        //catch //(System.Data.Entity.Validation.DbEntityValidationException e)
        //{
            /*foreach (var eve in e.EntityValidationErrors)
            {
                Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                foreach (var ve in eve.ValidationErrors)
                {
                    Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                        ve.PropertyName, ve.ErrorMessage);
                }
            }*/
        //    result = false;
        //}
        return result;
    }

    public List<Artist> GetArtists()
    {
        var arts = from a in ste.Artists
                   orderby a.ArtistName
                   select a;
        List<Artist> artists = new List<Artist>();
        foreach (var a in arts)
        {
            Artist ar = new Artist();
            ar.ArtistKey = a.ArtistKey;
            ar.ArtistName = a.ArtistName;
            ar.ArtistEmail = a.ArtistEmail;
            artists.Add(ar);
        }
        return artists;
    }

    public List<string> GetGenres()
    {
        var gens = from g in ste.Genres
                   orderby g.GenreName
                   select new { g.GenreName };
        List<String> genres = new List<string>();
        foreach (var g in gens)
        {
            genres.Add(g.GenreName);
        }
        return genres;
    }

    public List<Show> GetShows()
    {
        var shs = from s in ste.Shows
                  orderby s.ShowName
                  select s;
        List<Show> shows = new List<Show>();
        foreach (var sh in shs)
        {
            Show s = new Show();
            s.ShowName = sh.ShowName;
            s.ShowTicketInfo = sh.ShowTicketInfo;
            s.ShowTime = sh.ShowTime;
            s.ShowKey = sh.ShowKey;
            s.ShowDate = sh.ShowDate;
            s.ShowDateEntered = sh.ShowDateEntered;
            shows.Add(s);
        }
        return shows;
    }
}
