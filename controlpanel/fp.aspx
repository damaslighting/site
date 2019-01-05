<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fp.aspx.cs" Inherits="Admin_fp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>One Way Star Digital</title>
<LINK REL="SHORTCUT ICON" HREF="../images/logo.ico" />
     <link rel="stylesheet" type="text/css" href="../App_Themes/admin/admin_pages.css" />
      
</head>
<body>
    <form id="form1" runat="server" style="width:100%" >
    <table style="height:400px; width:100%; vertical-align:middle; text-align:center;">
        <tr>
            <td>
  <table width="500" border="0" align="center" cellpadding="0" cellspacing="5" class="page_heading" style="border:1px solid silver;">
    <tr> 
      <td height="25" colspan="2" class="page_heading"> Password Reminder</td>
    </tr>
    <tr> 
      <td height="25" colspan="2" align="center" style="color:Red;" >
          <asp:Literal  ID="Literal1"  runat="server"></asp:Literal></td>
    </tr>
    <tr> 
      <td height="25" align="right"><font size="2" face="Verdana">Email id (provided for registration)&nbsp;</font></td>
      <td height="25" style="text-align:left;">
          <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
    </tr>
   
    <tr> 
      <td ><div align="right"><asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="reset" /></div></td>
      <td height="25" style="text-align:left;"><asp:Button ID="Button1" runat="server"  onclick="Button1_Click" Text="Request Password" /></td></tr>
    <tr> 
      <td height="25" colspan="2" class="logout" ><div align="center"><font size="2" face="Verdana"><b>
     <a href="Default.aspx" >Return To Login&nbsp; Page</a></b></font></div></td>
    </tr>
    <tr align="center" > 
      <td colspan="2" style="font-size:11px;">copyrights © One Way Star Digital</td>
    </tr>
  </table>
    </td>
        </tr>
    </table>
    </form>
</body>
</html>
