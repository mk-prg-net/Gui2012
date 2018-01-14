<%@ Page Title="Dateitabelle" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true"
    CodeBehind="FileTable.aspx.cs" Inherits="WebDms2.FileTable" EnableTheming="true"
    Theme="Design1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/DMSMaster.Master" %>
<%@ Register Assembly="mko.Asp" Namespace="mkoIt.Asp" TagPrefix="mkoIt" %>
<%@ Register Src="../VonBisZeitintervall.ascx" TagName="VonBisZeitintervall" TagPrefix="uc1" %>
<%@ Register Src="../UIDblIntervall.ascx" TagName="UIDblIntervall" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfBackgroundImage" runat="server" Value="betonkachel.jpg" />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ToolkitScriptManager>
    <!-- Datenquellen -->
    <!-- Liste aller Dateien -->
    <asp:ObjectDataSource ID="odsAll" runat="server" 
        TypeName="DMS.FCollect.Db.BoFilesBasic"
        DataObjectTypeName="DMS.FCollect.Db.BoFilesBasic+View"
        SelectMethod="selectSorted" UpdateMethod="Update" 
        SelectCountMethod="selectCount" SortParameterName="sortType" EnablePaging="True"
        StartRowIndexParameterName="StartRowIndex" MaximumRowsParameterName="PageSize"
        OnObjectCreated="odsAll_ObjectCreated" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="grdAll" Name="sortType" PropertyName="SortExpression"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <!-- Liste aller Klassen des Dateiinhaltes -->
    <asp:EntityDataSource ID="edsFileClasses" runat="server" ConnectionString="name=FileFeaturesDbEntities"
        DefaultContainerName="FileFeaturesDbEntities" EnableFlattening="False" EntitySetName="FileClasses">
    </asp:EntityDataSource>
    <!-- Sitemap Dataspurce -->
    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="false"
        StartFromCurrentNode="True" StartingNodeOffset="-1" />
    <table class="pTab" style="width: 100%;">
        <tr>
            <td>
                <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1" Orientation="Horizontal"
                    DynamicHorizontalOffset="2" StaticSubMenuIndent="10px" 
                    MaximumDynamicDisplayLevels="1">
                    <StaticSelectedStyle BackColor="#507CD1" BorderStyle="Outset" BorderColor="ActiveBorder"
                        BorderWidth="3" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" BorderStyle="Outset"
                        BorderColor="ActiveBorder" BorderWidth="3" />
                    <DynamicHoverStyle BackColor="#284E98" ForeColor="White" BorderStyle="Outset" BorderColor="ActiveBorder"
                        BorderWidth="3" />
                    <DynamicMenuStyle BackColor="#B5C7DE" BorderStyle="Outset" BorderColor="ActiveBorder"
                        BorderWidth="3" />
                    <DynamicSelectedStyle BackColor="#507CD1" BorderStyle="Outset" BorderColor="ActiveBorder"
                        BorderWidth="3" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" BorderStyle="Outset"
                        BorderColor="ActiveBorder" BorderWidth="3" />
                    <StaticHoverStyle BackColor="#284E98" ForeColor="White" BorderStyle="Outset" BorderColor="ActiveBorder"
                        BorderWidth="3" />
                </asp:Menu>
            </td>
        </tr>
        <tr>
            <td class="pTabHeader">
                <asp:Label ID="Label1" runat="server" Text="Dateitabelle"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="updOp" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <!-- Operationen -->
                        <table style="width: 100%;">
                            <colgroup>
                                <col width="220" />
                                <col width="220" />
                                <col width="220" />
                                <col width="220" />
                                <col width="*" />
                            </colgroup>
                            <tr>
                                <td style="text-align: right" colspan="5">
                                    Anzahl Datensätze:
                                    <asp:Label ID="lblAnzDaten" runat="server" Text="0" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="updGrdAll" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:GridView ID="grdAll" runat="server" AutoGenerateColumns="False" AllowSorting="True"
                            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                            DataSourceID="odsAll" DataKeyNames="Id" ForeColor="Black" GridLines="None" OnRowDataBound="grdAll_RowDataBound"
                            Width="100%" OnRowUpdating="grdAll_RowUpdating" AllowPaging="True"
                            OnSorting="grdAll_Sorting" OnDataBinding="grdAll_DataBinding" OnLoad="grdAll_Load"
                            OnPageIndexChanged="grdAll_PageIndexChanged" PageSize="15">
                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            <EmptyDataTemplate>
                                Es sind keine Dateien erfasst, die den aktuell eingestellten Filtern entsprechen.<br />
                                <asp:Button ID="btnRemoveFilter" runat="server" Text="# aus" ToolTip="Filter abschalten"
                                    OnClick="btnRemoveFilter_Click" Width="50" CssClass="btnDelete" />
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderStyle-Width="70" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-VerticalAlign="Top">
                                    <HeaderTemplate>
                                        <asp:UpdatePanel ID="updSetFilter" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                Filter
                                                <br />
                                                <asp:Button ID="btnSetFilter" runat="server" Text="# ein" ToolTip="Aktuelle Filtereinstellungen werden den bestehenden hinzugefügt"
                                                    OnClick="btnSetFilter_Click" Width="100%" CssClass="btnSet" ValidationGroup="vldGW" />
                                                <br />
                                                <asp:Button ID="btnRemoveFilter" runat="server" Text="# aus" ToolTip="Filter abschalten"
                                                    OnClick="btnRemoveFilter_Click" Width="100%" CssClass="btnDelete" />
                                                <asp:Panel ID="panSetFilterWait" runat="server" BackColor="Tan">
                                                    <asp:Image ID="imgStatus" runat="server" ImageUrl="~/Bilder/status_anim.gif" Width="0" />
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanelAnimationExtender ID="updSetFilter_AnimationExtender" runat="server"
                                            TargetControlID="updSetFilter">
                                            <Animations>  
                                                <OnUpdating>
                                                    <Sequence Duration=".5" Fps="20">                          
                                                        <EnableAction Enabled="true" />
                                                        <Resize AnimationTarget="imgStatus" Width="70" Height="20" />                                                                                                                                          
                                                    </Sequence>
                                                </OnUpdating>          
                                                <OnUpdated>
                                                    <Sequence Duration=".5" Fps="20">
                                                        <Resize AnimationTarget="imgStatus" Width="0"  Height="0"/>
                                                        <EnableAction Enabled="false" />                                                       
                                                    </Sequence>
                                                </OnUpdated>
                                            </Animations>
                                        </asp:UpdatePanelAnimationExtender>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table style="width: 100%">
                                            <colgroup>
                                                <col style="width: 50%; text-align: right;" />
                                                <col style="width: 50%" />
                                            </colgroup>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblZeilenNr" runat="server" Text="0" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="&gt;_" Width="30"
                                                        ToolTip="Daten ändern" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblZeilenNr" runat="server" Text="0" />
                                        &nbsp;
                                        <asp:ImageButton ID="btnUpdate" runat="server" CommandName="Update" ImageUrl="~/Bilder/Save.bmp"
                                            AlternateText="Aktualisieren" ToolTip="Änderungen in der Datenbank sichern" CausesValidation="true"
                                            ValidationGroup="vldGW" />
                                        &nbsp;
                                        <asp:ImageButton ID="btnCancel" runat="server" CommandName="Cancel" ImageUrl="~/Bilder/Refresh_Cancel.bmp"
                                            AlternateText="Abbrechen" ToolTip="Keine Änderungen in der Datenbank übernehmen" />
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" Width="70px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dir" SortExpression="DirName" HeaderStyle-Width="500"
                                    HeaderStyle-VerticalAlign="Top" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbtDirNameSort" runat="server" CommandName="Sort" CommandArgument="DirName"
                                            ForeColor="Black" Text="Verzeichnis" ToolTip="Verzeichnis, in dem die Datei liegt" />
                                        <br />
                                        <asp:TextBox ID="tbxDirNameFilter" runat="server" Width="95%" OnLoad="tbxDirNameFilter_Load" />
                                        <asp:AutoCompleteExtender ID="autExtbxDirNameFilter" runat="server" TargetControlID="tbxDirNameFilter"
                                            ServiceMethod="GetDirNameCompletionList" MinimumPrefixLength="1" CompletionInterval="500"
                                            EnableCaching="true" CompletionSetCount="5">
                                        </asp:AutoCompleteExtender>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDirName" runat="server" Text='<%# Eval("DirName") %>'  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Datei" SortExpression="FileName" HeaderStyle-Width="100"
                                    HeaderStyle-VerticalAlign="Top" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbtFileNameSort" runat="server" CommandName="Sort" CommandArgument="FileName"
                                            ForeColor="Black" Text="Datei" ToolTip=" Name der Datei" />
                                        <br />
                                        <asp:TextBox ID="tbxFileNameFilter" runat="server" Width="95%" OnLoad="tbxFileNameFilter_Load" />
                                        <asp:AutoCompleteExtender ID="autExtbxFileNameFilter" runat="server" TargetControlID="tbxFileNameFilter"
                                            ServiceMethod="GetFileNameCompletionList" MinimumPrefixLength="1" CompletionInterval="500"
                                            EnableCaching="true" CompletionSetCount="5">
                                        </asp:AutoCompleteExtender>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblFileName" runat="server" Text='<%# Eval("FileName") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FileClass" SortExpression="FileClassTxt" HeaderStyle-VerticalAlign="Top"
                                    HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="80">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbtFileClass" runat="server" Text="Klasse" CommandName="Sort"
                                            CommandArgument="FileClassTxt" ForeColor="Black" />
                                        <br />
                                        <asp:DropDownList ID="dpdFileClassFilter" runat="server" DataSourceID="edsFileClasses"
                                            Width="95%" DataTextField="name" DataValueField="id" AppendDataBoundItems="true"
                                            OnLoad="dpdFileClassFilter_Load">
                                            <asp:ListItem Selected="True" Text="Alle" Value="-1" />
                                        </asp:DropDownList>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblFileClass" runat="server" Text='<%# Eval("FileClassTxt") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Größe" SortExpression="SizeInBytes" HeaderStyle-Width="80"
                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbtSizeInBytes" runat="server" Text="Größe" ToolTip="Größe der Datei in Byte"
                                            CommandName="Sort" CommandArgument="SizeInBytes" ForeColor="Black" />
                                        <uc2:UIDblIntervall ID="SizeInBytesIntervallFilter" runat="server" OnLoad="SizeInBytesIntervallFilter_Load" />
                                        <br />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSizeInBytes" runat="server" Text='<%# Eval("SizeInBytes") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="erstellt" SortExpression="CreationTime" HeaderStyle-Width="80"
                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lbtCDat" runat="server" Text="erstellt" ToolTip="Datei angelegt am"
                                            CommandName="Sort" CommandArgument="CreationTime" ForeColor="Black" />
                                        <uc1:VonBisZeitintervall ID="CreationTimeZeitintervall" runat="server" OnLoad="CreationTimeZeitintervall_Load" />
                                        <br />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreationTime" runat="server" Text='<%# Eval("CreationTime", "{0:d}") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        &nbsp;
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Rating" HeaderText="Rating" NullDisplayText="-" ReadOnly="true" />
                                <asp:TemplateField HeaderText="RatingUp">
                                    <EditItemTemplate>
                                        
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="Tan" />
                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                            <SortedAscendingCellStyle BackColor="#FAFAE7" />
                            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                            <SortedDescendingCellStyle BackColor="#E1DB9C" />
                            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vldGW"
        DisplayMode="BulletList" ForeColor="Red" ShowSummary="true" />
</asp:Content>
