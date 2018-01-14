using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicBrowser
{
    class DirEntryClassificator
    {

        static string[] bilddateitypen = { ".jpg", ".jpeg", ".tif", ".tiff", ".gif", ".png" };

        public static DirEntryDescriptor CreateDirEntryDescriptor(string path) {
            try
            {
                DMS.FC.IFileClassificator fc = new DMS.FC.StandardFileClassificator();

                if (System.IO.Directory.Exists(path))
                {
                    var entry = new DirEntryDescriptor() { IsDir = true, Path = path };
                    fc.classify(path, out entry.Cv);
                    return entry;
                }
                else if (System.IO.File.Exists(path))
                {                     
                    var cv = new DMS.FC.ContentVector();
                    fc.classify(path, out cv);

                    if (bilddateitypen.Any(r => r == System.IO.Path.GetExtension(path).ToLower()))            
                    {
                        cv.FotosCount = 1;
                        var entry = new DirEntryDescriptorFotos() { IsDir = false, Cv = cv, Path = path };
                        var bmp = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(path);
                        entry.Exif = new DMS.EXIF(bmp);
                        return entry;
                    }
                    else
                    {
                        return new DirEntryDescriptor() { IsDir = false, Cv = cv, Path = path };
                    }
                }
                else
                    throw new Exception("unbekannter Typ von Verzeichniseintrag");
                
            }
            catch (Exception ex)
            {
                throw new Exception("DirEntryClassificator.CreateDirEntryDescriptor: " + ex.Message, ex);
            }
        }
    }
}
