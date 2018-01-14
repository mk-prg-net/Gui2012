<%@ Page Title="" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true"
    CodeBehind="RunatServer.aspx.cs" Inherits="WebDms2.AspBasics.RunatServer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="btnSetImage" runat="server" Text="Bilds setzen" OnClick="btnSetImage_Click" />
    <asp:Panel ID="panHtmlContainer" runat="server">
        <img id="img1" src="" alt="Hier sollte ein Bild erscheinen" runat="server" />
    </asp:Panel>
</asp:Content>
