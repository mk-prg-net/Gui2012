using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.FC
{
    /// <summary>
    /// Beschrreibt die wichtigsten Eigenschaften einer Datei
    /// </summary>
    public class FileDescriptor
    {       
        public string Path;
        public string Extension;
        public ContentVector.FileClasses FClass = ContentVector.FileClasses.Other;
        public long SizeInBytes = 0;
        public bool ArchiveBit = false;

    }
}
