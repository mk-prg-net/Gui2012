using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebGraphics.Controllers
{
    public class TriangleController : Controller
    {
        const string IdServermodel = "TriangleModel";

        const double Translation = 20.0;


        //
        // GET: /Triangle/

        public ActionResult Index()
        {
            return View();
        }


        protected Models.DynTriangle Servermodel
        {
            get
            {
                return Session[IdServermodel] as Models.DynTriangle;
            }

            set
            {
                Session[IdServermodel] = value;
            }
        }


        public ActionResult Create()
        {
            Servermodel = new Models.DynTriangle();
            return View("TriangleMoveView", Servermodel);
        }

        public ActionResult MoveLeft()
        {           
            return View("TriangleMoveView",  Servermodel.MoveLeft(Translation));
        }

        public ActionResult MoveLeftUp()
        {
            return View("TriangleMoveView", Servermodel.MoveLeft(Translation).MoveUp(Translation));
        }

        public ActionResult MoveLeftDown()
        {
            return View("TriangleMoveView", Servermodel.MoveLeft(Translation).MoveDown(Translation));
        }

        public JavaScriptResult MoveLeftAjax()
        { 
            var canTriangle = new mkoIt.Asp.HtmlCtrl.Canvas("canTriangel");
            var plotter = new mko.Graphic.WebClient.CanvasPlotter(canTriangle.ScriptBld);

            Servermodel.MoveLeft(Translation).Triangle.draw(plotter);            

            //return JavaScript(canTriangle.ScriptBld.Eval(plotter.GetScript(true)));
            //return JavaScript(plotter.GetScript(false));

            return JavaScript("alert('" + DateTime.Now.ToString() + "')");
        }

        public ActionResult MoveRight()
        {            
            return View("TriangleMoveView", Servermodel.MoveRight(Translation));
        }

        public ActionResult MoveRightUp()
        {
            return View("TriangleMoveView", Servermodel.MoveRight(Translation).MoveUp(Translation));
        }

        public ActionResult MoveRightDown()
        {
            return View("TriangleMoveView", Servermodel.MoveRight(Translation).MoveDown(Translation));
        }

        public ActionResult MoveUp()
        {            
            return View("TriangleMoveView", Servermodel.MoveUp(Translation));
        }

        public ActionResult MoveDown()
        {            
            return View("TriangleMoveView", Servermodel.MoveDown(Translation));
        }



    }
}
