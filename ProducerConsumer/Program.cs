using Exercise;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;


namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            int wt = 1000;
            Stopwatch sw1 = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();
            Stopwatch sw3 = new Stopwatch();

            Simulator simulator = new Simulator(10, wt);
            // todo 1: uncomment this and check the result. Analyze the related code.
            sw1.Start();
            Console.Clear();
            Console.WriteLine("Sequential version ....");
            simulator.sequentialOneProducerOneConsumer();
            sw1.Stop();
            Console.ReadKey();
            sw2.Start();
            Console.Clear();
            Console.WriteLine("Concurrent (one producer one consumer) version ....");
            // todo 2: uncomment this and check the result. Analyze the related code. Try with higher values for n.
            int n = 100; 
            simulator.concurrentOneProducerOneConsumer(n);
            sw2.Stop();
            // todo 3: Analyze the result of concurrentOneProducerOneConsumer(n). Is it working correctly? Is the program thread-safe? Analyse what could be the problem?
            // todo 4: Make the program thread-safe.

            // todo 5: uncomment the following code and analyze the execution and behaviour. Is the program thread-safe?

            Console.ReadKey(); 
            sw3.Start();
            Console.Clear();
            Console.WriteLine("Concurrent (multiple producer multiple consumer) version ....");
            simulator.concurrentMultiProducerMultiConsumer(n,5);
            sw3.Stop();
            Console.WriteLine("...");
            Console.WriteLine("Sequential version: {0} ms", sw1.ElapsedMilliseconds);
            Console.WriteLine("Concurrent (one producer one consumer) version: {0} ms", sw2.ElapsedMilliseconds);
            Console.WriteLine("Concurrent (multiple producer multiple consumer) version: {0} ms", sw3.ElapsedMilliseconds);
            Console.ReadKey();
            Console.WriteLine("... how many times the buffer was empty? {0}", Exercise.Consumer.EMPTY);


        }
    }
}
