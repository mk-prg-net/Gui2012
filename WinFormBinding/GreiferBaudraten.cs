using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WinFormBinding
{
    public class GreiferBaudraten
    {
        public Greifer.GreiferID ZulässigeGreifer { get; set; }

        public bool Contains(string Greifername) {

            var ID = (Greifer.GreiferID) Enum.Parse(typeof(Greifer.GreiferID), Greifername);
            return (ZulässigeGreifer & ID) != 0;
        }

        public int Baudrate { get; set; }

        public static GreiferBaudraten[] CreateList()
        {
            return new GreiferBaudraten[] {
                new GreiferBaudraten() { Baudrate = 9600, ZulässigeGreifer = Greifer.GreiferID.A | Greifer.GreiferID.B | Greifer.GreiferID.C},
                new GreiferBaudraten() { Baudrate = 19200, ZulässigeGreifer = Greifer.GreiferID.A | Greifer.GreiferID.B },
                new GreiferBaudraten() { Baudrate = 38400, ZulässigeGreifer = Greifer.GreiferID.A | Greifer.GreiferID.B },
                new GreiferBaudraten() { Baudrate = 57600, ZulässigeGreifer = Greifer.GreiferID.A },
            };
        }

        public String Filter
        {
            set
            {
                if (value.StartsWith("Baudrate"))
                {
                    Debug.WriteLine("Bin in Filter");
                }

            }
        }

    }
}
