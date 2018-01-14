<%@ Page Title="Leuchttisch" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true"
    CodeBehind="Leuchttisch.aspx.cs" Inherits="WebDms2.Leuchttisch" EnableTheming="true"
    Theme="Design1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" >        
    </asp:ToolkitScriptManager>

    <asp:EntityDataSource ID="edsImages" runat="server" ConnectionString="name=FileFeaturesDbEntities"
        DefaultContainerName="FileFeaturesDbEntities" EnableFlattening="False" EntitySetName="images">
    </asp:EntityDataSource>

    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="false"
        StartFromCurrentNode="true" StartingNodeOffset="-1" />


    <table class="pTab" style="width: 100%;">
        <tr>
            <td>
                <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1" Orientation="Horizontal"
                    DynamicHorizontalOffset="2" StaticSubMenuIndent="10px">
                    <StaticSelectedStyle BackColor="#507CD1" BorderStyle="Outset" BorderColor="ActiveBorder"
                        BorderWidth="3" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" BorderStyle="Outset"
                        BorderColor="ActiveBorder" BorderWidth="3" />
                    <DynamicHoverStyle BackColor="#284E98" ForeColor="White" BorderStyle="Outset" BorderColor="ActiveBorder"
                        BorderWidth="3" />
                    <DynamicMenuStyle BackColor="#B5C7DE" BorderStyle="Outset" BorderColor="ActiveBorder"
                        BorderWidth="3" />
                    <DynamicSelectedStyle BackColor="#507CD1" BorderStyle="Outset" BorderColor="ActiveBorder"
                        BorderWidth="3" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" BorderStyle="Outset"
                        BorderColor="ActiveBorder" BorderWidth="3" />
                    <StaticHoverStyle BackColor="#284E98" ForeColor="White" BorderStyle="Outset" BorderColor="ActiveBorder"
                        BorderWidth="3" />
                </asp:Menu>
            </td>
        </tr>
        <tr>
            <td class="pTabHeader">
                <asp:Label ID="Label1" runat="server" Text="Leuchttisch"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="updOp" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <!-- Operationen -->
                        <table style="width: 100%;">
                            <colgroup>
                                <col width="220" />
                                <col width="220" />
                                <col width="220" />
                                <col width="220" />
                                <col width="*" />
                            </colgroup>
                            <tr>
                                <td style="text-align: right" colspan="5">
                                    Anzahl Datensätze:
                                    <asp:Label ID="lblAnzDaten" runat="server" Text="0" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <!-- Ausgabe -->
                <asp:Repeater ID="repLeuchttisch" runat="server" DataSourceID="edsImages">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <SeparatorTemplate>
                        <%# SetSeparator() %>
                    </SeparatorTemplate>
                    <ItemTemplate>
                        <div runat="server" id="ImageFrame" style='<%# ImageFrameStyle() %>'>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/GetMyImage.ashx?file_id=" + Eval("id") %>' />
                            <br />
                            <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("description") %>' />
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>                
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vldGW"
        DisplayMode="BulletList" ForeColor="Red" ShowSummary="true" />
</asp:Content>
