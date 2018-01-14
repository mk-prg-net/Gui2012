using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.FCollect
{
    class FeatureIsDir : Feature
    {
        public override string Description
        {
            get { return "Dateisystemobjekt ist ein Unterverzeichnis"; }
        }

        public override string Name
        {
            get { return "IsDir"; }
        }

        // Name des Dateiverzeichnisses
        public string DirName { get; set; }

        public override string ToString()
        {
            return DirName;
        }

        public override bool extract(string path)
        {
            if (System.IO.Directory.Exists(path))
            {
                DirName = path;
                return true;
            }
            return false;
        }

        public override bool extract(System.IO.Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
