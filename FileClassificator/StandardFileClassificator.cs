using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace DMS.FC
{
    public class StandardFileClassificator : IFileClassificator
    {

        #region IFileClassificator Member

        bool IFileClassificator.classify(string Filename, out ContentVector vec)
        {
            vec = new ContentVector();            
            // 1. Merkmale der Datei bestimmen 
            long sizeInBytes = 0;
            try
            {
                FileStream fs = File.Open(Filename, FileMode.Open, FileAccess.Read);
                sizeInBytes = fs.Length;
                fs.Close();
            }
            catch (Exception)
            {
            }            

            FileAttributes fatt = File.GetAttributes(Filename);

            string ext = Path.GetExtension(Filename);

            // 2. Merkmale bewerten

            if ((fatt & FileAttributes.Archive) != 0)
            {
                vec.ArchiveBitSetCount = 1;
                vec.ArchiveBitSetSizeInBytes = sizeInBytes;
            }

            switch (ext.ToLower())
            {
                case ".htm":
                case ".html":
                case ".js":
                case ".gif":
                case ".png":
                    vec.WebCount = 1;
                    vec.WebSizeInBytes = sizeInBytes;
                    break;
                case ".xml":
                case ".cpp":
                case ".vb":
                case ".vbs":
                case ".cs":
                case ".pl":
                    vec.SourceCodeCount = 1;
                    vec.SourceCodeSizeInBytes = sizeInBytes;
                    break;
                case ".odt":
                case ".odg":
                case ".ods":
                case ".odf":
                case ".pdf":
                case ".txt":
                case ".xls":
                case ".ppt":
                case ".doc":
                    vec.OfficeCount = 1;
                    vec.OfficeSizeInBytes = sizeInBytes;
                    break;
                case ".jpg":
                case ".tiff":
                case ".bmp":
                    if (sizeInBytes < 1024 * 100)
                    {
                        vec.WebCount = 1;
                        vec.WebSizeInBytes = sizeInBytes;
                    }
                    else
                    {
                        vec.FotosCount = 1;
                        vec.FotosSizeInBytes = sizeInBytes;
                    }
                    break;
                case ".avi":
                case ".mov":
                case ".rm":
                case ".wmv":
                    vec.VideosCount = 1;
                    vec.VideosSizeInBytes = sizeInBytes;
                    break;
                default:
                    vec.OtherCount = 1;
                    vec.OtherSizeInBytes = sizeInBytes;
                    break;
            }

            return true;
        }

        #endregion

        #region IFileClassificator Member


        bool IFileClassificator.classify(string Filename, out FileDescriptor fd)
        {
            fd = new FileDescriptor();
            fd.Path = Filename;
            fd.Extension = Path.GetExtension(Filename).ToLower();

            // 1. Merkmale der Datei bestimmen 
            fd.SizeInBytes = 0;
            try
            {
                FileStream fs = File.Open(Filename, FileMode.Open, FileAccess.Read);
                fd.SizeInBytes = fs.Length;
                fs.Close();
            }
            catch (Exception)
            {
            }

            FileAttributes fatt = File.GetAttributes(Filename);

            
            // 2. Merkmale bewerten

            if ((fatt & FileAttributes.Archive) != 0)
                fd.ArchiveBit = true;

            switch (fd.Extension)
            {
                case ".htm":
                case ".html":
                case ".js":
                case ".gif":
                case ".png":
                    fd.FClass = ContentVector.FileClasses.Web;                    
                    break;
                case ".xml":
                case ".cpp":
                case ".vb":
                case ".vbs":
                case ".cs":
                case ".pl":
                    fd.FClass = ContentVector.FileClasses.SourceCode;                    
                    break;
                case ".odt":
                case ".odg":
                case ".ods":
                case ".odf":
                case ".pdf":
                case ".txt":
                case ".xls":
                case ".ppt":
                case ".doc":
                    fd.FClass = ContentVector.FileClasses.Office;
                    break;
                case ".jpg":
                case ".tiff":
                case ".bmp":
                    if (fd.SizeInBytes < 1024 * 100)
                    {
                        fd.FClass = ContentVector.FileClasses.Web;
                    }
                    else
                    {
                        fd.FClass = ContentVector.FileClasses.Fotos;
                    }
                    break;
                case ".avi":
                case ".mov":
                case ".rm":
                case ".wmv":
                    fd.FClass = ContentVector.FileClasses.Videos;
                    break;
                default:
                    fd.FClass = ContentVector.FileClasses.Other;
                    break;
            }

            return true;

        }

        #endregion
    }
}
