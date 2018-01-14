using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace DMS.FCollect
{
    public class FeatureSizeInBytes : Feature
    {
        public new class Exc : Feature.Exc
        {
            public Exc(string msg) : base(msg) { }
            public Exc(string msg, Exception innerException) : base(msg, innerException) { }
        }

        public override string ToString()
        {
            return SizeInBytes.ToString();
        }

        public long SizeInBytes { get; set; }

        public override string Name
        {
            get { return "SizeInBytes"; }
        }

        public override string Description
        {
            get { return "Size in Bytes"; }
        }

        public override bool extract(string path)
        {
            try
            {
                var info = new FileInfo(path);
                if (!info.Exists)
                    throw new FileNotFoundException("", path);

                SizeInBytes = info.Length;
            }
            catch (Exception ex)
            {
                throw new Exc("Beim extrahieren der Dateigröße", ex);
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
                    SizeInBytes = fs.Length;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exc("Beim extrahieren der Dateigröße", ex);
            }

        }
    }
}
