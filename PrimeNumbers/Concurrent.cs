using System;
using System.Diagnostics;
using System.Threading;
using Exercise;

namespace Concurrent
{
    public class ConPrimeNumbers : PrimeNumbers
    {
        public ConPrimeNumbers()
        {
        }
        /// <summary>
        /// This method 
        /// </summary>
        /// <param name="m"> is the minimum number</param>
        /// <param name="M"> is the maximum number</param>
        /// <param name="nt"> is the number of threads. For simplicity assume two.</param>
        public void runConcurrent(int m, int M, int nt = 2)
        {
            // Todo 1: Create two threads, define their segments and start them. Join them all to have all the work done.
            int segments = (M - m) / nt;
            Thread[] threads = new Thread[nt];
            for (int i = 0; i < nt; i++)
            {
                int lower = m + i * segments;
                int upper = lower + segments - 1;
                threads[i] = new Thread(() => printPrimes(lower, upper));
                threads[i].Start();
            }
            for (int i = 0; i < nt; i++)
            {
                threads[i].Join();
            }
        }

    }
}
