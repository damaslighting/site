using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class admin_changepassword : System.Web.UI.Page
{
    AdminLogin obj_action = new AdminLogin();

    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_msg.Text= "";
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txt_useName.Text) || string.IsNullOrEmpty(txt_newPass.Text) || string.IsNullOrEmpty(txt_oldPassword.Text))
            return;

        var userData = obj_action.get_adin_login(txt_useName.Text, txt_oldPassword.Text);
        if (userData.Count() == 0)
        {
            lbl_msg.Text = "Incurrect username or password!";
            return;
        }

        //update_user
		foreach (AdminLogin dr in userData.ToList())
        {
            var userDD = obj_action.get_admin_user(dr.username);

			//AdminLogin usr = userDD.Single(p => p.username == dr.username);
            //usr.password = txt_newPass.Text;
            obj_action.change_admin_user_password(dr.username, txt_newPass.Text);

            lbl_msg.Text = "Password Changed Successfully";
            txt_confirmPass.Text = "";
            txt_newPass.Text = "";
            txt_oldPassword.Text = "";
            txt_useName.Text = "";
        }
    }   
}
