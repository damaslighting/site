<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="portfolio.aspx.cs" Inherits="portfolio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntArea" runat="Server">

   <script type="text/javascript" src="highslide/highslide-with-gallery.js"></script>

    <link rel="stylesheet" type="text/css" href="highslide/highslide.css" />

    <script type="text/javascript">
        hs.graphicsDir = 'highslide/graphics/';
        hs.align = 'center';
        hs.transitions = ['expand', 'crossfade'];
        hs.outlineType = 'rounded-white';
        hs.fadeInOut = true;
        //hs.numberPosition = 'caption';
        hs.dimmingOpacity = 0.75;

        // Add the controlbar
        if (hs.addSlideshow) hs.addSlideshow({
            //slideshowGroup: 'group1',
            interval: 5000,
            repeat: false,
            useControls: true,
            fixedControls: 'fit',
            overlayOptions: {
                opacity: .75,
                position: 'bottom center',
                hideOnMouseOut: true
            }
        });
    </script>

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
                                        <span class="heading_mehroon">PORTFOLIO</span>
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
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="50%">
                                                    Associated with our experienced and hardworking team <%--<span class="text_orange">damas</span>
                                                    <span class="text_mehroon">Lighting</span>--%><img src="images/damas-light.png" /> designed and supplied a number of prestigious
                                                    projects.
                                                </td>
                                               <%-- <td width="50%" align="center">
                                                    <a href="images/DAMAS_PROFILE.pdf" target="_blank">
                                                        <img src="images/pdf.png" width="187" height="101" border="0"></a>
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:ListView ID="ListView2" runat="server" GroupItemCount="5">
                                            <LayoutTemplate>
                                                <table id="Category" runat="server" align="left" cellpadding="0" cellspacing="10">
                                                    <tr id="groupPlaceholder" runat="server" />
                                                </table>
                                            </LayoutTemplate>
                                            <GroupTemplate>
                                                <tr id="ProductsRow" runat="server">
                                                    <td id="itemPlaceholder" runat="server" />
                                                </tr>
                                            </GroupTemplate>
                                            <ItemTemplate>
                                                <td id="Td1" runat="server">
                                                    <table width="183px" cellspacing="0" cellpadding="0" height="160px">
                                                        <tr class="row">
                                                            <td style="padding-left: 0px; padding-right: 0px; background-image: url('images/port_bg.jpg'); background-repeat: no-repeat;" >
                                                                <table cellpadding="0" cellspacing="0" width="183px" height="160px">
                                                                    <tr>
                                                                        <td height="120px" valign="middle" align="center">
                                                                            <a href='img_big/<%#Eval("img").ToString()%>'  class="highslide" onclick="return hs.expand(this)"
                                                                                alt="Highslide JS"  >
                                                                                <%--<a href="SpecialofferDetails.aspx?id=<%#Eval("id") %>" >--%>
                                                                                <img width="140px" height="100px" src='img_small/<%#Eval("img").ToString() %>' /></a>
                                                                           <%-- <div class="highslide-caption" style="font-size: 12px;">
                                                                                <table width="100%" cellpadding="5" cellspacing="0">
                                                                                    <tr>
                                                                                        <td style="border: dashed 1px #cccccc;">
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <%#Eval("title") %>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>--%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" height="25px" align="center" style="font-size: 14px; font-family: Tahoma;">
                                                                            <%#Eval("title")%>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </ItemTemplate>
                                            <EmptyDataTemplate>
                                                <div align="center" style="font-size: 12px; width: 240px; font-family: Arial; font-weight: bold;
                                                    color: Red">
                                                    <br />
                                                    Records not found in this category....
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:ListView>
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
