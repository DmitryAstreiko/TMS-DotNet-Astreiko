using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Astreiko.Homework8.Helper
{
    class Thread_v_Process
    {
        // Threads vs Processes
        // A thread is analogous to the operating system process in which your application runs.
        // Just as processes run in parallel on a computer, threads run in parallel within a single process.
        // Processes are fully isolated from each other; threads have just a limited degree of isolation.
        // In particular, threads share (heap) memory with other threads running in the same application.
        // This, in part, is why threading is useful: one thread can fetch data in the background, for instance,
        // while another thread can display the data as it arrives.

        public void Main()
        {
            Thread t = new Thread(new ThreadStart(WriteY)); // Kick off a new thread
            t.Start();                               // running WriteY()

            // Simultaneously, do something on the main thread.
            for (int i = 0; i < 1000; i++) Console.Write("x");
        }

        static void WriteY()
        {
            for (int i = 0; i < 1000; i++) Console.Write("y");
        }
    }
}
