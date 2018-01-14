<%@ Page Title="" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true"
    CodeBehind="Datenbindung.aspx.cs" Inherits="WebDms2.AspBasics.Datenbindung" EnableTheming="true"
    Theme="Design1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <section>
        <header>
        <h1>
            Datenbindungen</h1>
        Datenbindungen ordnen die Felder eines Datenobjektes den Eigenschaften eines WebControls
    zu. Sie sind die Grundlage für automatisierte Datenabgleiche zwischen Datenobjekt
    und WebControl.
        </header>
        <section>
            <header>
                <h3>
                    Bsp. 1: TextBox.Text-Eigenschaft an eine öffentliche Eigenschaft der Page- Klasse
                    binden
                </h3>
            </header>
            <p>
                In der Page- Klasse der CodeBhind- Datei wurde die öffentliche Eigenschaft <span
                    style="font-style: italic">AktuelleUhrzeit</span> angelegt. Mittels eines Datenbindungsausdruckes
                im Markup wird die Text- Eigenschaft der TextBox an diese gebunden.
            </p>
            <p>
                Der Datenabgleich wird durch Aufruf von DataBind im PageLoad- Eventhandler gestartet.
            </p>
            <div class="beispiel">
                Seite wurde Abgerufen um
                <asp:TextBox ID="tbxNow1" runat="server" Text='<%# AktuelleUhrzeit %>' />
            </div>
        </section>
        <section>
            <header>
                <h3>
                    Bsp. 2: Mehrer Eigenschaften simultan an Daten binden</h3>
            </header>
            <p>
                Hintergrund- und Schriftfarbe einer Textbox mittels Datenbindung setzen</p>
            <div class="beispiel">
                Gib in der Textbox einen engl. Namen für eine Farbe ein (z.B. green)
                <asp:TextBox ID="tbxColor" runat="server" Text="green" ForeColor='<%# ForeColor %>'
                    BackColor='<%# BackgroundColor %>' />
                <asp:Button ID="btnSetColor" runat="server" Text="setzen" OnClick="btnSetColor_Click" />
            </div>
        </section>
        <section>
            <header>
                <h3>
                    Bsp. 3: Datengebundene Steuerelemente</h3>
            </header>
            <p>
                Datengebundene Websteuerelemente dienen zur Anzeige von Listen. Sie können über
                die Eigenschaft <span style="font-style: italic">DataSource</span> oder <span style="font-style: italic">
                    DataSourceId</span> mit einem Objekt, das die IEnumerable oder IQueryable- Schnittstelle
                unterstützt, gebunden werden.
            </p>
            <div class="beispiel">
                <table>
                    <tr>
                        <th>
                            V<sub>In</sub>
                        </th>
                        <th>
                            Einheit
                        </th>
                        <th>
                            V<sub>Out</sub>
                        </th>
                        <th>
                            Zieleinheit
                        </th>
                        <th>
                            &nbsp;
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="tbxVin" runat="server" CssClass="numValue" Width="100" />
                        </td>
                        <td>
                            <asp:DropDownList ID="dpdEinheitVin" runat="server" DataSource='<%# AlleVEinheiten %>'
                                DataTextField="Key" DataValueField="Value">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lblVout" runat="server" CssClass="numValue" Width="100" />
                        </td>
                        <td>
                            <asp:DropDownList ID="dpdEinheitVout" runat="server" DataSource='<%# AlleVEinheiten %>'
                                DataTextField="Key" DataValueField="Value">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnUmrechnung" runat="server" Text="umrechnen" OnClick="btnUmrechnung_Click" />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblStatus" runat="server" />
            </div>
        </section>
        <section>
            <header>
                <h3>
                    Bsp. 4: Komplexes Datengebundenes Steuerelement GridView
                </h3>
            </header>
            <p>
                Im Beispiel wird die ballistische Bahn eines Flugkörpers aus gegebener Anfangsgeschwindigkeit
                berechnet. Die Bahndaten werden in einer Tabelle dargestellt, welche durch das datengebundene
                Steuerelement GridView erzeugt wird.
            </p>
            <div class="beispiel">
                <h4>
                    Startwerte definieren</h4>
                <table>
                    <tr>
                        <th>
                            Flugkörper
                        </th>
                        <th>
                            Masse
                        </th>
                        <th>
                            Einheit Masse
                        </th>
                        <th>
                            V<sub>x</sub>
                        </th>
                        <th>
                            V<sub>y</sub>
                        </th>
                        <th>
                            Einheit V
                        </th>
                        <th>
                            t<sub>Flugzeit</sub>
                        </th>
                        <th>
                            Einheit t
                        </th>
                        <th>
                            Operation
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="dpdFlugkoerper" runat="server">
                                <asp:ListItem Text="Granate" Value="1" />
                                <asp:ListItem Text="Wurfgleiter" Value="2" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="tbxMasse" runat="server" Width="100" CssClass="numValue" />
                        </td>
                        <td>
                            <asp:DropDownList ID="dpdMasseEinheit" runat="server" DataSource='<%# AlleMasseEinheiten %>'
                                DataTextField="Key" DataValueField="Value" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxV0x" runat="server" Width="100" CssClass="numValue" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxV0y" runat="server" Width="100" CssClass="numValue" />
                        </td>
                        <td>
                            <asp:DropDownList ID="dpdBallistikEinheitV" runat="server" DataSource='<%# AlleVEinheiten %>'
                                DataTextField="Key" DataValueField="Value">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="tbxFlugzeit" runat="server" Width="100" CssClass="numValue" />
                        </td>
                        <td>
                            <asp:DropDownList ID="dpdFlugzeitEinheit" runat="server" DataSource='<%# AlleZeitEinheiten %>'
                                DataTextField="Key" DataValueField="Value">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnNeuberechnen" runat="server" Text="neuberechnen" OnClick="btnNeuberechnen_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                <div style="float:left; width: 300px;">
                    <asp:GridView ID="grdBallistik" runat="server" AutoGenerateColumns="false">
                        <EmptyDataTemplate>
                            Keine Flugdaten wurden berechnet
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="UnitSymbol" HeaderText="Einheit" DataFormatString="{0:g}" />
                            <asp:TemplateField HeaderText="Sx">
                                <ItemTemplate>
                                    <asp:Label ID="lblSx" runat="server" Text='<%# ((mko.Euklid.Vector)Eval("Vector"))[0] %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sy">
                                <ItemTemplate>
                                    <asp:Label ID="lblSy" runat="server" Text='<%# ((mko.Euklid.Vector)Eval("Vector"))[1] %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div style="float: left; width: 1000px">
                    <asp:Chart ID="Chart1" runat="server" Width="999">
                        <Series>
                            <asp:Series Name="Series1" ChartType="Line" XValueType="Single" XValueMember="X" YValueType="Single" YValueMembers="Y">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisX Title="X">
                                    
                                </AxisX>
                                <AxisY Title="Y"></AxisY>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>                    
                </div>
            </div>
        </section>
    </section>
</asp:Content>
