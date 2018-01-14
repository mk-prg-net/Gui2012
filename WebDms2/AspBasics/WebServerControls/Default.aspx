<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="WebServerControls_Default" Title="Untitled Page"
    EnableTheming="true" Theme="Design1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" class="h1Tab">
        <tr>
            <td class="h1TabItem">
                Zugriff auf die ArtikelDB mittels WebServerControls
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <!-- Datenquellen -->
    <asp:SqlDataSource ID="sqlDsAlleLieferanten" runat="server" ConnectionString='<%$ ConnectionStrings: DBArtikelConnectionString %>'
        SelectCommandType="Text" SelectCommand="select name, lfnr from dbo.Lieferanten order by name">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDsLieferantenDetails" runat="server" ConnectionString='<%$ ConnectionStrings: DBArtikelConnectionString %>'
        SelectCommandType="Text" SelectCommand="select * from dbo.ArtikelDetailsView where lfnr=@lfnr">
        <SelectParameters>
            <asp:ControlParameter ControlID="dpdLieferanten2" PropertyName="SelectedValue" Type="string"
                Name="lfnr" Direction="Input" />
        </SelectParameters>
    </asp:SqlDataSource>
    <!-- Markup für Webform -->
    <table width="100%">
        <tr>
            <td class="pTabItem">
                Liferanten ohne Postback:
                <asp:DropDownList ID="dpdLieferanten" runat="server" DataSourceID="sqlDsAlleLieferanten"
                    DataTextField="name" DataValueField="lfnr" AppendDataBoundItems="true" OnSelectedIndexChanged="dpdLieferanten_SelectedIndexChanged"
                    ToolTip="Auswahl eines Lieferanten" Width="100mm" Height="30pt" style="font-size: 24pt; color: blue">
                    <asp:ListItem Text="Keine ausgewählt" Value="-1" Selected="True" />
                </asp:DropDownList>
                <asp:Button ID="btnSelectLieferantendaten" runat="server" Text="Details abrufen"
                    OnClick="btnSelectLieferantendaten_Click" />
                &nbsp; Liferanten mit Postback:
                <asp:DropDownList ID="dpdLieferanten2" runat="server" DataSourceID="sqlDsAlleLieferanten"
                    DataTextField="name" DataValueField="lfnr" AppendDataBoundItems="true" AutoPostBack="true"
                    OnSelectedIndexChanged="dpdLieferanten2_SelectedIndexChanged">
                    <asp:ListItem Text="Keine ausgewählt" Value="-1" Selected="True" />
                </asp:DropDownList>
                <asp:Button ID="btnStil" runat="server"  Text="Stil programmatisch ändern" OnClick="btnStil_Click"
                     />
                <asp:RadioButton ID="rbtSichtbar"  GroupName="sichbarkeit" Text="sichtbar" Checked="true" runat="server" AutoPostBack="true" />   
                <asp:RadioButton ID="rbtUnSichtbar"  GroupName="sichbarkeit" Text="unsichtbar"  runat="server"  AutoPostBack="true"/>   
                <!-- Enabled -->
                <asp:RadioButton ID="rbtEnabled"  GroupName="Enabled" Text="An" Checked="true" runat="server" AutoPostBack="true" />   
                <asp:RadioButton ID="rbtDisabled"  GroupName="Enabled" Text="Aus"  runat="server"  AutoPostBack="true"/>   
            </td>
        </tr>
        <tr>
            <td class="pTabItem">
                <asp:GridView ID="grdLieferantenDetails" runat="server" DataSourceID="sqlDsLieferantenDetails">
                    <EmptyDataTemplate>
                        Keine Details zum Lieferanten vorhanden
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField DataField="artnr" HeaderText="ArtNr" />
                        <asp:BoundField DataField="ProduktName" HeaderText="Produkt" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <!-- Steuerelemente Allerlei -->
        <tr>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="LinkButton" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton><br />
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Multiviews/Default.aspx">Navigiere zu Multiview</asp:HyperLink>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                    <asp:ListItem Text="Milch" Value="1" Selected="True" />
                    <asp:ListItem Text="Zucker" Value="1" Selected="false" />
                </asp:CheckBoxList><br />
                <asp:FileUpload ID="FileUpload1" runat="server"  />
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Graphics/pfeile-top.gif"
                    OnClick="ImageButton1_Click" />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" /></td>
               
        </tr>
    </table>
</asp:Content>
    
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <asp:Label ID="lblStatus" runat="server" />
</asp:Content>
