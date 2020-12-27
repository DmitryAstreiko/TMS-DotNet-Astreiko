using Astreiko.Homework5.Models;
using System;
using System.Collections.Generic;

namespace Astreiko.Homework5
{
    class Program
    {
        public static List<Bear> ListBear;
        public static List<Cat> ListCat;
        public static List<Elephant> ListElephant;
        public static List<Giraffe> ListGiraffe;
        public static List<Tigger> ListTigger;

        static void Main(string[] args)
        {
            AddDefaultAnimals();

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
                        ShowListAnimals();
                        Console.WriteLine();
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

        private static void ShowListAnimals()
        {
            if (ListTigger.Count != 0)
            {
                foreach (var rowTigger in ListTigger)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"-----{nameof(Tigger)} : {rowTigger.Name}-----");
                    Console.ResetColor();
                    Console.WriteLine($"{nameof(Tigger.Age)} = {rowTigger.Age}.");
                    Console.WriteLine($"{nameof(Tigger.Weight)} = {rowTigger.Weight}.");
                    rowTigger.Eat();
                    rowTigger.Say();
                    rowTigger.Traffic();
                    Console.WriteLine();
                }
            }
            else if (ListCat.Count != 0)
            {
                
            }
            else if (ListBear.Count != 0)
            {

            }
            else if (ListElephant.Count != 0)
            {

            }
            else if (ListGiraffe.Count != 0)
            {

            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Menu operations : ");

            Console.WriteLine("Show list animals - press s");

            Console.WriteLine("Add animal (You can add Bear, Cat, Elephant, Giraffe, Tiger) - press a");

            Console.WriteLine("Exit - press c");
        }

        private static void AddDefaultAnimals()
        {
            ListTigger = new List<Tigger>();

            var tig = new Tigger()
            {
                Age = 0.5,
                Name = "Yaguar",
                Weight = 250,
                WhatSay = "RRR-RRR",
                WhatTraffic = "High speed",
                WhatEat = "Meat"
            };

            ListTigger.Add(tig);

            
        }

    }
}
