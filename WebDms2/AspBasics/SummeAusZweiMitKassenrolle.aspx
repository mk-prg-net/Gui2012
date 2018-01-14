<%@ Page Title="" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true"
    CodeBehind="SummeAusZweiMitKassenrolle.aspx.cs" Inherits="WebDms2.AspBasics.SummeAusZweiMitKassenrolle"
    EnableTheming="true" Theme="Design1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>
        Summe aus Zwei mit Validierung der Eingaben</h1>
    <asp:Table ID="tabRechnerLayout" runat="server" SkinID="tabSkin2">
        <asp:TableRow ID="TableRow1" runat="server">
            <asp:TableCell ID="TableCell1" runat="server" Width="50px" SkinID="tabCellSkin2_1">A =</asp:TableCell>
            <asp:TableCell ID="TableCell2" runat="server" Width="100px" SkinID="tabCellSkin2_2">
                <asp:TextBox ID="tbxA" runat="server" Text="" />
            </asp:TableCell><asp:TableCell ID="tabCellVldA" runat="server" Width="10px" BackColor="Gray">
                <asp:RequiredFieldValidator ID="reqVldTbxA" runat="server" ErrorMessage="In A muss eine Zahl eingegeben werden"
                    ControlToValidate="tbxA" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cmpVldA" runat="server" Type="Double" Operator="DataTypeCheck"
                    ControlToValidate="tbxA" ErrorMessage="In A wurde keine gültige Zahl eingegeben">*</asp:CompareValidator>
            </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow2" runat="server">
            <asp:TableCell ID="TableCell3" runat="server" SkinID="tabCellSkin2_1">B =</asp:TableCell><asp:TableCell
                ID="TableCell4" runat="server" BackColor="Gray">
                <asp:TextBox ID="tbxB" runat="server" Text="" />
            </asp:TableCell><asp:TableCell ID="tabCellVldB" runat="server" SkinID="tabCellSkin2_2">
                <asp:RequiredFieldValidator ID="reqVldTbxB" runat="server" ErrorMessage="In B muss eine Zahl eingegeben werden"
                    ControlToValidate="tbxB" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cmpVldB" runat="server" Type="Double" Operator="DataTypeCheck"
                    ControlToValidate="tbxB" ErrorMessage="In B wurde keine gültige Zahl eingegeben">*</asp:CompareValidator>
            </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow3" runat="server">
            <asp:TableCell ID="TableCell5" runat="server" SkinID="tabCellSkin2_1" ColumnSpan="3"
                HorizontalAlign="Center">
                <asp:Button ID="btnAdd" runat="server" Text="+" OnClick="btnOp_Click" CommandName="op"
                    CommandArgument="add" SkinID="btnSkin2" />
                &nbsp;
                <asp:Button ID="btnSub" runat="server" Text="-" OnClick="btnOp_Click" CommandName="op"
                    CommandArgument="sub" SkinID="btnSkin2" />
                &nbsp;
                <asp:Button ID="btnMul" runat="server" Text="x" OnClick="btnOp_Click" CommandName="op"
                    CommandArgument="mul" SkinID="btnSkin2" />
                &nbsp;
                <asp:Button ID="btnDiv" runat="server" Text="/" OnClick="btnOp_Click" CommandName="op"
                    CommandArgument="div" SkinID="btnSkin2" />
                &nbsp;
                <asp:Button ID="btnPow" runat="server" Text="^" OnClick="btnOp_Click" CommandName="op"
                    CommandArgument="pow" SkinID="btnSkin2" />
            </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow4" runat="server">
            <asp:TableCell ID="TableCell6" runat="server" SkinID="tabCellSkin2_3">Sum=</asp:TableCell><asp:TableCell
                ID="tabCellResult" runat="server" SkinID="tabCellSkin2_3"></asp:TableCell><asp:TableCell
                    ID="TableCell7" runat="server" SkinID="tabCellSkin2_3"></asp:TableCell></asp:TableRow></asp:Table><br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList"
        ForeColor="Red" />
    <h2>
        Kassenrolle</h2><asp:Panel ID="panKassenrolleOps" runat="server">
        <asp:Button ID="btnBonAbreissen" runat="server" OnClick="btnBonAbreissen_Click" Text="Bon abreissen" />
        <asp:CheckBox 
            ID="cbxMitViewState" runat="server" Checked="true" 
            Text="ViewState der Kassenrolle aktiv" AutoPostBack="True" 
            oncheckedchanged="cbxMitViewState_CheckedChanged" /><asp:Button 
            ID="btnSaveBon" runat="server" onclick="btnSaveBon_Click" Text="Sichern" /><asp:Button 
            ID="btnRestoreBon" runat="server" onclick="btnRestoreBon_Click" 
            Text="Wiederherstellen" /></asp:Panel>
    <asp:Panel ID="panKassenrolle" runat="server">
        <asp:ListBox ID="lbxKassenrolle" runat="server" Width="200" Height="300"></asp:ListBox>
    </asp:Panel>
</asp:Content>
