using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DMS.FC
{
    public class ContentVectorDataTableWriter : DMS.FC.IContenVectorWriter
    {

        TraceSwitch ts = new TraceSwitch("ContentVectorDataTableWriterTraceSwitch", "Grad der Protokollierung beeinflussen");

        DsFilesClassification.ContentVecDataTable _tab;

        public DsFilesClassification.ContentVecDataTable Table
        {
            get
            {
                return _tab;
            }
        }

        public ContentVectorDataTableWriter()
        {
            _tab = new DsFilesClassification.ContentVecDataTable();
        }

        public void SetContentVecTab(DsFilesClassification.ContentVecDataTable tab)
        {
            _tab = tab;
        }

        public ContentVectorDataTableWriter(DsFilesClassification.ContentVecDataTable tab)
        {
            _tab = tab;
        }

        #region IContenVectorWriter Member

        public bool Open()
        {
            Trace.WriteLineIf(ts.TraceInfo, "Open: Klassifizieren von Dateien und laden neuer Contentvektoren beginnt. Alle alten Eonträge werden gelöscht.");
            _tab.Clear();

            return true;
        }

        public bool Write(int Tiefe, string path, DMS.FC.ContentVector vec)
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
            Trace.WriteLineIf(ts.TraceInfo, "Close: Neue Contentvektoren wurden geladen");
            return true;
        }

        #endregion
    }
}
