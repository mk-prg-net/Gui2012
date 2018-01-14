<%@ Page Title="" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true" CodeBehind="AdminFunktionen.aspx.cs" Inherits="WebDms2.AspBasics.AdminFunktionen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>Manche Funktionen sind nur was für den Admin</h1>
    <asp:Button ID="btnFrei" runat="server" Text="Click mich" 
        onclick="btnFrei_Click" />
    <asp:Button ID="btnAdminsOnly"
        runat="server" Text="Click mich" onclick="btnAdminsOnly_Click" />
        <br />
    <asp:Label ID="lblAusgabe" runat="server" Text="-"></asp:Label>
</asp:Content>
