using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Core
{
    public class CountFilesInClass : DMS.DirTree
    {
        /// <summary>
        /// Klasse der Dateien, deren Mächtigkeit bestimmt werden soll
        /// </summary>
        public DMS.FC.ContentVector.FileClasses FileClass { get; set; }

        /// <summary>
        /// Mächtigkeit der Dateiklasse
        /// </summary>
        public long Count { get; set; }

        DMS.FC.IFileClassificator fc;

        private CountFilesInClass(DMS.FC.IFileClassificator fileClassificator)
        {
            fc = fileClassificator;
        }

        /// <summary>
        /// ClassFactory: Erstellt eine Instanz auf Basis der Standard- Klassifikations- Algorithmusses
        /// </summary>
        /// <returns></returns>
        public static CountFilesInClass CreateWithStandardFileClassificator() {
            return new CountFilesInClass(new DMS.FC.StandardFileClassificator());
        }

        protected override bool BeginScanDir(string path)
        {
            Count = 0;
            return true;
        }

        protected override bool TouchFile(string path)
        {
            DMS.FC.IFileClassificator ifc = fc;
            DMS.FC.ContentVector vec;
            ifc.classify(path, out vec);
            Count += vec[FileClass];
            return true;
        }
    }
}
