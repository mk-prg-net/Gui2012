<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebGraphics.Models.Polygon>" %>
<form runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<asp:PlaceHolder ID="phld1" runat="server"></asp:PlaceHolder>

<script runat="server">

    mkoIt.Asp.HtmlCtrl.Canvas canMain;

    mkoIt.Asp.HtmlCtrl.TextBox tbx;
    mko.Graphic.WebClient.CanvasPlotter Plotter;


    protected void Page_Init(object sender, EventArgs e)
    {
        //var phld1 = sender as PlaceHolder;

        phld1.Controls.Add(
            new mkoIt.Asp.HtmlCtrl.DIV(
                    new mkoIt.Asp.HtmlCtrl.Canvas("canMain", out canMain)
                    {
                        Width = 1000,
                        Height = 500
                    }
                )
        );


        Plotter = new mko.Graphic.WebClient.CanvasPlotter(new mkoIt.Asp.HtmlCtrl.Canvas.ClientComponentScriptBld(canMain.ClientID));

        Model.PolygonBlock.draw(Plotter);
    }

    void Page_PreRender(object sender, EventArgs e)
    {
        // Scrpit in die Webform ausgeben
        Page.ClientScript.RegisterStartupScript(GetType(), "SCRIPT1",
            "<script type=\"text/javascript\"> function pageLoad() { " + Plotter.Context.ToString() + "} <" + '/' + "script>");
    }
</script>
</form>
