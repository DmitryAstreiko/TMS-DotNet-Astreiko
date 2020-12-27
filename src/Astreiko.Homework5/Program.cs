using Astreiko.Homework5.Models;
using System;
using System.Collections.Generic;

namespace Astreiko.Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            

            ShowMenu();

            var check = true;

            while (check)
            {
                Console.WriteLine();
                Console.Write("Please press any key : ");

                var inputChar = Console.ReadLine().Trim();

                switch (inputChar)
                {
                    case "s":

                        ShowMenu();
                        break;
                    case "a":

                        ShowMenu();
                        break;
                    case "c":
                        check = false;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Exit from application.");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Uncorrect key.");
                        Console.ResetColor();
                        ShowMenu();
                        break;
                } 
            }
            
            Console.ReadKey();
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Menu operations : ");

            Console.WriteLine("Show list animals - press s");

            Console.WriteLine("Add animal (You can add Bear, Cat, Elephant, Giraffe, Tiger) - press a");

            Console.WriteLine("Exit - press c");
        }
    }
}
