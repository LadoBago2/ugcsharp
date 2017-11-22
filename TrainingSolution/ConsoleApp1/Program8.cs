using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate int TakesAWhileDelegate(int data, int ms);

    class Program8
    {
        static void Main2(string[] args)
        {
            // synchronous method call
            // TakesAWhile(1, 3000);

            // asynchronous by using a delegate
            //TakesAWhileDelegate d1 = TakesAWhile;

            // ასინქრონული გამოძახების 1-ილ მეთოდი
            //IAsyncResult ar = d1.BeginInvoke(1, 3000, null, null);
            //while (!ar.IsCompleted)
            //{
            //    // doing something else in the main thread
            //    Console.Write(".");
            //    Thread.Sleep(50);
            //}
            //int result = d1.EndInvoke(ar);
            //Console.WriteLine("result: {0}", result);

            // ასინქრონული გამოძახების მე-2 მეთოდი
            //AsyncCallback callback = TakesAWhileCompleted;
            //d1.BeginInvoke(1, 3000, callback, d1);
            //d1.BeginInvoke(1, 3000, ar => {
            //    int result = d1.EndInvoke(ar);
            //    Console.WriteLine("result: {0}", result);
            //}, null);
            //for (int i = 0; i < 100; i++)
            //{
            //    Console.Write(".");
            //    Thread.Sleep(50);
            //}


            //Thread t1 = new Thread(ThreadMain);
            //Thread t1 = new Thread(() => Console.WriteLine("Running in a thread."));
            //t1.Start();
            //ParameterizedThreadStart pts = new ParameterizedThreadStart(ThreadMain2);
            //Thread t2 = new Thread(pts);
            //t2.Start(5);
            //Console.WriteLine("This is the main thread.");


            //Thread t1 = new Thread(ThreadMain3)
            //{
            //    Name = "MyNewThread",
            //    IsBackground = true
            //};

            //t1.Start();
            //Console.WriteLine("Main thread ending now.");

            int nWorkerThreads;
            int nCompletionPortThreads;
            ThreadPool.GetMaxThreads(out nWorkerThreads, out nCompletionPortThreads);
            Console.WriteLine("Max worker threads: {0}, " +
                "I/O completion threads: {1}",
                nWorkerThreads,
                nCompletionPortThreads
            );

            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(JobForAThread);
            }

            Thread.Sleep(3000);
        }

        static int TakesAWhile(int data, int ms)
        {
            Console.WriteLine("TakesAWhile started");
            Thread.Sleep(ms);
            Console.WriteLine("TakesAWhile completed");
            return ++data;
        }
        static void TakesAWhileCompleted(IAsyncResult ar)
        {
            if (ar == null)
                throw new ArgumentNullException("ar");
            TakesAWhileDelegate d1 = ar.AsyncState as TakesAWhileDelegate;

            Trace.Assert(d1 != null, "Invalid object type");

            int result = d1.EndInvoke(ar);
            Console.WriteLine("result: {0}", result);
        }
        static void ThreadMain()
        {
            Console.WriteLine("Running in a thread.");
        }
        static void ThreadMain2(object a)
        {
            Console.WriteLine("Running in a thread.a={0}", a.ToString());
        }
        static void ThreadMain3()
        {
            Console.WriteLine("Thread {0} started", Thread.CurrentThread.Name);
            Thread.Sleep(3000);
            Console.WriteLine("Thread {0} completed", Thread.CurrentThread.Name);
        }
        static void JobForAThread(object state)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(
                    "loop {0}, running inside pooled thread {1}",
                    i,
                    Thread.CurrentThread.ManagedThreadId
                );
                Thread.Sleep(50);
            }
        }
    }
}