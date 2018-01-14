using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace MultiThreading_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Testen von Thread Abort
            //ThreadAbort taTest = new ThreadAbort();
            //taTest.starter();


            // Kritische Abschnitte

            //Critical.testeKritischenAbschnitt();


            //System.Threading.EventWaitHandle systemweit = new System.Threading.EventWaitHandle(false,
            //   System.Threading.EventResetMode.ManualReset,
            //   "MeineSystemweite");

            //Console.WriteLine("1: Warte auf 2....");

            //systemweit.WaitOne();

            //Console.WriteLine("1: 2 hat Systemweit gesetzt");


            //Critical.testeKritischenAbschnitt();


            // Arbeiten mit WaitHandles

            WartenAufDenAnderen kontext = new WartenAufDenAnderen();
            System.Threading.Thread t1 = new System.Threading.Thread(new ThreadStart(kontext.workerA));
            System.Threading.Thread t2 = new System.Threading.Thread(new ThreadStart(kontext.workerB));

            t1.Start();
            t2.Start();

            Debug.WriteLine("Threads gestartet");

            t1.Join();
            t2.Join();

        }
    }
}
