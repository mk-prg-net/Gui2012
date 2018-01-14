using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Diagnostics;

namespace DMS.FCollect
{
    [DebuggerDisplay("FNAme={FileName}")]
    public class FeatureFileName : Feature
    {
        public new class Exc : Feature.Exc
        {
            public Exc(string msg) : base(msg) { }
            public Exc(string msg, Exception innerException) : base(msg, innerException) { }
        }

        public override string Description
        {
            get { return "Vollqualifizierter Name der Datei"; }
        }

        public override string Name
        {
            get { return "FileName"; }
        }

        public string FileName { get; set; }

        public override string ToString()
        {
            return FileName;
        }

        public override bool extract(string path)
        {
            FileName = path;
            return true;
        }

        public override bool extract(System.IO.Stream stream)
        {
            try
            {
                if (stream is FileStream)
                {
                    var fs = stream as FileStream;
                    FileName = fs.Name;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exc("Beim extrahieren des Dateinamens", ex);
            }
        }
    }
}
