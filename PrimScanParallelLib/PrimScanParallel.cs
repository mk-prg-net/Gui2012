using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CT = System.Threading;
using TPL = System.Threading.Tasks;


namespace PrimScanParallelLib
{
    public class PrimScanParallel
    {
        public class Partition
        {
            public long Start { get; set; }
            public long Ende { get; set; }
        }


        public delegate void DGProgress(Partition p);
        public static event DGProgress Progress;
        
        public static void scan(long startScope, long endScope)
        {
            var alleTasks = new List<TPL.Task>();

            // Die Ergebnisse werden in dieser Liste abgelegt
            var partitionenErgebnisse = new System.Collections.Concurrent.ConcurrentBag<long[]>();

            // Partitionierung des Auftrages
            for (long start = startScope + 1, ende = startScope + 10000; start < endScope; start += 10000, ende += 10000)
            {
                // Pro Partition wird ein Task aufgesetzt
                var t = new TPL.Task(ParamPartitionAsObject =>
                {
                    // Downcast des Parameters vom Typ Object in den Typ Partition
                    var ParamPartition = ParamPartitionAsObject as Partition;

                    var result = mko.Algo.NumberTheory.PrimeFactors.scan(ParamPartition.Start, ParamPartition.Ende);

                    partitionenErgebnisse.Add(result.ToArray());

                    // Informieren über die Fertigstellung der Partition
                    if (Progress != null)
                        Progress(ParamPartition);

                }, new Partition() { Start = start, Ende = ende });
                t.Start();

                alleTasks.Add(t);
            }

            TPL.Task.WaitAll(alleTasks.ToArray());
        }

    }
}
