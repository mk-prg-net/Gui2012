using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDms2.AspBasics
{
    public partial class Chat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                // Exklusiven Zugriff auf den Anwendungszustand sichern
                Application.Lock();

                // Referenz auf das DsChatDB Dataset der Anwendung holen
                DsChatDB ds = (DsChatDB)Application["ChatDB"];

                // Neue Zeile für die Tabelle Beitrag erzeugen und mit den Daten aus dem Webform laden
                DsChatDB.BeitraegeRow row = ds.Beitraege.NewBeitraegeRow();

                row.userid = tbxUserId.Text;
                row.Beitrag = tbxBeitrag.Text;

                // Neue Zeile der Tebelle Beitrag hinzufügen

                ds.Beitraege.AddBeitraegeRow(row);

                //// Sicht auf die Liste der Beiträge aktualisieren
                //grdBeitraege.DataBind();
            }
            finally
            {
                Application.UnLock();
            }
        }
        protected void objChatDb_ObjectCreated(object sender, ObjectDataSourceEventArgs e)
        {
            // Zugriff auf das Business- Object, um es vor dem Abruf der Daten mittels Select zu 
            // konfigurieren
            BoBeitrag bo = e.ObjectInstance as BoBeitrag;

            bo.DB = (DsChatDB)Application["ChatDB"];

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Sicht auf die Liste der Beiträge aktualisieren
            grdBeitraege.DataBind();
        }

        protected void grdBeitraege_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:
                    break;
                case DataControlRowType.DataRow:
                    var datarow = (e.Row.DataItem as System.Data.DataRowView).Row as WebDms2.DsChatDB.BeitraegeRow;
                    if (datarow.id % 3 == 0)
                    {
                        var lbl = e.Row.FindControl("Label1") as Label;
                        lbl.BackColor = System.Drawing.Color.Green;
                    }
                    break;
                case DataControlRowType.Footer:
                    break;
                default: ;
                    break;

            }
        }

    }
}
