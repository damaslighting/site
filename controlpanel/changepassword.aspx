<%@ Page Language="C#" MasterPageFile="~/controlpanel/MasterPage.master" AutoEventWireup="true" CodeFile="changepassword.aspx.cs" Inherits="admin_changepassword" %>

 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_header" Runat="Server">
    Change Password
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_body" Runat="Server">
    <table align="left" cellpadding="0" cellspacing="5" style="width:100%">
    <tr>
        <td align="left" valign="top" width="20%">
                &nbsp;</td>
        <td style=" width:1px">
                &nbsp;</td>
        <td align="left" valign="top" width="87%">
            <asp:Label ID="lbl_msg" runat="server" ForeColor="#FF3300"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
              User name</td>
        <td>  :</td>
        <td>
            <asp:TextBox ID="txt_useName" runat="server" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
                Old password</td>
        <td>
                :</td>
        <td>
            <asp:TextBox ID="txt_oldPassword" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
                New password</td>
        <td>
                :</td>
        <td>
            <asp:TextBox ID="txt_newPass" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
                Confirm password</td>
        <td>
                :</td>
        <td>
            <asp:TextBox ID="txt_confirmPass" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txt_newPass" ControlToValidate="txt_confirmPass" 
                    ErrorMessage="Confirm password is not same"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td>
                &nbsp;</td>
        <td>
                &nbsp;</td>
        <td>
            <asp:Button ID="btn_save" runat="server" onclick="btn_save_Click" Text="Submit" 
                style="height: 26px" />
        </td>
    </tr>
    <tr>
        <td>
                &nbsp;</td>
        <td>
                &nbsp;</td>
        <td>
                &nbsp;</td>
    </tr>
    <tr>
        <td>
                &nbsp;</td>
        <td>
                &nbsp;</td>
        <td>
                &nbsp;</td>
    </tr>
</table>
</asp:Content>

