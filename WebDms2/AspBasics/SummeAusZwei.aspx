<%@ Page Title="Start\Basics\Sum2" Language="C#" MasterPageFile="~/DMSMaster.Master"
    AutoEventWireup="true" CodeBehind="SummeAusZwei.aspx.cs" Inherits="WebDms2.AspBasics.SummeAusZwei"
    EnableTheming="true" Theme="Design1" Trace="true"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>
        Summe aus zwei</h1>
    <asp:Table ID="tabRechnerLayout" runat="server" BorderStyle="Outset" BackColor="#0033CC"
        BorderWidth="3" SkinID="tabSkin1">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" Width="50px" BackColor="#0033CC">A =</asp:TableCell>
            <asp:TableCell runat="server" Width="100px" BackColor="Gray">
                <asp:TextBox ID="tbxA" runat="server" Text="" />
            </asp:TableCell><asp:TableCell ID="tabCellVldA" runat="server" Width="10px" BackColor="Gray"></asp:TableCell></asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" BackColor="#0033CC">B =</asp:TableCell><asp:TableCell
                runat="server" BackColor="Gray">
                <asp:TextBox ID="tbxB" runat="server" Text="" />
            </asp:TableCell><asp:TableCell ID="tabCellVldB" runat="server" BackColor="Gray" /></asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" BackColor="#0033CC" ColumnSpan="3" HorizontalAlign="Center">
                <asp:Button ID="btnAdd" runat="server" Text="+" OnClick="btnOp_Click" CommandName="op"
                    CommandArgument="add" />
                &nbsp;
                <asp:Button ID="btnSub" runat="server" Text="-" OnClick="btnOp_Click" CommandName="op"
                    CommandArgument="sub" />
                &nbsp;
                <asp:Button ID="btnMul" runat="server" Text="x" OnClick="btnOp_Click" CommandName="op"
                    CommandArgument="mul" />
                &nbsp;
                <asp:Button ID="btnDiv" runat="server" Text="/" OnClick="btnOp_Click" CommandName="op"
                    CommandArgument="div" />
                &nbsp;
                <asp:Button ID="btnPow" runat="server" Text="^"  CommandName="op"
                    CommandArgument="pow" />
            </asp:TableCell></asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" BackColor="#3399FF">Sum=</asp:TableCell><asp:TableCell
                ID="tabCellResult" runat="server" BackColor="#3399FF"></asp:TableCell><asp:TableCell
                    runat="server" BackColor="#3399FF"></asp:TableCell></asp:TableRow>
    </asp:Table>
    <asp:Label ID="lblPw" runat="server" />
</asp:Content>
