using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;


public static class dbMain
{
    public static SqlConnection CNN;
    public static SqlCommand CMMD;
    public static SqlDataAdapter ADPT;
    public static string CNNSTR = ConfigurationManager.ConnectionStrings["CNN_STR"].ConnectionString;
    public static ArrayList ARPRM = new ArrayList();
    public static ArrayList ARVAL = new ArrayList();

    public static bool EXE_FUN(string PROC, ArrayList PRAM, ArrayList VAL)
    {
        bool F;
        CNN = new SqlConnection(CNNSTR);
        CNN.Open();
        try
        {
            CMMD = new SqlCommand(PROC, CNN);
            CMMD.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < VAL.Count; i++)
            {
                CMMD.Parameters.AddWithValue(PRAM[i].ToString(), VAL[i]);
            }
            CMMD.ExecuteNonQuery();
            F = true;
        }
        catch (Exception ex)
        {
            F = false;
        }
        finally
        {
            CNN.Close();
        }
        return F;
    }
    public static bool EXE_FUN1(string PROC)
    {
        bool F;
        CNN = new SqlConnection(CNNSTR);
        CNN.Open();
        try
        {
            CMMD = new SqlCommand(PROC, CNN);
            CMMD.ExecuteNonQuery();
            F = true;
        }
        catch (Exception ex)
        {
            F = false;
        }
        finally
        {
            CNN.Close();
        }
        return F;
    }


    public static DataTable GET_DATA_TAB(string PROC, ArrayList PRAM, ArrayList VAL)
    {
        DataTable DT = new DataTable();
        CNN = new SqlConnection(CNNSTR);
        CNN.Open();
        try
        {
            CMMD = new SqlCommand(PROC, CNN);
            CMMD.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < VAL.Count; i++)
            {
                CMMD.Parameters.AddWithValue(PRAM[i].ToString(), VAL[i]);
            }
            ADPT = new SqlDataAdapter(CMMD);
            ADPT.Fill(DT);
        }
        catch (Exception ex)
        {
            DT = null;
        }
        finally
        {
            CNN.Close();
        }
        return DT;
    }

    public static DataTable GET_DATA_TAB1(string PROC)
    {
        DataTable DT = new DataTable();
        CNN = new SqlConnection(CNNSTR);
        CNN.Open();
        try
        {
            CMMD = new SqlCommand(PROC, CNN);
            ADPT = new SqlDataAdapter(CMMD);
            ADPT.Fill(DT);
        }
        catch (Exception ex)
        {
            DT = null;
        }
        finally
        {
            CNN.Close();
        }
        return DT;
    }
    public static string GET_DATA_TAB123(string PROC)
    {
        string str;
        DataTable DT = new DataTable();
        CNN = new SqlConnection(CNNSTR);
        CNN.Open();
        try
        {
            CMMD = new SqlCommand(PROC, CNN);
            ADPT = new SqlDataAdapter(CMMD);
            ADPT.Fill(DT);
            str = DT.Rows[0][0].ToString();
        }
        catch (Exception ex)
        {
            str = "";
        }
        finally
        {
            CNN.Close();
        }
        return str;
    }

    public static string GET_DATA_STRING(string PROC)
    {
        string str;
        DataTable DT = new DataTable();
        CNN = new SqlConnection(CNNSTR);
        CNN.Open();
        try
        {
            CMMD = new SqlCommand(PROC, CNN);
            ADPT = new SqlDataAdapter(CMMD);
            ADPT.Fill(DT);
            str = DT.Rows[0][0].ToString();
        }
        catch (Exception ex)
        {
            str = "";
        }
        finally
        {
            CNN.Close();
        }
        return str;
    }

    public static DataSet GET_DATA_SET(string PROC, ArrayList PRAM, ArrayList VAL)
    {
        DataSet DS = new DataSet();
        CNN = new SqlConnection(CNNSTR);
        CNN.Open();
        try
        {
            CMMD = new SqlCommand(PROC, CNN);
            CMMD.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < VAL.Count; i++)
            {
                CMMD.Parameters.AddWithValue(PRAM[i].ToString(), VAL[i]);
            }
            ADPT = new SqlDataAdapter(CMMD);
            ADPT.Fill(DS);
        }
        catch (Exception ex)
        {
            DS = null;
        }
        finally
        {
            CNN.Close();
        }
        return DS;
    }

    public static void GRID_BIND(GridView GRID, string PROC, ArrayList PRAM, ArrayList VAL)
    {
        DataTable DT = new DataTable();
        CNN = new SqlConnection(CNNSTR);
        CNN.Open();
        try
        {
            CMMD = new SqlCommand(PROC, CNN);
            CMMD.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < VAL.Count; i++)
            {
                CMMD.Parameters.AddWithValue(PRAM[i].ToString(), VAL[i]);
            }
            ADPT = new SqlDataAdapter(CMMD);
            ADPT.Fill(DT);
            GRID.DataSource = DT;
            GRID.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            CNN.Close();
        }
    }
    public static void LIST_BIND(ListView LIST, string PROC)
    {
        DataTable DT = new DataTable();
        CNN = new SqlConnection(CNNSTR);
        CNN.Open();
        try
        {
            ADPT = new SqlDataAdapter(PROC, CNN);
            ADPT.Fill(DT);
            LIST.DataSource = DT;
            LIST.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            CNN.Close();
        }
    }

    public static void DROP_BIND(DropDownList DRP, string PROC, ArrayList PRAM, ArrayList VAL, string VFIL,string TFIL)
    {
        DataTable DT = new DataTable();
        CNN = new SqlConnection(CNNSTR);
        CNN.Open();
        try
        {
            CMMD = new SqlCommand(PROC, CNN);
            CMMD.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < VAL.Count; i++)
            {
                CMMD.Parameters.AddWithValue(PRAM[i].ToString(), VAL[i]);
            }
            ADPT = new SqlDataAdapter(CMMD);
            ADPT.Fill(DT);
            DRP.DataSource = DT;
            DRP.DataTextField = TFIL;
            DRP.DataValueField = VFIL;
            DRP.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            CNN.Close();
        }
    }
    public static void DROP_BIND1(DropDownList ddl, string str, string text, string value)
    {
        DataSet ds = new DataSet();
        CNN = new SqlConnection(CNNSTR);
        CNN.Open();
        ADPT = new SqlDataAdapter(str, CNN);
        ADPT.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = ds.Tables[0];
            ddl.DataTextField = text;
            ddl.DataValueField = value;
            ddl.DataBind();
        }
        else
        {
            ddl.Items.Clear();
            ListItem list = new ListItem("Select", "0", true);
            ddl.Items.Insert(0, list);
        }
    }
    public static void DROP_CNT(DropDownList ddl, string cnt)
    {
        for (int i = 1; i <= Convert.ToInt32(cnt); i++)
        {
            ddl.Items.Add(i.ToString());
        }
    }

    public static void ResizeImage(string OriginalFile, string NewFile, int NewWidth, int MaxHeight, bool OnlyResizeIfWider)
    {
        System.Drawing.Image FullsizeImage = System.Drawing.Image.FromFile(OriginalFile);

        // Prevent using images internal thumbnail
        FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
        FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

        if (OnlyResizeIfWider)
        {
            if (FullsizeImage.Width <= NewWidth)
            {
                //this is also for change automaticaly fix the width of the image 
                NewWidth = FullsizeImage.Width;
                //  NewWidth = 150;
            }
        }

        //this is automatically fix the height of the image 
        int NewHeight = FullsizeImage.Height * NewWidth / FullsizeImage.Width;
        //     int NewHeight = 170;
        if (NewHeight > MaxHeight)
        {
            // Resize with height instead
            //this is automatically fix the width of the image  
            NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height;
            // NewWidth = 150;
            NewHeight = MaxHeight;
        }

        System.Drawing.Image NewImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);

        // Clear handle to original file so that we can overwrite it if necessary
        FullsizeImage.Dispose();

        // Save resized picture
        NewImage.Save(NewFile);

    }

    public static string disp(object obj)
    {
        if (obj.ToString() == "noimage.jpg") return "none";
        else return "block";
    }
}
