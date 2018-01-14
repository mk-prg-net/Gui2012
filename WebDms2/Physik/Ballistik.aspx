<%@ Page Title="" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true"
    CodeBehind="Ballistik.aspx.cs" Inherits="WebDms2.Physik.Ballistik" EnableTheming="true"
    Theme="Design1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <section>
        <header>
            <h1>
                Ballistische Flugbahn
            </h1>
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
                        Auftrieb
                    </th>
                    <th>
                        Luftwiderstand
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
                        <asp:TextBox ID="tbxMasse" runat="server" Width="100" CssClass="numValue" Text="1" />
                    </td>
                    <td>
                        <asp:DropDownList ID="dpdMasseEinheit" runat="server" DataSource='<%# AlleMasseEinheiten %>'
                            DataTextField="Key" DataValueField="Value" />
                    </td>
                    <td>
                        <asp:TextBox ID="tbxV0x" runat="server" Width="100" CssClass="numValue" Text="3" />
                    </td>
                    <td>
                        <asp:TextBox ID="tbxV0y" runat="server" Width="100" CssClass="numValue" Text="2"/>
                    </td>
                    <td>
                        <asp:DropDownList ID="dpdBallistikEinheitV" runat="server" DataSource='<%# AlleVEinheiten %>'
                            DataTextField="Key" DataValueField="Value">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxFlugzeit" runat="server" Width="100" CssClass="numValue" Text="10" />
                    </td>
                    <td>
                        <asp:DropDownList ID="dpdFlugzeitEinheit" runat="server" DataSource='<%# AlleZeitEinheiten %>'
                            DataTextField="Key" DataValueField="Value">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxAuftrieb" runat="server" Width="100" CssClass="numValue" Text="0,1" />
                    </td>
                    <td>
                        <asp:TextBox ID="tbxLuftwiderstand" runat="server" Width="100" CssClass="numValue"
                            Text="0,0001" />
                    </td>
                    <td>
                        <asp:Button ID="btnNeuberechnen" runat="server" Text="neuberechnen" OnClick="btnNeuberechnen_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <div style="float: left; width: 300px; vertical-align: top; margin-top: 30px">
                <asp:GridView ID="grdBallistik" runat="server" AutoGenerateColumns="false">
                    <EmptyDataTemplate>
                        Keine Flugdaten wurden berechnet
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField DataField="UnitSymbol" HeaderText="Einheit" DataFormatString="{0:g}" />
                        <asp:TemplateField HeaderText="Sx">
                            <ItemTemplate>
                                <asp:Label ID="lblSx" runat="server" Text='<%# Math.Round(((mko.Euklid.Vector)Eval("Vector"))[0], 2) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sy">
                            <ItemTemplate>
                                <asp:Label ID="lblSy" runat="server" Text='<%# Math.Round(((mko.Euklid.Vector)Eval("Vector"))[1], 2) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div style="float: left; width: 1300px; vertical-align: top; margin-top: 30px">
                <asp:Chart ID="Chart1" runat="server" Width="1200" Height="500">
                    <Series>
                        <asp:Series Name="Flugbahn" ChartType="Line" XValueType="Single" XValueMember="X"
                            YValueType="Single"  YValueMembers="Y" ChartArea="ChartArea1"
                            Color="Red" IsXValueIndexed="false" XAxisType="Primary" 
                            BackGradientStyle="TopBottom" BorderColor="White">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BackColor="Beige" BackGradientStyle="TopBottom" ShadowColor="DarkGray" ShadowOffset="20" >                            
                            <AxisX Title="Wurfweite" ArrowStyle="SharpTriangle" IsStartedFromZero="true" 
                                IntervalOffsetType="Number" IntervalType="Number" IsLabelAutoFit="False"    >
                                <MajorGrid Interval="1000" IntervalType="Number" Enabled="true" LineColor="Gray"  />
                                <MinorGrid Interval="500" IntervalType="Number" Enabled="true" LineColor="LightGray" />
                                <MajorTickMark Interval="Auto" />
                            </AxisX>
                            <AxisY Title="Höhe" ArrowStyle="SharpTriangle" IsStartedFromZero="true" >
                                <MajorGrid Interval="1000" IntervalType="Number" Enabled="true" LineColor="Gray" />
                                <MinorGrid Interval="500" IntervalType="Number" Enabled="true" LineColor="LightGray" />
                            </AxisY>
                            <Area3DStyle IsRightAngleAxes="False" LightStyle="Realistic" PointDepth="300" />
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
        </div>
    </section>
</asp:Content>
