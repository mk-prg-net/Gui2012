<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrDefault.aspx.cs" Inherits="WebDms2.ErrorPages.ErrDefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Ein allgemeiner Fehler ist aufgetreten</h1>
        <asp:Table ID="tabErrorinfo" runat="server">
            <asp:TableRow runat="server" Width="100%">
                <asp:TableCell runat="server" BackColor="#FFCC99" Width="150px">Fehlercode</asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="tabCellErrCode" runat="server" BackColor="#FFCC99">Beschreibung</asp:TableCell>
                <asp:TableCell ID="tabCellErrText" runat="server"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Image ID="imgErr" runat="server" ImageUrl="~/ErrorPages/ErrorSmiley.png" />
    
    </div>
    </form>
</body>
</html>
