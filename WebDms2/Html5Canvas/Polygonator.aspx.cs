using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using E = mko.Euklid;
using Htm = mkoIt.Asp.HtmlCtrl;
using Css = mkoIt.Xhtml.Css;
using GphW3 = mko.Graphic.WebClient;

namespace WebDms2.Html5Canvas
{
    public partial class Polygonator : System.Web.UI.Page
    {
        mkoIt.Asp.HtmlCtrl.Canvas canMain;

        Htm.TextBox tbx;
        Htm.Button btnCreateSpiral;
        Htm.Button btnCreateTrapez;
        Htm.Button btnCreateNikohome;


        GphW3.CanvasPlotter Plotter;

        Models.Polygon Model;

        /// <summary>
        /// Seiteninhalt programatisch aufbauen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
            Model = mkoIt.Asp.PageState<Models.Polygon>.Create(Session);

            //var phld1 = sender as PlaceHolder;

            phld1.Controls.Add(
                new mkoIt.Asp.HtmlCtrl.DIV(
                        new Htm.Button("btnCreateSpiral", out btnCreateSpiral)
                        {
                            Text = "Spirale erzeugen",
                            SetClick = (s, args) =>
                            {
                                double Vergrößerungsfaktor;
                                if (double.TryParse(tbx.Text, out Vergrößerungsfaktor))
                                    SpiralFactory.Create(Vergrößerungsfaktor, Model, Plotter);
                            }
                        },
                        new Htm.TextBox("tbxSpiralFactor", out tbx)
                        {
                            Text = "2",
                            ToolTip = "Vergrößerungsfaktor der Spirale",
                            CssStyleBld = new Css.StyleBuilder()
                            {
                                Width = new Css.LengthPixel(30),
                                TextAlign = Css.TextAlign.Right,
                                BackgroundColor = Css.Color.Aqua
                            }
                        },
                        new Htm.Button("btnCreateTrapez", out btnCreateTrapez)
                        {
                            Text = "Trapez Erzeugen",
                            SetClick = (s, args) =>
                            {

                            }
                        },
                        new Htm.Button("btnCreateHausNiko", out btnCreateNikohome)
                        {
                            Text = "Haus von Nikolaus",
                            SetClick = (s, args) =>
                            {
                                Model.Clear();
                                Css.Color[] colors = { Css.Color.Lime, Css.Color.Red, Css.Color.Blue };
                                int cs = 0;
                                for (double a = 0.0; a < 2 * Math.PI; a += 2 * Math.PI / 20.0, cs++)
                                {
                                    Model.DefaultColor = colors[cs % colors.Length];
                                    var Pos = new E.Vector(a*200.0, Math.Sin(a)*300);
                                    NikoHomeFactory.Create(new E.Vector(100, 300) + Pos, Model, Plotter);
                                }
                            }
                        },

                        new Htm.BR(),
                        new Htm.Canvas("canMain", out canMain)
                        {
                            Width = 1500,
                            Height = 800
                        }
                    )
                    {
                        CssStyleBld = new Css.StyleBuilder()
                        {
                            BackgroundColor = Css.Color.Black,
                            BorderStyle = Css.BorderStyle.Inset
                        }
                    }
            );

            Plotter = new mko.Graphic.WebClient.CanvasPlotter(new Htm.Canvas.ClientComponentScriptBld(canMain.ClientID));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }


        void Page_PreRender(object sender, EventArgs e)
        {
            // Scrpit in die Webform ausgeben
            //"<script type=\"text/javascript\"> function pageLoad() { " + Plotter.Context.ToString() + "} <" + '/' + "script>");
            Page.ClientScript.RegisterStartupScript(
                GetType(),
                "SCRIPT1",
                Plotter.scriptBld.CreateMSAjaxPageLoadEventHandler(Plotter.Context.ToString(), true));
        }
    }
}