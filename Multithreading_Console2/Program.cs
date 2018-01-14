using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multithreading_Console2
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.EventWaitHandle systemweit = new System.Threading.EventWaitHandle(false, 
                System.Threading.EventResetMode.ManualReset, 
                "MeineSystemweite");

            Console.WriteLine("2: Gib irgend was ein !");
            Console.ReadLine();


            systemweit.Set();

            Console.WriteLine("2: Habe Systemweit gesetzt");



        }
    }
}
