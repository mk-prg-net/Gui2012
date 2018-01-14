using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Diagnostics;

namespace MultiThreading_Console
{
    class ThreadAbort
    {

        public void starter()
        {
            Thread workerThread = new Thread(new ThreadStart(worker));

            workerThread.Start();

            Thread.Sleep(2000);
            workerThread.Abort();             
            

            Thread.Sleep(2000);
            workerThread.Abort();


        }

        public void worker()
        {
            int Abbruchversuche = 0;
            bool Abbrechen = false;

            do
            {
                try
                {
                    Debug.WriteLine("Tue wichtiges.");
                    do
                    {
                        Debug.Write(".");
                        Thread.Sleep(500);
                    } while (true);
                }
                catch (ThreadAbortException tex)
                {
                    if (Abbruchversuche++ >= 1)
                    {
                        Abbrechen = true;
                        Debug.WriteLine("Worker abgebrochen");
                    }
                    else
                    {
                        Thread.ResetAbort();
                    }
                    
                    Debug.WriteLineIf(!Abbrechen, "Kein Abbruch");                    

                }
            } while (!Abbrechen);

        }
    }
}
