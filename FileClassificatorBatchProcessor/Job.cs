using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DMS.FC.BP
{
    [Serializable]
    [XmlRoot(Namespace="DMS.FileClassificator", ElementName="Job")]
    public class Job : DMS.Job
    {
        // Verzeichnis, in dem nach Dateien gesucht werden soll
        [XmlElement("Root")]
        public string dir = "";        

        // Liste der gefundenen Dateien
        public DsFilesClassification.ContentVecDataTable results = new DsFilesClassification.ContentVecDataTable();

        [XmlAttribute]
        public long CountDirs = 0;

        [XmlAttribute]
        public long CountFiles = 0;
    }
}
