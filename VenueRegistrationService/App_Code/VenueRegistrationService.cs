using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VenueRegistrationService" in code, svc and config file together.
public class VenueRegistrationService : IVenueRegistrationService
{
    ShowTrackerEntities ste = new ShowTrackerEntities();
    public bool RegisterVenue(VenueLite r)
    {
        bool result = true;
        try
        {
            PasswordHash ph = new PasswordHash();
            RandomSeed rs = new RandomSeed();
            int code = rs.GetHashCode();
            byte[] hashed = ph.HashIt(r.Password, code.ToString());

            Venue ven = new Venue();
            ven.VenueName = r.VenueName;
            ven.VenueAddress = r.Address;
            ven.VenueCity = r.City;
            ven.VenueState = r.State;
            ven.VenueZipCode = r.ZipCode;
            ven.VenuePhone = r.Phone;
            ven.VenueEmail = r.Email;
            ven.VenueWebPage = r.WebPage;
            ven.VenueAgeRestriction = r.AgeRestriction;
            ste.Venues.Add(ven);
            VenueLogin vlg = new VenueLogin();
            vlg.Venue = ven;
            vlg.VenueLoginUserName = r.UserName;
            vlg.VenueLoginPasswordPlain = r.Password;
            vlg.VenueLoginRandom = code;
            vlg.VenueLoginHashed = hashed;
            vlg.VenueLoginDateAdded = DateTime.Now;
            ste.VenueLogins.Add(vlg);
            ste.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            result = false;
        }
        return result;
    }

    public int VenueLogin(string UserName, string Password)
    {
        int id = 0;

        LoginClass lc = new LoginClass(Password, UserName);
        id = lc.ValidateLogin();

        return id;
    }
}
