using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReviewerRegistrationService" in code, svc and config file together.
public class ReviewerRegistrationService : IReviewerRegistrationService
{
    BookReviewDbEntities db = new BookReviewDbEntities();

    public bool RegisterReviewer(ReviewerLite r)
    {
        bool result = true;
        try
        {
            PasswordHash ph = new PasswordHash();
            RandomSeed rs = new RandomSeed();
            int code = rs.GetSeed();
            byte[] hashed = ph.HashIt(r.Password, code.ToString());

            Reviewer rev = new Reviewer();
            rev.ReviewerFirstName = r.FirstName;
            rev.ReviewerLastName = r.LastName;
            rev.ReviewerUserName = r.UserName;
            rev.ReviewerEmail = r.Email;
            rev.ReviewPlainPassword = r.Password;
            rev.ReviewerKeyCode = code;
            rev.ReviewerHashedPass = hashed;
            rev.ReviewerDateEntered = DateTime.Now;
            db.Reviewers.Add(rev);
            db.SaveChanges();
        }
        catch
        {
            result = false;
        }
        return result;
    }

    public int ReviewerLogin(string userName, string password)
    {
        int id = 0;
        LoginClass lc = new LoginClass(password, userName);
        id = lc.ValidateLogin();
        return id;
    }
}
