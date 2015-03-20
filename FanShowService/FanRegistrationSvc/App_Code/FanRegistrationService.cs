using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FanRegistrationService" in code, svc and config file together.
public class FanRegistrationService : IFanRegistrationService
{
    ShowTrackerEntities ste = new ShowTrackerEntities();
    public bool RegisterFan(FanLite f)
    {
        bool result = true;
        if (ste.FanLogins.Where(r => r.FanLoginUserName.Equals(f.userName)).Count() > 0)
        {
            result = false; //username already exists
        }
        else
        {
            RandomSeed k = new RandomSeed();
            int seed = k.GetSeed();
            PasswordHash phash = new PasswordHash();
            byte[] pass = phash.HashIt(f.password, seed.ToString());
            Fan newfan = new Fan();
            newfan.FanEmail = f.email;
            newfan.FanName = f.fanName;
            newfan.FanDateEntered = DateTime.Now;
            ste.Fans.Add(newfan);
            FanLogin newfanlogin = new FanLogin();
            newfanlogin.Fan = newfan;
            newfanlogin.FanLoginUserName = f.userName;
            newfanlogin.FanLoginHashed = pass;
            newfanlogin.FanLoginPasswordPlain = f.password;
            newfanlogin.FanLoginRandom = seed;
            newfanlogin.FanLoginDateAdded = DateTime.Now;
            ste.FanLogins.Add(newfanlogin);
            ste.SaveChanges();
        }
        return result;
    }

    public int FanLogin(string userName, string password)
    {
        int id = 0;
        LoginClass lc = new LoginClass(password, userName);
        id = lc.ValidateLogin();
        return id;
    }
}
