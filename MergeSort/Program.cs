using System;
using System.Diagnostics;
using System.Threading;
using Exercise;
//using Solution;

namespace Program
{
    class MergeSort
    {

        static void Main(string[] args)
        {
            int[] arr = { 1, 5, 4, 11, 20, 8, 2, 98, 90, 16, 3 , 100, 83, 24, 18, 33, 44, 76 };

            
            SequentialMergeSort mergeSort = new SequentialMergeSort(arr);
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch1.Start();
            mergeSort.printContent("\n Before the sequential merge-sort \n");
            mergeSort.sortSeq(0, arr.Length - 1);
            mergeSort.printContent("\n After the sequential merge-sort \n");
            stopwatch1.Stop();

            ConcurrentMergeSort concMergeSort = new ConcurrentMergeSort(arr);
            stopwatch2.Start();
            concMergeSort.printContent("\n Before the concurrent merge-sort \n");
            concMergeSort.sortCon(0, arr.Length - 1);
            concMergeSort.printContent("\n After the concurrent merge-sort \n");
            stopwatch2.Stop();

            Console.WriteLine("\n Sequential merge-sort took {0} ms", stopwatch1.ElapsedMilliseconds);
            Console.WriteLine("\n Concurrent merge-sort took {0} ms", stopwatch2.ElapsedMilliseconds);
            // #TODO:
            // uncomment this only if the solution is available
            //Console.WriteLine("\n Now concurrent sort will be running ...\n");
            //SolutionConcurrentMergeSort concMergeSort = new SolutionConcurrentMergeSort();
            //concMergeSort.sortCon(arr);

        }
    }
}
