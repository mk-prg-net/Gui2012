using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace DMS.FCollect
{
    public class FeatureLastWriteTime : Feature
    {
        public new class Exc : Feature.Exc
        {
            public Exc(string msg) : base(msg) { }
            public Exc(string msg, Exception innerException) : base(msg, innerException) { }
        }


        public override string Description
        {
            get { return "Zeitpunkt der letzten Änderung"; }
        }

        public override string Name
        {
            get { return "LastWriteTime"; }
        }

        public override string ToString()
        {
            return time.ToString();
        }

        public DateTime time { get; set; }

        public override bool extract(string path)
        {
            try
            {
                var info = new FileInfo(path);
                if (!info.Exists)
                    throw new FileNotFoundException("", path);

                time = info.LastWriteTime;
            }
            catch (Exception ex)
            {
                throw new Exc("Beim extrahieren des Zeitpunktes der letzten Änderung", ex);
            }

            return true;

        }

        public override bool extract(System.IO.Stream stream)
        {
            try
            {
                if (stream is FileStream)
                {
                    var fs = stream as FileStream;
                    var info = new FileInfo(fs.Name);

                    time = info.LastWriteTime;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exc("Beim extrahieren des Zeitpunktes der letzten Änderung", ex);
            }

        }
    }
}
