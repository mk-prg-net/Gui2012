using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDms2.AspBasics
{
    public partial class WebServerControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)               
            {
                string htmText= @"Öl ist <b>fett</b>";
                LiteralDemoEncode.Text = htmText;
                LiteralDemoPassThrough.Text = htmText;
                LiteralDemoTransform.Text = htmText;
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Click auf Linkbutton";
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void btnFileUploadDemo_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    // Physikalischen Pfad des virtuellen Verzeichnisses zur Aufnahme der Anhänge bestimmen
                    string savePath = Server.MapPath("~/Uploads");

                    // Get the name of the file to upload.
                    string fileName = FileUpload1.FileName;

                    // GUID- hinzufügen
                    Guid file_id = Guid.NewGuid();
                    string uniqueFileName = string.Format("{0}.{1}", fileName, file_id.ToString());

                    // Zielpfad für den Dateianhang bilden
                    savePath += (@"\" + uniqueFileName);

                    // Datei hochladen
                    FileUpload1.SaveAs(savePath);

                    lblStatus.Text = string.Format("Dateiupload erfolgreich: {0}", savePath);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = string.Format("Fehler: {0}", ex.Message);
            }
        }


        protected void btnCbxDemoAuswahlDruchsetzen_Click(object sender, EventArgs e)
        {
            tdCbxDemo.BgColor = cbxDemoBackColor.Checked ? "#800000" : "";
            tdCbxDemo.BorderColor = cbxDemoBorderColor.Checked ? "#ffff00" : "";     
        }

        protected void cbxDemoBackColor1_CheckedChanged(object sender, EventArgs e)
        {
            var cbx = sender as CheckBox;
            tdCbxDemo.BgColor = cbx.Checked ? "#800000" : "";
        }

        protected void cbxDemoBorderColor1_CheckedChanged(object sender, EventArgs e)
        {
            var cbx = sender as CheckBox;
            tdCbxDemo.BorderColor = cbx.Checked ? "#ffff00" : "";     
        }

        protected void imgBtnDemo_Click(object sender, ImageClickEventArgs e)
        {
            var btn = sender as ImageButton;
            if (btn.ImageUrl.Contains("smiley.gif"))
            {
                btn.ImageUrl = "~/Bilder/smiley-boese.gif";
            }
            else
            {
                btn.ImageUrl = "~/Bilder/smiley.gif";
            }
        }

        protected void LinkButtonDemo_Click(object sender, EventArgs e)
        {
            lblLinkButtonDemo.Text = DateTime.Now.ToLongTimeString();
        }

        protected void rbtDemoLeft_CheckedChanged(object sender, EventArgs e)
        {
            imgDemo.ImageAlign = ImageAlign.Left;
        }

        protected void rbtDemoRight_CheckedChanged(object sender, EventArgs e)
        {
            imgDemo.ImageAlign = ImageAlign.Right;
        }

        protected void btnDemoListbox_Click(object sender, EventArgs e)
        {
            // Auswerten der DropDown- Liste
            divBuehne.Style.Remove(HtmlTextWriterStyle.BackgroundColor);
            divBuehne.Style.Add(HtmlTextWriterStyle.BackgroundColor, dpdDemo.SelectedValue);

            plcHldDemo.Controls.Clear();

            // Auswerten der Listbox
            foreach (ListItem litem in lbxDemo.Items)
            {
                if (litem.Selected)
                {
                    // Für jeden selektierten Eintrag wird dem Panel ein Image- Element 
                    // hinzugefügt
                    plcHldDemo.Controls.Add(new Image() {ImageUrl= litem.Value});
                }
            }
        }

        protected void rbtListDemo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //panDemo1.Visible = panDemo2.Visible = panDemo3.Visible = false;
            panDemo1.Enabled = panDemo2.Enabled = panDemo3.Enabled = false;

            var rbtList = sender as RadioButtonList;
            var pan = panDemoAll.FindControl(rbtList.SelectedValue) as Panel;
            pan.Enabled = true;
        }

        protected void CalendarDemo_SelectionChanged(object sender, EventArgs e)
        {
            var cld = sender as Calendar;
            lblCalendarDemo.Text = cld.SelectedDate.ToString();
        }

        protected void btnTabDemo_Click(object sender, EventArgs e)
        {
            // Alle alten Ergebnisse löschen
            tabPrimzahlen.Rows.Clear();

            var rowh = new TableHeaderRow();

            rowh.Cells.Add(new TableHeaderCell() { Text = "Nr", Width = 30, HorizontalAlign = HorizontalAlign.Center });
            rowh.Cells.Add(new TableHeaderCell() { Text = "Primzahl", Width = 50, HorizontalAlign = HorizontalAlign.Center });
            tabPrimzahlen.Rows.Add(rowh);


            // Neue Primzahlentabelle aufbauen
            int bis = int.Parse(tbxTabDemo.Text);
            int z = 1;
            for (int i = 3; i <= bis; i++)
            {
                bool teilbar = false;
                for (int j = 2; j <= i / 2; j++)
                {
                    teilbar = i % j == 0;
                    if (teilbar) break;
                }

                if (!teilbar)
                {
                    // Neue Tabellenzeile anlegen
                    var row = new TableRow();

                    row.Cells.Add(new TableCell() { Text = z++.ToString(), Width=30, HorizontalAlign= HorizontalAlign.Center });
                    row.Cells.Add(new TableCell() { Text = i.ToString(), Width=50, HorizontalAlign= HorizontalAlign.Right });

                    tabPrimzahlen.Rows.Add(row);
                }                
            }
        }

        protected void CalendarDemo_Load(object sender, EventArgs e)
        {
           
        }

        protected void CalendarDemo_Init(object sender, EventArgs e)
        {
            var cld = sender as Calendar;

            //cld.SelectedDate = new DateTime(2012, 12, 24);
            cld.SelectedDate = DateTime.Now;
            //cld.SelectionMode = CalendarSelectionMode.DayWeekMonth;
        }

    }
}