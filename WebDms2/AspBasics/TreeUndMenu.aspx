<%@ Page Title="" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true" CodeBehind="TreeUndMenu.aspx.cs" Inherits="WebDms2.AspBasics.TreeUndMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />

<h1>Tree</h1>
    <asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1" 
        ExpandDepth="1" ImageSet="WindowsHelp">
        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
        <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" 
            HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="1px" />
        <ParentNodeStyle Font-Bold="False" />
        <SelectedNodeStyle Font-Underline="False" 
            HorizontalPadding="0px" VerticalPadding="0px" BackColor="#B5B5B5" />
    </asp:TreeView>
<h2>Tree aus XML</h2>
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" 
        DataFile="~/App_Data/Planeten.xml"></asp:XmlDataSource>
    <asp:TreeView ID="TreeView2" runat="server" DataSourceID="XmlDataSource1" 
        ExpandDepth="1" onselectednodechanged="TreeView2_SelectedNodeChanged">
        <DataBindings>
            <asp:TreeNodeBinding DataMember="Planet" TextField="name" />
            <asp:TreeNodeBinding DataMember="Mond" TextField="name" />
            <asp:TreeNodeBinding DataMember="Durchmesser" Text="Durchmesser" 
                ToolTipField="Wert" />
        </DataBindings>
    </asp:TreeView>
    <br />
    Sie haben den Knoten<asp:Label ID="lblSelectedNode" runat="server" Text="?"></asp:Label> gewählt.
<h1>Menu</h1>
    <p></p>
    <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1" 
        BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Verdana" 
        Font-Size="0.8em" ForeColor="#7C6F57" StaticSubMenuIndent="10px">
        <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicMenuStyle BackColor="#F7F6F3" />
        <DynamicSelectedStyle BackColor="#5D7B9D" />
        <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticSelectedStyle BackColor="#5D7B9D" />
    </asp:Menu>
</asp:Content>
