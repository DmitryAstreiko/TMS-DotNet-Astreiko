using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Astreiko.Homework8.Helper
{
    class Exception_Handing
    {
        static class Program
        {

            public static void Main()
            {
                try
                {
                    var thread = new Thread(Go);
                    //thread.IsBackground = true; // see what happens
                    thread.Start();
                }
                catch (Exception ex)
                {
                    // We'll never get here!
                    Console.WriteLine($"Exception! {ex.Message}");
                }

                // how to handle?
            }

            static void Go() { throw null; }   // Throws a NullReferenceException
        }
    }
}
