<%@ Page Title="" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true" CodeBehind="AuswahlDerOperartionen.aspx.cs" Inherits="WebDms2.AspBasics.AuswahlDerOperartionen" EnableTheming="true" Theme="Design1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<h1>Bitte wählen Sie aus</h1>
    <asp:ListBox ID="dpdAuswahl" runat="server" 
        onselectedindexchanged="dpdAuswahl_SelectedIndexChanged" 
        AutoPostBack="True">
        <asp:ListItem Text="A" Value="1" />
        <asp:ListItem Text="B" Value="2" />
    </asp:ListBox>

    <asp:Panel ID="panA" runat="server">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Bilder/smiley-gross.png" />
    </asp:Panel>

    <asp:Panel ID="panB" runat="server">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Bilder/smiley-boese-gross.png" />
    </asp:Panel>
</asp:Content>
