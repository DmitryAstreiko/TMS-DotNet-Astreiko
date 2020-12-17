using System;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            //int? qwe = null; полный вид NUllable<int> qwe = null;

            var penOne = new Pen();

            var penTwo = new Pen(123);

            Console.WriteLine($"{penOne}");
            Console.WriteLine($"{penOne.Color}");

            Console.WriteLine($"{penTwo}");
            Console.WriteLine($"{penTwo.Color}");

            Console.ReadKey();
        }
    }
}
