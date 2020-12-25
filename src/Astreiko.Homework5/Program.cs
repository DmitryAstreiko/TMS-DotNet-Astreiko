using Astreiko.Homework5.Models;
using System;

namespace Astreiko.Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            var eee = new Tigger();

            Console.WriteLine($"{eee.WhatEat} {eee.WhatSay}");

            eee.WhatEat = "12312321";

            Console.WriteLine($"{eee.WhatEat} {eee.WhatSay}");

            Console.ReadKey();
        }
    }
}
