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
/// Summary description for Cls_message
/// </summary>
public class Cls_message
{
	public Cls_message()
	{
	 
	}

    public string getMessage(int msgId)
    {
        switch (msgId)
        {
            case 1: return "Record was Saved sucessfully.";
            case 2: return "Record cannot be saved.";
            case 3: return "Record was deleted sucessfully.";
            case 4: return "Record cannot be deleted.";
            case 5: return "Record was updated sucessfully.";
            case 6: return "Record cannot be updated.";

        }

        return "";
    }
}
