﻿using System;
using System.Threading;

namespace sysMutex
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * var mutexLocal = new Mutex(true,"Local/namedSysMutex");
             * mutexLocal.ReleaseMutex();
             */
            var mutexName = "Local/namedSysMutex";
            var mutex = Mutex.OpenExisting(mutexName);
            mutex.WaitOne();
            Console.WriteLine($"Get the mutex");
            Thread.Sleep(5000);
            mutex.ReleaseMutex();
            Console.WriteLine($"Released the mutex");
        }
    }
}
