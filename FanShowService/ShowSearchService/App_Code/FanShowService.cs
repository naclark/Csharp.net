using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FanShowService" in code, svc and config file together.
public class FanShowService : IFanShowService
{
    ShowSearchModelContainer ss = new ShowSearchModelContainer();

    public List<Genre> GetMyGenres(int fanKey)
    {
        try
        {
            List<Genre> genres = new List<Genre>();
            var gens = (from f in ss.Fans
                        where f.FanKey.Equals(fanKey)
                        select f.Genres).First();
            foreach (var ge in gens)
            {
                Genre g = new Genre();
                g.GenreName = ge.GenreName;
                g.GenreKey = ge.GenreKey;
                g.GenreDescription = ge.GenreDescription;
                genres.Add(g);
            }
            return genres;
        }
        catch
        {
            return null;
        }
    }

    public List<Artist> GetMyArtists(int fanKey)
    {
        try
        {
            var arts = (from i in ss.Fans
                         where i.FanKey.Equals(fanKey)
                         select i.Artists).First();
            List<Artist> artists = new List<Artist>();
            foreach (var ar in arts)
            {
                Artist a = new Artist();
                a.ArtistName = ar.ArtistName;
                a.ArtistKey = ar.ArtistKey;
                a.ArtistEmail = ar.ArtistEmail;
                a.ArtistWebPage = ar.ArtistWebPage;
                artists.Add(a);
            }
            return artists;
        }
        catch
        {
            return null;
        }
    }

    public List<Genre> GetGenres()
    {
        try
        {
            List<Genre> genres = new List<Genre>();
            var gens = from f in ss.Genres
                        select f;
            foreach (var ge in gens)
            {
                Genre g = new Genre();
                g.GenreName = ge.GenreName;
                g.GenreKey = ge.GenreKey;
                g.GenreDescription = ge.GenreDescription;
                genres.Add(g);
            }
            return genres;
        }
        catch
        {
            return null;
        }
    }


    public List<Artist> GetArtists()
    {
        try
        {
            var arts = from i in ss.Artists
                        select i;
            List<Artist> artists = new List<Artist>();
            foreach (var ar in arts)
            {
                Artist a = new Artist();
                a.ArtistName = ar.ArtistName;
                a.ArtistKey = ar.ArtistKey;
                a.ArtistEmail = ar.ArtistEmail;
                a.ArtistWebPage = ar.ArtistWebPage;
                artists.Add(a);
            }
            return artists;
        }
        catch
        {
            return null;
        }
    }


    public List<ShowLite> HomepageShows(int fanKey)
    {

        /*
         * select distinct s.ShowKey, ShowName from Show s inner join ShowDetail sd on s.Showkey = sd.ShowKey
	left join FanArtist fa on sd.ArtistKey = fa.ArtistKey 
	inner join ArtistGenre ag on sd.ArtistKey = ag.ArtistKey 
	left join FanGenre fg on ag.GenreKey = fg.GenreKey 
	where fa.FanKey = 20 or fg.FanKey = 20
         * */


        try
        {
            List<Artist> arts = GetMyArtists(fanKey);
            List<Genre> gens = GetMyGenres(fanKey);
            List<Show> artShow = new List<Show>();
            foreach (var a in arts)
            {
                var shws = from show in ss.Shows
                           from sd in show.ShowDetails
                           where sd.ArtistKey == a.ArtistKey
                           select show;
                artShow.AddRange(shws.ToList());
            }
            List<Show> genShow = new List<Show>();
            foreach (var g in gens)
            {
                var shws = from show in ss.Shows
                           from sd in show.ShowDetails
                           from ag in sd.Artist.Genres
                           where ag.GenreKey == g.GenreKey
                           select show;
                genShow.AddRange(shws.ToList());
            }
            var result = artShow.Union(genShow);
            List<ShowLite> myShows = new List<ShowLite>();
            foreach (var sd in result)
            {
                ShowLite sh = new ShowLite();
                sh.ShowName = sd.ShowName;
                sh.ShowDate = sd.ShowDate;
                sh.ShowTime = sd.ShowTime;
                sh.ArtistName = sd.ShowDetails.First().Artist.ArtistName;
                sh.VenueName = sd.Venue.VenueName;
                sh.ShowTicketInfo = sd.ShowTicketInfo;
                myShows.Add(sh);
            }
            return myShows;
        }
        catch
        {
            return null;
        }
    }

