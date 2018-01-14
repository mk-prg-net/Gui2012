using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprachkonzepte
{
    public sealed class Schlachtschiff
    {
        public string Name { get; set; }
        public int AnzLeben { get; set; }
        public int Feuerkraft { get; set; }
    }       


    // Moderne Lösung
    public static class SchlachtschiffExtensions
    {
        public static void schiessenAuf(this Schlachtschiff feuernde, Schlachtschiff befeuerte)
        {
            befeuerte.AnzLeben -= feuernde.Feuerkraft;
        }
    }

    public class Erweiterungsmethoden
    {

        // Klassische Lösung, einen Vorgegebene Klasse um Funktionen zu erweitern
        static void schiessen(Schlachtschiff feuernde, Schlachtschiff befeuerte)
        {
            befeuerte.AnzLeben -= feuernde.Feuerkraft;
        }      


        static bool exec()
        {
            var bismarck = new Schlachtschiff() { AnzLeben = 100, Feuerkraft = 10 };
            var hood = new Schlachtschiff() { AnzLeben = 70, Feuerkraft = 10 };

            schiessen(bismarck, hood);

            bismarck.schiessenAuf(hood);

            // Kompiler übersetzt den vorausgegangenen Ausdruck in folgenden
            SchlachtschiffExtensions.schiessenAuf(bismarck, hood);


            return true;
        }
    }
}
