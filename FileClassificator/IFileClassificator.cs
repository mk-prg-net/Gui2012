using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.FC
{
    public interface IFileClassificator
    {
        bool classify(string Filename, out ContentVector vec);
        bool classify(string Filename, out FileDescriptor fd);
    }
}
