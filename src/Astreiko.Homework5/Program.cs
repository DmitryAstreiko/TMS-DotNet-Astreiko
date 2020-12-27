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
        public static List<Tiger> ListTiger;

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
            if (ListTiger.Count != 0)
            {
                foreach (var rowTiger in ListTiger)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"-----{nameof(Tiger)} : {rowTiger.Name}-----");
                    Console.ResetColor();
                    Console.WriteLine($"{nameof(Tiger.Age)} = {rowTiger.Age}.");
                    Console.WriteLine($"{nameof(Tiger.Weight)} = {rowTiger.Weight}.");
                    rowTiger.Eat();
                    rowTiger.Say();
                    rowTiger.Traffic();
                    Console.WriteLine();
                }
            }
            else if (ListCat.Count != 0)
            {
                foreach (var rowCat in ListCat)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"-----{nameof(Cat)} : {rowCat.Name}-----");
                    Console.ResetColor();
                    Console.WriteLine($"{nameof(Cat.Age)} = {rowCat.Age}.");
                    Console.WriteLine($"{nameof(Cat.Weight)} = {rowCat.Weight}.");
                    rowCat.Eat();
                    rowCat.Say();
                    rowCat.Traffic();
                    Console.WriteLine();
                }

            }
            else if (ListBear.Count != 0)
            {
                foreach (var rowBear in ListBear)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"-----{nameof(Bear)} : {rowBear.Name}-----");
                    Console.ResetColor();
                    Console.WriteLine($"{nameof(Bear.Age)} = {rowBear.Age}.");
                    Console.WriteLine($"{nameof(Bear.Weight)} = {rowBear.Weight}.");
                    rowBear.Eat();
                    rowBear.Say();
                    rowBear.Traffic();
                    Console.WriteLine();
                }

            }
            else if (ListElephant.Count != 0)
            {
                foreach (var rowEl in ListElephant)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"-----{nameof(Elephant)} : {rowEl.Name}-----");
                    Console.ResetColor();
                    Console.WriteLine($"{nameof(Elephant.Age)} = {rowEl.Age}.");
                    Console.WriteLine($"{nameof(Elephant.Weight)} = {rowEl.Weight}.");
                    rowEl.Eat();
                    rowEl.Say();
                    rowEl.Traffic();
                    Console.WriteLine();
                }
            }
            else if (ListGiraffe.Count != 0)
            {
                foreach (var rowGiraffe in ListGiraffe)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"-----{nameof(Giraffe)} : {rowGiraffe.Name}-----");
                    Console.ResetColor();
                    Console.WriteLine($"{nameof(Giraffe.Age)} = {rowGiraffe.Age}.");
                    Console.WriteLine($"{nameof(Giraffe.Weight)} = {rowGiraffe.Weight}.");
                    rowGiraffe.Eat();
                    rowGiraffe.Say();
                    rowGiraffe.Traffic();
                    Console.WriteLine();
                }
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
            ListTiger = new List<Tiger>();

            var tig = new Tiger()
            {
                Age = 0.5,
                Name = "Yaguar",
                Weight = 250,
                WhatSay = "RRR-RRR",
                WhatTraffic = "High speed",
                WhatEat = "Meat"
            };

            ListTiger.Add(tig);

            ListElephant = new List<Elephant>();

            var el = new Elephant()
            {
                Age = 1.6,
                Name = "Big mam",
                Weight = 1500,
                WhatTraffic = "35 kn/h"
            };

            ListElephant.Add(el);

            ListGiraffe = new List<gira>();

            var el = new Elephant()
            {
                Age = 1.6,
                Name = "Big mam",
                Weight = 1500,
                WhatTraffic = "35 kn/h"
            };

            ListElephant.Add(el);
        }

    }
}
