<%@ Page Title="Wizzard" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true"
    CodeBehind="WizzardDemo.aspx.cs" Inherits="WebDms2.AspBasics.WizzardDemo" EnableTheming="true"
    Theme="Design1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>
        Wizzard</h1>
    <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" OnFinishButtonClick="Wizard1_FinishButtonClick">
        <WizardSteps>
            <asp:WizardStep ID="WizardStep1" runat="server" Title="Wilkommen">
                Hallo, bitte geben Sie ihren Namen ein:
                <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep2" runat="server" Title="Daten erfassen">
                Bitte geben Sie ihr gehalt ein:
                <asp:TextBox ID="tbxGehalt" runat="server"></asp:TextBox>
            </asp:WizardStep>
            <asp:WizardStep ID="WizzardStep3" runat="server" Title="Abschluss">
                Vielen Dank. Ihre Euro- Soliabgabe wird nun berechnet.
            </asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
    Sie haben bis morgen zu entrichten:
    <asp:Label ID="lblAbgabe" runat="server" />
    Eur !
</asp:Content>
