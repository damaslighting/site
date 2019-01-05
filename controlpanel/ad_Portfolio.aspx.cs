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
using System.IO;

public partial class ad_Portfolio : System.Web.UI.Page
{
    DataSet dss = new DataSet();
    string searchtype;
    int id;
    Utility ut = new Utility();
    public string part2, rec1, rec2, rec3, rec4, folder2, rec5, rec6, rec7, rec8, rec9, rec10, rec11, rec12, rec13, folder, dat;
    public int get;
    public string buytype, pname, emirates, pid, location, propertytype, bedroom, path, proname,img;
    public static int proid, projectid, imageid;
    public double price;
    public int cnt = 0, cnt1 = 0;
    public DataSet ds1 = new DataSet();
    public DataSet ds = new DataSet();
    DataSet tempds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        pname = "";
        if (!Page.IsPostBack)
        {

            lbl_msg.Text = "";
            ut.gridbind(GridView1, "select * from portfolio order by imageid desc");
            ds1 = ut.returndataset("select * from portfolio order by imageid desc");
            Button1.Enabled = true;
            Button2.Enabled = false;
            Button3.Enabled = false;
        }
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ut.gridbind(GridView1, "select * from portfolio order by imageid desc");
        ds1 = ut.returndataset("select * from portfolio order by imageid desc");
    }
    //public string Upload(FileUpload fpUp)
    //{
    //    dat = DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("hhmmss").ToString();
    //    string ext;
    //    if (fpUp.HasFile)
    //    {
    //        ext = Path.GetExtension(fpUp.FileName).ToLower();
    //        folder = dat + ext;

    //        string ptimg = Server.MapPath("../img_small/" + folder);
    //        fpUp.SaveAs(ptimg);
    //        string ptorg = Server.MapPath("../img_big/" + folder);
    //        fpUp.SaveAs(ptorg);
    //        return folder;
    //    }
    //    return "noimage.jpg";
    //}

    private void Upload(FileUpload flnm, int widthsmall, int heightsmall, int widthbig, int heightbig)
    {

        string path = "", folder = "", p1 = "", f1 = "", p2 = "", f2 = "", p3 = "", f3 = "";
        if (flnm.HasFile)
        {
            folder = dat + flnm.FileName.ToString();
            //Directory.CreateDirectory(Server.MapPath("galimg\\" + folder));
            //Directory.CreateDirectory(Server.MapPath("galorg\\" + folder));
            path = Server.MapPath("..//img_small\\" + flnm.FileName);
            string path1 = Server.MapPath("..//img_small\\" +folder );
            string pathorg = Server.MapPath("..//img_big\\" + folder);
            string path2 = Server.MapPath("..//img_big\\" + folder);
            flnm.SaveAs(pathorg);
            flnm.SaveAs(path);
            Session.Add("ImagePath", folder);
            System.IO.File.Move(@path, @path1);
            System.IO.File.Move(@pathorg, @path2);
            string Si = "Full";
            ut.ResizeImage(path2,widthbig, heightbig, true);
            ut.ResizeImage(path1,widthsmall, heightsmall, true);

        }

    }





    protected void Button1_Click(object sender, EventArgs e)
    {
        dat = DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("hhmmss").ToString();
        //if (FileUpload1.FileName != "")
        //{
        //    folder =Upload(FileUpload1);
        //}
        //else
        //{
        //    folder = "noimage.jpg";
        //}
        if (FileUpload1.FileName != "")
        {
            folder = dat + FileUpload1.FileName;
        }
        else
        {
            folder = "noimage.jpg";
        }
        ut.GALLERY_ENTRY(0, 0, txttitle.Text, folder, "portfolioEntry");
        Upload(FileUpload1, 200, 200, 800, 600);
        //ut.insRec("insert into galleryproject1(projectid,image)values(" + pid + ",'" + folder + "')");

        ut.gridbind(GridView1, "select * from portfolio order by imageid desc");
        ds1 = ut.returndataset("select * from portfolio order by imageid desc");
        lbl_msg.Text = "";
        txttitle.Text = "";
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        ut.gridbind(GridView1, "select * from portfolio order by imageid desc");
        ds1 = ut.returndataset("select * from portfolio order by imageid desc");

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text);
        int id = Convert.ToInt32(((Label)GridView1.Rows[e.RowIndex].FindControl("lblid")).Text);
        string mid = ((Label)GridView1.Rows[e.RowIndex].FindControl("lblimg")).Text;

        ut.insRec("delete portfolio where imageid=" + id + "");
        ut.gridbind(GridView1, "select * from portfolio order by imageid desc");
        ds1 = ut.returndataset("select * from portfolio order by imageid desc");
        rec8 = ds1.Tables[0].Rows[0]["img"].ToString();
        if (rec8 != "spblank.gif" && rec8 != "")
        {
            ut.deleteFile(Server.MapPath("..\\img_small/" + rec8), rec8);
            ut.deleteFile(Server.MapPath("..\\img_big/" + rec8), rec8);
        }
        //if (File.Exists(Server.MapPath("../img_small/" + mid)))
        //    File.Delete(Server.MapPath("../img_small/" + mid));

        //if (File.Exists(Server.MapPath("../img_big/" + mid)))
        //    File.Delete(Server.MapPath("../img_big/" + mid));
        lbl_msg.Text = "";
        txttitle.Text = "";
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        ds1 = ut.returndataset("select * from portfolio order by imageid desc");

        ut.gridbind(GridView1, "select * from portfolio order by imageid desc");
    }
    public static string img123;
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        //int showid = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text.ToString());
        int showid = Convert.ToInt32(((Label)GridView1.SelectedRow.FindControl("lblid")).Text);
        img123 = ((Label)GridView1.SelectedRow.FindControl("lblimg")).Text;
        imageid = showid;
        ds = ut.returndataset("select * from portfolio where imageid=" + showid + "");
        txttitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
        //  DropDownList1.Text = ds.Tables[0].Rows[0]["imgfor"].ToString();
        ds1 = ut.returndataset("select * from portfolio order by imageid desc");
        //txttilte.Text = ds.Tables[0].Rows[0]["title"].ToString();
        Button1.Enabled = false;
        Button2.Enabled = true;
        Button3.Enabled = true;
        lbl_msg.Text = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //if (FileUpload1.FileName != "")
        //{
        //    folder = Upload(FileUpload1);
        //    if (File.Exists(Server.MapPath("../img_small/" + img123)))
        //        File.Delete(Server.MapPath("../img_small/" + img123));
        //    if (File.Exists(Server.MapPath("../img_big/" + img123)))
        //        File.Delete(Server.MapPath("../img_big/" + img123));
        //}
        //else
        //{
        //    folder = img123;
        //}
        int showid = Convert.ToInt32(((Label)GridView1.SelectedRow.FindControl("lblid")).Text);
        ds = ut.returndataset("select * from portfolio where imageid=" + showid + "");
        if (ds.Tables[0].Rows.Count > 0)
        {
            img = ds.Tables[0].Rows[0]["img"].ToString();
        }
        if (FileUpload1.FileName != "")
        {
            folder = dat + FileUpload1.FileName;
            img = ds.Tables[0].Rows[0]["img"].ToString();
            if (img != "spblank.gif" && img != "")
            {
                ut.deleteFile(Server.MapPath("..\\img_small/" + img), img);
                ut.deleteFile(Server.MapPath("..\\img_big/" + img), img);
            }
        }
        else
        {

            folder = img.ToString();
        }

        ut.GALLERY_ENTRY(imageid, 0, txttitle.Text, folder, "portfolioUpdate");
        ds1 = ut.returndataset("select * from portfolio order by imageid desc");
        ut.gridbind(GridView1, "select * from portfolio order by imageid desc");
        lbl_msg.Text = "";
        txttitle.Text = "";
        Upload(FileUpload1, 200, 200, 800, 600);
        Button1.Enabled = true;
        Button2.Enabled = false;
        Button3.Enabled = false;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Button1.Enabled = true;
        Button2.Enabled = false;
        Button3.Enabled = false;
        lbl_msg.Text = "";
        txttitle.Text = "";
        ds1 = ut.returndataset("select * from portfolio order by imageid desc");

    }
}
