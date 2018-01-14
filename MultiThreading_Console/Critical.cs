using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace MultiThreading_Console
{
    class Critical
    {
        int eingang = 100000; // Hallo
        int ausgang = 0;

        public int transaktion()
        {
            int bilanzsumme = 0;
            try
            {
                //System.Threading.Monitor.Enter(this);
                 
                // lock ruft auch Monitor Enter und Exit auf, stellt
                // aber sicher, daß in jedem Fall beim verlassen des 
                // Blockes Monitor.Exit aufgerufen wird
                lock (this)
                {
                    eingang--;

                    System.Threading.Thread.Sleep(100);

                    ausgang++;

                    bilanzsumme = eingang + ausgang;
                }

                //System.Threading.Monitor.Exit(this);
            }
            catch (Exception)
            {
            }

            return bilanzsumme;
        }

        static Critical critical = new Critical();

        static void worker()
        {
            for (int i = 0; i < 100; i++)
            {
                Debug.WriteLine(String.Format("TId {0:d} Bilanz= {1:d}",
                    System.Threading.Thread.CurrentThread.ManagedThreadId,
                    critical.transaktion()));
            }


        }

        public static void testeKritischenAbschnitt()
        {
            System.Threading.Thread t1 = new System.Threading.Thread(new System.Threading.ThreadStart(worker));
            t1.Priority = System.Threading.ThreadPriority.Lowest;
            t1.Start();

            System.Threading.Thread t2 = new System.Threading.Thread(new System.Threading.ThreadStart(worker));
            t2.Priority = System.Threading.ThreadPriority.Highest;
            t2.Start();

            t1.Join();
            t2.Join();
        }

    }
}
