<%@ Page Title="" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true"
    CodeBehind="WebServerControls.aspx.cs" Inherits="WebDms2.AspBasics.WebServerControls"
    EnableTheming="true" Theme="Design1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%-- Datenquellen --%>
    <!-- Markup für Webform -->
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <h1>
                Webserver- Steuerelemente</h1>
            <h3>
                Checkbox</h3>
            Mit Checkboxen kann man z.B. etwas konfigurieren.<br />
            <asp:CheckBox ID="cbxDemoBackColor" runat="server" Text="Hintergrundfarbe"  />
            <asp:CheckBox ID="cbxDemoBorderColor" runat="server" Text="Farbiger Rahmen" />
            <asp:Button ID="btnCbxDemoAuswahlDruchsetzen" runat="server" OnClick="btnCbxDemoAuswahlDruchsetzen_Click"
                Text="Auswahl setzen" />
            <table width="400">
                <tr>
                    <td id="tdCbxDemo" runat="server" style="border-width: 1; border-style: dotted">
                        <asp:Label ID="lblCbxDemo" runat="server" Text="CheckBoxDemo: Rahmen und Hintergrund konfigurieren" />
                    </td>
                </tr>
            </table>
            <asp:CheckBox ID="cbxDemoBackColor1" runat="server" AutoPostBack="true" Text="Hintergrundfarbe sofort setzen"
                OnCheckedChanged="cbxDemoBackColor1_CheckedChanged" />
            <asp:CheckBox ID="cbxDemoBorderColor1" runat="server" AutoPostBack="true" Text="Farbiger Rahmen sofort setzen"
                OnCheckedChanged="cbxDemoBorderColor1_CheckedChanged" />
            <h3>
                Image und Radiobuttons</h3>
            <div>
                <asp:RadioButton ID="rbtDemoLeft" runat="server" AutoPostBack="true" Checked="true"
                    GroupName="ImgLeftRight" Text="Bild nach links" OnCheckedChanged="rbtDemoLeft_CheckedChanged" />
                <div style="height: 50px; width: 100px; background-color: Blue;">
                    <asp:Image ID="imgDemo" runat="server" ImageAlign="Left" ImageUrl="~/Bilder/smiley.gif" />
                </div>
                <asp:RadioButton ID="rbtDemoRight" runat="server" AutoPostBack="true" GroupName="ImgLeftRight"
                    Text="Bild nach rechts" OnCheckedChanged="rbtDemoRight_CheckedChanged" />
            </div>
            <h3>
                ImageButton und LinkButton</h3>
            Ein Image- Button
            <asp:ImageButton ID="imgBtnDemo" runat="server" ImageUrl="~/Bilder/smiley.gif" OnClick="imgBtnDemo_Click" />
            <br />
            Ein
            <asp:LinkButton ID="LinkButtonDemo" runat="server" OnClick="LinkButtonDemo_Click">LinkButton</asp:LinkButton>
            der diese Uhr aktualisiert:
            <asp:Label ID="lblLinkButtonDemo" runat="server" Text="00:00:00" />
            <h3>
                Listbox, DropDownList, Placeholder</h3>
            <div style="height: 50px; width: 500px; position: relative">
                <div style="height: 60px; width: 200px; background-color: Green; position: relative;
                    top: 0; left: 0;">
                    <div style="height: 10px; width: 25px; position: relative; top: 0px; left: 0px">
                        Charakter
                    </div>
                    <div style="height: 10px; width: 25px; position: relative; top: -10px; left: 60px">
                        Ort
                    </div>
                    <div style="height: 30px; width: 25px; position: relative; top: 0px; left: 0px">
                        <asp:ListBox ID="lbxDemo" runat="server" Width="50" Height="50" SelectionMode="Multiple">
                            <asp:ListItem Text="Gut" Value="~/Bilder/Smiley.gif" />
                            <asp:ListItem Text="B&ouml;se" Value="~/Bilder/Smiley-boese.gif" />
                        </asp:ListBox>
                    </div>
                    <div style="width: 25px; position: relative; top: -30px; left: 60px;">
                        <asp:DropDownList ID="dpdDemo" runat="server" Width="100" Height="50">
                            <asp:ListItem Text="Himmel" Value="#00ffff" />
                            <asp:ListItem Text="Erde" Value="#800000" Selected="True" />
                            <asp:ListItem Text="Hölle" Value="#ff0000" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="divBuehne" runat="server" style="height: 40px; width: 100px; background-color: #800000;
                    position: relative; top: -60px; left: 200px;">
                    <asp:PlaceHolder ID="plcHldDemo" runat="server" />
                </div>
                <div style="height: 20px; width: 100px; background-color: #808000; position: relative;
                    top: -60px; left: 200px;">
                    <asp:Button ID="btnDemoListbox" runat="server" Text="Bild erzeugen" OnClick="btnDemoListbox_Click" />
                </div>
            </div>
            <h3>
                Literal</h3>
            Mit dem Literal kann markuphaltiger Text in die Ausgabe an den Browser eingeschleust
            werden.<br />
            <asp:Literal ID="LiteralDemoEncode" runat="server" Mode="Encode"></asp:Literal>
            <br />
            <asp:Literal ID="LiteralDemoPassThrough" runat="server" Mode="PassThrough"></asp:Literal>
            <br />
            <asp:Literal ID="LiteralDemoTransform" runat="server" Mode="Transform"></asp:Literal>
            <h3>
                Panel</h3>
            Mit Panels kann man z.B. Steuerelemente zu Gruppen zusammenfassen, die gemeinsamm
            aus- oder einblendbar sind.<br />
            <asp:RadioButtonList ID="rbtListDemo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtListDemo_SelectedIndexChanged">
                <asp:ListItem Text="Panel 1" Value="panDemo1" Selected="True" />
                <asp:ListItem Text="Panel 2" Value="panDemo2" />
                <asp:ListItem Text="Panel 3" Value="panDemo3" />
            </asp:RadioButtonList>
            <asp:Panel ID="panDemoAll" runat="server">
                <asp:Panel ID="panDemo1" runat="server" Visible="True" BackColor="Red" Width="100"
                    Height="30">
                    Panel 1<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                </asp:Panel>
                <asp:Panel ID="panDemo2" runat="server" Visible="True" BackColor="Green" Width="100"
                    Height="30">
                    Panel 2<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </asp:Panel>
                <asp:Panel ID="panDemo3" runat="server" Visible="True" BackColor="Blue" Width="100"
                    Height="30">
                    Panel 3<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </asp:Panel>
            </asp:Panel>
            <h3>
                Table</h3>
            Die Tabelle spielt ihre Stärke beim dynaischen Aufbau tabellarischer Daten aus.<br />
            <div>
                Alle Primzahlen bis
                <asp:TextBox ID="tbxTabDemo" runat="server" Text="20" Width="30">
                </asp:TextBox><asp:RangeValidator ID="rngVldTabDemo" runat="server" ControlToValidate="tbxTabDemo"
                    Type="Integer" MinimumValue="2" MaximumValue="1000" ErrorMessage="Nur Werte zwischen 2 und 1000 sind erlaubt"
                    ForeColor="Red" ValidationGroup="TabDemo">*</asp:RangeValidator>
                <asp:Button ID="btnTabDemo" runat="server" Text="Berechnen" OnClick="btnTabDemo_Click"
                    ValidationGroup="TabDemo" />
                <br />
                <asp:ValidationSummary ID="vldSumTabDemo" runat="server" ForeColor="Red" ValidationGroup="TabDemo" />
            </div>
            <asp:Table ID="tabPrimzahlen" runat="server" BorderColor="#333333" BorderWidth="1px">
            </asp:Table>
            <h3>
                XML</h3>
            Mit dem XML- Steuerelement kann auf XML- Markup ein Stylesheet angewendet werden.
            Das Ergebnis wird an den Browser gesendet.
            <asp:Xml ID="XmlDemo" runat="server" DocumentSource="~/App_Data/Planeten.xml" TransformSource="~/App_Data/Tabelle-der-Planeten-und-Monde-ohne-body.xslt"></asp:Xml>
            <h3>
                File Upload</h3>
            <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Button ID="btnFileUploadDemo"
                runat="server" OnClick="btnFileUploadDemo_Click" Text="Button" />
            <h3>
                Kalender</h3>
            <asp:Label ID="lblCalendarDemo" runat="server" />
            <br />
            <asp:Calendar ID="CalendarDemo" runat="server" 
                OnSelectionChanged="CalendarDemo_SelectionChanged" oninit="CalendarDemo_Init" 
                onload="CalendarDemo_Load">
            </asp:Calendar>
            <h3>AjaxToolkit- Kalender</h3>

            <asp:TextBox ID="tbxAjaxKalenderDemop" runat="server"></asp:TextBox>


            <asp:CalendarExtender ID="tbxAjaxKalenderDemop_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="tbxAjaxKalenderDemop" Format="dd.MM.yyyy"
                TodaysDateFormat="dd.MM.yyyy">
            </asp:CalendarExtender>


        </ContentTemplate>
    </asp:UpdatePanel>
    
    <h3>AdRotator</h3>
    AdRotator blendet werbebanner nach einem Zufallsprinzip ein. Die Werbung wird in
    einem XML- File hinterlegt.<br />
    <asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="~/AspBasics/AdRotatorAdvertisements.xml" />
    <asp:Label ID="lblStatus" runat="server" />
</asp:Content>
