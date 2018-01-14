<%@ Page Title="Charts" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true"
    CodeBehind="StatCharts.aspx.cs" Inherits="WebDms2.StatCharts" EnableTheming="true"
    Theme="Design1" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%-- Datenquellen --%>
    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" 
        ShowStartingNode="False" StartFromCurrentNode="True" StartingNodeOffset="-1" />

    <asp:EntityDataSource ID="edsFileClasses" runat="server" 
        ConnectionString="name=FileFeaturesDbEntities" 
        DefaultContainerName="FileFeaturesDbEntities" EnableFlattening="False" 
        EntitySetName="FileClasses">
    </asp:EntityDataSource>


    <asp:ObjectDataSource ID="odsSizePerFileClass" runat="server" SelectMethod="selectSorted"
        TypeName="DMS.FCollect.Db.BoSizePerFileClass" OnObjectCreated="odsSizePerFileClass_ObjectCreated">
        <SelectParameters>
            <asp:Parameter DefaultValue="ClassName" Name="sortType" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <%-- Seitenmenü --%>
    <div>
        <asp:Menu ID="Menu1" runat="server" DataSourceID="SiteMapDataSource1" Orientation="Horizontal"
            DynamicHorizontalOffset="2" StaticSubMenuIndent="10px" MaximumDynamicDisplayLevels="1">
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
    </div>
    <h1>Aufteilung des Speicherplatzes unter den Dateiklassen</h1>
    <div>
        <asp:CheckBoxList ID="cbxListFileClasses" runat="server" 
            DataSourceID="edsFileClasses" DataTextField="name" DataValueField="id"             
            RepeatDirection="Horizontal" ondatabound="cbxListFileClasses_DataBound">            
        </asp:CheckBoxList>
        &nbsp;
        <asp:Button ID="btnSetChoice" runat="server" Text="Auswahl setzen" 
            onclick="btnSetChoice_Click" />
    </div>
    <div>
        <div style="position: relative; top: 0px; left: 0px; width: 400px; height: 400px">
            <asp:Chart ID="Chart1" runat="server" DataSourceID="odsSizePerFileClass" Height="350px"
                Width="350px" BackColor="64, 64, 64" Palette="Fire">
                <Series>
                    <asp:Series Name="Series1" ChartType="Pie" XValueMember="ClassName" YValueMembers="SumSize"
                        Legend="Legend1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BackColor="64, 64, 64">
                        <Area3DStyle Enable3D="True" />
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend DockedToChartArea="ChartArea1" Name="Legend1">
                    </asp:Legend>
                </Legends>
            </asp:Chart>
        </div>
        <div style="position: relative; top: -400px; left: 420px; width: 400px; height: 400px">
            <asp:Chart ID="Chart2" runat="server" DataSourceID="odsSizePerFileClass" Height="350px"
                Width="350px" BackColor="64, 64, 64" Palette="Fire">
                <Series>
                    <asp:Series Name="Series1" ChartType="Pyramid" XValueMember="ClassName" YValueMembers="SumSize">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BackColor="64, 64, 64">
                        <Area3DStyle Enable3D="True" />
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
        <div style="position: relative; top: -800px; left: 840px; width: 400px; height: 400px">
            <asp:Chart ID="Chart3" runat="server" DataSourceID="odsSizePerFileClass" Height="350px"
                Width="350px" BackColor="64, 64, 64" Palette="Fire">
                <Series>
                    <asp:Series Name="Series1" XValueMember="ClassName" YValueMembers="SumSize" LabelForeColor="White">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BackColor="64, 64, 64">
                        <Area3DStyle Enable3D="True" />
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
    </div>
</asp:Content>
