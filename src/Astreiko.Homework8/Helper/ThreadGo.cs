using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Astreiko.Homework8.Helper
{
    class ThreadGo
    {
        public void Main()
        {
            new Thread(Go).Start();      // Call Go() on a new thread
            Go();                         // Call Go() on the main thread
        }

        static void Go()
        {
            // Declare and use a local variable - 'cycles'
            for (int cycles = 0; cycles < 5; cycles++) Console.Write('?');
        }
    }
}
