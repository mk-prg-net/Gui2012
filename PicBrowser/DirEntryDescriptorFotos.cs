using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicBrowser
{
    class DirEntryDescriptorFotos : DirEntryDescriptor
    {
        public DMS.EXIF Exif
        {
            get;
            set;
        }
    }
}
