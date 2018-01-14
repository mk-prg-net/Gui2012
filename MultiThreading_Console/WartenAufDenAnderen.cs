using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace MultiThreading_Console
{
    class WartenAufDenAnderen
    {
        System.Threading.AutoResetEvent signal = new System.Threading.AutoResetEvent(false);

        int gemeinsam = 0;

        public void workerA()
        {            
            System.Threading.Thread.Sleep(1000);
            
            Debug.WriteLine("A, vor der 1. Semaphore. gemeinsam = " + gemeinsam);
            
            // Warten auf B
            signal.WaitOne();

            gemeinsam -= 99;
            Debug.WriteLine("A, B hat Signal freigegeben. gemeinsam = " + gemeinsam);

        }

        public void workerB()
        {         
            System.Threading.Thread.Sleep(5000);
            gemeinsam = 100;
            Debug.Write("B, vor der 1. Semaphore. gemeinsam = " + gemeinsam);
            // Signalisieren A, das ich bereit bin
            signal.Set();

            
            Debug.WriteLine("B, nach dem freigegeben. gemeinsam = " + gemeinsam);

        }

    }
}
