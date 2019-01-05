<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Damas Lighting LLC</title>
<LINK REL="SHORTCUT ICON" HREF="../images/logo.ico" />
<style type="text/css">
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	text-align: center;
}
</style>
<link href="images/login.css" rel="stylesheet" type="text/css" /> 
</head>
<body>
<form runat="server" >
<table width="100%" border="0"  height="673"cellspacing="0" cellpadding="0">
  <tr>
    <td align="center"  valign="middle"><table width="530" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td height="300px" valign="top" background="images/bglogin.png"><table width="530"  height="310px"border="0" cellspacing="0" cellpadding="3" style="background-repeat:no-repeat; text-align: center;">
          <tr>
            <td width="6%">&nbsp;</td>
            <td width="88%" valign="top" class="style">Admin Control Panel </td>
            <td width="6%">&nbsp;</td>
          </tr>
           
          <tr>
            <td>&nbsp;</td>
            <td style="text-align:center;" height="40" class="style2">
            <h2 >
               <%-- <img src="images/logo01.png" />--%>Damas Lighting LLC</h2></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="3">
              <tr>
                <td width="39%" class="text" style="text-align: right"></td>
                <td width="3%" style="text-align: center"></td>
                <td width="58%" class="msg"><asp:Literal ID="lbl_msg"  runat="server"></asp:Literal>
                  </td>
              </tr>
              <tr>
                <td width="39%" class="text" style="text-align: right">User Name</td>
                <td width="3%" style="text-align: center">:</td>
                <td width="58%"><asp:TextBox ID="txt_username" Width="150"  runat="server"></asp:TextBox></td>
              </tr>
              <tr>
                <td class="text" style="text-align: right">Password</td>
                <td style="text-align: center">:</td>
                <td><asp:TextBox ID="txt_password" Width="150" TextMode="Password"  runat="server"></asp:TextBox></td>
              </tr>
              <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:ImageButton ID="btn_login" ImageUrl="images/login-blue.png" runat="server" 
                        onclick="btn_login_Click" /></td>
              </tr>
              <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="text2"><a href="fp.aspx">Forgot your password?</a></td>
              </tr>
            </table></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td align="right" class="text2">Copyrights © Damas Lighting LLC</td>
            <td>&nbsp;</td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td class="text4">&nbsp;</td>
      </tr>
    </table></td>
  </tr>
</table>
</form>
</body>
</html>