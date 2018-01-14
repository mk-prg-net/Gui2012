<%@ Page Title="UserControls" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true"
    CodeBehind="UserControlTest.aspx.cs" Inherits="WebDms2.AspBasics.UserControlTest"
    EnableTheming="true" Theme="Design1" %>

<%@ Register Src="../UIDblIntervall.ascx" TagName="UIDblIntervall" TagPrefix="uc1" %>
<%@ Register src="../VonBisZeitintervall.ascx" tagname="VonBisZeitintervall" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>
        UserControls</h1>
    <table>
        <colgroup>
            <col width="100" />
            <col width="100" />
        </colgroup>
        <tr>
            <th>
                num. Intervall
            </th>
            <th>
                Zeitraum
            </th>
        </tr>
        <tr>
            <td>
                <uc1:UIDblIntervall ID="UIDblIntervall1" runat="server" OnIntervalChanged="uiDbIntervallMinMax1_Changed" />
            </td>
            <td>
                
                <uc2:VonBisZeitintervall ID="VonBisZeitintervall1" runat="server" OnVonBisChanged="zeitraum_Changed" />
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblIntervall" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblZeitraum" runat="server"></asp:Label>
            </td>
        </tr>
    </table>  
    <asp:Button ID="btnSetIntervall" runat="server" Text="Neues Intervall setzen" />
    <br />
    Neues Intervall
</asp:Content>
