using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace DMS.FC
{
    [DebuggerDisplay("FileCount= {FileCount}, FileSize= {SizeInBytes}")]
    public class ContentVector : ICloneable
    {
        /// <summary>
        /// Klassifizierung der Dateien
        /// </summary>
        /// 

        public enum FileClasses
        {
            Fotos = 1,
            Office = 2,
            Other = 3,
            SourceCode = 4,
            Videos = 5,
            Web = 6
        }

        // Indexer für den Zugriff auf die Zähler
        public long this[FileClasses fc]
        {
            get
            {
                switch (fc)
                {
                    case FileClasses.Fotos:
                        return FotosCount;
                    case FileClasses.Office:
                        return OfficeCount;
                    case FileClasses.Other:
                        return OtherCount;
                    case FileClasses.SourceCode:
                        return SourceCodeCount;
                    case FileClasses.Videos:
                        return VideosCount;
                    case FileClasses.Web:
                        return WebCount;
                    default:
                        return OtherCount;
                }
            }
        }

        public long SizeInBytesOf(FileClasses fc)
        {
            switch (fc)
            {
                case FileClasses.Fotos:
                    return FotosSizeInBytes;
                case FileClasses.Office:
                    return OfficeSizeInBytes;
                case FileClasses.Other:
                    return OtherSizeInBytes;
                case FileClasses.SourceCode:
                    return SourceCodeSizeInBytes;
                case FileClasses.Videos:
                    return VideosSizeInBytes;
                case FileClasses.Web:
                    return WebSizeInBytes;
                default:
                    return OtherCount;
            }
        }

        // Zähler für die File- Klassen

        long _OfficeCount;

        public long OfficeCount
        {
            get { return _OfficeCount; }
            set { _OfficeCount = value; }
        }

        long _OfficeSizeInBytes;

        public long OfficeSizeInBytes
        {
            get { return _OfficeSizeInBytes; }
            set { _OfficeSizeInBytes = value; }
        }

        long _SourceCodeCount;

        public long SourceCodeCount
        {
            get { return _SourceCodeCount; }
            set { _SourceCodeCount = value; }
        }

        long _SourceCodeSizeInBytes;

        public long SourceCodeSizeInBytes
        {
            get { return _SourceCodeSizeInBytes; }
            set { _SourceCodeSizeInBytes = value; }
        }

        long _WebCount;

        public long WebCount
        {
            get { return _WebCount; }
            set { _WebCount = value; }
        }

        long _WebSizeInBytes;

        public long WebSizeInBytes
        {
            get { return _WebSizeInBytes; }
            set { _WebSizeInBytes = value; }
        }

        long _FotosCount;

        public long FotosCount
        {
            get { return _FotosCount; }
            set { _FotosCount = value; }
        }

        long _FotosSizeInBytes;

        public long FotosSizeInBytes
        {
            get { return _FotosSizeInBytes; }
            set { _FotosSizeInBytes = value; }
        }

        long _VideosCount;

        public long VideosCount
        {
            get { return _VideosCount; }
            set { _VideosCount = value; }
        }

        long _VideosSizeInBytes;

        public long VideosSizeInBytes
        {
            get { return _VideosSizeInBytes; }
            set { _VideosSizeInBytes = value; }
        }

        long _OtherCount;

        public long OtherCount
        {
            get { return _OtherCount; }
            set { _OtherCount = value; }
        }

        long _OtherSizeInBytes;

        public long OtherSizeInBytes
        {
            get { return _OtherSizeInBytes; }
            set { _OtherSizeInBytes = value; }
        }

        /// <summary>
        /// Zusatzinformationen über die Dateien
        /// </summary>

        long _ArchiveBitSetCount;

        public long ArchiveBitSetCount
        {
            get { return _ArchiveBitSetCount; }
            set { _ArchiveBitSetCount = value; }
        }


        long _ArchiveBitSetSizeInBytes;

        public long ArchiveBitSetSizeInBytes
        {
            get { return _ArchiveBitSetSizeInBytes; }
            set { _ArchiveBitSetSizeInBytes = value; }
        }


        // Summe aller Dateien in unter einem Dateiverzeichnis
        public long FileCount
        {
            get
            {
                return _FotosCount + _OfficeCount + _OtherCount + _SourceCodeCount + _VideosCount + _WebCount;
            }
        }

        public long SizeInBytes
        {
            get
            {
                return _FotosSizeInBytes + _OfficeSizeInBytes + _OtherSizeInBytes + _SourceCodeSizeInBytes + _VideosSizeInBytes + _WebSizeInBytes;
            }
        }

        // Vektoroperationen
        public static ContentVector operator +(ContentVector a, ContentVector b)
        {
            ContentVector sum = new ContentVector();

            sum.ArchiveBitSetCount = a.ArchiveBitSetCount + b.ArchiveBitSetCount;
            sum.ArchiveBitSetSizeInBytes = a.ArchiveBitSetSizeInBytes + b.ArchiveBitSetSizeInBytes;
            sum.FotosCount = a.FotosCount + b.FotosCount;
            sum.FotosSizeInBytes = a.FotosSizeInBytes + b.FotosSizeInBytes;
            sum.OfficeCount = a.OfficeCount + b.OfficeCount;
            sum.OfficeSizeInBytes = a.OfficeSizeInBytes + b.OfficeSizeInBytes;
            sum.OtherCount = a.OtherCount + b.OtherCount;
            sum.OtherSizeInBytes = a.OtherSizeInBytes + b.OtherSizeInBytes;
            sum.SourceCodeCount = a.SourceCodeCount + b.SourceCodeCount;
            sum.SourceCodeSizeInBytes = a.SourceCodeSizeInBytes + b.SourceCodeSizeInBytes;
            sum.VideosCount = a.VideosCount + b.VideosCount;
            sum.VideosSizeInBytes = a.VideosSizeInBytes + b.VideosSizeInBytes;
            sum.WebCount = a.WebCount + b.WebCount;
            sum.WebSizeInBytes = a.WebSizeInBytes + b.WebSizeInBytes;
            return sum;
        }

        public static ContentVector operator -(ContentVector a, ContentVector b)
        {
            ContentVector sum = new ContentVector();

            sum.ArchiveBitSetCount = a.ArchiveBitSetCount - b.ArchiveBitSetCount;
            sum.ArchiveBitSetSizeInBytes = a.ArchiveBitSetSizeInBytes - b.ArchiveBitSetSizeInBytes;
            sum.FotosCount = a.FotosCount - b.FotosCount;
            sum.FotosSizeInBytes = a.FotosSizeInBytes - b.FotosSizeInBytes;
            sum.OfficeCount = a.OfficeCount - b.OfficeCount;
            sum.OfficeSizeInBytes = a.OfficeSizeInBytes - b.OfficeSizeInBytes;
            sum.OtherCount = a.OtherCount - b.OtherCount;
            sum.OtherSizeInBytes = a.OtherSizeInBytes - b.OtherSizeInBytes;
            sum.SourceCodeCount = a.SourceCodeCount - b.SourceCodeCount;
            sum.SourceCodeSizeInBytes = a.SourceCodeSizeInBytes - b.SourceCodeSizeInBytes;
            sum.VideosCount = a.VideosCount - b.VideosCount;
            sum.VideosSizeInBytes = a.VideosSizeInBytes - b.VideosSizeInBytes;
            sum.WebCount = a.WebCount - b.WebCount;
            sum.WebSizeInBytes = a.WebSizeInBytes - b.WebSizeInBytes;
            return sum;
        }       

        #region ICloneable Member

        public object Clone()
        {
            ContentVector vec = new ContentVector();
            vec.ArchiveBitSetCount = ArchiveBitSetCount;
            vec.ArchiveBitSetSizeInBytes = ArchiveBitSetSizeInBytes;
            vec.FotosCount = FotosCount;
            vec.FotosSizeInBytes = FotosSizeInBytes;
            vec.OfficeCount = OfficeCount;
            vec.OfficeSizeInBytes = OfficeSizeInBytes;
            vec.OtherCount = OtherCount;
            vec.OtherSizeInBytes = OtherSizeInBytes;
            vec.SourceCodeCount = SourceCodeCount;
            vec.SourceCodeSizeInBytes = SourceCodeSizeInBytes;
            vec.VideosCount = VideosCount;
            vec.VideosSizeInBytes = VideosSizeInBytes;
            vec.WebCount = WebCount;
            vec.WebSizeInBytes = WebSizeInBytes;

            return vec;
        }

        #endregion
    }
}
