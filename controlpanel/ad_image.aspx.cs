﻿using System;
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

public partial class ad_image : System.Web.UI.Page
{
    DataSet dss = new DataSet();
    string searchtype;
    int id;
    Utility ut = new Utility();
    public string part2, rec1, rec2, rec3, rec4, folder2, rec5, rec6, rec7, rec8, rec9, rec10, rec11, rec12, rec13, folder, dat;
    public int get;
    public string buytype, pname, emirates, pid, location, propertytype, bedroom, path, proname;
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
            ut.gridbind(GridView1, "select * from gallimage order by imageid desc");
            ds1 = ut.returndataset("select * from gallimage order by imageid desc");
            Button1.Enabled = true;
            Button2.Enabled = false;
            Button3.Enabled = false;
        }
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ut.gridbind(GridView1, "select * from gallimage order by imageid desc");
        ds1 = ut.returndataset("select * from gallimage order by imageid desc");
    }
    public string Upload(FileUpload fpUp)
    {
        dat = DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("hhmmss").ToString();
        string ext;
        if (fpUp.HasFile)
        {
            ext = Path.GetExtension(fpUp.FileName).ToLower();
            folder = dat + ext;

            string ptimg = Server.MapPath("../img_small/" + folder);

            fpUp.SaveAs(ptimg);

            return folder;
        }
        return "noimage.jpg";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.FileName != "")
        {
            folder = Upload(FileUpload1);
        }
        else
        {
            folder = "noimage.jpg";
        }
        ut.GALLERY_ENTRY(0, 0, txttitle.Text, folder, "gallimageEntry");

        //ut.insRec("insert into galleryproject1(projectid,image)values(" + pid + ",'" + folder + "')");

        ut.gridbind(GridView1, "select * from gallimage order by imageid desc");
        ds1 = ut.returndataset("select * from gallimage order by imageid desc");
        lbl_msg.Text = "";
        txttitle.Text = "";
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        ut.gridbind(GridView1, "select * from gallimage order by imageid desc");
        ds1 = ut.returndataset("select * from gallimage order by imageid desc");

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text);
        int id = Convert.ToInt32(((Label)GridView1.Rows[e.RowIndex].FindControl("lblid")).Text);
        string mid = ((Label)GridView1.Rows[e.RowIndex].FindControl("lblimg")).Text;

        ut.insRec("delete gallimage where imageid=" + id + "");
        ut.gridbind(GridView1, "select * from gallimage order by imageid desc");
        ds1 = ut.returndataset("select * from gallimage order by imageid desc");

        if (File.Exists(Server.MapPath("../img_small/" + mid)))
            File.Delete(Server.MapPath("../img_small/" + mid));
        lbl_msg.Text = "";
        txttitle.Text = "";
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        ds1 = ut.returndataset("select * from gallimage order by imageid desc");

        ut.gridbind(GridView1, "select * from gallimage order by imageid desc");
    }
    public static string img123;
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        //int showid = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text.ToString());
        int showid = Convert.ToInt32(((Label)GridView1.SelectedRow.FindControl("lblid")).Text);
        img123 = ((Label)GridView1.SelectedRow.FindControl("lblimg")).Text;
        imageid = showid;
        ds = ut.returndataset("select * from gallimage where imageid=" + showid + "");
        txttitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
        //  DropDownList1.Text = ds.Tables[0].Rows[0]["imgfor"].ToString();
        ds1 = ut.returndataset("select * from gallimage order by imageid desc");
        //txttilte.Text = ds.Tables[0].Rows[0]["title"].ToString();
        Button1.Enabled = false;
        Button2.Enabled = true;
        Button3.Enabled = true;
        lbl_msg.Text = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (FileUpload1.FileName != "")
        {
            folder = Upload(FileUpload1);
            if (File.Exists(Server.MapPath("../img_small/" + img123)))
                File.Delete(Server.MapPath("../img_small/" + img123));

        }
        else
        {
            folder = img123;
        }

        ut.GALLERY_ENTRY(imageid, 0, txttitle.Text, folder, "gallimageUpdate");
        ds1 = ut.returndataset("select * from gallimage order by imageid desc");
        ut.gridbind(GridView1, "select * from gallimage order by imageid desc");
        lbl_msg.Text = "";
        txttitle.Text = "";
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
        ds1 = ut.returndataset("select * from gallimage order by imageid desc");

    }
}
