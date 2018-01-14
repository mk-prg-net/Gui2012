using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Euk = mko.Euklid;
using Gph = mko.Graphic;
using GphW3 = mko.Graphic.WebClient;
using Css = mkoIt.Xhtml.Css;

namespace WebGraphics.Controllers
{
    public class PolygonatorController : Controller
    {
        const string IdServermodel = "PolygonatorModel";

        const string PolygonatorStartsView = "PolygonatorStartsView";
        const string PolygonatorLineToView = "PolygonatorLineToView";
        const string PolygonatorDrawView = "PolygonatorDrawView";

        protected Models.Polygon Servermodel
        {
            get
            {
                return Session[IdServermodel] as Models.Polygon;
            }

            set
            {
                Session[IdServermodel] = value;
            }
        }


        //
        // GET: /Polygonator/

        public ActionResult Index()
        {
            return View();
        }       

        //
        // GET: /Polygonator/Create

        public ActionResult Create()
        {
            Servermodel = new Models.Polygon();

            var Corner = new Models.CornerPoint() { Operator = Models.CornerPoint.Operators.starts };

            return View(PolygonatorStartsView, Corner);

        }

        public ActionResult Starts(Models.CornerPoint corner)
        {
            Servermodel.StartsAt(corner.P);

            return View(PolygonatorLineToView, corner);
        }

        public ActionResult LineTo(Models.CornerPoint corner)
        {
            Servermodel.LineTo(corner.P);
            return View(PolygonatorLineToView, corner);
        }


        public ActionResult GetPolygon()
        {
            return View(PolygonatorDrawView, Servermodel);
        }


        //
        // GET: /Polygonator/Delete/5

        public ActionResult Clear()
        {
            Servermodel.Clear();
            return View(PolygonatorStartsView, new Models.CornerPoint() { Operator = Models.CornerPoint.Operators.starts });
        }        
    }
}
