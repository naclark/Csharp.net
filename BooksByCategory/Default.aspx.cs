using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    BookReviewDbEntities1 bookentities = new BookReviewDbEntities1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var cats = from c in bookentities.Categories
                       orderby c.CategoryName
                       select new { c.CategoryName, c.CategoryKey };

            DropDownList1.DataSource = cats.ToList();
            DropDownList1.DataTextField = "CategoryName";
            DropDownList1.DataValueField = "CategoryKey";
            DropDownList1.DataBind();
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var bks = from b in bookentities.Books
                  from c in b.Categories
                  from a in b.Authors
                  where c.CategoryName == DropDownList1.SelectedItem.Text
                  select new { b.BookTitle, b.BookISBN, a.AuthorName };
        GridView1.DataSource = bks.ToList();
        GridView1.DataBind();
    }
}