using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Mail;

public class Cls_tools
{
	public Cls_tools()
	{ 
	}

    public string get_ToEmail()
    {
        return "info@prosonic-mea.com";
    }
    public string get_FromEmail()
    {
        return "info@prosonic-mea.com";
    }
    public string get_CCEmail()
    {
        return "info@prosonic-mea.com";
    }
    public string get_BCCEmail()
    {
        return "js@infobahnworld.com";
    }

    public string getFormateddate(String dbDate)
    {
        string formateDate = "";

        DateTime dt = new DateTime();
        if (!String.IsNullOrEmpty(dbDate))
        {
            try
            {
                dt = Convert.ToDateTime(dbDate);
                formateDate = "" + dt.Day + " " + getmonth(dt.Month) + " " + dt.Year;
            }
            catch (Exception errr) { formateDate = ""; }
        }
        return formateDate;
    }

    public string getFormateddate_time(String dbDate)
    {
        string formateDate = "";

        DateTime dt = new DateTime();
        if (!String.IsNullOrEmpty(dbDate))
        {
            try
            {
                dt = Convert.ToDateTime(dbDate);
                string strAPM="AM";
                int stTime = dt.Hour;

                if (dt.Hour>11)
                    strAPM = "PM";

                if (dt.Hour > 12)
                    stTime = (stTime - 12);


                formateDate = "" + stTime + ":" + dt.Minute + "" + strAPM + ", " + dt.Day + " " + getmonth(dt.Month);
            }
            catch (Exception errr) { formateDate = ""; }
        }
        return formateDate;
    }
    public bool sendEmail(string subject, string fromMail, string tomail, string cc, string body)
    {
        string message = "";
        MailMessage msgMail = new MailMessage();
        msgMail.To = tomail;
        msgMail.Bcc = cc;
        msgMail.From = fromMail;
        msgMail.Subject = subject;

        message = "<html><head></head><body>";
        message += body;
        message += " </body></html>";

        msgMail.BodyFormat = MailFormat.Html;
        msgMail.Body = message;

        try
        {
            SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
            SmtpMail.Send(msgMail);
        }
        catch (Exception er) { return false; }

        return true;
    }
    private string getmonth(int intmonth)
    {
        switch (intmonth)
        {
            /*  case 1: return "Jan";
            case 2: return "Feb";
            case 3: return "Mar";
            case 4: return "Apr";
            case 5: return "May";
            case 6: return "Jun";
            case 7: return "Jul";
            case 8: return "Aug";
            case 9: return "Sep";
            case 10: return "Oct";
            case 11: return "Nov";
            case 12: return "Dec";*/

            case 1: return "January";
             case 2: return "February";
             case 3: return "March";
             case 4: return "April";
             case 5: return "May";
             case 6: return "June";
             case 7: return "July";
             case 8: return "August";
             case 9: return "September";
             case 10: return "October";
             case 11: return "November";
             case 12: return "December";
        }

        return "";
    }


}
