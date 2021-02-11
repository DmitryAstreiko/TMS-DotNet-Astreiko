using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Astreiko.Homework8.Helper
{
    class Static_fields_are_shared_between_all_threads
    {
        public class Program
        {

            static bool done;    // Static fields are shared between all threads

            public void Main()
            {
                new Thread(Go).Start();
                Go();
            }

            public void Go()
            {
                if (!done) { done = true; Console.WriteLine("Done"); }
            }
        }
    }
}

