<%@ Page Title="" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true" CodeBehind="LebenszyklusEvents.aspx.cs" Inherits="WebDms2.AspBasics.LebenszyklusEvents"
EnableTheming="true" Theme="Design1"
 %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Button ID="btnMakeClickEvent" runat="server" Text="Erzeuge ein Klickevent" 
        onclick="btnMakeClickEvent_Click" />
    <asp:ListBox ID="lbxMeldungen" runat="server" Width="100%" Height="1000"></asp:ListBox>

</asp:Content>
