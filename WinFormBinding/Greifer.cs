using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormBinding
{
    public class Greifer
    {
        public enum GreiferID
        {
            A = 0x1,
            B = 0x2,
            C = 0x4
        }

        public GreiferID ID { get; set; }
        public string Name
        {
            get
            {
                return ID.ToString();
            }
        }

        public static Greifer[] CreateList() 
        {
            return new Greifer[] {
                new Greifer() { ID = GreiferID.A},
                new Greifer() { ID = GreiferID.B},
                new Greifer() { ID = GreiferID.C}
            };
        
        }
    }
}
