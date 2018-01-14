<%@ Page Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true"
    CodeBehind="Lieferanten.aspx.cs" Inherits="WebDms2.DBArtikel.Lieferanten"
    Title="Start\DBArtikel\Lieferanten" EnableViewState="true" EnableTheming="true" Theme="Design1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>
        Zugriff auf Datenbanken mittels Websteuerelementen</h1>
    <p>
        Mittels der ObjectDataSource wird das Geschäftsobjekt BoLieferant an ein Websteuerelement
        gebunden.</p>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="select"
        TypeName="DBArtikelDbLayer.BoLieferant" UpdateMethod="update" OldValuesParameterFormatString="original_{0}"
        DataObjectTypeName="DBArtikelDbLayer.Dtx.Lieferanten" 
        InsertMethod="insert" DeleteMethod="delete">
        <DeleteParameters>
            <asp:Parameter Name="lfnr" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
    <h2>
        Tabellarische Darstellung mittels GridView und Objectdatasource</h2>
    <p>
        Die GridView ist ein bewährtes Websteuerelement seit der .NET Version 2.0 zur tabellarischen
        Darstellung von Daten.</p>
    <p>
        <b>Achtung </b>Die Integritätsregeln der ArtikelDB überprüfen beim Update den Aufbau
        von Emails und Postleitzahlen. Postleitzahlen sollten fünfstellig sein, und Emails
        dem Muster Name@Domain.Landeskennung entsprechen.</p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
        Width="555px" DataKeyNames="lfnr">
        <Columns>
            <asp:BoundField DataField="lfnr" HeaderText="lfnr" SortExpression="lfnr" ReadOnly="true" />
            <asp:BoundField DataField="name" HeaderText="Name" ConvertEmptyStringToNull="true" />
            <asp:BoundField DataField="email" HeaderText="Email" ConvertEmptyStringToNull="true" />
            <asp:BoundField DataField="plz" HeaderText="Postleitzahl" ConvertEmptyStringToNull="true"
                HtmlEncode="False" />
            <asp:CommandField ShowSelectButton="True" />
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <h3>
        Zugriff auf die von einem Lieferanten angebotenen Artikel über eine 1:N Beziehung
    </h3>
    <p>
        Die Objektdatasource kapselt wieder das BoLieferanten- Objekt. Diesmal wird als
        Select- Methode jedoch selectArtikel(int lfnr) benutzt. Für den Parameter lfnr wird
        eine Datenbindung an die lfnr Spalte in der aktuell ausgewählten Zeile der GridView
        1 definiert.
    </p>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="selectArtikel"
        TypeName="DBArtikelDbLayer.BoLieferant" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="lfnr" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2">
        <Columns>
            <asp:BoundField DataField="artnr" HeaderText="artnr" SortExpression="artnr" />
            <asp:BoundField DataField="lfnr" HeaderText="lfnr" SortExpression="lfnr" />
            <asp:BoundField DataField="pnr" HeaderText="pnr" SortExpression="pnr" />
            <asp:BoundField DataField="vorrat" HeaderText="vorrat" SortExpression="vorrat" />
            <asp:BoundField DataField="preis" HeaderText="preis" SortExpression="preis" />
        </Columns>
        <EmptyDataTemplate>
            Es wurde kein Lieferant ausgewählt
        </EmptyDataTemplate>
    </asp:GridView>
    <h3>
        Hinzufügen eines neuen Lieferanten mittels einer Detailsview</h3>
    <p>
        Die DetailsView dient zur Darstellung eines einzelnen Datensatzes. Im Gegensatz
        zur Gridview verfügt sie über einen Hinzufügen- Button. Mittels der DetailsView
        können somit neue Datensätze angelegt werden.</p>
    <p>
        <b>Achtung </b>Die Integritätsregeln der ArtikelDB überprüfen beim Insert den Aufbau
        von Emails und Postleitzahlen. Postleitzahlen sollten fünfstellig sein, und Emails
        dem Muster Name@Domain.Landeskennung entsprechen.</p>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" DataObjectTypeName="DBArtikelDbLayer.Dtx.Lieferanten"
        InsertMethod="insert" SelectMethod="select" TypeName="DBArtikelDbLayer.BoLieferant"
        UpdateMethod="update">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="lfnr" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" AutoGenerateRows="False"
        DataSourceID="ObjectDataSource3" OnItemInserted="DetailsView1_ItemInserted">
        <Fields>
            <asp:BoundField DataField="lfnr" HeaderText="lfnr" SortExpression="lfnr" />
            <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
            <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
            <asp:BoundField DataField="plz" HeaderText="Postleitzahl" SortExpression="plz" />
            <asp:CommandField ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
    <h3>
        Einfügen neuer Datensätze über selbstdefinierte Formularfelder</h3>
    <table>
        <tbody>
            <tr>
                <th>
                    lfnr
                </th>
                <th>
                    Name
                </th>
                <th>
                    Email
                </th>
                <th>
                    Plz
                </th>
                <th>
                    &nbsp;
                </th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxLfNr" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="tbxName" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="tbxEmail" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="tbxPlz" runat="server" />
                </td>
                <td>
                    <asp:Button ID="btnNeu" runat="server" Text="Neu" onclick="btnNeu_Click" />
                </td>
            </tr>
        </tbody>
    </table>
    
    <h2>
        Gepeicherte Prozeduren mittels LINQ und Objketdatasource abrufen</h2>
    <p>
        Gepeicherte Prozeduren können genauso wie Tabellen aus dem Serverexplorer in das
        Designerfenster für den Objektrelationalen Mapper gezogen werden. Das Kapseln der
        LINQ Befehle in einem Geschäftsobjekt (BoLieferanten) ist analog dem Vorgehen bei
        Tabellen (siehe oben). Auch hier ist die ObjektDatasource der Mittler zwischen Geschäftsobjekt
        und GridView
    </p>
    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="callStoredProcedure"
        TypeName="DBArtikelDbLayer.BoLieferant"></asp:ObjectDataSource>
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource4">
        <Columns>
            <asp:BoundField DataField="artnr" HeaderText="artnr" SortExpression="artnr" />
            <asp:BoundField DataField="Hersteller" HeaderText="Hersteller" SortExpression="Hersteller" />
            <asp:BoundField DataField="Produkt" HeaderText="Produkt" SortExpression="Produkt" />
            <asp:BoundField DataField="vorrat" HeaderText="vorrat" SortExpression="vorrat" />
            <asp:BoundField DataField="Wert" HeaderText="Wert" SortExpression="Wert" />
        </Columns>
        <EmptyDataTemplate>
            Kein Datensatz vorhanden
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>
