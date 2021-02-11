using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Astreiko.Homework8.Helper
{
    class Immutable_objects
    {
    
        public class Program
        {

            // An immutable object is one whose state cannot be altered — externally or internally.
            // Immutability is a hallmark of functional programming — where instead of mutating an object,
            // you create a new object with different properties.
            // Immutability is also valuable in multithreading in that it avoids the problem of shared writable state.

            //public void Main()
            //{
            //    // how to fix?           

            //    var hello = new char[] { 'H', 'e', 'l', 'l', 'o' };
            //    new Thread(() => Console.WriteLine((hello.ToUpper()))).Start();
            //    Console.WriteLine(hello.ToLower());
            //}

            //private char[] ToUpper(this char[] obj)
            //{
            //    for (int i = 0; i < obj.Length; i++)
            //    {
            //        obj[i] = char.ToUpper(obj[i]);
            //    }

            //    return obj;
            //}

            //private char[] ToLower(this char[] obj)
            //{
            //    for (int i = 0; i < obj.Length; i++)
            //    {
            //        obj[i] = char.ToLower(obj[i]);
            //    }

            //    return obj;
            //}
        }
    }
}
