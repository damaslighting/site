using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Linq;
using System.Web.UI.WebControls;

public class My_utl
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    string _ConnectionString;
    DataClassesDataContext dbs = new DataClassesDataContext();
    
    //public int add_category(int id, string catname, string catimg, string status)
    //{
    //    if (id == 0)
    //    {
    //        int id1 = 0;
    //        category obj = new category();
    //        obj.catname = catname;
    //        obj.catimg = catimg;
    //        obj.status = status;
    //        try
    //        {
    //            dbs.categories.InsertOnSubmit(obj);
    //            dbs.SubmitChanges();
    //            id = obj.id;
    //        }
    //        catch (Exception err) { }
    //        return id;
    //    }
    //    else
    //    {
    //        try
    //        {
    //            category obj = dbs.categories.Single(a => a.id == id);
    //            obj.catname = catname;
    //            obj.catimg = catimg;
    //            obj.status = status;
    //            dbs.SubmitChanges();
    //        }
    //        catch (Exception err) { return 0; }
    //        return id;
    //    }
    //    return id;
    //}
   // public int add_subcategory(int id, int cat, string subcatname, string subcatimg, string status, string subdetail)
    //public int add_subcategory(int id,int cat,string subcatname,string status)
    //{
    //    if (id == 0)
    //    {
    //        int id1 = 0;
    //        subcategory obj = new subcategory();
    //        obj.cat = cat;
    //        obj.subcatname = subcatname;
    //       // obj.subcatimg = subcatimg;
    //        obj.status = status;
    //       // obj.subdetail = subdetail;
    //        try
    //        {
    //            dbs.subcategories.InsertOnSubmit(obj);
    //            dbs.SubmitChanges();
    //            id = obj.id;
    //        }
    //        catch (Exception err) { }
    //        return id;
    //    }
    //    else
    //    {
    //        try
    //        {
    //            subcategory obj = dbs.subcategories.Single(a => a.id == id);
    //            obj.cat = cat;
    //            obj.subcatname = subcatname;
    //           // obj.subcatimg = subcatimg;
    //            obj.status = status;
    //           // obj.subdetail = subdetail;
    //            dbs.SubmitChanges();
    //        }
    //        catch (Exception err) { return 0; }
    //        return id;
    //    }
    //    return id;
    //}
    //public int add_service(int id, string cid, string sid, string pname, string pimg, string pdetails, string status)
    //{
    //    if (id == 0)
    //    {
    //        int id1 = 0;
    //        service obj = new service();
    //        obj.cid = Convert.ToInt32(cid);
    //        obj.sid = Convert.ToInt32(sid);
    //        obj.pname = pname;
    //        obj.pimg = pimg;
    //        obj.pdetails = pdetails;
    //        obj.status = status;
    //        try
    //        {
    //            dbs.services.InsertOnSubmit(obj);
    //            dbs.SubmitChanges();
    //            id = obj.id;
    //        }
    //        catch (Exception err) { }
    //        return id;
    //    }
    //    else
    //    {
    //        try
    //        {
    //            service obj = dbs.services.Single(a => a.id == id);
    //            obj.cid = Convert.ToInt32(cid);
    //            obj.sid = Convert.ToInt32(sid);
    //            obj.pname = pname;
    //            obj.pimg = pimg;
    //            obj.pdetails = pdetails;
    //            obj.status = status;
    //            dbs.SubmitChanges();
    //        }
    //        catch (Exception err) { return 0; }
    //        return id;
    //    }
    //    return id;
    //}
    //public int add_data(int id, string uid, string filename, string fileupload, string status)
    //{
    //    if (id == 0)
    //    {
    //        int id1 = 0;
    //        data obj = new data();
    //        obj.uid = uid;
    //        obj.filename = filename;
    //        obj.fileupload = fileupload;
    //        obj.status = status;
    //        try
    //        {
    //            dbs.datas.InsertOnSubmit(obj);
    //            dbs.SubmitChanges();
    //            id = obj.id;
    //        }
    //        catch (Exception err) { }
    //        return id;
    //    }
    //    else
    //    {
    //        try
    //        {
    //            data obj = dbs.datas.Single(a => a.id == id);
    //            obj.uid = uid;
    //            obj.filename = filename;
    //            obj.fileupload = fileupload;
    //            obj.status = status;
    //            dbs.SubmitChanges();
    //        }
    //        catch (Exception err) { return 0; }
    //        return id;
    //    }
    //    return id;
    //}
    //public int add_userlogin(int id, string name, string username, string password, string email, string address, string status)
    //{
    //    if (id == 0)
    //    {
    //        int id1 = 0;
    //        userlogin obj = new userlogin();
    //        obj.name = name;
    //        obj.username = username;
    //        obj.password = password;
    //        obj.email = email;
    //        obj.address = address;
    //        obj.status = status;
    //        try
    //        {
    //            dbs.userlogins.InsertOnSubmit(obj);
    //            dbs.SubmitChanges();
    //            id = obj.id;
    //        }
    //        catch (Exception err) { }
    //        return id;
    //    }
    //    else
    //    {
    //        try
    //        {
    //            userlogin obj = dbs.userlogins.Single(a => a.id == id);
    //            obj.name = name;
    //            obj.username = username;
    //            obj.password = password;
    //            obj.email = email;
    //            obj.address = address;
    //            obj.status = status;
    //            dbs.SubmitChanges();
    //        }
    //        catch (Exception err) { return 0; }
    //        return id;
    //    }
    //    return id;
    //}
    //public int add_news1(int id, string pname, string pimg, string pdetails, string detail, string status)
    //{
    //    if (id == 0)
    //    {
    //        int id1 = 0;
    //        news1 obj = new news1();
    //        obj.pname = pname;
    //        obj.pimg = pimg;
    //        obj.pdetails = pdetails;
    //        obj.detail = Convert.ToDateTime(detail);
    //        obj.status = status;
    //        try
    //        {
    //            dbs.news1s.InsertOnSubmit(obj);
    //            dbs.SubmitChanges();
    //            id = obj.id;
    //        }
    //        catch (Exception err) { }
    //        return id;
    //    }
    //    else
    //    {
    //        try
    //        {
    //            news1 obj = dbs.news1s.Single(a => a.id == id);
    //            obj.pname = pname;
    //            obj.pimg = pimg;
    //            obj.pdetails = pdetails;
    //            obj.detail = Convert.ToDateTime(detail);
    //            obj.status = status;
    //            dbs.SubmitChanges();
    //        }
    //        catch (Exception err) { return 0; }
    //        return id;
    //    }
    //    return id;
    //}



   
}