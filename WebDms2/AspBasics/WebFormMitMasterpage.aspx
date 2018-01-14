<%@ Page Title="Mein Titel" Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true" CodeBehind="WebFormMitMasterpage.aspx.cs" Inherits="WebDms2.AspBasics.WebFormMitMasterpage" %>

<%@ MasterType VirtualPath="~/DemoMaster.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hier steht der Inhalt</h1>    
    Der Author der Masterseite ist <asp:Label ID="lblAuthorMaster" runat="server" />
</asp:Content>

