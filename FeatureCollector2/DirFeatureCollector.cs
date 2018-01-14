using System;
using System.Collections.Generic;
using lq = System.Linq;
using System.Text;

namespace DMS.FCollect
{
    public class DirFeatureCollector : DMS.DirTree
    {
        public FeatureCollector FC = new FeatureCollector();

        protected override bool BeginScanDir(string path)
        {
            // Nur starten, wenn tatsächlich Extractoren vorhanden sind
            if (FC.extractors.Count == 0)
                return false;

            FC.ClearFeatureCollection();
            return true;
        }

        protected override bool TouchFile(string path)
        {
            return FC.Collect(path);
        }

    }
}