    public List<Venue> GetVenues()
    {
        var vens = from v in ss.Venues
                   orderby v.VenueName
                   select v;
        List<Venue> venues = new List<Venue>();
        foreach (var vn in vens)
        {
            Venue v = new Venue();
            v.VenueName = vn.VenueName;
            v.VenueAddress = vn.VenueAddress;
            v.VenueAgeRestriction = vn.VenueAgeRestriction;
            v.VenueCity = vn.VenueCity;
            v.VenueEmail = vn.VenueEmail;
            v.VenueKey = vn.VenueKey;
            v.VenuePhone = vn.VenuePhone;
            v.VenueState = vn.VenueState;
            v.VenueWebPage = vn.VenueWebPage;
            v.VenueZipCode = vn.VenueZipCode;
            venues.Add(v);
        }
        return venues;
    }

    public bool FollowGenre(int genreKey, int fanKey)
    {
        bool result = true;
        try
        {
            var myFan = (from i in ss.Fans
                       where i.FanKey.Equals(fanKey)
                       select i).First();
            var myGenre = (from i in ss.Genres
                               where i.GenreKey.Equals(genreKey)
                               select i).First();
            myFan.Genres.Add(myGenre);
            ss.SaveChanges();
        }
        catch
        {
            result = false;
        }
        return result;
    }

    public bool FollowArtist(int artistKey, int fanKey)
    {
        bool result = true;
        try
        {
            var myFan = (from i in ss.Fans
                         where i.FanKey.Equals(fanKey)
                         select i).First();
            var myArtist = (from i in ss.Artists
                           where i.ArtistKey.Equals(artistKey)
                           select i).First();
            myFan.Artists.Add(myArtist);
            ss.SaveChanges();
        }
        catch
        {
            result = false;
        }
        return result;
    }

    public List<ShowLite> SearchShows(string query, int mode)
    {
        //Mode:
        //1 - Search by artist name
        //2 - Search by genre
        //3 - Search by venue
        query = query.ToLower();
        var result = new List<ShowLite>();
        switch (mode)
        {
            case 1:
                var artShows = from s in ss.Shows
                               from sd in s.ShowDetails
                               where sd.Artist.ArtistName.ToLower().Contains(query)
                               select s;
                foreach (var s in artShows)
                {
                    ShowLite sh = new ShowLite();
                    sh.ShowName = s.ShowName;
                    sh.ShowDate = s.ShowDate;
                    sh.ShowTime = s.ShowTime;
                    sh.ArtistName = s.ShowDetails.First().Artist.ArtistName;
                    sh.VenueName = s.Venue.VenueName;
                    sh.ShowTicketInfo = s.ShowTicketInfo;
                    result.Add(sh);
                }
                break;
            case 2:
                var genShows = from s in ss.Shows
                               from sd in s.ShowDetails
                               from g in sd.Artist.Genres
                               where g.GenreName.ToLower().Contains(query)
                               select s;
                foreach (var s in genShows)
                {
                    ShowLite sh = new ShowLite();
                    sh.ShowName = s.ShowName;
                    sh.ShowDate = s.ShowDate;
                    sh.ShowTime = s.ShowTime;
                    sh.ArtistName = s.ShowDetails.First().Artist.ArtistName;
                    sh.VenueName = s.Venue.VenueName;
                    sh.ShowTicketInfo = s.ShowTicketInfo;
                    result.Add(sh);
                }
                break;
            case 3:
                var venShows = from s in ss.Shows
                               where s.Venue.VenueName.ToLower().Contains(query)
                               select s;
                foreach (var s in venShows)
                {
                    ShowLite sh = new ShowLite();
                    sh.ShowName = s.ShowName;
                    sh.ShowDate = s.ShowDate;
                    sh.ShowTime = s.ShowTime;
                    sh.ArtistName = s.ShowDetails.First().Artist.ArtistName;
                    sh.VenueName = s.Venue.VenueName;
                    sh.ShowTicketInfo = s.ShowTicketInfo;
                    result.Add(sh);
                }
                break;
        }
        return result;
    }
}

