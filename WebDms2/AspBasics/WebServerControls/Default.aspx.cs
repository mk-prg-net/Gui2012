using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class WebServerControls_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (rbtSichtbar.Checked)
                dpdLieferanten2.Visible = true;
            else
                dpdLieferanten2.Visible = false;

            if (rbtEnabled.Checked)
                dpdLieferanten2.Enabled = true;
            else
                dpdLieferanten2.Enabled = false;
        }

    }
    protected void dpdLieferanten_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void dpdLieferanten2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnSelectLieferantendaten_Click(object sender, EventArgs e)
    {

    }
    protected void btnStil_Click(object sender, EventArgs e)
    {
        dpdLieferanten2.ForeColor = System.Drawing.Color.Yellow;
        dpdLieferanten2.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 255);

        dpdLieferanten2.Height = new Unit(30, UnitType.Point);

        dpdLieferanten2.Font.Name = "Arial";
        dpdLieferanten2.Font.Italic = true;
        dpdLieferanten2.Font.Size = new FontUnit(24, UnitType.Point);
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        lblStatus.Text = "Click auf Linkbutton";
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
  
    }
    protected void Button1_Click(object sender, EventArgs e)
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
}
