using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.FC
{
    public interface IContenVectorWriter
    {
        // 1. Medium öffnen
        bool Open();

        // 2. Datensatz schreiben
        bool Write(int Tiefe, string path, ContentVector vec);

        // 3. Medium schließen
        bool Close();
    }
}
