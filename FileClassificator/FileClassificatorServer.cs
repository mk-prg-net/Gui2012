using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DMS.FC
{
    public class FileClassificatorServer: DMS.DirTree
    {
        // Ablaufverfolgung konfigurieren        
        TraceSwitch FileClassificatorServerSwitch = new TraceSwitch("FileClassificatorServerSwitch", "Grad der Trace- Informationen von FileClassificatorServer beeinflussen");       

        // Objekt, über das die Ausgabe der Ergebnisse erfolgt
        IContenVectorWriter _writer;
        IFileClassificator _classificator;

        // Konstruktor
        [DebuggerStepThrough]
        public FileClassificatorServer(IFileClassificator classificator, IContenVectorWriter writer)           
        {
            _classificator = classificator;
            _writer = writer;
        }

        // Felder zur Abbildung des internen Objektzustandes
        ContentVector _contentVec;
        
        Stack<ContentVector> _stack = new Stack<ContentVector>();

        // Überschreiben der virtuellen Methoden der Basisklasse
        protected override bool BeginScanDir(string path)
        {
            // Prüfung der Eingabe im Debugzweig
            Debug.Assert(System.IO.Directory.Exists(path), path + "existiert nicht");

            _contentVec = new ContentVector();

            if(!_writer.Open()) return false;

            Trace.WriteLineIf(FileClassificatorServerSwitch.TraceInfo ,"Scan startete um " + DateTime.Now.ToLongTimeString());

            return true;
        }

        protected override bool EnterDir(string path)
        {
            // Speichern des aktuellen Wertes von SumSizeInBytes
            _stack.Push((ContentVector)_contentVec.Clone());            

            // Dokumentieren für das Debugging
            Trace.WriteLineIf(FileClassificatorServerSwitch.TraceInfo ,"Betrete Pfad " + path + " SumSizeInBytes= " + _contentVec.SizeInBytes);
            return true;
        }

        protected override bool TouchFile(string path)
        {
            // Prüfen der Eingaben im Debug- Zweig
            Debug.Assert(System.IO.File.Exists(path), "Datei " + path + "existiert nicht");
            ContentVector newContentVec;
            if (_classificator.classify(path, out newContentVec))
            {
                _contentVec += newContentVec;
                return true;
            }
            else
                return false;
        }

        protected override bool ExitDir(string path)
        {
            // Prüfen im Debugzweig
            Debug.Assert(_stack.Count > 0, "Stack ist vorzeitig geleert worden");

            int Tiefe = _stack.Count;
            ContentVector Vec = _contentVec - _stack.Pop();

            // Dokumentiern im Debugzweig
            Trace.WriteLineIf(FileClassificatorServerSwitch.TraceInfo ,"Tiefe= " + Tiefe + " " + path + " SizeInBytes= " + Vec.SizeInBytes);

            if(!_writer.Write(Tiefe, path, Vec)) return false;

            return true;
        }

        protected override bool EndScanDir(string path)
        {
            Trace.WriteLineIf(FileClassificatorServerSwitch.TraceInfo ,"Scann endet um " + DateTime.Now.ToLongTimeString());
            if(!_writer.Close()) return false;
            return true;
        }

    }
}

