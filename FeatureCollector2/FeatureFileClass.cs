using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.FCollect
{
    public class FeatureFileClass : Feature
    {
        public new class Exc : Feature.Exc
        {
            public Exc(string msg) : base(msg) { }
            public Exc(string msg, Exception innerException) : base(msg, innerException) { }
        }


        public override string Description
        {
            get { return "Klassifizierung des Inhaltes"; }
        }

        public override string Name
        {
            get { return "FileClass"; }
        }

        public override string ToString()
        {
            return FileClass.ToString();
        }

        public DMS.FC.ContentVector.FileClasses FileClass { get; set; }

        DMS.FC.StandardFileClassificator sfc = new FC.StandardFileClassificator();

        public override bool extract(string path)
        {
            try
            {
                DMS.FC.IFileClassificator ifc = sfc;
                DMS.FC.FileDescriptor fd;
                ifc.classify(path, out fd);
                FileClass = fd.FClass;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exc("Beim extrahieren der Klasse des Dateiinhaltes", ex);
            }
        }

        public override bool extract(System.IO.Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
