using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Diagnostics;

namespace DMS.FCollect
{
    [DebuggerDisplay("Created={time}")]
    public class FeatureCreationTime : Feature
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
            get { return "TimeOfModification"; }
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

                time = info.CreationTime;
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

                    time = info.CreationTime;
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
