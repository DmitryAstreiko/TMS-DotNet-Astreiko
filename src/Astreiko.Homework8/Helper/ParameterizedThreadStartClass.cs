using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Astreiko.Homework8.Helper
{
    class ParameterizedThreadStartClass
    {
        public void Main(string[] args)
        {
            Thread t = new Thread(new ParameterizedThreadStart(WriteY)); // Kick off a new thread
            t.Start("y");                               // running WriteY()

            // Simultaneously, do something on the main thread.
            for (int i = 0; i < 1000; i++) Console.Write("x");
        }

        static void WriteY(object y)
        {
            for (int i = 0; i < 1000; i++) Console.Write(y);
        }
    }
}
