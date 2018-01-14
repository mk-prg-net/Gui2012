<%@ Page Title="" Language="C#" MasterPageFile="~/DMSMaster.Master" AutoEventWireup="true"
    CodeBehind="MultiView.aspx.cs" Inherits="WebDms2.AspBasics.MultiView" EnableTheming="true" Theme="Design1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div>
        <table width="100%">
            <tr>
                <td class="pTabHeader">
                    Aufteilen einer Webform in Views
                </td>
            </tr>
        </table>
        <asp:MultiView ID="MuliView1" runat="server">
            <asp:View ID="View1" runat="server">
                <table width="100%">
                    <tr>
                        <td class="pTabItem">
                            <h2>
                                View 1</h2>
                        </td>
                    </tr>
                    <tr>
                        <td class="pTabItem">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Bilder/smiley-gross.png" AlternateText="Hier sollte das ausgewählte Bild erscheinen !" />
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <table width="100%">
                    <tr>
                        <td class="pTabItem">
                            <h2>
                                View 2</h2>
                        </td>
                    </tr>
                    <tr>
                        <td class="pTabItem">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Bilder/smiley-boese-gross.png" AlternateText="Hier sollte das ausgewählte Bild erscheinen !" />
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
        <table width="100%">
            <tr>
                <td class="pTabItem">
                    <asp:Button ID="btnShowView1" runat="server" Text="View1 anzeigen" OnClick="btnShowView1_Click" />
                    &nbsp;
                    <asp:Button ID="btnShowView2" runat="server" Text="View2 anzeigen" OnClick="btnShowView2_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
