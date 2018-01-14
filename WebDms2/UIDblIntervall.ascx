<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UIDblIntervall.ascx.cs"
    Inherits="GBLWeb.UIDblIntervall" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<table style="margin: 1px" cellpadding="0" >
    <tr style="background-color: #A9A9A9;">
        <td style="text-align: left;">
            <asp:Button ID="btnResetVon" runat="server" Text="|<" OnClick="btnResetVon_Click" />
        </td>
        <td>
            &nbsp;
            <asp:CustomValidator ID="vldVon" runat="server" ControlToValidate="tbxVon" OnServerValidate="vldVon_ServerValidate"
                ValidationGroup="vldGroupVonBis" />
        </td>
        <td style="text-align: right;">
            von
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:TextBox ID="tbxVon" runat="server" Width="92%" Text="min" EnableViewState="true"
                OnTextChanged="tbxVon_TextChanged" />
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:TextBox ID="tbxBis" runat="server" Width="92%" Text="max" EnableViewState="true"
                OnTextChanged="tbxBis_TextChanged" />
        </td>
    </tr>
    <tr style="background-color: #A9A9A9;">
        <td style="text-align: left;">
            bis
        </td>
        <td>
            &nbsp;
            <asp:CustomValidator ID="vldBis" runat="server" ControlToValidate="tbxbis" OnServerValidate="vldBis_ServerValidate"
                ValidationGroup="vldGroupVonBis" />
        </td>
        <td style="text-align: right; ">
            <asp:Button ID="btnResetBis" runat="server" Text=">|" OnClick="btnResetBis_Click" />
        </td>
    </tr>
</table>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vldGroupVonBis" />
