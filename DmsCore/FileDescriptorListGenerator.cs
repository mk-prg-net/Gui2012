using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Core
{
    public class FileDescriptorListGenerator : DMS.DirTree
    {
        public FileDescriptorListGenerator(DMS.FC.IFileClassificator fc)
        {
            classificator = fc;
        }

        private DMS.FC.IFileClassificator classificator;

        // Liste von Dateideskriptoren, die alle Dateien unterhalb eines Unterverzeichnisses beschreiben
        public List<DMS.FC.FileDescriptor> FileDescriptorList = new List<FC.FileDescriptor>();

        protected override bool BeginScanDir(string path)
        {
            // Löschen aller aten Einträge in der FileDescriptorList
            FileDescriptorList.Clear();

            return true;
        }

        protected override bool TouchFile(string path)
        {
            DMS.FC.FileDescriptor desc;
            if (classificator.classify(path, out desc))
            {
                FileDescriptorList.Add(desc);
                return true;
            }
            return false;

        }
    }
}
