using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Astreiko.Homework8.Helper
{
    class Lock_to_Monitor
    {
        //static class Program
        //{

        //    static bool done;
        //    static readonly object locker = new object();

        //    static void Main()
        //    {
        //        new Thread(Go).Start();
        //        Go();
        //    }

        //    static void Go()
        //    {
        //        bool lockWasTaken = false;
        //        var temp = locker;
        //        try
        //        {
        //            Monitor.Enter(temp, ref lockWasTaken);
        //            {
        //                if (!done) { Console.WriteLine("Done"); done = true; }
        //            }
        //        }
        //        finally
        //        {
        //            if (lockWasTaken) Monitor.Exit(temp);
        //        }
        //    }
        //}
    }
}
