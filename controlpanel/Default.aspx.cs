using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_msg.Text = " "; 
    } 

    protected void btn_login_Click(object sender, ImageClickEventArgs e)
    {
        var adminData = new AdminLogin().get_adin_login(txt_username.Text, txt_password.Text);

		foreach (AdminLogin dr in adminData.ToList())
        {
            if ((dr.username == txt_username.Text) && (dr.password == txt_password.Text))
            {
                Session["adminctrl"] = txt_username.Text;
                Response.Redirect("home.aspx");
            }
        }
        lbl_msg.Text = "Invalid authonication!"; 

    }

}
