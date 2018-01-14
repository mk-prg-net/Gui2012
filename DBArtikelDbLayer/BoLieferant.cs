using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DBArtikelDbLayer
{
    public class BoLieferant
    {
        Dtx.DtxDBArtikelDataContext DataContext;

        public static string ConnectionString;

        public BoLieferant()
        {
            DataContext = new DBArtikelDbLayer.Dtx.DtxDBArtikelDataContext(ConnectionString);
        }

        // Alle Datensätze aus der Lieferantentabelle lesen
        public IQueryable<Dtx.Lieferanten> select()
        {
            return DataContext.Lieferantens.OrderBy(lf => lf.name);
        }

        // Lieferant mit lfnr lesen
        public IQueryable<Dtx.Lieferanten> select(int lfnr)
        {   
            return DataContext.Lieferantens.Where(lf => lf.lfnr == lfnr);                
        }


        // Neuen Datensatz hinzufügen
        public int insert(Dtx.Lieferanten lf)
        {
            Debug.Assert(lf != null);
            try
            {
                // Einfügen eines neuen Lieferantendatensatzes anmelden
                Dtx.Lieferanten lfNeu = new DBArtikelDbLayer.Dtx.Lieferanten();
                lfNeu.email = lf.email;
                lfNeu.lfnr = lf.lfnr;
                lfNeu.name = lf.name;
                lfNeu.plz = lf.plz;

                DataContext.Lieferantens.InsertOnSubmit(lfNeu);

                // Einfüge- Operation wird an den Datenbankserver abgesendet
                DataContext.SubmitChanges();

                return lf.lfnr;
            }
            catch (Exception ex)
            {
                Debug.Fail("Fehler beim Aufruf von BoLieferanten.insert(...): " + ex.Message, ex.InnerException != null ? ex.InnerException.Message : "");
                return -1;
            }
        }

        public void update(Dtx.Lieferanten lf)
        {
            // Voraussetzung: unter der übergebenen Lieferantennummer existiert in der Datenbank 
            // ein Datensatz
            Debug.Assert(lf != null && DataContext.Lieferantens.Any(plf => plf.lfnr == lf.lfnr));
            try
            {
                // Zugriff auf den bestehenden Datensatz
                Dtx.Lieferanten lfAlt = select(lf.lfnr).First();

                lfAlt.name = !string.IsNullOrEmpty(lf.name) ? lf.name : null;
                lfAlt.plz = !string.IsNullOrEmpty(lf.plz) ? lf.plz : null;
                lfAlt.email = !string.IsNullOrEmpty(lf.email) ? lf.email : null;

                // Änderungen am lfAlt Datensatz aus der Tabelle DataContext.Lieferantes in Datenbank durchschreiben
                DataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                Debug.Fail("Fehler beim Aufruf von BoLieferanten.update(...): " + ex.Message, ex.InnerException != null ? ex.InnerException.Message : "");
            }

        }

        // Löschen eines Lieferanten
        public void delete(Dtx.Lieferanten lf)
        {
            // Voraussetzung: unter der übergebenen Lieferantennummer existiert in der Datenbank 
            // ein Datensatz
            Debug.Assert(lf != null && DataContext.Lieferantens.Any(plf => plf.lfnr == lf.lfnr));

            Dtx.Lieferanten lfToKill = DataContext.Lieferantens.Where(plf => plf.lfnr == lf.lfnr).First();
            DataContext.Lieferantens.DeleteOnSubmit(lfToKill);
            DataContext.SubmitChanges();
            Debug.WriteLine("Der Lieferant " + lf.name + " mit der Lieferantennummer " + lf.lfnr + " wurde erfolgreich gelöscht");

        }

        // Alle Artikel zu einem Lieferanten abfragen
        public List<Dtx.Artikel> selectArtikel(int lfnr)
        {
            if(DataContext.Lieferantens.Any(lfa => lfa.lfnr == lfnr))
                return select(lfnr).First().Artikels.ToList();
            return null;
        }


        public List<Dtx.lagerbestandResult> callStoredProcedure()
        {
            return DataContext.lagerbestand().ToList();
        }
    }
}
