using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Core
{
    public class CountFilesOfType : DMS.DirTree
    {

        // Vereinfachte Form
        public string FileType { get; set; }


        // Anzahl der Gefundenen Dateien mit der Extension FileType
        public long Count { get; set; }


        // Ausnahmen
        public class EmptyFileTypeException : ApplicationException {
            // Es wurde kein Filetype definiert
        }


        protected override bool BeginScanDir(string path)
        {
            if (string.IsNullOrEmpty(FileType))
                //throw new Exception("Es wurde kein Filetype spezifiziert");
                throw new EmptyFileTypeException();

            Count = 0;

            return true;
        }

        protected override bool TouchFile(string path)
        {
            if (System.IO.Path.GetExtension(path).ToLower() == FileType.ToLower())
                Count++;

            return true;
        }
    }
}
