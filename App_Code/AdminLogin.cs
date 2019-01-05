using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for AdminLogin
/// </summary>
public partial class AdminLogin
{
    DataClassesDataContext dbs = new DataClassesDataContext();  

	public System.Linq.IQueryable<AdminLogin> get_admin_user(string username, string password)
	{
		var admin_user = from p in dbs.AdminLogins
						 where p.username == username && p.password == password
						 select p;

		return admin_user;
	}

	public System.Linq.IQueryable<AdminLogin> get_admin_user(string email)
	{
		var res = from data in dbs.AdminLogins
				  where data.email == email
				  select data;
		return res;
	}


	public bool change_admin_user_password(string username, string newpassword)
	{
		try
		{
			AdminLogin cc = dbs.AdminLogins.Single(p => p.username == username);
			cc.password = newpassword;
			dbs.SubmitChanges();
		}
		catch (Exception err) { return false; }
		return true;
	}



	public System.Linq.IQueryable<AdminLogin> get_adin_login(string username, string password)
	{
		var res = from data in dbs.AdminLogins
				  where data.username == username && data.password == password
				  select data;
		return res;
	}

}
