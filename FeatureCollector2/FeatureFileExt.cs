using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace DMS.FCollect
{
    public class FeatureFileExt : Feature
    {
        public new class Exc : Feature.Exc
        {
            public Exc(string msg) : base(msg) { }
            public Exc(string msg, Exception innerException) : base(msg, innerException) { }
        }

        public override string Name
        {
            get { return "Ext"; }
        }

        public override string Description
        {
            get { return "Dateierweiterung"; }
        }

        public override string ToString()
        {
            return Ext;
        }

        public string Ext { get; set; }

        public override bool extract(string path)
        {
            Ext = Path.GetExtension(path);
            return true;
        }

        public override bool extract(System.IO.Stream stream)
        {
            try
            {
                if (stream is FileStream)
                {
                    var fs = stream as FileStream;
                    Ext = Path.GetExtension(fs.Name);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exc("Beim extrahieren der Dateierweiterung", ex);
            }

        }
    }
}
