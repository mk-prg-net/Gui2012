//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 02.2007
//
//  Projekt.......: FeatureCollector2
//  Name..........: FeatureCollector
//  Aufgabe/Fkt...: Server, der für eine Menge von Dateien Merkmale 
//                  extrahiert. Die zu extrahierenden Merkmale sind wählbar.
//
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
using System.Data;

using System.Diagnostics;

using System.IO;

namespace DMS.FCollect
{
    public class FeatureCollector
    {
        /// <summary>
        /// Basisklasse von Fehlerobjekte, die Eigenschaften und Methoden der Feature- Klasse
        /// werden können
        /// </summary>
        public class Exc : ApplicationException
        {
            public Exc(string msg) : base(msg) { }
            public Exc(string msg, Exception innerException) : base(msg, innerException) { }
        }

        /// <summary>
        /// Liste aller bereits zugeordneten Guids (FileId's) zu Dateinamen
        /// </summary>
        public Dictionary<string, Guid> MapPathToGuid = new Dictionary<string,Guid>();

        /// <summary>
        /// Konfigurierbare Liste von Extraktoren        
        /// </summary>
        public Dictionary<Type, ExtractorBase> extractors = new Dictionary<Type, ExtractorBase>();

        public bool HasExtractor(Type ExtractorType)
        {
            return extractors.ContainsKey(ExtractorType);
        }

        public void AddExtractor(ExtractorBase newExtractor)
        {
            // Alle Extraktoren zeichnen die Dateipfade in einer zentralen
            // Dictionary auf, die jedem Pfad eine GUID zuordnet
            newExtractor.MapPathToGuid = MapPathToGuid;

            Type extType = newExtractor.GetType();

            // Falls älteres Filter vorhanden, dann dieses löschen
            if (extractors.ContainsKey(extType))
                extractors.Remove(extType);
            //throw new Exception("Das Filter mit vom Typ " + fltType.FullName + " wurde bereits angelegt, und kann nun nicht nochmals angelegt werden");

            extractors.Add(extType, newExtractor);
            Debug.WriteLine("Der Extractor mit dem Typ " + extType.FullName + " wurde hinzugefügt");
        }

        public void RemoveExtractor(Type extractorType)
        {
            if (extractors.ContainsKey(extractorType))
            {
                extractors.Remove(extractorType);
                Debug.WriteLine("Der Extractor mit dem Typ " + extractorType.FullName + " wurde entfernt");
            }
        }

        public ExtractorBase GetExtractor(Type ExtractorType)
        {
            Debug.Assert(extractors.ContainsKey(ExtractorType));
            return extractors[ExtractorType];
        }

        /// <summary>
        /// Liste aller extrahierter Merkmale aus allen, der Collect- Methode 
        /// übergebenen Dateien.
        /// </summary>
        public LinkedList<Feature> FeatureCollection = new LinkedList<Feature>();

        public void ClearFeatureCollection()
        {
            FeatureCollection.Clear();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Collect(string path)
        {
            try
            {
                bool success = true;
                foreach (var pair in extractors)
                {
                    Feature feature;

                    // Nur erfolgreich extrahierte Features werden in der Collection aufgenommen
                    if(pair.Value.extract(path, out feature))
                        FeatureCollection.AddLast(feature);

                }

                return success;
            }
            catch (Exception ex)
            {
                throw new Exc("Beim Sammeln von Merkmalen von " + path, ex);
            }
        }

        public bool Collect(Stream stream)
        {
            try
            {
                bool success = true;
                foreach (var pair in extractors)
                {
                    Feature feature;

                    // Nur erfolgreich extrahierte Features werden in der Collection aufgenommen
                    if(pair.Value.extract(stream, out feature))
                        FeatureCollection.AddLast(feature);
                }

                return success;
            }
            catch (Exception ex)
            {
                throw new Exc("Beim Sammeln von Merkmalen", ex);
            }

        }

    }

}