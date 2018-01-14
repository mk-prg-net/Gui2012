using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

using View = DMS.FCollect.Db.BoFilesBasic.View;
using Db = DMS.FCollect.Db;

// Funktionalität für Page- Methoden
using System.Web.Script.Services;
using System.Web.Services;


namespace WebDms2
{
    public partial class FileTable : System.Web.UI.Page
    {
        // Spaltennummern
        const int ZeilenNrCol = 0;

        mko.Log.LogServer log = new mko.Log.LogServer();
        //mkoIt.Asp.SessionVar<GBLWeb.Stammdaten.GK.GKSessionVar> sessVar;
        WebDms2.FileTabSessionVar sessVar;

        int zeilennr = 0;
        bool grdDataBindingNow = false;


        protected void Page_Load(object sender, EventArgs e)
        {
            log.registerLogHnd(Master.StatusLabel);
            sessVar = mkoIt.Asp.PageState<WebDms2.FileTabSessionVar>.Create(Session);
        }

        mkoIt.Asp.GridFilterTexBoxCtrl<View.DirNameFilter, Db.File> ctrlFilterDir;
        protected void tbxDirNameFilter_Load(object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;
            Debug.Assert(tbx != null);
            ctrlFilterDir = new mkoIt.Asp.GridFilterTexBoxCtrl<View.DirNameFilter, Db.File>(tbx, grdDataBindingNow, sessVar);
        }

        mkoIt.Asp.GridFilterTexBoxCtrl<View.FileNameFilter, Db.File> ctrlFilterFileName;
        protected void tbxFileNameFilter_Load(object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;
            Debug.Assert(tbx != null);
            ctrlFilterFileName = new mkoIt.Asp.GridFilterTexBoxCtrl<View.FileNameFilter, Db.File>(tbx, grdDataBindingNow, sessVar);
        }

        mkoIt.Asp.GrdFilterDropDownCtrl<View.FileClassFilter, Db.File> ctrlFilterFileClass;
        protected void dpdFileClassFilter_Load(object sender, EventArgs e)
        {
            DropDownList dpd = sender as DropDownList;
            Debug.Assert(dpd != null);
            ctrlFilterFileClass = new mkoIt.Asp.GrdFilterDropDownCtrl<View.FileClassFilter, Db.File>(dpd, grdDataBindingNow, sessVar);
        }



        protected void btnSetFilter_Click(object sender, EventArgs e)
        {
            if (grdAll.HeaderRow != null && IsValid)
            {
                // Zugriff auf die Steuerelemente in der Kopfzeile, deren Servereigenschaften nicht mittels 
                // ...Changed aktualisiert werden können

                // Darstellung des neu gefilterten Resultsets bei der 1. Seite beginnen lassen
                grdAll.PageIndex = 0;
                sessVar.PageIndex = 0;

                // Neuen Abruf des gefilterten Resultsets erzwingen
                grdAll.DataBind();

            }
            else
                log.Log(mko.Log.RC.CreateError("Die eingaben sind fehlerhaft"));
        }

        /// <summary>
        /// Entfernt alle Filter, indem die Seite neu Aufgerufen wird (Kein Postback)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            sessVar.RemoveAllFilters();

            // Erneuter Aufruf der Webseite ohne Filter- Restriktionen
            Response.Redirect(SiteMap.CurrentNode.Url, true);

        }


        protected void grdAll_DataBinding(object sender, EventArgs e)
        {
            zeilennr = 0;
            grdDataBindingNow = true;
        }

        protected void grdAll_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var grd = (GridView)sender;

            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:
                    zeilennr = -1;
                    var bo = new DMS.FCollect.Db.BoFilesBasic();
                    sessVar.SetFilterAndSort(bo);
                    lblAnzDaten.Text = (bo.selectCount("") - 1).ToString();

                    break;
                case DataControlRowType.DataRow:
                    var view = (DMS.FCollect.Db.BoFilesBasic.View)e.Row.DataItem;
                    zeilennr++;

                    Label lblZeilenNr = e.Row.Cells[ZeilenNrCol].FindControl("lblZeilenNr") as Label;
                    Debug.Assert(lblZeilenNr != null, "grdAll_RowDataBound: Das Label lblZeilenNr wurde nicht gefunden");

                    lblZeilenNr.Text = String.Format("{0,3:N0}", zeilennr + grd.PageSize * grd.PageIndex);                   


