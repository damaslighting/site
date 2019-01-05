using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Mail;
using System.Linq;

public partial class Admin_fp : System.Web.UI.Page
{ 
    Cls_tools obj_tools = new Cls_tools();

    protected void Page_Load(object sender, EventArgs e)
    {
        Server.ScriptTimeout = 600; 
        Literal1.Text = "";  
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text == "")
        {
            Literal1.Text = "Please Enter Email Id";
            TextBox2.Focus();
            return;
        }
        else
        {
			var data_admin = new AdminLogin().get_admin_user(TextBox2.Text);

            if (data_admin.Count() == 0)
            {
                Literal1.Text = "Incorrect email";
                TextBox2.Focus();
                return;
            }
            else
            {
				foreach (AdminLogin dr in data_admin.ToList())
                {
                    if (dr.email == TextBox2.Text)
                    {
						string message = "<table align=center><tr><td><b><u>Iftin Trading LLC - Password Request</u></b></td><tr></table>";
                        message = message + "<table align=center><tr><td>&nbsp;</td><tr></table>";
                        message = message + "<table align=center WIDTH=650><tr><td WIDTH=200>username : </td><td>" + dr.username + "</td></tr>";

                        message = message + "<tr><td WIDTH=200>Password : </td><td>" + dr.password + "</td></tr>";
						message = message + "<tr><td colspan=2><br>Thanks<br>Iftin Trading LLC Team </td></tr></table>";

						if (obj_tools.sendEmail("Iftin Trading LLC - Password Request", obj_tools.get_ToEmail(), "" + dr.email, "", message))
                        {
                            Literal1.Text = "Your Password has sent to your email address."; 
                          
                            TextBox2.Text = "";
                        } 
                    }
                    else
                        Literal1.Text = "Invalid email.";
                }
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
      
        TextBox2.Text = "";
        Response.Redirect("fp.aspx");
    }
}
