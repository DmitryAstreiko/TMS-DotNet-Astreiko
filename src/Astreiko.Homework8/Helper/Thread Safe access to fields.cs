using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Astreiko.Homework8.Helper
{
    class Thread_Safe_access_to_fields
    {
        public class Program
        {

            public bool done;
            public readonly object locker = new object();

            public void Main()
            {
                new Thread(Go).Start();
                Go();
            }

            public void Go()
            {
                lock (locker)
                {
                    if (!done) { Console.WriteLine("Done"); done = true; }
                }
            }
        }
    }
}
