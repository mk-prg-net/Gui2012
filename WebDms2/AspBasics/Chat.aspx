<%@ Page Title="Start\Basics\Chat" Language="C#" MasterPageFile="~/DMSMaster.Master"
    AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="WebDms2.AspBasics.Chat" EnableTheming="true" Theme="Design1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:ObjectDataSource ID="objChatDb" runat="server" OnObjectCreated="objChatDb_ObjectCreated"
            SelectMethod="select" TypeName="BoBeitrag"></asp:ObjectDataSource>
        <h2>
            Willkommen im ASP.NET Chat</h2>
        <table width="100%">
            <colgroup>
                <col width="200" />
                <col width="*" />
            </colgroup>
            <tr>
                <td>
                    UserId
                </td>
                <td>
                    Beitrag
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top">
                    <asp:TextBox ID="tbxUserId" runat="server" Width="100%"></asp:TextBox><br />
                    <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Beitrag senden" />
                    <br />
                    <asp:Button ID="btnRefresh" runat="server" Text="Aktualisieren" />
                </td>
                <td>
                    <asp:TextBox ID="tbxBeitrag" runat="server" TextMode="MultiLine" Rows="4" Width="100%"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    Bisherige Beiträge<br />
    <asp:GridView ID="grdBeitraege" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
        DataSourceID="objChatDb" onrowdatabound="grdBeitraege_RowDataBound">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                SortExpression="id" />
            <asp:BoundField DataField="userid" HeaderText="userid" SortExpression="userid" />
            <asp:TemplateField HeaderText="Beitrag" SortExpression="Beitrag">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Beitrag") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    &lt;&lt;<asp:Label ID="Label1" runat="server" Text='<%# Bind("Beitrag") %>'></asp:Label>&gt;&gt;
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
