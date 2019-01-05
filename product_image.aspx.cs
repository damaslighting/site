using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class product_image : System.Web.UI.Page
{
    public DataSet ds = new DataSet();
    Utility ut = new Utility();
    public string catname, id, img;
    public DataTable dt_product, dt_subcat = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        dt_product = ut.GET_DATA_TAB1("select img from gallimage");
    }
}
