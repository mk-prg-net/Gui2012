using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace mko
{
    public class Utils
    {
        public static object CloneSerializableObject(object obj)
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone)); 
                binaryFormatter.Serialize(memStream, obj); 
                memStream.Seek(0, SeekOrigin.Begin); 
                return binaryFormatter.Deserialize(memStream);
            }
        }        
    }


}