                    break;
                case DataControlRowType.EmptyDataRow:
                    break;
                default: ;
                    break;
            }
        }

        protected void grdAll_Load(object sender, EventArgs e)
        {
            if (!IsPostBack || grdDataBindingNow)
            {
                GridView grd = sender as GridView;
                Debug.Assert(grd != null);
                grd.PageIndex = sessVar.PageIndex;
            }
        }

        protected void grdAll_PageIndexChanged(object sender, EventArgs e)
        {
            // Protokollieren der Seitenstandes
            GridView grd = sender as GridView;
            Debug.Assert(grd != null);

            sessVar.PageIndex = grd.PageIndex;
        }


        protected void grdAll_Sorting(object sender, GridViewSortEventArgs e)
        {
            GridView grd = (GridView)sender;
            sessVar.SortDirection = e.SortDirection;
            sessVar.SortExpression = e.SortExpression;
            grd.DataBind();
        }

        protected void grdAll_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridView grd = sender as GridView;
            Debug.Assert(grd != null);

            Validate("vldGW");
            if (!IsValid)
            {
                e.Cancel = true;
                return;
            }


            // Wandeln der Datumsangaben in ein robustes Format
            //e.NewValues["GeliefertAm"] = DateTime.Parse(e.NewValues["GeliefertAm"].ToString()).ToString("s");

        }


        protected void odsAll_ObjectCreated(object sender, ObjectDataSourceEventArgs e)
        {
            var bo = e.ObjectInstance as DMS.FCollect.Db.BoFilesBasic;
            Debug.Assert(bo != null);

            // Setzen der Filter
            sessVar.SetFilterAndSort(bo);

        }



        mkoIt.Asp.GridFilterZeitintervallCtrl<View.CreationTimeFilter, Db.File, GBLWeb.VonBisZeitintervall> ctrlFilterCreationTime;
        protected void CreationTimeZeitintervall_Load(object sender, EventArgs e)
        {
            var vonBis = sender as GBLWeb.VonBisZeitintervall;
            Debug.Assert(vonBis != null);
            ctrlFilterCreationTime = new mkoIt.Asp.GridFilterZeitintervallCtrl<View.CreationTimeFilter, Db.File, GBLWeb.VonBisZeitintervall>(vonBis, grdDataBindingNow, sessVar);

            vonBis.ValidationGroup = "vldGW";
            vonBis.ErrorMessage = "Das Intervall zur Einschränkung der Erstellungszeit ist unkorrekt";
        }

        mkoIt.Asp.GrdFilterDblIntervalCtrl<View.SizeInBytesFilter, Db.File, GBLWeb.UIDblIntervall> SizeInByteIntervallDeko;
        protected void SizeInBytesIntervallFilter_Load(object sender, EventArgs e)
        {
            var uiDb = sender as GBLWeb.UIDblIntervall;
            Debug.Assert(uiDb != null);
            SizeInByteIntervallDeko = new mkoIt.Asp.GrdFilterDblIntervalCtrl<View.SizeInBytesFilter, Db.File, GBLWeb.UIDblIntervall>(uiDb, grdDataBindingNow, sessVar, 0, double.MaxValue);

        }


        [ScriptMethod]
        [WebMethod]
        public static string[] GetFileNameCompletionList(string prefixText, int count)
        {
            try
            {
                var bo = new DMS.FCollect.Db.BoFilesBasic();
                List<string> lstCompletitionSet = bo.GetFileNameStartsWith(prefixText, count);

                string[] completitionSet = new string[lstCompletitionSet.Count];
                lstCompletitionSet.CopyTo(completitionSet);
                return completitionSet;

            }
            catch (Exception ex)
            {
                //log.Log(mko.Log.RC.CreateError("Beim Anbieten von passenden Lieferscheinnummern zur Eingabe: " + ex.Message));
                throw new Exception("Beim Anbieten von passenden Dateinamen zur Eingabe: ", ex);
            }
        }

        [ScriptMethod]
        [WebMethod]
        public static string[] GetDirNameCompletionList(string prefixText, int count)
        {
            try
            {
                var bo = new DMS.FCollect.Db.BoFilesBasic();
                List<string> lstCompletitionSet = bo.GetDirNameStartsWith(prefixText, count);

                string[] completitionSet = new string[lstCompletitionSet.Count];
                lstCompletitionSet.CopyTo(completitionSet);
                return completitionSet;

            }
            catch (Exception ex)
            {
                //log.Log(mko.Log.RC.CreateError("Beim Anbieten von passenden Lieferscheinnummern zur Eingabe: " + ex.Message));
                throw new Exception("Beim Anbieten von passenden Dateinamen zur Eingabe: ", ex);
            }
        }





    }
}