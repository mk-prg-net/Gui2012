using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDms2
{
    public class FileTabSessionVar : mkoIt.Asp.SessionStateFilterAndSortEntities<DMS.FCollect.Db.File>
    {
        // Hier werden die Verschiedenen Sichten auf einen Gesteinskörnungsdatensatz 
        // beim Blättern synchronisiert
        public int PageIndex = 0;
        public int IdKunde = -1;

    }
}