<%@ Page Title="" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true"
    CodeBehind="Reports.aspx.cs" Inherits="WebDms2.FileFeatures.Reports" EnableTheming="true"
    Theme="Design1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

     <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" 
        ShowStartingNode="False" StartFromCurrentNode="True" StartingNodeOffset="-1" />
    <%-- Seitenmenü --%>
    <div>
        <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1" Orientation="Horizontal"
            DynamicHorizontalOffset="2" StaticSubMenuIndent="10px" MaximumDynamicDisplayLevels="1">
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
    </div>

    <h1>
        Berichte erzeugen</h1>
    <p>
    </p>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        Height="403px" InteractiveDeviceInfos="(Auflistung)" WaitMessageFont-Names="Verdana"
        WaitMessageFont-Size="14pt" Width="858px">
        <LocalReport ReportPath="FileFeatures\Report1.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="odsBoBasicFiles" Name="FilesDateSet" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="odsBoBasicFiles" runat="server" 
        SelectMethod="selectSorted" TypeName="DMS.FCollect.Db.BoFilesBasic">
        <SelectParameters>
            <asp:Parameter DefaultValue="Name" Name="sortType" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
