<%@ Page Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" Inherits="WebDms2.AspBasics.HtmlControls" Title="HTML Ctrls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        U2- Steuerelemente</h1>
    <h2>
        HTML- Steuerelemente</h2>
    <table id="Table1" style="width: 504px; height: 399px" cellspacing="1" cellpadding="1"
        width="504" border="1">
        <tr>
            <td style="width: 133px; height: 45px">
                Textfeld
            </td>
            <td style="width: 253px; height: 45px">
                <input runat="server" id="tbxHtm" style="width: 144px; height: 22px" type="text"
                    size="18" />
                <asp:RequiredFieldValidator ControlToValidate="tbxHtm" ErrorMessage="Text fehlt  Text"
                    runat="server" ID="RequiredFieldValidator1">
								*
                </asp:RequiredFieldValidator>
            </td>
            <td id="TD1" runat="server" style="height: 45px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 133px; height: 45px">
                Textfeld2
            </td>
            <td style="width: 253px; height: 45px">
                <asp:TextBox ID="tbx2" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ControlToValidate="tbx2" ErrorMessage="Keine Email in  Text2"
                    ValidationExpression=".+@.+\..+" runat="server" ID="RegularExpressionValidator1">
								Es wurde keine gültige Email- Adresse eingegeben.
                </asp:RegularExpressionValidator>
            </td>
            <td style="height: 45px">
            </td>
        </tr>
        <tr>
            <td style="width: 133px; height: 45px">
                Textfeld3- nur Zahlen
            </td>
            <td style="width: 253px; height: 45px">
                <asp:TextBox ID="tbx3" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ControlToValidate="tbx3" ErrorMessage="Keine Zahl in Text3"
                    ValidationExpression="\d+,?\d*" runat="server" ID="Regularexpressionvalidator2">
								Es wurde keine gültige Zahl eingegeben.
                </asp:RegularExpressionValidator>
            </td>
            <td style="height: 45px">
            </td>
        </tr>
        <tr>
            <td style="width: 133px">
                Passwort
            </td>
            <td style="width: 253px">
                <input id="tbxPassword" type="password" runat="server" />
            </td>
            <td id="TD2" runat="server">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 133px">
                File
            </td>
            <td style="width: 253px">
                <input id="fileHtm" style="width: 232px; height: 22px" type="file" size="19" runat="server" />
            </td>
            <td id="TD3" runat="server">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 133px">
                Check- Box
            </td>
            <td style="width: 253px">
                <input id="checkHtmMilch" style="width: 16px; height: 20px" type="checkbox" runat="server" />Milch
                <input id="checkHtmZucker" type="checkbox" runat="server">Zucker<input id="checkHtmSahne"
                    type="checkbox" />Sahne
            </td>
            <td id="TD4" runat="server">
                &nbsp;
                <asp:Button ID="Button2" runat="server" Text="Button" />
            </td>
        </tr>
        <tr>
            <td style="width: 133px">
                Radio- Button
            </td>
            <td style="width: 253px">
                <input id="radioHtmMann" type="radio" />männlich
                <input id="radioHtmFrau" type="radio" />weiblich
            </td>
            <td id="TD5" runat="server">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 133px">
                List- Box
            </td>
            <td style="width: 253px">
                <select id="lbxHtmDatenbank" style="width: 176px; height: 38px" size="2" runat="server">
                    <option>SQL- Server</option>
                    <option>Oracle</option>
                    <option>IBM DB2</option>
                    <option>Access</option>
                </select>
            </td>
            <td id="TD6" runat="server">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 133px">
                Multilist- Box
            </td>
            <td style="width: 253px">
                <select id="mlbxHtmDatenbank" style="width: 176px; height: 38px" multiple size="2"
                    runat="server">
                    <option>SQL- Server</option>
                    <option>Oracle</option>
                    <option>IBM DB2</option>
                    <option>Access</option>
                </select>
            </td>
            <td id="TD7" runat="server">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 133px">
                Drop- Down
            </td>
            <td style="width: 253px">
                <select id="drdHtmSprache" style="width: 176px">
                    <option selected>deutsch</option>
                    <option>englisch</option>
                    <option>italienisch</option>
                    <option>spanisch</option>
                </select>
            </td>
            <td id="TD8" runat="server">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 133px">
                Textarea
            </td>
            <td style="width: 253px">
                <textarea rows="5" cols="20">							</textarea>
            </td>
            <td id="TD9" runat="server">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 133px">
                Button
            </td>
            <td style="width: 253px">
                <input onclick="javascript: alert('Hallo');" type="button" value="Button" />
            </td>
            <td id="TD10" runat="server">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 133px">
            </td>
            <td style="width: 253px">
                <asp:Button ID="Button1" runat="server" Text="Button"></asp:Button>
            </td>
            <td id="TD11" runat="server">
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:ValidationSummary HeaderText="Folgende Fehler traten auf:" ShowSummary="true"
        DisplayMode="BulletList" runat="server" ID="ValidationSummary1" />
    <h3>
        Auslesen aller Einträge der einfachen Listbox</h3>
    <ol runat="server" id="lstDatenSimpelLbx">
    </ol>
    <h3>
        Auslesen aller Einträge der Multi- Listbox</h3>
    <ol runat="server" id="lstDatenMultiLbx">
    </ol>
    <h2>
        Webserversteuerelemente</h2>
    <p>
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    </p>
</asp:Content>

