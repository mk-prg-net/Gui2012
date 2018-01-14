<%@ Page Title="Start\Basics\ImageMap-Siegerehrung" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true" CodeBehind="ImageMap-Siegerehrung.aspx.cs" Inherits="WebDms2.AspBasics.ImageMap_Siegerehrung" EnableTheming="true" Theme="Design1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1 style="text-align:center">Hurra, Sie haben gewonnen</h1>
    Ihr Weg zum Sieg: 
    <asp:PlaceHolder ID="PlaceHolderWegZumSieg" runat="server"></asp:PlaceHolder>
    
    <asp:Panel ID="Panel1" runat="server" Width="100%" HorizontalAlign="Center">
        <asp:Image ID="imgEhrung" runat="server" ImageUrl="~/Bilder/Siegerehrung.gif" AlternateText="Hier sollte die Siegerehrung erscheinen"  ImageAlign="Middle"/>
    </asp:Panel>    
</asp:Content>
