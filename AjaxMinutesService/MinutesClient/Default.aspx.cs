using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clnBDay.SelectedDate = DateTime.Parse("12/21/2112");
            activateTimer();
        }
    }

    protected void activateTimer()
    {
        MinutesSvcRef.MinutesServiceClient mc = new MinutesSvcRef.MinutesServiceClient();
        DateTime sendDate = clnBDay.SelectedDate;
        int minutes = mc.GetMinutes(sendDate);
        lblMessage.Text = "Number of minutes until your selected date is " + minutes.ToString();
    }
    protected void btnJump_Click(object sender, EventArgs e)
    {
        DateTime yearSet = DateTime.Now;
        try
        {
            lblError.Text = "";
            yearSet = new DateTime(Convert.ToInt32(txtYear.Text), clnBDay.SelectedDate.Month, clnBDay.SelectedDate.Day);
        }
        catch
        {
            lblError.Text = "Put in a real year, please.";
        }
        clnBDay.TodaysDate = yearSet;
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        MinutesSvcRef.MinutesServiceClient mc = new MinutesSvcRef.MinutesServiceClient();
        DateTime sendDate = clnBDay.SelectedDate;
        int minutes = mc.GetMinutes(sendDate);
        lblMessage.Text = "Number of minutes until your selected date is " + minutes.ToString();
    }
    protected void clnBDay_SelectionChanged(object sender, EventArgs e)
    {
        activateTimer();
    }
}