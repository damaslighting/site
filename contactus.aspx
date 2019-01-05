<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="contactus.aspx.cs" Inherits="contactus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntArea" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="center">
                <table width="1000" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="inner_contentbg">
                            <table width="972" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span class="heading_orange">CONTACT </span><span class="heading_mehroon">US</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="8">
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#b7b7b7" height="1">
                                    </td>
                                </tr>
                                <tr>
                                    <td height="8">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="98%" border="0" cellspacing="4" cellpadding="4">
                                            <tr>
                                                <td style="height: 143px">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="top">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="33%">
                                                                            <%--<span class="contactheading_orange">--%><img src="images/damas-light.png" /><%--</span>--%>
                                                                        </td>
                                                                    </tr>
                                                                  <%--  <tr>
                                                                        <td height="1">
                                                                            <img src="images/bottom_line.png">
                                                                        </td>
                                                                    </tr>--%>
                                                                    <tr>
                                                                        <td><br />
                                                                            Tel. +971 4 2398883<br/><br />
                                                                            Fax. +971 4 2398884<br/><br />
                                                                            Email: <a href="mailto:info@damaslighting.ae" class="email_color">info@damaslighting.ae</a><br/><br />
                                                                            Hamarain Center, Deira - Dubai, UAE<br /><br />
                                                                        </td>
                                                                    </tr>
                                                                   <%-- <tr>
                                                                        <td height="1">
                                                                            <img src="images/bottom_line.png">
                                                                        </td>
                                                                    </tr>--%>
                                                                </table>
                                                            </td>
                                                            <td width="60%">
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            Please Feel Free to Contact With us. (<span style="color:Red;">*</span>) Required Field
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                         &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Name <span style="color:Red;">*</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBox1" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Email<span style="color:Red;">*</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBox2" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Telephone No<span style="color:Red;">*</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBox3" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Message<span style="color:Red;">*</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBox4" runat="server" Width="300" TextMode="MultiLine" Height="50"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" align="center">
                                                                            <asp:Button ID="Button1" runat="server" Text="Send" onclick="Button1_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <%-- <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td class="contactheading_orange">
                                                    Location Map
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background: url(images/bottom_line.png)  repeat-x center top; height: 1px;
                                                    width: 100%;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div id="googlemap-widget-3" style="border: 1px dashed #cccccc; padding: 3px;" class="widget widget_googlemap substitute_widget_class">
                                                        <%-- <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3608.1342190200344!2d55.33021600000001!3d25.26606999999996!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3e5f5cc464aee2b7%3A0x451ac37ead519a31!2sHamarain+Center+1!5e0!3m2!1sen!2sae!4v1409140753680" width="946" height="250" frameborder="0" style="border:0"></iframe>--%>
                                                        <iframe width="946" height="400" frameborder="0" scrolling="no" marginheight="0"
                                                            marginwidth="0" src="https://www.google.ae/maps/ms?msa=0&amp;msid=204199789009209296522.0005023801a9f36dc0890&amp;hl=en&amp;ie=UTF8&amp;t=m&amp;ll=25.269022,55.331687&amp;spn=0.002911,0.01016&amp;z=17&amp;iwloc=000502380523902ca94b8&amp;output=embed">
                                                        </iframe>
                                                        <br />
                                                        <small>View <a href="https://www.google.ae/maps/ms?msa=0&amp;msid=204199789009209296522.0005023801a9f36dc0890&amp;hl=en&amp;ie=UTF8&amp;t=m&amp;ll=25.269022,55.331687&amp;spn=0.002911,0.01016&amp;z=17&amp;iwloc=000502380523902ca94b8&amp;source=embed"
                                                            style="color: #0000FF; text-align: left">DAMAS LIGHTING LLC</a> in a larger map</small>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img src="images/inner_contentbg_bottom.jpg" width="1000" height="3" alt="">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
