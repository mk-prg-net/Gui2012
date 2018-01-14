<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrUnauthorized.aspx.cs"
    Inherits="WebDms2.ErrorPages.ErrUnauthorized1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Zutritt Verboten !</h1>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Bilder/StopVerboten.png" AlternateText="Hier sollte ein Parkverbotsschild erscheinen" />
    </div>
    </form>
</body>
</html>
