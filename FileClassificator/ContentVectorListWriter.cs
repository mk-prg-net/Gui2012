using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DMS.FC
{
    public class ContentVectorListWriter : IContenVectorWriter
    {
        TraceSwitch ts = new TraceSwitch("ContentVectorListWriterTraceSwitch", "Grad der Protokollierung beeinflussen");

        List<ContentVector> _lst;

        public ContentVectorListWriter()
        {
            _lst = new List<ContentVector>();
        }

        public ContentVectorListWriter(List<ContentVector> lst)
        {
            Debug.Assert(lst != null);
            _lst = lst;
        }

        #region IContenVectorWriter Member

        public bool Open()
        {
            Debug.Assert(_lst != null);
            Trace.WriteLineIf(ts.TraceInfo, "Open: ContentVectorList");
            _lst.Clear();
            return true;            
        }

        public bool Write(int Tiefe, string path, ContentVector vec)
        {
            Debug.Assert(!string.IsNullOrEmpty(path) && vec != null);
            _lst.Add((ContentVector)vec.Clone());
            return true;
        }

        public bool Close()
        {
            Trace.WriteLineIf(ts.TraceInfo, "Close: ContentVectorList mit " + _lst.Count + " Einträgen");
            throw new NotImplementedException();
        }

        #endregion
    }
}
