using System;
using System.Collections.Generic;
using System.Text;

namespace Astreiko.Homework8.Helper
{
    class Mutex
    {
        //static class Program
        //{

        //    //A Mutex is like a C# lock, but it can work across multiple processes.
        //    //In other words, Mutex can be computer-wide as well as application-wide.

        //    static void Main()
        //    {
        //        // Naming a Mutex makes it available computer-wide. Use a name that's
        //        // unique to your company and application (e.g., include your URL).

        //        using (var mutex = new Mutex(false, "TMS.NET06.Lesson11.Multithreading"))
        //        {
        //            // Wait a few seconds if contended, in case another instance
        //            // of the program is still in the process of shutting down.

        //            if (!mutex.WaitOne(TimeSpan.FromSeconds(3), false))
        //            {
        //                Console.WriteLine("Another app instance is running. Bye!");
        //                return;
        //            }
        //            RunProgram();
        //        }
        //    }

        //    static void RunProgram()
        //    {
        //        Console.WriteLine("Running. Press Enter to exit");
        //        Console.ReadLine();
        //    }
        //}
    }
}
