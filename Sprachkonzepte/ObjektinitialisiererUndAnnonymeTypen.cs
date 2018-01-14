using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprachkonzepte
{
    class ObjektinitialisiererUndAnnonymeTypen
    {

        /// <summary>
        /// 
        /// </summary>
        class Filedesccriptor
        {
            public string filename;
            public string filetype;
            public long sizeInBytes;
        }

        public void exe()
        {
            // Neu: Objektinitialisierer anstelle Konstruktors
            Filedesccriptor fd2 = new Filedesccriptor
            {
                filename = "boot.ini",
                filetype = ".ini",
                sizeInBytes = 999
            };

            // Typinferenz
            int i = 99;

            // var wurde aus JavaScript entlehnt
            var j = 199;

            // Typinferenz bedeutet keine Aufweichung der strengen Typisierung
            //j = "299"; // Fehler. In JavaScript wäre es kein Fehler, da JavaScript nicht typisiert ist

            // Anonyme Typen
            var fdAnonym = new { filename = "boot.ini", filetype = ".ini", sizeInBytes = 999 };            

            // Auch für anonyme Typen gelten strenge Typisierung
            //fdAnonym.sizeInBytes = "Hallo Welt"; // Fehler            
        }
    }
}
