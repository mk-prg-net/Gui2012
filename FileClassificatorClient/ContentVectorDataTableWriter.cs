using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace FileClassificatorClient
{
    class ContentVectorDataTableWriter : DMS.IContenVectorWriter
    {
        DsFilesClassification.ContentVecDataTable _tab;

        public ContentVectorDataTableWriter(DsFilesClassification.ContentVecDataTable tab)
        {
            _tab = tab;
        }

        #region IContenVectorWriter Member

        public bool Open()
        {
            Debug.WriteLine("Open: Klassifizieren von Dateien und laden neuer Contentvektoren beginnt. Alle alten Eonträge werden gelöscht.");
            _tab.Clear();

            return true;
        }

        public bool Write(int Tiefe, string path, DMS.ContentVector vec)
        {
            DsFilesClassification.ContentVecRow row = _tab.NewContentVecRow();
            row.depth = Tiefe;
            row.path = path;
            row.ArchiveBitSetCount = vec.ArchiveBitSetCount;
            row.SumArchiveBitFileSize = vec.ArchiveBitSetSizeInBytes;
            row.FileCount = vec.FileCount;
            row.SumFilesSize = vec.SizeInBytes;
            row.FotosCount = vec.FotosCount;
            row.SumFotosSize = vec.FotosSizeInBytes;
            row.OfficeCount = vec.OfficeCount;
            row.SumOfficeFilesSize = vec.OfficeSizeInBytes;
            row.OtherCount = vec.OtherCount;
            row.SumOtherFilesSize = vec.OtherSizeInBytes;
            row.SourceCodeCount = vec.SourceCodeCount;
            row.SumSourceCodeFilesSize = vec.SourceCodeSizeInBytes;
            row.VideosCount = vec.VideosCount;
            row.SumVideosFilesSize = vec.VideosSizeInBytes;
            row.WebCount = vec.WebCount;
            row.SumWebFilesSize = vec.WebSizeInBytes;

            _tab.AddContentVecRow(row);

            return true;
        }

        public bool Close()
        {
            Debug.WriteLine("Close: Neue Contentvektoren wurden geladen");
            return true;
        }

        #endregion
    }
}
