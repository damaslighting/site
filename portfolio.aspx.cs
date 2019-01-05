using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class portfolio : System.Web.UI.Page
{
    Utility ut = new Utility();
    public DataSet ds = new DataSet();
    public string str;
    protected void Page_Load(object sender, EventArgs e)
    {
        ut.lstbind(ListView2, "select * from portfolio order by imageid asc");
    }
}
