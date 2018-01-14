using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.FCollect
{
    public class FeatureKleinbild : Feature
    {
        public new class Exc : Feature.Exc
        {
            public Exc(string msg) : base(msg) { }
            public Exc(string msg, Exception innerException) : base(msg, innerException) { }
        }

        public override string Description
        {
            get { return "Minaturansicht des Bildes"; }
        }

        public override string Name
        {
            get { return "Miniatur"; }
        }

        public override string ToString()
        {
            return "Miniatur";
        }

        public byte[] Img;

        bool ThumbnailCallback()
        {
            return false;
        }

        public override bool extract(string path)
        {
            try
            {
                string ext = System.IO.Path.GetExtension(path);

                if ((new string[] { ".jpg", ".bmp", ".tif" }).Any(r => r == ext))
                {
                    // Miniaturansicht generieren 
                    System.Drawing.Bitmap bmp = System.Drawing.Bitmap.FromFile(path) as System.Drawing.Bitmap;
   

                    int hoeheMiniatur = (120 * bmp.Height) / bmp.Width;

                    System.Drawing.Bitmap bmpMini = (System.Drawing.Bitmap)bmp.GetThumbnailImage(120, hoeheMiniatur, null, IntPtr.Zero);

                    var memStream = new System.IO.MemoryStream();
                    bmpMini.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);                    

                    Img = new byte[memStream.Length];
                    Array.Copy(memStream.GetBuffer(), Img, Img.Length);

                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exc("Beim extrahieren der Miniaturansicht", ex);
            }
        }

        public override bool extract(System.IO.Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
