using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.FCollect
{
    public abstract class Feature
    {
        /// <summary>
        /// Basisklasse von Fehlerobjekte, die Eigenschaften und Methoden der Feature- Klasse
        /// werden können
        /// </summary>
        public class Exc : ApplicationException {
            public Exc(string msg) : base(msg) { }
            public Exc(string msg, Exception innerException) : base(msg, innerException) { }
        }

        /// <summary>
        /// Guid der Datei mit diesem Merkmal
        /// </summary>
        public Guid FileId { get; set; }

        /// <summary>
        /// Guid des Verzeichnisses, in dem sich die Datei befindet
        /// </summary>
        public Guid ParentDirId { get; set; }

        /// <summary>
        /// Guid des Elternverzechnisses vom aktuellen Verzeichnis
        /// </summary>
        public Guid SuperDirId { get; set; }

        /// <summary>
        /// Textuelle Beschreibung des Merkmals
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Regulärer Name (Alphanummerisch, darf keine Leerzeichen enthalten) des Merkmals
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Textuelle Präsentation des Features
        /// </summary>
        /// <returns></returns>
        public new abstract string ToString();

        /// <summary>
        /// Extrahiert das Feature aus einer Datei mit dem übergebenen Dateipfad
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public abstract bool extract(string path);

        /// <summary>
        /// Extrahiert das Feature aus einem geöffneten Datenstrom
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public abstract bool extract(System.IO.Stream stream);
        
    }
}
