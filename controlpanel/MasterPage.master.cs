using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_MasterPage : System.Web.UI.MasterPage
{
    string userid = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (String.IsNullOrEmpty(Session["adminctrl"].ToString()))
                    Response.Redirect("Default.aspx");
            }
            catch (Exception er) { Response.Redirect("Default.aspx"); }
        }

    }
    protected void btn_logout_Click(object sender, EventArgs e)
    {
        Session["adminctrl"] = "";
        Response.Redirect("Default.aspx");
    }
}
