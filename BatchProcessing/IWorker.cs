//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 12.5.2008
//
//  Projekt.......: Stapelverarbeitung
//  Name..........: IWorker.cs
//  Aufgabe/Fkt...: Schnittstelle f�r Objekte, die Jobs in einen Stapelverarbeitungsprozess
//                  durchf�hren
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
//  �nderungen....: 
//
//</unit_history>
//</unit_header>        
        
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS
{
    public interface IWorker
    {
        // Ausf�hrung eines Jobs vorbereiten
        bool setup(DMS.Job currentJob);
    
        // Einen Job ausf�hren
        void doIt(DMS.Job currentJob);

        // Aktuellen Bearbeitungszustand bestimmen und als Ableitung von 
        // JobProgressInfo zur�ckgeben
        JobProgressInfo GetProgressInfo(DMS.Job job);      

    }

    // Delegate zum asynchronen Start der bearbeitung eines Jobs
    public delegate void DGworkerdoIt(DMS.Job currentJob);
}
