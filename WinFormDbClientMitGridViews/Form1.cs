using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WinFormDbClientMitGridViews
{
    public partial class Form1 : WinFormTemplates.WinFormTemplate1
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Diese Codezeile lädt Daten in die Tabelle "dsDbArtikel1.ArtikelDetailsView". Sie können sie bei Bedarf verschieben oder entfernen.
            this.artikelDetailsViewTableAdapter.Fill(this.dsDbArtikel1.ArtikelDetailsView);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "dsDbArtikel1.Produkte". Sie können sie bei Bedarf verschieben oder entfernen.
            this.produkteTableAdapter.Fill(this.dsDbArtikel1.Produkte);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "dsDbArtikel1.Lieferanten". Sie können sie bei Bedarf verschieben oder entfernen.
            this.lieferantenTableAdapter.Fill(this.dsDbArtikel1.Lieferanten);
        }

        private void btnRequeryLieferanten_Click(object sender, EventArgs e)
        {
            try
            {
                var adp = new DsDbArtikelTableAdapters.LieferantenTableAdapter();                
                adp.Fill(dsDbArtikel1.Lieferanten);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("FEhler beim Abruf der Lieferantendaten: " + ex.Message);
            }
        }

        private void btnLieferantenSave_Click(object sender, EventArgs e)
        {
            try
            {
                var adp = new DsDbArtikelTableAdapters.LieferantenTableAdapter();
                adp.Update(dsDbArtikel1.Lieferanten);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("FEhler beim sichern der aktualisierten Lieferantendaten in der Db: " + ex.Message);
            }
        }

        private void LieferantenBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void LieferantenBindingSource_PositionChanged(object sender, EventArgs e)
        {

        }

        private void LieferantenBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            var bs = sender as BindingSource;

            // Aus dem aktuell ausgewählten DAtensatz die Lieferantennummer isolieren            


            if (bs.Current != null)            
            {
                int? lfnr = (int?)((DataRowView)bs.Current).Row[0];
                //grdMAsterDetailProdukte.DataSource = dsDbArtikel1.Artikel.Where(r => r.lfnr == lfnr).Select(r => r.ProdukteRow);
                //ArtikelViewBindingSource.DataSource = 
                //grdMAsterDetailProdukte.DataSource = null;
                grdMAsterDetailProdukte.DataSource = dsDbArtikel1.ArtikelDetailsView.Where(r => r.lfnr == lfnr).AsDataView();

                //ArtikelViewBindingSource.DataSource = dsDbArtikel1.ArtikelDetailsView.Where(r => r.lfnr == lfnr).AsDataView();
            }


        }
    }
}
