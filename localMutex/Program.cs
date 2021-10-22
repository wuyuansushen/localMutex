using System;
using System.Threading;

namespace localMutex
{
    class Program
    {
        private static Mutex mutex = new Mutex(false,"Local/namedSysMutex");
        private const int numIterations = 1;
        private const int numThreads = 3;
        static void Main(string[] args)
        {
            for (int i = 0; i < numThreads; i++)
            {
                var newThread = new Thread(ThreadProc);
                newThread.Start();
            }
            Console.WriteLine($"Main thread-{Thread.CurrentThread.ManagedThreadId} has started all addtional threads, closing...");
        }

        private static void ThreadProc()
        {
            for(int i=0;i<numIterations;i++)
            {
                UseResource();
            }
        }

        private static void UseResource()
        {
            string threadNameWithID = $"Thread{Thread.CurrentThread.ManagedThreadId}";
            Console.WriteLine($"{threadNameWithID} is requesting the mutex.");
            mutex.WaitOne();
            Console.WriteLine($"{threadNameWithID} has entered the protected area.\n");

            Thread.Sleep(5000);

            Console.WriteLine($"{threadNameWithID} is leaving the protected area.");
            mutex.ReleaseMutex();
            Console.WriteLine($"{threadNameWithID} has released the mutex");
        }
    }
}
