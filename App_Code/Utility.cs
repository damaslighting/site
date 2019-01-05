using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Linq;
using System.Web.Mail;
using System.Web.Configuration;


/// <summary>
/// Summary description for Utility
/// </summary>
public class Utility
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    string _ConnectionString;
    public Utility()
    {
        try
        {
			_ConnectionString = WebConfigurationManager.ConnectionStrings["CNN_STR"].ConnectionString;
            con = new SqlConnection(_ConnectionString);
            con.Open();
        }
        catch (Exception)
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con = new SqlConnection(_ConnectionString);
            con.Open();
        }
    }
    public int extensionValidationimg(FileUpload flnm)
    {

        int chk;
        //string p = @"C:\Users\Sam\Documents\Test.txt";
        string ex = Path.GetExtension(flnm.FileName).ToLower();
        // string e = Path.GetExtension(p);
        if (ex == ".jpg" || ex == ".jpeg" || ex == ".gif" || ex == ".bmp" || ex == ".tif" || ex == ".png")
        {
            return chk = 1;
        }
        else
        {
            return chk = 0;
        }

    }
    public DataTable GET_DATA_TAB1(string PROC)
    {
        DataTable DT = new DataTable();

        try
        {
            cmd = new SqlCommand(PROC, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(DT);
        }
        catch (Exception ex)
        {
            DT = null;
        }
        finally
        {
            con.Close();
        }
        return DT;
    }
    public int retID(string qry)
    {
        int ans;

        SqlCommand cmd = new SqlCommand(qry, con);
        if (cmd.ExecuteScalar() == DBNull.Value)
            ans = 0;
        else
            ans = Convert.ToInt32(cmd.ExecuteScalar());

        return ans;
    }
    public string retStr(string qry)
    {
        string ans;

        SqlCommand cmd = new SqlCommand(qry, con);
        if (cmd.ExecuteScalar() == DBNull.Value)
            ans = "0";
        else
            ans = Convert.ToString(cmd.ExecuteScalar());

        return ans;
    }
    public void lstbind(ListView gd, string str)
    {

        DataSet ds = new DataSet();
        da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        gd.DataSource = ds.Tables[0];
        gd.DataBind();

    }
    public int GALLERY_ENTRY(int imageid, int projectid, string title, string img, string procedurename)
    {

        SqlCommand cmd = new SqlCommand(procedurename, con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter p1 = new SqlParameter("@imageid", SqlDbType.Int);
        p1.Direction = ParameterDirection.Input;
        p1.Value = imageid;
        cmd.Parameters.Add(p1);

        //SqlParameter pim1 = new SqlParameter("@projectid", SqlDbType.Int);
        //pim1.Direction = ParameterDirection.Input;
        //pim1.Value = projectid;
        //cmd.Parameters.Add(pim1);

        SqlParameter p3 = new SqlParameter("@title", SqlDbType.VarChar, 100);
        p3.Direction = ParameterDirection.Input;
        p3.Value = title;
        cmd.Parameters.Add(p3);

        SqlParameter pimgfor3 = new SqlParameter("@img", SqlDbType.VarChar, 50);
        pimgfor3.Direction = ParameterDirection.Input;
        pimgfor3.Value = img;
        cmd.Parameters.Add(pimgfor3);

        SqlParameter p4 = new SqlParameter("@moid", SqlDbType.Int);
        p4.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(p4);
        cmd.ExecuteNonQuery();

        if (cmd.Parameters["@moid"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@moid"].Value));

    }
    public int GALLERY_ENTRY_ar(int imageid, string title, string img, string procedurename)
    {

        SqlCommand cmd = new SqlCommand(procedurename, con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter p1 = new SqlParameter("@imageid", SqlDbType.Int);
        p1.Direction = ParameterDirection.Input;
        p1.Value = imageid;
        cmd.Parameters.Add(p1);

        //SqlParameter pim1 = new SqlParameter("@projectid", SqlDbType.Int);
        //pim1.Direction = ParameterDirection.Input;
        //pim1.Value = projectid;
        //cmd.Parameters.Add(pim1);

        SqlParameter p3 = new SqlParameter("@title", SqlDbType.NVarChar, 100);
        p3.Direction = ParameterDirection.Input;
        p3.Value = title;
        cmd.Parameters.Add(p3);

        SqlParameter pimgfor3 = new SqlParameter("@img", SqlDbType.VarChar, 50);
        pimgfor3.Direction = ParameterDirection.Input;
        pimgfor3.Value = img;
        cmd.Parameters.Add(pimgfor3);

        SqlParameter p4 = new SqlParameter("@moid", SqlDbType.Int);
        p4.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(p4);
        cmd.ExecuteNonQuery();

        if (cmd.Parameters["@moid"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@moid"].Value));

    }
    public void ResizeImage(string OriginalFile, int NewWidth, int MaxHeight, bool OnlyResizeIfWider)
    {
        System.Drawing.Image FullsizeImage = System.Drawing.Image.FromFile(OriginalFile);
        FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
        FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

        if (OnlyResizeIfWider)
        {
            if (FullsizeImage.Width <= NewWidth)
            {
                NewWidth = FullsizeImage.Width;

            }
        }
        int NewHeight = FullsizeImage.Height * NewWidth / FullsizeImage.Width;
        if (NewHeight > MaxHeight)
        {
            NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height;
            NewHeight = MaxHeight;
        }

        System.Drawing.Image NewImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);
        FullsizeImage.Dispose();
       // NewImage.Save(NewFile);
        FullsizeImage.Dispose();


    }
    public int GALLERY_ENTRY123(int imageid, int projectid, string title, string img, string detail, string procedurename)
    {

        SqlCommand cmd = new SqlCommand(procedurename, con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter p1 = new SqlParameter("@imageid", SqlDbType.Int);
        p1.Direction = ParameterDirection.Input;
        p1.Value = imageid;
        cmd.Parameters.Add(p1);

        SqlParameter pim1 = new SqlParameter("@projectid", SqlDbType.Int);
        pim1.Direction = ParameterDirection.Input;
        pim1.Value = projectid;
        cmd.Parameters.Add(pim1);

        SqlParameter p3 = new SqlParameter("@title", SqlDbType.VarChar, 100);
        p3.Direction = ParameterDirection.Input;
        p3.Value = title;
        cmd.Parameters.Add(p3);

        SqlParameter pimgfor3 = new SqlParameter("@img", SqlDbType.VarChar, 50);
        pimgfor3.Direction = ParameterDirection.Input;
        pimgfor3.Value = img;
        cmd.Parameters.Add(pimgfor3);

        SqlParameter asdfgh = new SqlParameter("@detail", SqlDbType.Text);
        asdfgh.Direction = ParameterDirection.Input;
        asdfgh.Value = detail;
        cmd.Parameters.Add(asdfgh);

        SqlParameter p4 = new SqlParameter("@moid", SqlDbType.Int);
        p4.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(p4);
        cmd.ExecuteNonQuery();

        if (cmd.Parameters["@moid"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@moid"].Value));

    }
    public int BANNER_ENTRY(int imageid, string link, string img, string procedurename)
    {

        SqlCommand cmd = new SqlCommand(procedurename, con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter p1 = new SqlParameter("@imageid", SqlDbType.Int);
        p1.Direction = ParameterDirection.Input;
        p1.Value = imageid;
        cmd.Parameters.Add(p1);

        SqlParameter p3 = new SqlParameter("@link", SqlDbType.Text);
        p3.Direction = ParameterDirection.Input;
        p3.Value = link;
        cmd.Parameters.Add(p3);

        SqlParameter pimgfor3 = new SqlParameter("@img", SqlDbType.VarChar, 50);
        pimgfor3.Direction = ParameterDirection.Input;
        pimgfor3.Value = img;
        cmd.Parameters.Add(pimgfor3);

        SqlParameter p4 = new SqlParameter("@moid", SqlDbType.Int);
        p4.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(p4);
        cmd.ExecuteNonQuery();

        if (cmd.Parameters["@moid"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@moid"].Value));

    }
    public int BANNER_ENTRY1(int imageid, string link, string img, string position, string procedurename)
    {

        SqlCommand cmd = new SqlCommand(procedurename, con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter p1 = new SqlParameter("@imageid", SqlDbType.Int);
        p1.Direction = ParameterDirection.Input;
        p1.Value = imageid;
        cmd.Parameters.Add(p1);

        SqlParameter pimgfor4 = new SqlParameter("@position", SqlDbType.VarChar, 50);
        pimgfor4.Direction = ParameterDirection.Input;
        pimgfor4.Value = position;
        cmd.Parameters.Add(pimgfor4);

        SqlParameter p3 = new SqlParameter("@link", SqlDbType.Text);
        p3.Direction = ParameterDirection.Input;
        p3.Value = link;
        cmd.Parameters.Add(p3);

        SqlParameter pimgfor3 = new SqlParameter("@img", SqlDbType.VarChar, 50);
        pimgfor3.Direction = ParameterDirection.Input;
        pimgfor3.Value = img;
        cmd.Parameters.Add(pimgfor3);


        SqlParameter p4 = new SqlParameter("@moid", SqlDbType.Int);
        p4.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(p4);
        cmd.ExecuteNonQuery();

        if (cmd.Parameters["@moid"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@moid"].Value));

    }
    //public string retStr(string qry)
    //{
    //    string ans;

    //    SqlCommand cmd = new SqlCommand(qry, con);
    //    if (cmd.ExecuteScalar() == DBNull.Value)
    //        ans = "0";
    //    else
    //        ans = Convert.ToString(cmd.ExecuteScalar());

    //    return ans;
    //}
    public int galleryartcollEntry(int imageid, int projectid, string title, string image, string procedurename, string imgeye, string imgfor)
    {

        SqlCommand cmd = new SqlCommand(procedurename, con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter p1 = new SqlParameter("@imageid", SqlDbType.Int);
        p1.Direction = ParameterDirection.Input;
        p1.Value = imageid;
        cmd.Parameters.Add(p1);

        SqlParameter pim1 = new SqlParameter("@projectid", SqlDbType.Int);
        pim1.Direction = ParameterDirection.Input;
        pim1.Value = projectid;
        cmd.Parameters.Add(pim1);

        SqlParameter p3 = new SqlParameter("@psize", SqlDbType.VarChar, 500);
        p3.Direction = ParameterDirection.Input;
        p3.Value = title;
        cmd.Parameters.Add(p3);

        SqlParameter pimgfor3 = new SqlParameter("@imgfor", SqlDbType.VarChar, 50);
        pimgfor3.Direction = ParameterDirection.Input;
        pimgfor3.Value = imgfor;
        cmd.Parameters.Add(pimgfor3);

        SqlParameter pimge3 = new SqlParameter("@imgeye", SqlDbType.VarChar, 500);
        pimge3.Direction = ParameterDirection.Input;
        pimge3.Value = imgeye;
        cmd.Parameters.Add(pimge3);

        SqlParameter pp3 = new SqlParameter("@pair", SqlDbType.VarChar, 500);
        pp3.Direction = ParameterDirection.Input;
        pp3.Value = image;
        cmd.Parameters.Add(pp3);

        SqlParameter p4 = new SqlParameter("@moid", SqlDbType.Int, 50);
        p4.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(p4);
        cmd.ExecuteNonQuery();

        if (cmd.Parameters["@moid"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@moid"].Value));

    }
    public void deleteFile(string path, string FileName)
    {
        File.Delete( "\\" + FileName);
    }
    public int fileUpload(string path, FileUpload fileUploaderName)
    {

        string fileName = "";
        string strErr = "";
        fileName = fileUploaderName.FileName.ToString();

        if (fileName != "")
        {
            string fileExt = Path.GetExtension(fileUploaderName.FileName).ToLower();
            //if(fileExt==".jpg")
            //{
            if (Directory.Exists(fileUploaderName.FileName.ToString()) == false)
            {

                Directory.CreateDirectory(path + "\\" + fileUploaderName.FileName.ToString());
                fileUploaderName.SaveAs(path + "\\" + fileUploaderName.FileName.ToString() + "\\" +
                fileUploaderName.FileName.ToString());
                fileName = fileUploaderName.FileName.ToString() + "\\"
                + fileUploaderName.FileName.ToString();

            }

            //}

        }
        return fileName.Length;
    }
    public string getTOEmailId()
    {
        return "info@bonganidubai.com";
    }
    public void ddlbind(DropDownList ddl, string str, string dataText, string dataValue)
    {

        DataSet ds = new DataSet();
        da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        ddl.DataSource = ds.Tables[0];
        ddl.DataTextField = dataText;
        ddl.DataValueField = dataValue;
        ddl.DataBind();

    }
	public void dtlistbind(DataList gd, string str)
	{

		DataSet ds = new DataSet();
		da = new SqlDataAdapter(str, con);
		da.Fill(ds);
		gd.DataSource = ds.Tables[0];
		gd.DataBind();

	}
    public DataSet GetCategories(string sqlCommand)
    {
        DataSet ds = new DataSet();
        da = new SqlDataAdapter(sqlCommand, con);
        da.Fill(ds);
        return ds;
    }
	public string GetStr(string sqlCommand)
	{
		DataTable dt = new DataTable();
		da = new SqlDataAdapter(sqlCommand, con);
		da.Fill(dt);
		if (dt.Rows.Count > 0)
			return dt.Rows[0][0].ToString();
		else
			return "";
	}
	public int AddSubscriber(int newsletterId, string name, string emailId, bool status, string StoredProcedureName)
	{
		SqlCommand cmd = new SqlCommand(StoredProcedureName, con);
		cmd.CommandType = CommandType.StoredProcedure;

		SqlParameter pNewsletterId = new SqlParameter("@NewsletterId", SqlDbType.Int);
		pNewsletterId.Direction = ParameterDirection.Input;
		pNewsletterId.Value = newsletterId;
		cmd.Parameters.Add(pNewsletterId);

		SqlParameter pName = new SqlParameter("@Name", SqlDbType.VarChar, 50);
		pName.Direction = ParameterDirection.Input;
		pName.Value = name;
		cmd.Parameters.Add(pName);

		SqlParameter pEmailId = new SqlParameter("@EmailId", SqlDbType.VarChar, 50);
		pEmailId.Direction = ParameterDirection.Input;
		pEmailId.Value = emailId;
		cmd.Parameters.Add(pEmailId);

		SqlParameter pStatus = new SqlParameter("@Status", SqlDbType.Bit);
		pStatus.Direction = ParameterDirection.Input;
		pStatus.Value = status;
		cmd.Parameters.Add(pStatus);

		SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
		pReturnValue.Direction = ParameterDirection.Output;
		cmd.Parameters.Add(pReturnValue);
		try
		{
			cmd.ExecuteNonQuery();
		}
		catch (Exception er) { return 0; }
		if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
			return 0;
		else
			return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
	}
    public int fileUploadEntry(string id, string title, string type, string filename, string originalName, string filesize, string procedurename)
    {
        SqlCommand cmd = new SqlCommand(procedurename, con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter p32 = new SqlParameter("@id", SqlDbType.Int);
        p32.Direction = ParameterDirection.Input;
        p32.Value = id;
        cmd.Parameters.Add(p32);
        SqlParameter p1 = new SqlParameter("@title", SqlDbType.VarChar, 100);
        p1.Direction = ParameterDirection.Input;
        p1.Value = title;
        cmd.Parameters.Add(p1);

        SqlParameter ptype = new SqlParameter("@type", SqlDbType.Text);
        ptype.Direction = ParameterDirection.Input;
        ptype.Value = type;
        cmd.Parameters.Add(ptype);
        SqlParameter p2 = new SqlParameter("@filename", SqlDbType.Text);
        p2.Direction = ParameterDirection.Input;
        p2.Value = filename;
        cmd.Parameters.Add(p2);

        SqlParameter p3 = new SqlParameter("@originalName", SqlDbType.VarChar, 150);
        p3.Direction = ParameterDirection.Input;
        p3.Value = originalName;
        cmd.Parameters.Add(p3);

        SqlParameter p4 = new SqlParameter("@uploadDate", SqlDbType.DateTime);
        p4.Direction = ParameterDirection.Input;
        p4.Value = DateTime.Now;
        cmd.Parameters.Add(p4);

        SqlParameter p5 = new SqlParameter("@filesize", SqlDbType.Float);
        p5.Direction = ParameterDirection.Input;
        p5.Value = filesize;
        cmd.Parameters.Add(p5);

        SqlParameter pm786 = new SqlParameter("@moid", SqlDbType.Int, 50);
        pm786.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(pm786);
        cmd.ExecuteNonQuery();

        if (cmd.Parameters["@moid"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@moid"].Value)); 
    }

    public bool CheckFileType(string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower())
        {
            case ".pdf":
                return true;
            default:
                return false;
        }
    }
	public int AddOpinionPoll(int id, string question, string ans1, string ans2, string ans3, string ans4, string ans5, string StoredProcedureName)
	{
		SqlCommand cmd = new SqlCommand(StoredProcedureName, con);
		cmd.CommandType = CommandType.StoredProcedure;

		SqlParameter pid = new SqlParameter("@id", SqlDbType.Int);
		pid.Direction = ParameterDirection.Input;
		pid.Value = id;
		cmd.Parameters.Add(pid);

		SqlParameter pquestion = new SqlParameter("@question", SqlDbType.VarChar, 100);
		pquestion.Direction = ParameterDirection.Input;
		pquestion.Value = question;
		cmd.Parameters.Add(pquestion);

		SqlParameter fans1 = new SqlParameter("@ans1", SqlDbType.VarChar, 50);
		fans1.Direction = ParameterDirection.Input;
		fans1.Value = ans1;
		cmd.Parameters.Add(fans1);

		SqlParameter fans2 = new SqlParameter("@ans2", SqlDbType.VarChar, 50);
		fans2.Direction = ParameterDirection.Input;
		fans2.Value = ans2;
		cmd.Parameters.Add(fans2);

		SqlParameter fans3 = new SqlParameter("@ans3", SqlDbType.VarChar, 50);
		fans3.Direction = ParameterDirection.Input;
		fans3.Value = ans3;
		cmd.Parameters.Add(fans3);

		SqlParameter fans4 = new SqlParameter("@ans4", SqlDbType.VarChar, 50);
		fans4.Direction = ParameterDirection.Input;
		fans4.Value = ans4;
		cmd.Parameters.Add(fans4);

		SqlParameter fans5 = new SqlParameter("@ans5", SqlDbType.VarChar, 50);
		fans5.Direction = ParameterDirection.Input;
		fans5.Value = ans5;
		cmd.Parameters.Add(fans5);

		SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
		pReturnValue.Direction = ParameterDirection.Output;
		cmd.Parameters.Add(pReturnValue);
		try
		{
			cmd.ExecuteNonQuery();
		}
		catch (Exception er) { return 0; }
		if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
			return 0;
		else
			return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
	}
	public int AddOpinionPollAns(int id, int poll, int ans1, int ans2, int ans3, int ans4, int ans5, string StoredProcedureName)
	{
		SqlCommand cmd = new SqlCommand(StoredProcedureName, con);
		cmd.CommandType = CommandType.StoredProcedure;

		SqlParameter pid = new SqlParameter("@id", SqlDbType.Int);
		pid.Direction = ParameterDirection.Input;
		pid.Value = id;
		cmd.Parameters.Add(pid);

		SqlParameter ppoll = new SqlParameter("@poll", SqlDbType.Int);
		ppoll.Direction = ParameterDirection.Input;
		ppoll.Value = poll;
		cmd.Parameters.Add(ppoll);

		SqlParameter fans1 = new SqlParameter("@ans1", SqlDbType.Int);
		fans1.Direction = ParameterDirection.Input;
		fans1.Value = ans1;
		cmd.Parameters.Add(fans1);

		SqlParameter fans2 = new SqlParameter("@ans2", SqlDbType.Int);
		fans2.Direction = ParameterDirection.Input;
		fans2.Value = ans2;
		cmd.Parameters.Add(fans2);

		SqlParameter fans3 = new SqlParameter("@ans3", SqlDbType.Int);
		fans3.Direction = ParameterDirection.Input;
		fans3.Value = ans3;
		cmd.Parameters.Add(fans3);

		SqlParameter fans4 = new SqlParameter("@ans4", SqlDbType.Int);
		fans4.Direction = ParameterDirection.Input;
		fans4.Value = ans4;
		cmd.Parameters.Add(fans4);

		SqlParameter fans5 = new SqlParameter("@ans5", SqlDbType.Int);
		fans5.Direction = ParameterDirection.Input;
		fans5.Value = ans5;
		cmd.Parameters.Add(fans5);

		SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
		pReturnValue.Direction = ParameterDirection.Output;
		cmd.Parameters.Add(pReturnValue);
		try
		{
			cmd.ExecuteNonQuery();
		}
		catch (Exception er) { return 0; }
		if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
			return 0;
		else
			return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
	}
	public int AddPresentation(int id, string title, string pdffile, string StoredProcedureName)
	{
		SqlCommand cmd = new SqlCommand(StoredProcedureName, con);
		cmd.CommandType = CommandType.StoredProcedure;

		SqlParameter pid = new SqlParameter("@id", SqlDbType.Int);
		pid.Direction = ParameterDirection.Input;
		pid.Value = id;
		cmd.Parameters.Add(pid);

		SqlParameter ptitle = new SqlParameter("@title", SqlDbType.VarChar, 100);
		ptitle.Direction = ParameterDirection.Input;
		ptitle.Value = title;
		cmd.Parameters.Add(ptitle);

		SqlParameter fpdffile = new SqlParameter("@pdffile", SqlDbType.VarChar, 100);
		fpdffile.Direction = ParameterDirection.Input;
		fpdffile.Value = pdffile;
		cmd.Parameters.Add(fpdffile);

		SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
		pReturnValue.Direction = ParameterDirection.Output;
		cmd.Parameters.Add(pReturnValue);
		try
		{
			cmd.ExecuteNonQuery();
		}
		catch (Exception er) { return 0; }
		if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
			return 0;
		else
			return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
	}
	public int AddBookcorner(int id, string title, string details, string img, string pdffile, string StoredProcedureName)
	{
		SqlCommand cmd = new SqlCommand(StoredProcedureName, con);
		cmd.CommandType = CommandType.StoredProcedure;

		SqlParameter pid = new SqlParameter("@id", SqlDbType.Int);
		pid.Direction = ParameterDirection.Input;
		pid.Value = id;
		cmd.Parameters.Add(pid);

		SqlParameter ptitle = new SqlParameter("@title", SqlDbType.VarChar, 100);
		ptitle.Direction = ParameterDirection.Input;
		ptitle.Value = title;
		cmd.Parameters.Add(ptitle);

		SqlParameter pdetails = new SqlParameter("@details", SqlDbType.Text);
		pdetails.Direction = ParameterDirection.Input;
		pdetails.Value = details;
		cmd.Parameters.Add(pdetails);

		SqlParameter fimg = new SqlParameter("@img", SqlDbType.VarChar, 100);
		fimg.Direction = ParameterDirection.Input;
		fimg.Value = img;
		cmd.Parameters.Add(fimg);

		SqlParameter fpdffile = new SqlParameter("@pdffile", SqlDbType.VarChar, 100);
		fpdffile.Direction = ParameterDirection.Input;
		fpdffile.Value = pdffile;
		cmd.Parameters.Add(fpdffile);

		SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
		pReturnValue.Direction = ParameterDirection.Output;
		cmd.Parameters.Add(pReturnValue);
		try
		{
			cmd.ExecuteNonQuery();
		}
		catch (Exception er) { return 0; }
		if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
			return 0;
		else
			return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
	}

    public int InsertEmailIdForNewsletter(int newsletterId, string subscriberEmailId, byte status, string StoredProcedureName)
    {
        SqlCommand cmd = new SqlCommand(StoredProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter pNewsletterId = new SqlParameter("@NewsletterId", SqlDbType.Int);
        pNewsletterId.Direction = ParameterDirection.Input;
        pNewsletterId.Value = newsletterId;
        cmd.Parameters.Add(pNewsletterId);

        SqlParameter pSubscriberEmailId = new SqlParameter("@SubscriberEmailId", SqlDbType.VarChar, 100);
        pSubscriberEmailId.Direction = ParameterDirection.Input;
        pSubscriberEmailId.Value = subscriberEmailId;
        cmd.Parameters.Add(pSubscriberEmailId);

        SqlParameter pStatus = new SqlParameter("@Status", SqlDbType.Bit);
        pStatus.Direction = ParameterDirection.Input;
        pStatus.Value = status;
        cmd.Parameters.Add(pStatus);

        SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
        pReturnValue.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(pReturnValue);
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception er) { return 0; }
        if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
    }

    public int AddRentalGallery(int galleryId, int productId, string imageName, string storedProcedureName)
    {
        SqlCommand cmd = new SqlCommand(storedProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter pGalleryId = new SqlParameter("@GalleryId", SqlDbType.Int);
        pGalleryId.Direction = ParameterDirection.Input;
        pGalleryId.Value = galleryId;
        cmd.Parameters.Add(pGalleryId);

        SqlParameter pProductId = new SqlParameter("@ProductId", SqlDbType.Int);
        pProductId.Direction = ParameterDirection.Input;
        pProductId.Value = productId;
        cmd.Parameters.Add(pProductId);

        SqlParameter pImageName = new SqlParameter("@ImageName", SqlDbType.VarChar, 200);
        pImageName.Direction = ParameterDirection.Input;
        pImageName.Value = imageName;
        cmd.Parameters.Add(pImageName);

        SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
        pReturnValue.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(pReturnValue);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc)
        {
            return 0;
        }
        if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
    }

    public int AddGallery(int galleryId,  string imageName, string storedProcedureName)
    {
        SqlCommand cmd = new SqlCommand(storedProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter pGalleryId = new SqlParameter("@GalleryId", SqlDbType.Int);
        pGalleryId.Direction = ParameterDirection.Input;
        pGalleryId.Value = galleryId;
        cmd.Parameters.Add(pGalleryId);

        //SqlParameter pProductId = new SqlParameter("@ProductId", SqlDbType.Int);
        //pProductId.Direction = ParameterDirection.Input;
        //pProductId.Value = productId;
        //cmd.Parameters.Add(pProductId);

        SqlParameter pImageName = new SqlParameter("@ImageName", SqlDbType.VarChar, 200);
        pImageName.Direction = ParameterDirection.Input;
        pImageName.Value = imageName;
        cmd.Parameters.Add(pImageName);

        SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
        pReturnValue.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(pReturnValue);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc)
        {
            return 0;
        }
        if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
    }

    public int GalleryEntry(int galId, string galName, string imgName, string StoredProcedureName)
    {
        SqlCommand cmd = new SqlCommand(StoredProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter pGalleryId = new SqlParameter("@GalleryId", SqlDbType.Int);
        pGalleryId.Direction = ParameterDirection.Input;
        pGalleryId.Value = galId;
        cmd.Parameters.Add(pGalleryId);

        SqlParameter pGalleryName = new SqlParameter("@GalleryName", SqlDbType.VarChar, 100);
        pGalleryName.Direction = ParameterDirection.Input;
        pGalleryName.Value = galName;
        cmd.Parameters.Add(pGalleryName);

        SqlParameter pImageName = new SqlParameter("@ImageName", SqlDbType.VarChar, 100);
        pImageName.Direction = ParameterDirection.Input;
        pImageName.Value = imgName;
        cmd.Parameters.Add(pImageName);

        SqlParameter p4 = new SqlParameter("@moid", SqlDbType.Int);
        p4.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(p4);
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception er) { return 0; }
        if (cmd.Parameters["@moid"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@moid"].Value));
    }

    public int AddNews(int newsId, string newsHeading, DateTime newsDate, string newsDetails, string imageName, 
            string pdfArticle, string StoredProcedureName)
    {
        SqlCommand cmd = new SqlCommand(StoredProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter pNewsId = new SqlParameter("@NewsId", SqlDbType.Int);
        pNewsId.Direction = ParameterDirection.Input;
        pNewsId.Value = newsId;
        cmd.Parameters.Add(pNewsId);

        SqlParameter pNewsHeading = new SqlParameter("@NewsHeading", SqlDbType.VarChar, 100);
        pNewsHeading.Direction = ParameterDirection.Input;
        pNewsHeading.Value = newsHeading;
        cmd.Parameters.Add(pNewsHeading);

        SqlParameter pNewsDate = new SqlParameter("@NewsDate", SqlDbType.DateTime);
        pNewsDate.Direction = ParameterDirection.Input;
        pNewsDate.Value = newsDate;
        cmd.Parameters.Add(pNewsDate);

        SqlParameter pNewsDetails = new SqlParameter("@NewsDetails", SqlDbType.Text);
        pNewsDetails.Direction = ParameterDirection.Input;
        pNewsDetails.Value = newsDetails;
        cmd.Parameters.Add(pNewsDetails);


        SqlParameter paramImageName = new SqlParameter("@ImageName", SqlDbType.VarChar, 50);
        paramImageName.Direction = ParameterDirection.Input;
        paramImageName.Value = imageName;
        cmd.Parameters.Add(paramImageName);

        SqlParameter pPDFArticle = new SqlParameter("@PDFArticle", SqlDbType.VarChar, 50);
        pPDFArticle.Direction = ParameterDirection.Input;
        pPDFArticle.Value = pdfArticle;
        cmd.Parameters.Add(pPDFArticle);

        SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
        pReturnValue.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(pReturnValue);

        cmd.ExecuteNonQuery();
        if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
    }

    public int NewsEntry(int newsId, string newsHeading, DateTime newsDate, string newsDetails, string imageName, string StoredProcedureName)
    {
        SqlCommand cmd = new SqlCommand(StoredProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter paramNewsId = new SqlParameter("@NewsId", SqlDbType.Int);
        paramNewsId.Direction = ParameterDirection.Input;
        paramNewsId.Value = newsId;
        cmd.Parameters.Add(paramNewsId);

        SqlParameter paramNewsHeading = new SqlParameter("@NewsHeading", SqlDbType.VarChar, 100);
        paramNewsHeading.Direction = ParameterDirection.Input;
        paramNewsHeading.Value = newsHeading;
        cmd.Parameters.Add(paramNewsHeading);

        SqlParameter paramNewsDate = new SqlParameter("@NewsDate", SqlDbType.DateTime);
        paramNewsDate.Direction = ParameterDirection.Input;
        paramNewsDate.Value = newsDate;
        cmd.Parameters.Add(paramNewsDate);

        SqlParameter paramNewsDetails = new SqlParameter("@NewsDetails", SqlDbType.Text);
        paramNewsDetails.Direction = ParameterDirection.Input;
        paramNewsDetails.Value = newsDetails;
        cmd.Parameters.Add(paramNewsDetails);


        SqlParameter paramImageName = new SqlParameter("@ImageName", SqlDbType.VarChar, 50);
        paramImageName.Direction = ParameterDirection.Input;
        paramImageName.Value = imageName;
        cmd.Parameters.Add(paramImageName);

        SqlParameter MoId = new SqlParameter("@moid", SqlDbType.Int);
        MoId.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(MoId);

        cmd.ExecuteNonQuery();
        if (cmd.Parameters["@moid"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@moid"].Value));
    }

    public int newsEntry(string id, string title, string detail, string image, string procedurename)
    {
        SqlCommand cmd = new SqlCommand(procedurename, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter p32 = new SqlParameter("@id", SqlDbType.Int);
        p32.Direction = ParameterDirection.Input;
        p32.Value = id;
        cmd.Parameters.Add(p32);

        SqlParameter p42 = new SqlParameter("@title", SqlDbType.NVarChar, 150);
        p42.Direction = ParameterDirection.Input;
        p42.Value = title;
        cmd.Parameters.Add(p42);

        SqlParameter p52 = new SqlParameter("@detail", SqlDbType.Text);
        p52.Direction = ParameterDirection.Input;
        p52.Value = detail;
        cmd.Parameters.Add(p52);

        SqlParameter p62 = new SqlParameter("@image", SqlDbType.VarChar, 100);
        p62.Direction = ParameterDirection.Input;
        p62.Value = image;
        cmd.Parameters.Add(p62);

        SqlParameter p8 = new SqlParameter("@moid", SqlDbType.Int, 50);
        p8.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(p8);
        cmd.ExecuteNonQuery();

        if (cmd.Parameters["@moid"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@moid"].Value));
    }


    public int SubcategoryEntry(string id, string catId, string subcatName, string sub_image, string procedurename)
    {
        SqlCommand cmd = new SqlCommand(procedurename, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter p32 = new SqlParameter("@id", SqlDbType.Int);
        p32.Direction = ParameterDirection.Input;
        p32.Value = id;
        cmd.Parameters.Add(p32);

        SqlParameter p42 = new SqlParameter("@catId", SqlDbType.Int);
        p42.Direction = ParameterDirection.Input;
        p42.Value = catId;
        cmd.Parameters.Add(p42);

        SqlParameter p52 = new SqlParameter("@subcatName", SqlDbType.NVarChar, 150);
        p52.Direction = ParameterDirection.Input;
        p52.Value = subcatName;
        cmd.Parameters.Add(p52);

        SqlParameter p62 = new SqlParameter("@sub_image", SqlDbType.VarChar, 150);
        p62.Direction = ParameterDirection.Input;
        p62.Value = sub_image;
        cmd.Parameters.Add(p62);

        SqlParameter p8 = new SqlParameter("@moid", SqlDbType.Int, 50);
        p8.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(p8);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception err) { return 0; }

        if (cmd.Parameters["@moid"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@moid"].Value));
    }

    //public bool sendEmail(string subject, string fromMail, string tomail, string body)
    //{



    //    string message = "";
    //    MailMessage msgMail = new MailMessage();
    //    msgMail.To = tomail;
    //    msgMail.From = fromMail;
    //    msgMail.Subject = subject;

    //    message = "<html><head></head><body>";
    //    message += body;
    //    message += " </body></html>";

    //    msgMail.BodyFormat = MailFormat.Html;
    //    msgMail.Body = message;

    //    try
    //    {
    //        SmtpMail.Send(msgMail);
    //    }
    //    catch (Exception er) { return false; }

    //    return true;
    //}

    public bool sendEmail(string subject, string fromMail, string tomail, string ccTo, string body)
    {
        string message = "";
        MailMessage msgMail = new MailMessage();
        msgMail.To = tomail;
        msgMail.Bcc = ccTo;
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

    public bool SendEmail(string subject, string toAddress, string fromAddress, string ccAddress, string bccAddress, string body)
    {
        string message = "";
        MailMessage msgMail = new MailMessage();
        msgMail.To = toAddress;
        msgMail.From = fromAddress;
        msgMail.Cc = ccAddress;
        msgMail.Bcc = bccAddress;
        msgMail.Subject = subject;

        message = "<html><head></head><body>";
        message += body;
        message += " </body></html>";

        msgMail.BodyFormat = MailFormat.Html;
        msgMail.Body = message;

        try
        {
            SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
            //SmtpMail.SmtpServer = "localhost";
            SmtpMail.Send(msgMail);
        }
        catch (Exception er) { return false; }

        return true;
    }
    public bool SendEmail_att(string subject, string toAddress, string fromAddress, string ccAddress, string bccAddress, string body,string path)
    {
        string message = "";
        MailMessage msgMail = new MailMessage();
        msgMail.To = toAddress;
        msgMail.From = fromAddress;
        msgMail.Cc = ccAddress;
        msgMail.Bcc = bccAddress;
        msgMail.Subject = subject;

        message = "<html><head></head><body>";
        message += body;
        message += " </body></html>";
        MailAttachment attach = new MailAttachment(path);
        msgMail.Attachments.Add(attach);
        msgMail.BodyFormat = MailFormat.Html;
        msgMail.Body = message;

        try
        {
            SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
            //SmtpMail.SmtpServer = "localhost";
            SmtpMail.Send(msgMail);
        }
        catch (Exception er) { return false; }

        return true;
    }

    public bool sendEmail(string subject, string toAddress, string fromAddress, string ccAddress, string bccAddress, string body)
    {
        string message = "";
        MailMessage msgMail = new MailMessage();
        msgMail.To = toAddress;
        msgMail.From = fromAddress;
        msgMail.Cc = ccAddress;
        msgMail.Bcc = bccAddress;
        msgMail.Subject = subject;

        message = "<html><head></head><body>";
        message += body;
        message += " </body></html>";

        msgMail.BodyFormat = MailFormat.Html;
        msgMail.Body = message;

        try
        {
            SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
            //SmtpMail.SmtpServer = "localhost";
            SmtpMail.Send(msgMail);
        }
        catch (Exception er) { return false; }

        return true;
    }

    public bool SendEmailWithAttachment(string subject, string toAddress, string fromAddress, string ccAddress, string bccAddress, string body, string imgPath)
    {
        string message = "";
        MailMessage msgMail = new MailMessage();
        msgMail.To = toAddress;
        msgMail.From = fromAddress;
        msgMail.Cc = ccAddress;
        msgMail.Bcc = bccAddress;
        msgMail.Attachments.Add(imgPath);
        msgMail.Subject = subject;

        message = "<html><head></head><body>";
        message += body;
        message += " </body></html>";

        msgMail.BodyFormat = MailFormat.Html;
        msgMail.Body = message;

        try
        {
            SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
            //SmtpMail.SmtpServer = "localhost";
            SmtpMail.Send(msgMail);
        }
        catch (Exception er) { return false; }

        return true;
    }

    public void ddlbind1(DropDownList ddl, string str, string fname, string lname)
    {

        DataSet ds = new DataSet();
        da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        ddl.DataSource = ds.Tables[0];
        ddl.DataTextField = "area";
        //ddl.DataValueField = lname;
        ddl.DataBind();

    }
    public void ddllist(DropDownList ddl, string str, string text, string value)
    {

        DataSet ds = new DataSet();
        da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = ds.Tables[0];
            ddl.DataTextField = text;
            ddl.DataValueField = value;
            ddl.DataBind();
            //ddl.Items.Insert(0, "Select");
        }
        else
        {
            ddl.Items.Clear();
            ddl.Items.Insert(0, "Select");
        }

    }
    public void ddllist1(DropDownList ddl, string str, string text, string value)
    {
        DataSet ds = new DataSet();
        da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = ds.Tables[0];
            ddl.DataTextField = text;
            ddl.DataValueField = value;
            ddl.DataBind();
            ddl.Items.Insert(0, "Select");
        }
        else
        {
            ddl.Items.Clear();
            ddl.Items.Insert(0, "Select");
        }

    }
    public DataSet GetSubscribersEmailId()
    {
        DataSet ds = new DataSet();
        da = new SqlDataAdapter("Select * from Newsletter", con);
        da.Fill(ds);
        return ds;
    }

    public void gridbind(GridView gd, string str)
    {
        DataSet ds = new DataSet();
        da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        gd.DataSource = ds.Tables[0];
        gd.DataBind();
    }

    public bool SubscribeUnsubscribeEmailId(string id, bool active)
    {
        try
        {
            cmd = new SqlCommand("update Newsletter set Status='" + active + "' where NewsletterId='" + id + "' ", con);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception er) { return false; }
    }
    public bool execute_query(string sql)
    {
        try
        {
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception er) { return false; }
    }
    public DataSet returndataset(string str)
    {
        DataSet ds = new DataSet();

        SqlDataAdapter da1 = new SqlDataAdapter(str, con);
        da1.Fill(ds);
        return ds;
    }
	public DataTable GetDtTable(string sqlCommand)
	{
		DataTable dt = new DataTable();
		da = new SqlDataAdapter(sqlCommand, con);
		da.Fill(dt);
		return dt;
	}
	public string GetTotal(string sqlCommand)
	{
		string str = "select SUM(" + sqlCommand + ") from pollans";
		DataTable dt = new DataTable();
		da = new SqlDataAdapter(str, con);
		da.Fill(dt);
		if (dt.Rows[0][0].ToString() != "")
			return dt.Rows[0][0].ToString();
		else
			return "0";
	}
	
    public int itemchartentry(int chartid, string itemname, string brand, string price, string other, string procedurename)
    {
        SqlCommand cmd = new SqlCommand(procedurename, con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter p32 = new SqlParameter("@chartid", SqlDbType.Int);
        p32.Direction = ParameterDirection.Input;
        p32.Value = chartid;
        cmd.Parameters.Add(p32);
        SqlParameter p42 = new SqlParameter("@itemname", SqlDbType.VarChar, 50);
        p42.Direction = ParameterDirection.Input;
        p42.Value = itemname;
        cmd.Parameters.Add(p42);
        SqlParameter p52 = new SqlParameter("@brand", SqlDbType.VarChar, 50);
        p52.Direction = ParameterDirection.Input;
        p52.Value = brand;
        cmd.Parameters.Add(p52);
        SqlParameter p62 = new SqlParameter("@price", SqlDbType.VarChar, 50);
        p62.Direction = ParameterDirection.Input;
        p62.Value = price;
        cmd.Parameters.Add(p62);
        SqlParameter ps1 = new SqlParameter("@other", SqlDbType.VarChar, 50);
        ps1.Direction = ParameterDirection.Input;
        ps1.Value = other;
        cmd.Parameters.Add(ps1);

        SqlParameter p786 = new SqlParameter("@moid", SqlDbType.Int, 50);
        p786.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(p786);
        cmd.ExecuteNonQuery();

        if (cmd.Parameters["@moid"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@moid"].Value)); 
    }

    public int InsertCompany(int companyId, int categoryId, int subcategoryid, string companyName, 
            string companyDetails, string image1, string storedProcedureName)
    {
        SqlCommand cmd = new SqlCommand(storedProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter pCompanyId = new SqlParameter("@CompanyId", SqlDbType.Int);
        pCompanyId.Direction = ParameterDirection.Input;
        pCompanyId.Value = companyId;
        cmd.Parameters.Add(pCompanyId);

        SqlParameter pCategoryId = new SqlParameter("@CategoryId", SqlDbType.Int);
        pCategoryId.Direction = ParameterDirection.Input;
        pCategoryId.Value = categoryId;
        cmd.Parameters.Add(pCategoryId);

        SqlParameter pSubcategoryId = new SqlParameter("@SubcategoryId", SqlDbType.Int);
        pSubcategoryId.Direction = ParameterDirection.Input;
        pSubcategoryId.Value = subcategoryid;
        cmd.Parameters.Add(pSubcategoryId);

        SqlParameter pCompanyName = new SqlParameter("@CompanyName", SqlDbType.VarChar, 100);
        pCompanyName.Direction = ParameterDirection.Input;
        pCompanyName.Value = companyName;
        cmd.Parameters.Add(pCompanyName);

        SqlParameter pcompanyDetails = new SqlParameter("@CompanyDetails", SqlDbType.Text);
        pcompanyDetails.Direction = ParameterDirection.Input;
        pcompanyDetails.Value = companyDetails;
        cmd.Parameters.Add(pcompanyDetails);

        SqlParameter pImageName = new SqlParameter("@ImageName", SqlDbType.VarChar, 100);
        pImageName.Direction = ParameterDirection.Input;
        pImageName.Value = image1;
        cmd.Parameters.Add(pImageName);

        SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
        pReturnValue.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(pReturnValue);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc) { return 0; }
        if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
    }

    public void ResizeImages(string OriginalFile, string NewFile, int NewWidth, int MaxHeight, bool OnlyResizeIfWider)
    {
        System.Drawing.Image FullsizeImage = System.Drawing.Image.FromFile(OriginalFile);

        FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone); //Prevent using images internal thumbnail
        FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

        if (OnlyResizeIfWider)
        {
            if (FullsizeImage.Width <= NewWidth)
            {
                NewWidth = FullsizeImage.Width; //this is also for change automaticaly fix the width of the image 
                //NewWidth = 150;
            }
        }

        int NewHeight = FullsizeImage.Height * NewWidth / FullsizeImage.Width; //this is automatically fix the height of the image 

        if (NewHeight > MaxHeight) //int NewHeight = 170;
        {

            NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height; //Resize with height instead. This is automatically fix the width of the image  
            NewHeight = MaxHeight; //NewWidth = 150;
        }

        System.Drawing.Image NewImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);
        FullsizeImage.Dispose(); //Clear handle to original file so that we can overwrite it if necessary

        NewImage.Save(NewFile); // Save resized picture
    }

	public int AddVacancy(int VacancyId, string VacancyName, string ReferenceNumber, string Location,
        string Qualification, string Experience, string Details, string Email, string Status, string StoredProcedureName)
    {
        SqlCommand cmd = new SqlCommand(StoredProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter pVacancyId = new SqlParameter("@VacancyId", SqlDbType.Int);
        pVacancyId.Direction = ParameterDirection.Input;
        pVacancyId.Value = VacancyId;
        cmd.Parameters.Add(pVacancyId);

        SqlParameter pVacancyName = new SqlParameter("@vacancyName", SqlDbType.VarChar, 200);
        pVacancyName.Direction = ParameterDirection.Input;
        pVacancyName.Value = VacancyName;
        cmd.Parameters.Add(pVacancyName);

        SqlParameter pReferenceNumber = new SqlParameter("@RefNumber", SqlDbType.VarChar, 100);
        pReferenceNumber.Direction = ParameterDirection.Input;
        pReferenceNumber.Value = ReferenceNumber;
        cmd.Parameters.Add(pReferenceNumber);

        SqlParameter pLocation = new SqlParameter("@Location", SqlDbType.VarChar, 200);
        pLocation.Direction = ParameterDirection.Input;
        pLocation.Value = Location;
        cmd.Parameters.Add(pLocation);

		SqlParameter pQualification = new SqlParameter("@Qualification", SqlDbType.VarChar, 500);
		pQualification.Direction = ParameterDirection.Input;
		pQualification.Value = Qualification;
		cmd.Parameters.Add(pQualification);

		SqlParameter pExperience = new SqlParameter("@Experience", SqlDbType.VarChar, 500);
		pExperience.Direction = ParameterDirection.Input;
		pExperience.Value = Experience;
		cmd.Parameters.Add(pExperience);

        SqlParameter pDetails = new SqlParameter("@Details", SqlDbType.Text);
        pDetails.Direction = ParameterDirection.Input;
        pDetails.Value = Details;
        cmd.Parameters.Add(pDetails);

        SqlParameter pEmail = new SqlParameter("@Email", SqlDbType.Text);
        pEmail.Direction = ParameterDirection.Input;
        pEmail.Value = Email;
        cmd.Parameters.Add(pEmail);

        SqlParameter pStatus = new SqlParameter("@Status", SqlDbType.Text);
        pStatus.Direction = ParameterDirection.Input;
        pStatus.Value = Status;
        cmd.Parameters.Add(pStatus);

        SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
        pReturnValue.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(pReturnValue);

        cmd.ExecuteNonQuery();
        if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
    }
	public int AddMember(int id, string name, string job, string organization, string email, string pwd, string telno, string mobileno,
		string faxno, string address, string city, string country, string howdid, string status, string storedProcedureName)
	{
		SqlCommand cmd = new SqlCommand(storedProcedureName, con);
		cmd.CommandType = CommandType.StoredProcedure;

		SqlParameter pId = new SqlParameter("@id", SqlDbType.Int);
		pId.Direction = ParameterDirection.Input;
		pId.Value = id;
		cmd.Parameters.Add(pId);

		SqlParameter pname = new SqlParameter("@name", SqlDbType.VarChar, 100);
		pname.Direction = ParameterDirection.Input;
		pname.Value = name;
		cmd.Parameters.Add(pname);

		SqlParameter pjob = new SqlParameter("@job", SqlDbType.VarChar, 200);
		pjob.Direction = ParameterDirection.Input;
		pjob.Value = job;
		cmd.Parameters.Add(pjob);

		SqlParameter porganization = new SqlParameter("@organization", SqlDbType.VarChar, 100);
		porganization.Direction = ParameterDirection.Input;
		porganization.Value = organization;
		cmd.Parameters.Add(porganization);

		SqlParameter pemail = new SqlParameter("@email", SqlDbType.VarChar, 50);
		pemail.Direction = ParameterDirection.Input;
		pemail.Value = email;
		cmd.Parameters.Add(pemail);

		SqlParameter ppwd = new SqlParameter("@pwd", SqlDbType.VarChar, 50);
		ppwd.Direction = ParameterDirection.Input;
		ppwd.Value = pwd;
		cmd.Parameters.Add(ppwd);

		SqlParameter ptelno = new SqlParameter("@telno", SqlDbType.VarChar, 50);
		ptelno.Direction = ParameterDirection.Input;
		ptelno.Value = telno;
		cmd.Parameters.Add(ptelno);

		SqlParameter pmobileno = new SqlParameter("@mobileno", SqlDbType.VarChar, 50);
		pmobileno.Direction = ParameterDirection.Input;
		pmobileno.Value = mobileno;
		cmd.Parameters.Add(pmobileno);

		SqlParameter pfaxno = new SqlParameter("@faxno", SqlDbType.VarChar, 50);
		pfaxno.Direction = ParameterDirection.Input;
		pfaxno.Value = faxno;
		cmd.Parameters.Add(pfaxno);

		SqlParameter paddress = new SqlParameter("@address", SqlDbType.VarChar, 50);
		paddress.Direction = ParameterDirection.Input;
		paddress.Value = address;
		cmd.Parameters.Add(paddress);

		SqlParameter pcity = new SqlParameter("@city", SqlDbType.VarChar, 50);
		pcity.Direction = ParameterDirection.Input;
		pcity.Value = city;
		cmd.Parameters.Add(pcity);

		SqlParameter pcountry = new SqlParameter("@country", SqlDbType.VarChar, 50);
		pcountry.Direction = ParameterDirection.Input;
		pcountry.Value = country;
		cmd.Parameters.Add(pcountry);

		SqlParameter phowdid = new SqlParameter("@howdid", SqlDbType.VarChar, 50);
		phowdid.Direction = ParameterDirection.Input;
		phowdid.Value = howdid;
		cmd.Parameters.Add(phowdid);

		SqlParameter pstatus = new SqlParameter("@status", SqlDbType.Char, 1);
		pstatus.Direction = ParameterDirection.Input;
		pstatus.Value = status;
		cmd.Parameters.Add(pstatus);

		SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
		pReturnValue.Direction = ParameterDirection.Output;
		cmd.Parameters.Add(pReturnValue);

		try
		{
			cmd.ExecuteNonQuery();
		}
		catch (Exception exc) { return 0; }
		if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
			return 0;
		else
			return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
	}
	
    public int AddCandidate(int id, string title, string name, string email, string phone, string dob, string city,
        string countryresidence, string cityresidence, string address, string comments, string status,
        string storedProcedureName)
    {
        SqlCommand cmd = new SqlCommand(storedProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter pId = new SqlParameter("@id", SqlDbType.Int);
        pId.Direction = ParameterDirection.Input;
        pId.Value = id;
        cmd.Parameters.Add(pId);

        SqlParameter pVacancyId = new SqlParameter("@title", SqlDbType.VarChar,10);
        pVacancyId.Direction = ParameterDirection.Input;
        pVacancyId.Value = title;
        cmd.Parameters.Add(pVacancyId);

        SqlParameter pFirstName = new SqlParameter("@name", SqlDbType.VarChar, 100);
        pFirstName.Direction = ParameterDirection.Input;
        pFirstName.Value = name;
        cmd.Parameters.Add(pFirstName);

        SqlParameter pEmailId = new SqlParameter("@email", SqlDbType.VarChar, 50);
		pEmailId.Direction = ParameterDirection.Input;
        pEmailId.Value = email;
		cmd.Parameters.Add(pEmailId);

        SqlParameter pAge = new SqlParameter("@phone", SqlDbType.VarChar,50);
		pAge.Direction = ParameterDirection.Input;
        pAge.Value = phone;
		cmd.Parameters.Add(pAge);

        SqlParameter pGender = new SqlParameter("@dob", SqlDbType.DateTime);
        pGender.Direction = ParameterDirection.Input;
        pGender.Value = dob;
        cmd.Parameters.Add(pGender);

        SqlParameter pNationality = new SqlParameter("@city", SqlDbType.VarChar, 50);
		pNationality.Direction = ParameterDirection.Input;
        pNationality.Value = city;
		cmd.Parameters.Add(pNationality);

        SqlParameter pMobile = new SqlParameter("@countryresidence", SqlDbType.VarChar, 50);
        pMobile.Direction = ParameterDirection.Input;
        pMobile.Value = countryresidence;
        cmd.Parameters.Add(pMobile);

        SqlParameter pDateApplied = new SqlParameter("@cityresidence", SqlDbType.VarChar, 50);
        pDateApplied.Direction = ParameterDirection.Input;
        pDateApplied.Value = cityresidence;
        cmd.Parameters.Add(pDateApplied);

        SqlParameter paddress = new SqlParameter("@address", SqlDbType.VarChar, 50);
        paddress.Direction = ParameterDirection.Input;
        paddress.Value = address;
        cmd.Parameters.Add(paddress);

        SqlParameter pResume = new SqlParameter("@comments", SqlDbType.Text);
        pResume.Direction = ParameterDirection.Input;
        pResume.Value = comments;
        cmd.Parameters.Add(pResume);

        SqlParameter pstatus = new SqlParameter("@status", SqlDbType.Char, 1);
        pstatus.Direction = ParameterDirection.Input;
        pstatus.Value = status;
        cmd.Parameters.Add(pstatus);

        SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
        pReturnValue.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(pReturnValue);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc) { return 0; }
        if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
    }


    public int AddDonation(int id, string donatekind, string name, string email, string phone, string address,
        string wishtodonate, string cheque, string amount, string dated, string drawnon, string amountcredited,
        string date, string storedProcedureName)
    {
        SqlCommand cmd = new SqlCommand(storedProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter pId = new SqlParameter("@id", SqlDbType.Int);
        pId.Direction = ParameterDirection.Input;
        pId.Value = id;
        cmd.Parameters.Add(pId);

        SqlParameter pVacancyId = new SqlParameter("@donatekind", SqlDbType.VarChar, 50);
        pVacancyId.Direction = ParameterDirection.Input;
        pVacancyId.Value = donatekind;
        cmd.Parameters.Add(pVacancyId);

        SqlParameter pFirstName = new SqlParameter("@name", SqlDbType.VarChar, 100);
        pFirstName.Direction = ParameterDirection.Input;
        pFirstName.Value = name;
        cmd.Parameters.Add(pFirstName);

        SqlParameter pEmailId = new SqlParameter("@email", SqlDbType.VarChar, 50);
        pEmailId.Direction = ParameterDirection.Input;
        pEmailId.Value = email;
        cmd.Parameters.Add(pEmailId);

        SqlParameter pAge = new SqlParameter("@phone", SqlDbType.VarChar, 50);
        pAge.Direction = ParameterDirection.Input;
        pAge.Value = phone;
        cmd.Parameters.Add(pAge);

        SqlParameter pGender = new SqlParameter("@address", SqlDbType.Text);
        pGender.Direction = ParameterDirection.Input;
        pGender.Value = address;
        cmd.Parameters.Add(pGender);

        SqlParameter pNationality = new SqlParameter("@wishtodonate", SqlDbType.Text);
        pNationality.Direction = ParameterDirection.Input;
        pNationality.Value = wishtodonate;
        cmd.Parameters.Add(pNationality);

        SqlParameter pMobile = new SqlParameter("@cheque", SqlDbType.VarChar, 50);
        pMobile.Direction = ParameterDirection.Input;
        pMobile.Value = cheque;
        cmd.Parameters.Add(pMobile);

        SqlParameter pDateApplied = new SqlParameter("@amount", SqlDbType.VarChar, 50);
        pDateApplied.Direction = ParameterDirection.Input;
        pDateApplied.Value = amount;
        cmd.Parameters.Add(pDateApplied);

        SqlParameter paddress = new SqlParameter("@dated", SqlDbType.VarChar, 50);
        paddress.Direction = ParameterDirection.Input;
        paddress.Value = dated;
        cmd.Parameters.Add(paddress);

        SqlParameter pResume = new SqlParameter("@drawnon", SqlDbType.VarChar,50);
        pResume.Direction = ParameterDirection.Input;
        pResume.Value = drawnon;
        cmd.Parameters.Add(pResume);

        SqlParameter pstatus = new SqlParameter("@amountcredited", SqlDbType.VarChar, 50);
        pstatus.Direction = ParameterDirection.Input;
        pstatus.Value = amountcredited;
        cmd.Parameters.Add(pstatus);

        SqlParameter pdate = new SqlParameter("@date", SqlDbType.VarChar, 50);
        pdate.Direction = ParameterDirection.Input;
        pdate.Value = date;
        cmd.Parameters.Add(pdate);

        SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
        pReturnValue.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(pReturnValue);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc) { return 0; }
        if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
    }

    public int AddTestimonials(int id, string name, string email, string phone, string comments, string status,
        string storedProcedureName)
    {
        SqlCommand cmd = new SqlCommand(storedProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter pId = new SqlParameter("@id", SqlDbType.Int);
        pId.Direction = ParameterDirection.Input;
        pId.Value = id;
        cmd.Parameters.Add(pId);

        SqlParameter pVacancyId = new SqlParameter("@name", SqlDbType.VarChar, 100);
        pVacancyId.Direction = ParameterDirection.Input;
        pVacancyId.Value = name;
        cmd.Parameters.Add(pVacancyId);

        SqlParameter pFirstName = new SqlParameter("@email", SqlDbType.VarChar, 50);
        pFirstName.Direction = ParameterDirection.Input;
        pFirstName.Value = email;
        cmd.Parameters.Add(pFirstName);

        SqlParameter pEmailId = new SqlParameter("@phone", SqlDbType.VarChar, 50);
        pEmailId.Direction = ParameterDirection.Input;
        pEmailId.Value = phone;
        cmd.Parameters.Add(pEmailId);

        SqlParameter pGender = new SqlParameter("@comments", SqlDbType.Text);
        pGender.Direction = ParameterDirection.Input;
        pGender.Value = comments;
        cmd.Parameters.Add(pGender);

        SqlParameter pNationality = new SqlParameter("@status", SqlDbType.Char, 1);
        pNationality.Direction = ParameterDirection.Input;
        pNationality.Value = status;
        cmd.Parameters.Add(pNationality);

        SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
        pReturnValue.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(pReturnValue);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc) { return 0; }
        if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
    }

    public int AddRentalProduct(int productId, int categoryId, string name, string make, string brand,
        decimal price, string year, string country, string originalColor, string liftingCapacity,
        bool arrivedProduct, bool comingProduct, string details, string imageName, string storedProcedureName)
    {
        SqlCommand cmd = new SqlCommand(storedProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter pProductId = new SqlParameter("@ProductId", SqlDbType.Int);
        pProductId.Direction = ParameterDirection.Input;
        pProductId.Value = productId;
        cmd.Parameters.Add(pProductId);

        SqlParameter pCategoryId = new SqlParameter("@CategoryId", SqlDbType.Int);
        pCategoryId.Direction = ParameterDirection.Input;
        pCategoryId.Value = categoryId;
        cmd.Parameters.Add(pCategoryId);

        SqlParameter pName = new SqlParameter("@Name", SqlDbType.VarChar, 100);
        pName.Direction = ParameterDirection.Input;
        pName.Value = name;
        cmd.Parameters.Add(pName);

        SqlParameter pMake = new SqlParameter("@Make", SqlDbType.VarChar, 100);
        pMake.Direction = ParameterDirection.Input;
        pMake.Value = make;
        cmd.Parameters.Add(pMake);

        SqlParameter pBrand = new SqlParameter("@Brand", SqlDbType.VarChar, 100);
        pBrand.Direction = ParameterDirection.Input;
        pBrand.Value = brand;
        cmd.Parameters.Add(pBrand);

        SqlParameter pPrice = new SqlParameter("@Price", SqlDbType.Decimal);
        pPrice.Direction = ParameterDirection.Input;
        pPrice.Value = price;
        cmd.Parameters.Add(pPrice);

        SqlParameter pYear = new SqlParameter("@Year", SqlDbType.VarChar, 50);
        pYear.Direction = ParameterDirection.Input;
        pYear.Value = year;
        cmd.Parameters.Add(pYear);

        SqlParameter pCountry = new SqlParameter("@Country", SqlDbType.VarChar, 50);
        pCountry.Direction = ParameterDirection.Input;
        pCountry.Value = country;
        cmd.Parameters.Add(pCountry);

        SqlParameter pOriginalColor = new SqlParameter("@OriginalColor", SqlDbType.VarChar, 50);
        pOriginalColor.Direction = ParameterDirection.Input;
        pOriginalColor.Value = originalColor;
        cmd.Parameters.Add(pOriginalColor);

        SqlParameter pLiftingCapacity = new SqlParameter("@LiftingCapacity", SqlDbType.VarChar, 50);
        pLiftingCapacity.Direction = ParameterDirection.Input;
        pLiftingCapacity.Value = liftingCapacity;
        cmd.Parameters.Add(pLiftingCapacity);

        SqlParameter pArrivedProduct = new SqlParameter("@ArrivedProduct", SqlDbType.Bit);
        pArrivedProduct.Direction = ParameterDirection.Input;
        pArrivedProduct.Value = arrivedProduct;
        cmd.Parameters.Add(pArrivedProduct);

        SqlParameter pComingProduct = new SqlParameter("@ComingProduct", SqlDbType.Bit);
        pComingProduct.Direction = ParameterDirection.Input;
        pComingProduct.Value = comingProduct;
        cmd.Parameters.Add(pComingProduct);

        SqlParameter pDetails = new SqlParameter("@Details", SqlDbType.Text);
        pDetails.Direction = ParameterDirection.Input;
        pDetails.Value = details;
        cmd.Parameters.Add(pDetails);

        SqlParameter pImageName = new SqlParameter("@ImageName", SqlDbType.VarChar, 200);
        pImageName.Direction = ParameterDirection.Input;
        pImageName.Value = imageName;
        cmd.Parameters.Add(pImageName);

        SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
        pReturnValue.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(pReturnValue);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc) { return 0; }
        if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
    }

    public int AddQuestion(int itemId, string name, string details,
            string pdfFile, string imageName, string storedProcedureName)
    {
        SqlCommand cmd = new SqlCommand(storedProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter pItemId = new SqlParameter("@ItemId", SqlDbType.Int);
        pItemId.Direction = ParameterDirection.Input;
        pItemId.Value = itemId;
        cmd.Parameters.Add(pItemId);

        SqlParameter pName = new SqlParameter("@Name", SqlDbType.VarChar, 100);
        pName.Direction = ParameterDirection.Input;
        pName.Value = name;
        cmd.Parameters.Add(pName);

        SqlParameter pDetails = new SqlParameter("@Details", SqlDbType.Text);
        pDetails.Direction = ParameterDirection.Input;
        pDetails.Value = details;
        cmd.Parameters.Add(pDetails);

        SqlParameter pPDFFile = new SqlParameter("@PDFFile", SqlDbType.VarChar, 100);
        pPDFFile.Direction = ParameterDirection.Input;
        pPDFFile.Value = pdfFile;
        cmd.Parameters.Add(pPDFFile);

        SqlParameter pImageName = new SqlParameter("@ImageName", SqlDbType.VarChar, 100);
        pImageName.Direction = ParameterDirection.Input;
        pImageName.Value = imageName;
        cmd.Parameters.Add(pImageName);

        SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
        pReturnValue.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(pReturnValue);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc) { return 0; }
        if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
    }

    public int AddDownloadItems(int itemId, string name, string details,
            string pdfFile, string imageName, string storedProcedureName)
    {
        SqlCommand cmd = new SqlCommand(storedProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter pItemId = new SqlParameter("@ItemId", SqlDbType.Int);
        pItemId.Direction = ParameterDirection.Input;
        pItemId.Value = itemId;
        cmd.Parameters.Add(pItemId);

        SqlParameter pName = new SqlParameter("@Name", SqlDbType.VarChar, 100);
        pName.Direction = ParameterDirection.Input;
        pName.Value = name;
        cmd.Parameters.Add(pName);

        SqlParameter pDetails = new SqlParameter("@Details", SqlDbType.Text);
        pDetails.Direction = ParameterDirection.Input;
        pDetails.Value = details;
        cmd.Parameters.Add(pDetails);

        SqlParameter pPDFFile = new SqlParameter("@PDFFile", SqlDbType.VarChar, 100);
        pPDFFile.Direction = ParameterDirection.Input;
        pPDFFile.Value = pdfFile;
        cmd.Parameters.Add(pPDFFile);

        SqlParameter pImageName = new SqlParameter("@ImageName", SqlDbType.VarChar, 100);
        pImageName.Direction = ParameterDirection.Input;
        pImageName.Value = imageName;
        cmd.Parameters.Add(pImageName);

        SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
        pReturnValue.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(pReturnValue);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc) { return 0; }
        if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
    }

    public int AddProduct(int productId, int categoryId, string name, string details, 
            string imageName, string storedProcedureName)
    {
        SqlCommand cmd = new SqlCommand(storedProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter pProductId = new SqlParameter("@ProductId", SqlDbType.Int);
        pProductId.Direction = ParameterDirection.Input;
        pProductId.Value = productId;
        cmd.Parameters.Add(pProductId);

        SqlParameter pCategoryId = new SqlParameter("@CategoryId", SqlDbType.Int);
        pCategoryId.Direction = ParameterDirection.Input;
        pCategoryId.Value = categoryId;
        cmd.Parameters.Add(pCategoryId);

        SqlParameter pName = new SqlParameter("@Name", SqlDbType.VarChar, 100);
        pName.Direction = ParameterDirection.Input;
        pName.Value = name;
        cmd.Parameters.Add(pName);

        SqlParameter pDetails = new SqlParameter("@Details", SqlDbType.Text);
        pDetails.Direction = ParameterDirection.Input;
        pDetails.Value = details;
        cmd.Parameters.Add(pDetails);

        SqlParameter pImageName = new SqlParameter("@ImageName", SqlDbType.VarChar, 200);
        pImageName.Direction = ParameterDirection.Input;
        pImageName.Value = imageName;
        cmd.Parameters.Add(pImageName);

        SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
        pReturnValue.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(pReturnValue);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc) { return 0; }
        if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
    }

    public int AddProduct(int productId, int categoryId, string name, string make, string brand, 
        decimal price, string year, string country, string originalColor, string liftingCapacity, 
        bool arrivedProduct, bool comingProduct, string details, string imageName, string storedProcedureName)
    {
        SqlCommand cmd = new SqlCommand(storedProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter pProductId = new SqlParameter("@ProductId", SqlDbType.Int);
        pProductId.Direction = ParameterDirection.Input;
        pProductId.Value = productId;
        cmd.Parameters.Add(pProductId);

        SqlParameter pCategoryId = new SqlParameter("@CategoryId", SqlDbType.Int);
        pCategoryId.Direction = ParameterDirection.Input;
        pCategoryId.Value = categoryId;
        cmd.Parameters.Add(pCategoryId);

        SqlParameter pName = new SqlParameter("@Name", SqlDbType.VarChar, 100);
        pName.Direction = ParameterDirection.Input;
        pName.Value = name;
        cmd.Parameters.Add(pName);

        SqlParameter pMake = new SqlParameter("@Make", SqlDbType.VarChar, 100);
        pMake.Direction = ParameterDirection.Input;
        pMake.Value = make;
        cmd.Parameters.Add(pMake);

        SqlParameter pBrand = new SqlParameter("@Brand", SqlDbType.VarChar, 100);
        pBrand.Direction = ParameterDirection.Input;
        pBrand.Value = brand;
        cmd.Parameters.Add(pBrand);

        SqlParameter pPrice = new SqlParameter("@Price", SqlDbType.Decimal);
        pPrice.Direction = ParameterDirection.Input;
        pPrice.Value = price;
        cmd.Parameters.Add(pPrice);

        SqlParameter pYear = new SqlParameter("@Year", SqlDbType.VarChar, 50);
        pYear.Direction = ParameterDirection.Input;
        pYear.Value = year;
        cmd.Parameters.Add(pYear);

        SqlParameter pCountry = new SqlParameter("@Country", SqlDbType.VarChar, 50);
        pCountry.Direction = ParameterDirection.Input;
        pCountry.Value = country;
        cmd.Parameters.Add(pCountry);

        SqlParameter pOriginalColor = new SqlParameter("@OriginalColor", SqlDbType.VarChar, 50);
        pOriginalColor.Direction = ParameterDirection.Input;
        pOriginalColor.Value = originalColor;
        cmd.Parameters.Add(pOriginalColor);

        SqlParameter pLiftingCapacity = new SqlParameter("@LiftingCapacity", SqlDbType.VarChar, 50);
        pLiftingCapacity.Direction = ParameterDirection.Input;
        pLiftingCapacity.Value = liftingCapacity;
        cmd.Parameters.Add(pLiftingCapacity);

        SqlParameter pArrivedProduct = new SqlParameter("@ArrivedProduct", SqlDbType.Bit);
        pArrivedProduct.Direction = ParameterDirection.Input;
        pArrivedProduct.Value = arrivedProduct;
        cmd.Parameters.Add(pArrivedProduct);

        SqlParameter pComingProduct = new SqlParameter("@ComingProduct", SqlDbType.Bit);
        pComingProduct.Direction = ParameterDirection.Input;
        pComingProduct.Value = comingProduct;
        cmd.Parameters.Add(pComingProduct);

        SqlParameter pDetails = new SqlParameter("@Details", SqlDbType.Text);
        pDetails.Direction = ParameterDirection.Input;
        pDetails.Value = details;
        cmd.Parameters.Add(pDetails);

        SqlParameter pImageName = new SqlParameter("@ImageName", SqlDbType.VarChar, 200);
        pImageName.Direction = ParameterDirection.Input;
        pImageName.Value = imageName;
        cmd.Parameters.Add(pImageName);

        SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
        pReturnValue.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(pReturnValue);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc) { return 0; }
        if (cmd.Parameters["@ReturnValue"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value));
    }


    public void menu(Menu mnu, string str)
    {
        DataSet ds = new DataSet();
        da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        mnu.Items.Clear();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            mnu.Items.Add(new MenuItem(ds.Tables[0].Rows[i]["showroomname"].ToString()));
            mnu.DataBind();
        }
    }

    public int AddRentalCategory(int categoryId, string categoryName, int parentId, string storedProcedureName)
    {
        SqlCommand cmd = new SqlCommand(storedProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter pCategoryid = new SqlParameter("@Categoryid", SqlDbType.Int);
        pCategoryid.Direction = ParameterDirection.Input;
        pCategoryid.Value = categoryId;
        cmd.Parameters.Add(pCategoryid);

        SqlParameter pCategoryName = new SqlParameter("@CategoryName", SqlDbType.VarChar, 100);
        pCategoryName.Direction = ParameterDirection.Input;
        pCategoryName.Value = categoryName;
        cmd.Parameters.Add(pCategoryName);

        SqlParameter pParentId = new SqlParameter("@ParentId", SqlDbType.Int);
        pParentId.Direction = ParameterDirection.Input;
        pParentId.Value = parentId;
        cmd.Parameters.Add(pParentId);

        SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
        pReturnValue.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(pReturnValue);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc) { return 0; }

        if (cmd.Parameters["@Returnvalue"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@Returnvalue"].Value));
    }

    public int AddCategory(int categoryId, string categoryName, int parentId, string storedProcedureName)
    {
        SqlCommand cmd = new SqlCommand(storedProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter pCategoryid = new SqlParameter("@Categoryid", SqlDbType.Int);
        pCategoryid.Direction = ParameterDirection.Input;
        pCategoryid.Value = categoryId;
        cmd.Parameters.Add(pCategoryid);

        SqlParameter pCategoryName = new SqlParameter("@CategoryName", SqlDbType.VarChar, 100);
        pCategoryName.Direction = ParameterDirection.Input;
        pCategoryName.Value = categoryName;
        cmd.Parameters.Add(pCategoryName);

        SqlParameter pParentId = new SqlParameter("@ParentId", SqlDbType.Int);
        pParentId.Direction = ParameterDirection.Input;
        pParentId.Value = parentId;
        cmd.Parameters.Add(pParentId);

        SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
        pReturnValue.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(pReturnValue);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc) { return 0;}

        if (cmd.Parameters["@Returnvalue"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@Returnvalue"].Value));
    }

    public int InsertSubcategory(int subcategoryId, string categoryId, string subcategoryName, string storedProcedureName)
    {
        SqlCommand cmd = new SqlCommand(storedProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter pSubcategoryid = new SqlParameter("@Subcategoryid", SqlDbType.Int);
        pSubcategoryid.Direction = ParameterDirection.Input;
        pSubcategoryid.Value = subcategoryId;
        cmd.Parameters.Add(pSubcategoryid);

        SqlParameter pCategoryid = new SqlParameter("@Categoryid", SqlDbType.Int);
        pCategoryid.Direction = ParameterDirection.Input;
        pCategoryid.Value = categoryId;
        cmd.Parameters.Add(pCategoryid);

        SqlParameter pSubcategoryName = new SqlParameter("@SubcategoryName", SqlDbType.VarChar, 100);
        pSubcategoryName.Direction = ParameterDirection.Input;
        pSubcategoryName.Value = subcategoryName;
        cmd.Parameters.Add(pSubcategoryName);

        SqlParameter pReturnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
        pReturnValue.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(pReturnValue);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc) { return 0; }

        if (cmd.Parameters["@Returnvalue"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@Returnvalue"].Value));
    }

    public int GalleryEntry(int id, string imgName, string procedurename)
    { 
        SqlCommand cmd = new SqlCommand(procedurename, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
        p1.Direction = ParameterDirection.Input;
        p1.Value = id;
        cmd.Parameters.Add(p1);

        SqlParameter p2 = new SqlParameter("@imgName", SqlDbType.VarChar, 150);
        p2.Direction = ParameterDirection.Input;
        p2.Value = imgName;
        cmd.Parameters.Add(p2);
        
        SqlParameter p4 = new SqlParameter("@moid", SqlDbType.Int);
        p4.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(p4);
        cmd.ExecuteNonQuery();

        if (cmd.Parameters["@moid"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@moid"].Value));

    }
    //public int productentry(int productid, string productname, string category, string procedurename, string image, string color)
    //{

    //    SqlCommand cmd = new SqlCommand(procedurename, con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    SqlParameter p1 = new SqlParameter("@productid", SqlDbType.Int);
    //    p1.Direction = ParameterDirection.Input;
    //    p1.Value = productid;
    //    cmd.Parameters.Add(p1);
    //    SqlParameter p2 = new SqlParameter("@productname", SqlDbType.VarChar, 100);
    //    p2.Direction = ParameterDirection.Input;
    //    p2.Value = productname;
    //    cmd.Parameters.Add(p2);
    //    SqlParameter pn2 = new SqlParameter("@category", SqlDbType.VarChar, 100);
    //    pn2.Direction = ParameterDirection.Input;
    //    pn2.Value = category;
    //    cmd.Parameters.Add(pn2);
    //    SqlParameter psn2 = new SqlParameter("@color", SqlDbType.VarChar, 50);
    //    psn2.Direction = ParameterDirection.Input;
    //    psn2.Value = color;
    //    cmd.Parameters.Add(psn2);
    //    SqlParameter p786 = new SqlParameter("@image", SqlDbType.VarChar, 50);
    //    p786.Direction = ParameterDirection.Input;
    //    p786.Value = image;
    //    cmd.Parameters.Add(p786);
    //    SqlParameter p4 = new SqlParameter("@moid", SqlDbType.Int, 50);
    //    p4.Direction = ParameterDirection.Output;
    //    cmd.Parameters.Add(p4);
    //    cmd.ExecuteNonQuery();

    //    if (cmd.Parameters["@moid"].Value == DBNull.Value)
    //        return 0;
    //    else
    //        return (Convert.ToInt32(cmd.Parameters["@moid"].Value));

    //}

    
    public void fileUpload(string path, FileUpload flUpload, string dt)
    {
        string fileName = dt + flUpload.FileName;
        flUpload.SaveAs(path + "\\" + fileName);

        //string fileName = "";
        //string strErr = "";
        //fileName = fileUploaderName.FileName.ToString();

        //if (fileName != "")
        //{
        //    fileName = timeExt + fileUploaderName.FileName.ToString();
        //    string fileExt = Path.GetExtension(fileUploaderName.FileName).ToLower();
        //    if (Directory.Exists("" + fileName) == false)
        //    {
        //        fileUploaderName.SaveAs(path + "\\" + fileName); 
        //        fileName = fileName; 
        //    }
        //}
        //return fileName.Length;
    }

    public int newsEntry(int newsid, DateTime ndate, string news, string image, string procedurename, string newstitle, string snews)
    {

        SqlCommand cmd = new SqlCommand(procedurename, con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter p1 = new SqlParameter("@newsid", SqlDbType.Int);
        p1.Direction = ParameterDirection.Input;
        p1.Value = newsid;
        cmd.Parameters.Add(p1);
        SqlParameter p2 = new SqlParameter("@ndate", SqlDbType.DateTime);
        p2.Direction = ParameterDirection.Input;
        p2.Value = ndate;
        cmd.Parameters.Add(p2);
        SqlParameter p3 = new SqlParameter("@news", SqlDbType.Text);
        p3.Direction = ParameterDirection.Input;
        p3.Value = news;
        cmd.Parameters.Add(p3);
        SqlParameter ps3 = new SqlParameter("@snews", SqlDbType.VarChar, 150);
        ps3.Direction = ParameterDirection.Input;
        ps3.Value = news;
        cmd.Parameters.Add(ps3);
        SqlParameter p5 = new SqlParameter("@image", SqlDbType.VarChar, 50);
        p5.Direction = ParameterDirection.Input;
        p5.Value = image;
        cmd.Parameters.Add(p5);
        SqlParameter p15 = new SqlParameter("@newstitle", SqlDbType.VarChar, 60);
        p15.Direction = ParameterDirection.Input;
        p15.Value = newstitle;
        cmd.Parameters.Add(p15);
        SqlParameter p4 = new SqlParameter("@moid", SqlDbType.Int, 50);
        p4.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(p4);
        cmd.ExecuteNonQuery();

        if (cmd.Parameters["@moid"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@moid"].Value));

    }

    public int InsertLogin(int userId, string username, string password, string emailId, string procedurename)
    {
        SqlCommand cmd = new SqlCommand(procedurename, con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter p11 = new SqlParameter("@UserId", SqlDbType.Int);
        p11.Direction = ParameterDirection.Input;
        p11.Value = userId;
        cmd.Parameters.Add(p11);

        SqlParameter p1 = new SqlParameter("@UserName", SqlDbType.VarChar, 40);
        p1.Direction = ParameterDirection.Input;
        p1.Value = username;
        cmd.Parameters.Add(p1);

        SqlParameter p2 = new SqlParameter("@password", SqlDbType.VarChar, 30);
        p2.Direction = ParameterDirection.Input;
        p2.Value = password;
        cmd.Parameters.Add(p2);

        SqlParameter p22 = new SqlParameter("@EmailId", SqlDbType.VarChar, 100);
        p22.Direction = ParameterDirection.Input;
        p22.Value = emailId;
        cmd.Parameters.Add(p22);

        SqlParameter p4 = new SqlParameter("@ReturnValue", SqlDbType.Int);
        p4.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(p4);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc) { return 0; }

        if (cmd.Parameters["@Returnvalue"].Value == DBNull.Value)
            return 0;
        else
            return (Convert.ToInt32(cmd.Parameters["@Returnvalue"].Value));
    }

    public void loginEntry(string username, string password, string procedurename, string email)
    {

        SqlCommand cmd = new SqlCommand(procedurename, con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter p1 = new SqlParameter("@username", SqlDbType.VarChar, 50);
        p1.Direction = ParameterDirection.Input;
        p1.Value = username;
        cmd.Parameters.Add(p1);
        SqlParameter p2 = new SqlParameter("@password", SqlDbType.VarChar, 50);
        p2.Direction = ParameterDirection.Input;
        p2.Value = password;
        cmd.Parameters.Add(p2);
        SqlParameter p3 = new SqlParameter("@email", SqlDbType.VarChar, 50);
        p3.Direction = ParameterDirection.Input;
        p3.Value = email;
        cmd.Parameters.Add(p3);
        SqlParameter p4 = new SqlParameter("@moid", SqlDbType.VarChar, 50);
        p4.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(p4);
        cmd.ExecuteNonQuery(); 
    }



    public Boolean insRec(string qry)
    {
        try
        {
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception err) { }

        return false; 
    } 
    
}
