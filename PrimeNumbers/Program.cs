using System;
using System.Diagnostics;
using System.Threading;
using Exercise;
using Concurrent;
//using Solution;

/// <summary>
/// This example implements a concurrent version of finding and printing prime-numbers between two given numbers.
/// </summary>
namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int min = 5, max = 100000;

            ConPrimeNumbers pn = new ConPrimeNumbers();
            Stopwatch swsequential = new Stopwatch();
            swsequential.Start();
            pn.runSequential(min, max);
            swsequential.Stop();
            Console.WriteLine("Time for sequential version is {0} msec,", swsequential.ElapsedMilliseconds);
            

            Thread.Sleep(5000);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            pn.runConcurrent(min, max);
            sw.Stop();
            Console.WriteLine("Time for Concurrent version is {0} msec,", sw.ElapsedMilliseconds);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Time for sequential version is {0} msec,", swsequential.ElapsedMilliseconds);
            Console.WriteLine("Time for Concurrent version is {0} msec,", sw.ElapsedMilliseconds);
            Console.WriteLine("Speedup is {0}", swsequential.ElapsedMilliseconds / sw.ElapsedMilliseconds);


        }
    }
}
