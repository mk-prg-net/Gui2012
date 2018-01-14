using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DMS.Core
{
    public class ClassesOfFilesTab : DMS.FC.FileClassificatorServer
    {
        TraceSwitch ts = new TraceSwitch("ClassesOfFilesTabTraceSwitch", "Grad der Protokollierung einstellen");


        private ClassesOfFilesTab(DMS.FC.IFileClassificator fc, DMS.FC.IContenVectorWriter writer)
            : base(fc, writer)
        {   
        }

        public static ClassesOfFilesTab CreateStandardClassesInList()
        {
            return new ClassesOfFilesTab(new DMS.FC.StandardFileClassificator(), new DMS.FC.ContentVectorListWriter());
        }

        public static ClassesOfFilesTab CreateStandardClassesInTab()
        {
            return new ClassesOfFilesTab(new DMS.FC.StandardFileClassificator(), new DMS.FC.ContentVectorDataTableWriter());
        }

    }
}
