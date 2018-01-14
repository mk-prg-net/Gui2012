using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace DMS.FCollect
{
    public abstract class ExtractorBase
    {
        /// <summary>
        /// Referenz auf Liste in FeatureCollector aller bereits zugeordneten Guids (FileId's) zu Dateinamen
        /// </summary>
        public Dictionary<string, Guid> MapPathToGuid;        

        protected void GetFileId(string Path, Feature feature)
        {
            // Dateiid 
            if (MapPathToGuid.ContainsKey(Path))
                feature.FileId = MapPathToGuid[Path];
            else
            {
                feature.FileId = Guid.NewGuid();
                MapPathToGuid[Path] = feature.FileId;
            }

            // Id des Elternverzeichnisses
            string dir = System.IO.Path.GetDirectoryName(Path);
            if (!string.IsNullOrEmpty(dir))
            {
                if (MapPathToGuid.ContainsKey(dir))
                    feature.ParentDirId = MapPathToGuid[dir];
                else
                {
                    feature.ParentDirId = Guid.NewGuid();
                    MapPathToGuid[dir] = feature.ParentDirId;
                }
            }

            // Id des übergeordneten Verzeichnisses
            string parentdir = System.IO.Path.GetDirectoryName(dir);
            if (!string.IsNullOrEmpty(parentdir))
            {
                if (MapPathToGuid.ContainsKey(parentdir))
                    feature.SuperDirId = MapPathToGuid[parentdir];
                else
                {
                    feature.SuperDirId = Guid.NewGuid();
                    MapPathToGuid[parentdir] = feature.SuperDirId;
                }
            }
        }


        /// <summary>
        /// Extrahiert ein Merkmal aus einer Datei mit dem übergebenen Dateiname
        /// </summary>
        /// <param name="Path">Dateiname</param>
        /// <param name="feature">Das extrahierte Feature</param>
        /// <returns></returns>
        public abstract bool extract(string Path, out Feature feature);

        /// <summary>
        /// Extrahiert ein Merkmal aus einer Datei mit dem übergebenen Dateiname und
        /// FileId. Diese Methode eignet sich, um bereits in Datenbanken erfasste Dateien
        /// bezüglich ihrer aktuellen Features zu aktualisieren.
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="FileId"></param>
        /// <param name="feature"></param>
        /// <returns></returns>
        public abstract bool extract(string Path, Guid FileId, out Feature feature);

        /// <summary>
        /// Extrahiert ein Merkmal aus einem Dateistrom
        /// </summary>
        /// <param name="stream">Dateistrom</param>
        /// <param name="feature">Das Extrahiere Feature</param>
        /// <returns></returns>
        public abstract bool extract(Stream stream, out Feature feature);        
    }
}
