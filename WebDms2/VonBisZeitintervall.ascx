<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VonBisZeitintervall.ascx.cs"
    Inherits="GBLWeb.VonBisZeitintervall" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<table style="margin: 1px" cellpadding="0">
    <tr style="background-color: #A9A9A9;">
        <td style="text-align: left">
            <asp:Button ID="btnResetVon" runat="server" Text="|<" OnClick="btnResetVon_Click" />
        </td>
        <td>
            <asp:CustomValidator ID="vldVon" runat="server" ControlToValidate="tbxVon" OnServerValidate="vldVon_ServerValidate" />
        </td>
        <td style="text-align:right">
            <asp:ImageButton ID="btnCalenderVonOnOff" runat="server" ImageUrl="~/Bilder/Calendar_scheduleHS.png"
                ImageAlign="Middle" OnClick="btnCalenderVonOnOff_Click" />
            <asp:Calendar ID="CalendarVon" runat="server" Visible="false" OnSelectionChanged="CalendarVon_SelectionChanged">
            </asp:Calendar>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:TextBox ID="tbxVon" runat="server" Width="92%" Text="alt" EnableViewState="true"
                OnTextChanged="tbxVon_TextChanged" />
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:TextBox ID="tbxBis" runat="server" Width="92%" Text="neu" EnableViewState="true"
                OnTextChanged="tbxBis_TextChanged" />
        </td>
    </tr>
    <tr style="background-color: #A9A9A9;">
        <td style="text-align: left">
            <asp:ImageButton ID="btnCalenderBisOnOff" runat="server" ImageUrl="~/Bilder/Calendar_scheduleHS.png"
                ImageAlign="Middle" OnClick="btnCalenderBisOnOff_Click"   />
            <asp:Calendar ID="CalendarBis" runat="server" Visible="false" OnSelectionChanged="CalendarBis_SelectionChanged">
            </asp:Calendar>
        </td>
        <td>
            <asp:CustomValidator ID="vldBis" runat="server" ControlToValidate="tbxbis" OnServerValidate="vldBis_ServerValidate"
                ClientValidationFunction="IsVonBisValid" ForeColor="Red" ErrorMessage="Zeitintervall unkorrekt">*</asp:CustomValidator>
        </td>
        <td style="text-align: right">
            <asp:Button ID="btnResetBis" runat="server" Text=">|" OnClick="btnResetBis_Click" />
        </td>
    </tr>
    <!--
    <tr>
        <td colspan="4">
            <asp:TextBox ID="tbxDebug" runat="server"></asp:TextBox>
        </td>
    </tr>
    -->
</table>
<script type="text/javascript">

    // Validierungsfunktion
    // Prüfen:
    // 1) wurden gültige Datumswerte eingegeben
    // 2) ob ein gültiges Intervall eingerichtet wurde

    function IsVonBisValid(oSrc, args) {

        var tbxVon = document.getElementById('<%=tbxVon.ClientID %>');
        var tbxBis = document.getElementById('<%=tbxBis.ClientID %>');

        //            var tbxDebug = document.getElementById('<%=tbxDebug.ClientID %>');            

        args.IsValid = false;
        try {
            var von = Date.parseLocale("01.01.1900", "dd.MM.yyyy");
            var bis = Date.parseLocale("01.01.3000", "dd.MM.yyyy");

            if (tbxVon.value.toLowerCase() != 'alt')
                von = Date.parseLocale(tbxVon.value, "dd.MM.yyyy");
            if (tbxBis.value.toLowerCase() != 'neu')
                bis = Date.parseLocale(tbxBis.value, "dd.MM.yyyy");

            if (von <= bis)
                args.IsValid = true;

            //                tbxDebug.value = "von= " + von.format("dd.MM.yyyy") + "; bis=" + bis.format("dd.MM.yyyy") + "; Valid=" + args.IsValid.toString();

        } catch (e) {
            args.IsValid = false;
            //                tbxDebug.value = "Err: " + e.Description;
        }
    }
</script>
