<%@ Page Title="Start\Basics\ImageMap" Language="C#" MasterPageFile="~/DMSMaster.Master"
    AutoEventWireup="true" CodeBehind="ImageMap.aspx.cs" Inherits="WebDms2.AspBasics.ImageMap"
    EnableTheming="true" Theme="Design1" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1 style="text-align: center">
        Image Map: Suche alle Smileys</h1>
    <asp:Panel ID="panGame" runat="server" Width="100%" HorizontalAlign="Center">
        <asp:ImageMap ID="ImageMap1" runat="server" ImageUrl="~/bilder/Gondeln.jpg" OnClick="ImageMap1_Click">
            <asp:RectangleHotSpot Bottom="70" HotSpotMode="PostBack" Left="95" PostBackValue="Smiley1"
                Right="135" Top="40" />
            <asp:RectangleHotSpot Bottom="20" HotSpotMode="PostBack" Left="300" PostBackValue="Smiley2"
                Right="330" />
            <asp:RectangleHotSpot Bottom="200" HotSpotMode="PostBack" Left="350" PostBackValue="Smiley3"
                Right="370" Top="170" />
            <asp:RectangleHotSpot Bottom="420" HotSpotMode="PostBack" Left="220" PostBackValue="Smiley4"
                Right="230" Top="400" />
            <asp:RectangleHotSpot Bottom="470" HotSpotMode="PostBack" Left="10" PostBackValue="Smiley5"
                Right="60" Top="430" />
            <asp:RectangleHotSpot Bottom="350" HotSpotMode="PostBack" Left="30" PostBackValue="Smiley6"
                Right="70" Top="315" />                
        </asp:ImageMap>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:HyperLink ID="hlSiegerehrung" runat="server" NavigateUrl="~/AspBasics/ImageMap-Siegerehrung.aspx" Visible="false">Zur Siegerehrung</asp:HyperLink>
    </asp:Panel>
</asp:Content>
