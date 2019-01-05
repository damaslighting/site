using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Mail;
using System.IO;

public partial class contactus : System.Web.UI.Page
{
    public string message, findus, flg, rec1, rec2;
    public int id, fl;
    public string name, phno, company, country, city, email, comment, dt, enq;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string dat = DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("hhmmss").ToString();
        MailMessage msgMail = new MailMessage();

        if (TextBox1.Text != "" || TextBox2.Text != "" || TextBox3.Text != "" || TextBox4.Text != "")
        {
            msgMail.To = "info@damaslighting.ae";
            //  msgMail.Cc = "js@infobahnworld.com";
            msgMail.From = "info@damaslighting.ae";

            message = "<html><head></head><body>";
            message = message + "<table align=center><tr><td><b><u>Enquiry Form</u></b></td><tr></table>";
            message = message + "<table align=center><tr><td>&nbsp;</td><tr></table>";
            //  message = message + "<table align=center WIDTH=650><tr><td WIDTH=200>Enquiry Form : </td></tr><tr><td WIDTH=200>Name :              </td><td>" + TextBox1.Text + "</td></tr>";
            message = message + "<table align=center WIDTH=650><tr><td WIDTH=200>Name : </td><td>" + TextBox1.Text + "</td></tr>";


            message = message + "<tr><td WIDTH=200>E-Mail : </td><td>" + TextBox2.Text + "</td></tr>";
            message = message + "<tr><td WIDTH=200>Telephone : </td><td>" + TextBox3.Text + "</td></tr>";
            message = message + "<tr><td WIDTH=200>Comment/Enquiry : </td><td>" + TextBox4.Text + "</td></tr>";


            message = message + "</table></body></html>";
            msgMail.Subject = " - Enquiry";

            try
            {
                msgMail.BodyFormat = MailFormat.Html;
                msgMail.Body = message;
                SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["MySMTPServer"];
                SmtpMail.Send(msgMail);
            }
            catch (Exception ex)
            {

            }
            //Response.Write(message);


            ScriptManager.RegisterStartupScript(this, this.GetType(), "strScript", "alert('Your enquiry has been submitted successfully.'); ", true);
            TextBox1.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox2.Text = "";
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "strScript", "alert('Please Enter Your Name \\n Email Id \\n Phone No \\n Message'); ", true);
        }

    }
}
