<%@ Page Title="" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true"
    CodeBehind="DataSourceDemo.aspx.cs" Inherits="WebDms2.DBArtikel.DataSourceDemo"
    EnableTheming="true" Theme="Design1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!-- Kommentar -->
    <%-- ASP.NET Kommentar: Datenquellen --%>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WebDms2.Properties.Settings.DBArtikelConnectionString %>"
        SelectCommand="SELECT pnr, name FROM [Produkte]" DeleteCommand="DELETE FROM [Produkte] WHERE [pnr] = @pnr"
        InsertCommand="INSERT INTO [Produkte] ([pnr], [name]) VALUES (@pnr, @name)" UpdateCommand="UPDATE [Produkte] SET [name] = @name WHERE [pnr] = @pnr">
        <DeleteParameters>
            <asp:Parameter Name="pnr" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="pnr" Type="Int32" />
            <asp:Parameter Name="name" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="pnr" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <%-- Datengebundenen Steuerelemente --%>
    <asp:GridView ID="grdProdukteAusSqlDataSource" runat="server" AllowSorting="True"
        DataKeyNames="pnr" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <h2>
        Explizit definierte Spalten<asp:LinqDataSource 
            ID="LinqDataSource2" runat="server" 
            ContextTypeName="DBArtikelDbLayer.Dtx.DtxDBArtikelDataContext" 
            EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName="" 
            onselecting="LinqDataSource2_Selecting" TableName="Produktes" 
            Where="pnr == @pnr">
            <WhereParameters>
                <asp:Parameter Name="pnr" Type="Int32" />
            </WhereParameters>
        </asp:LinqDataSource>
    </h2>
    <table>
        <colgroup>
            <col width="33%" />
            <col width="33%" />
            <col width="33%" />
        </colgroup>
        <tr>
            <td  style="vertical-align: top;">
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" DataKeyNames="pnr"
                    DataSourceID="SqlDataSource1" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                        <asp:BoundField DataField="pnr" DataFormatString="{0:N0}" HeaderText="ProdNr" ReadOnly="True"
                            SortExpression="pnr" />
                        <asp:BoundField DataField="name" HeaderText="Produktname" SortExpression="name" />
                    </Columns>
                </asp:GridView>
            </td>
            <td style="vertical-align: top;">
                <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" 
                    DataSourceID="LinqDataSource2" AutoGenerateRows="False" DataKeyNames="pnr" 
                    onmodechanging="DetailsView1_ModeChanging">
                    <Fields>
                        <asp:BoundField DataField="pnr" HeaderText="pnr" ReadOnly="True" 
                            SortExpression="pnr" />
                        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                            ShowInsertButton="True" />
                    </Fields>
                </asp:DetailsView>
            </td>
            <td  style="vertical-align: top;">
                <asp:DropDownList ID="dpdProdukte" runat="server" AppendDataBoundItems="True" 
                    DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="pnr" 
                    AutoPostBack="True" onselectedindexchanged="dpdProdukte_SelectedIndexChanged">
                    <asp:ListItem Text="keine Auswahl" Value="-1" />
                </asp:DropDownList>
            </td>
        </tr>
    </table>    
    <h2>
        Ausgewählte Details</h2>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="DBArtikelDbLayer.Dtx.DtxDBArtikelDataContext"
        EntityTypeName="" OnSelecting="LinqDataSource1_Selecting" Select="new (artnr, lfnr, pnr, vorrat, preis, LieferantName, LieferantEmail, LieferantPlz, ProduktName)"
        TableName="ArtikelDetailsView" Where="pnr == @pnr" EnableInsert="True" 
        EnableUpdate="True">
        <WhereParameters>
            <asp:Parameter Name="pnr" Type="Int32" />
        </WhereParameters>
    </asp:LinqDataSource>
    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1">
        <EmptyDataTemplate>
            Keine Produkte vorhanden
        </EmptyDataTemplate>
        <Columns>
            <asp:BoundField DataField="artnr" HeaderText="artnr" ReadOnly="True" SortExpression="artnr" />
            <asp:BoundField DataField="lfnr" HeaderText="lfnr" ReadOnly="True" SortExpression="lfnr" />
            <asp:BoundField DataField="pnr" HeaderText="pnr" ReadOnly="True" SortExpression="pnr" />
            <asp:BoundField DataField="vorrat" HeaderText="vorrat" ReadOnly="True" SortExpression="vorrat" />
            <asp:BoundField DataField="preis" HeaderText="preis" ReadOnly="True" SortExpression="preis" />
            <asp:BoundField DataField="LieferantName" HeaderText="LieferantName" ReadOnly="True"
                SortExpression="LieferantName" />
            <asp:BoundField DataField="LieferantEmail" HeaderText="LieferantEmail" ReadOnly="True"
                SortExpression="LieferantEmail" />
            <asp:BoundField DataField="LieferantPlz" HeaderText="LieferantPlz" ReadOnly="True"
                SortExpression="LieferantPlz" />
            <asp:BoundField DataField="ProduktName" HeaderText="ProduktName" ReadOnly="True"
                SortExpression="ProduktName" />
        </Columns>
    </asp:GridView>
</asp:Content>
