<%@ Page Title="" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true"
    CodeBehind="WebPart.aspx.cs" Inherits="WebDms2.AspBasics.WebPart" EnableTheming="true"
    Theme="Design1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:WebPartManager ID="WebPartManager1" runat="server">
    </asp:WebPartManager>
    <asp:DropDownList ID="dpdWebPartModes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dpdWebPartModes_SelectedIndexChanged">
        <asp:ListItem Text="Browse" Value="1" Selected="True" />
        <asp:ListItem Text="Design" Value="2" />
        <asp:ListItem Text="Edit" Value="3" />
        <asp:ListItem Text="Catalog" Value="4" />
    </asp:DropDownList>
    <asp:Button ID="btnAddWebPart" runat="server" Text="Webpart dyn. hinzufügen" OnClick="btnAddWebPart_Click" />
    <asp:RadioButton ID="rbtGenWp" runat="server" Checked="True" GroupName="genWebPart"
        Text="generisches Webpart" />
    <asp:RadioButton ID="rbtWebPart" runat="server" GroupName="genWebPart" Text="Selbstdef. Webpart" />
    <br />
    <br />
    <table width="100%">
        <colgroup>
            <col width="50%" />
            <col width="50%" />
        </colgroup>
        <tr>
            <td style="vertical-align: top">
                <h2>
                    1. Zone</h2>
                <asp:WebPartZone ID="WebPartZone1" runat="server">
                    <ZoneTemplate>
                        <%-- ChartDashStyle Title Attribut setzt den Titel des Webparts ! --%>
                        <asp:Calendar ID="Calendar1" runat="server" Title="Mein Kalender"></asp:Calendar>
                    </ZoneTemplate>
                </asp:WebPartZone>
                <h2>
                    2. Zone</h2>
                <asp:WebPartZone ID="WebPartZone2" runat="server">
                    <ZoneTemplate>
                        <%-- ChartDashStyle Title Attribut setzt den Titel des Webparts ! --%>
                        <asp:Label ID="lblMeldung" runat="server" Text="2. Zone" Title="Meine Meldung" />
                    </ZoneTemplate>
                </asp:WebPartZone>
            </td>
            <td style="vertical-align: top">
                <h2>
                    Editor- Zone</h2>
                <asp:EditorZone ID="EditorZone1" runat="server">
                    <ZoneTemplate>
                        <asp:PropertyGridEditorPart ID="PropertyGridEditorPart1" runat="server" />
                        <asp:AppearanceEditorPart ID="AppearanceEditorPart1" runat="server" />
                        <asp:LayoutEditorPart ID="LayoutEditorPart1" runat="server" />
                        <asp:BehaviorEditorPart ID="BehaviorEditorPart1" runat="server" />
                    </ZoneTemplate>
                </asp:EditorZone>
                <h2>
                    Catalog</h2>
                <asp:CatalogZone ID="CatalogZone1" runat="server">
                    <ZoneTemplate>
                        <asp:PageCatalogPart ID="PageCatalogPart1" runat="server" />
                    </ZoneTemplate>
                </asp:CatalogZone>
            </td>
        </tr>
    </table>
</asp:Content>
