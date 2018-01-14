using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PicBrowser
{
    public class DirEntryDescriptor
    {   

        public bool IsDir { get; set; }
        public string Path { get; set; }
        public DMS.FC.ContentVector Cv = new DMS.FC.ContentVector();
        public virtual bool IsImage
        {
            get
            {
                if (!IsDir && Cv.FotosCount == 1)
                    return true;
                else return false;
            }
        }
    }
}
