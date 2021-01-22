using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Astreiko.Homework8.Helper
{
    class ObjectFieldsOnDifferentThreads
    {
        public class Program
        {

            bool done;

            public void Main()
            {
                Program tt = new Program();   // Create a common instance
                new Thread(tt.Go).Start();
                tt.Go();
            }

            // Note that Go is now an instance method
            void Go()
            {
                if (!done) { done = true; Console.WriteLine("Done"); }
            }
        }
    }
}
