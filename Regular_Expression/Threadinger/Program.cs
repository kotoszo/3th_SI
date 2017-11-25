using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threadinger
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart starter = new ThreadStart(Counting);
            Thread first = new Thread(starter);
            Thread second = new Thread(starter);

            first.Start();
            second.Start();

            first.Join();
            second.Join();

            Console.ReadKey();
        }

        public static void Counting()
        {
            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine("i: " + i + " ThreadID " + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);

            }
        }
    }
}
