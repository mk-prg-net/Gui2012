<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<WebGraphics.Models.CornerPoint>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>PolygonatorLineToView</title>
</head>
<body>
    <h2>PolygonatorView</h2>

    <form id="frm1" runat="server" method="post" target="LineTo">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%: Html.ValidationSummary(true)%>

    <div style="float: left; width: 200px">
        <h3>LineTo</h3>

        <div class="editor-label">
            <%= Html.LabelFor(model => model.CornerCount)%>
        </div>
        <div class="editor-field">
            <%= Html.ValueFor(model => model.CornerCount)%>
        </div>

        <div class="editor-label">
            <%= Html.LabelFor(model => model.PX)%>
        </div>
        <div class="editor-field">
            <%= Html.EditorFor(model => model.PX)%>
            <%= Html.ValidationMessageFor(model => model.PX)%>
        </div>

        <div class="editor-label">
            <%= Html.LabelFor(model => model.PY) %>
        </div>
        <div class="editor-field">
            <%= Html.EditorFor(model => model.PY)%>
            <%= Html.ValidationMessageFor(model => model.PY)%>
        </div>

        <div>
            <input id="Submit1" type="submit" value="LineTo" />

        </div>
    </div>
    <div style="float: left;">
        <%= Html.Action("GetPolygon")%>
    </div>
    <div style="clear: both"></div>
    </form>


    <div>
        <%: Html.ActionLink("Back to List", "Index", "Home")%>
    </div>

</body>
</html>
