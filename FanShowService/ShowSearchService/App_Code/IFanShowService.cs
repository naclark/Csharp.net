using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFanShowService" in both code and config file together.
[ServiceContract]
public interface IFanShowService
{
    [OperationContract]
    List<Genre> GetMyGenres(int fanKey);

    [OperationContract]
    List<Artist> GetMyArtists(int fanKey);

    [OperationContract]
    List<ShowLite> HomepageShows(int fanKey);

    [OperationContract]
    List<Artist> GetArtists();

    [OperationContract]
    List<Genre> GetGenres();

    [OperationContract]
    List<Venue> GetVenues();

    [OperationContract]
    bool FollowGenre(int genreKey, int fanKey);

    [OperationContract]
    bool FollowArtist(int artistKey, int fanKey);

    [OperationContract]
    List<ShowLite> SearchShows(string query, int mode);
}

public class ShowLite
{
    [DataMember]
    public string ShowName { set; get; }

    [DataMember]
    public DateTime ShowDate { set; get; }

    [DataMember]
    public TimeSpan ShowTime { set; get; }

    [DataMember]
    public string ArtistName { set; get; }

    [DataMember]
    public string VenueName { set; get; }

    [DataMember]
    public string ShowTicketInfo { set; get; }
}