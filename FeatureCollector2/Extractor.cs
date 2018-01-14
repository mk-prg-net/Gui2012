//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 2.8.2011
//
//  Projekt.......: FeatureCollector2
//  Name..........: Extractor.cs
//  Aufgabe/Fkt...: Klassenfabrik für Dateimerkmale (Features). 
//                  Ein Extraktor erzeugt für eine Datei ein Objekt,
//                  das von der Basisklasse Feature abgeleitet ist.
//                  Dieses stellt ein Merkmal einer Datei dar (z.B. Dateigröße)
//
//
//
//<unit_environment>
//------------------------------------------------------------------
//  Zielmaschine..: PC 
//  Betriebssystem: Windows XP mit .NET 2.0
//  Werkzeuge.....: Visual Studio 2005
//  Autor.........: Martin Korneffel (mko)
//  Version 1.0...: 
//
// </unit_environment>
//
//<unit_history>
//------------------------------------------------------------------
//
//  Version.......: 1.1
//  Autor.........: Martin Korneffel (mko)
//  Datum.........: 
//  Änderungen....: 
//
//</unit_history>
//</unit_header>        
        
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.FCollect
{
    public class Extractor<T> : ExtractorBase
        where T : Feature, new()        
    {

        public override bool extract(string Path, out Feature feature)
        {            
            feature = new T();
            GetFileId(Path, feature);

            return feature.extract(Path);
        }

        public override bool extract(string Path, Guid FileId, out Feature feature)
        {
            feature = new T();
            feature.FileId = FileId;
            if (!MapPathToGuid.ContainsKey(Path))
                MapPathToGuid[Path] = FileId;            

            return feature.extract(Path);
        }

        public override bool extract(System.IO.Stream stream, out Feature feature)
        {
            feature = new T();
            return feature.extract(stream);
        }
    }
}
