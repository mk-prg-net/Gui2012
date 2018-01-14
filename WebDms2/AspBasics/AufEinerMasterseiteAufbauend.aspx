<%@ Page Title="Mit Masterseite" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true" CodeBehind="AufEinerMasterseiteAufbauend.aspx.cs" Inherits="WebDms2.AspBasics.AufEinerMasterseiteAufbauend" EnableTheming="true" Theme="Design1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="Autor" content="mko" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>Arbeiten mit Masterpages</h1>
    <asp:Button ID="btnMakeErr" runat="server" Text="Fehlermeldung erzeugen" 
        onclick="btnMakeErr_Click" />
</asp:Content>
