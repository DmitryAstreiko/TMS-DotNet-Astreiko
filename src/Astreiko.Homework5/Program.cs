﻿using Astreiko.Homework5.Helper;
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
                        AddAnimals();
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

        /// <summary>
        /// Add animals to a specific list
        /// </summary>
        private static void AddAnimals()
        {
            ShowMenuAnimals();

            switch (SelectedKind())
            {
                case KindAnimals.Cat:
                    ListCat.Add(GetPropertiesCat());
                    break;

                case KindAnimals.Bear:
                    ListBear.Add(GetPropertiesBear());
                    break;

                case KindAnimals.Elephant:
                    ListElephant.Add(GetPropertiesElephant());
                    break;

                case KindAnimals.Giraffe:
                    ListGiraffe.Add(GetPropertiesGiraffe());
                    break;

                case KindAnimals.Tiger:
                    ListTiger.Add(GetPropertiesTiger());
                    break;
            }
        }

        /// <summary>
        /// Get properties for class Tiger
        /// </summary>
        /// <returns>class Tiger</returns>
        private static Tiger GetPropertiesTiger()
        {
            var animal = new Tiger();

            Console.Write("Enter Name : ");
            animal.Name = Console.ReadLine();


            var check = true;
            double vAge = 0;

            while (check)
            {
                Console.Write("Enter Age : ");
                try
                {
                    vAge = double.Parse(Console.ReadLine().Trim().Replace(".", ","));
                    check = false;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Uncorrect number. Try again.");
                    Console.ResetColor();
                }
            }

            animal.Age = vAge;


            check = true;
            double vWeight = 0;

            while (check)
            {
                Console.Write("Enter Weight : ");

                try
                {
                    vWeight = double.Parse(Console.ReadLine().Trim().Replace(".", ","));
                    check = false;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Uncorrect number. Try again.");
                    Console.ResetColor();
                }
            }

            animal.Weight = vWeight;

            Console.Write("Enter what eat : ");
            animal.WhatEat = Console.ReadLine();

            Console.Write("Enter what say : ");
            animal.WhatSay = Console.ReadLine();

            Console.Write("Enter what traffic : ");
            animal.WhatTraffic = Console.ReadLine();

            return animal;
        }

        /// <summary>
        /// Get properties for class Giraffe
        /// </summary>
        /// <returns>class Giraffe</returns>
        private static Giraffe GetPropertiesGiraffe()
        {
            var animal = new Giraffe();

            Console.Write("Enter Name : ");
            animal.Name = Console.ReadLine();


            var check = true;
            double vAge = 0;

            while (check)
            {
                Console.Write("Enter Age : ");
                try
                {
                    vAge = double.Parse(Console.ReadLine().Trim().Replace(".", ","));
                    check = false;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Uncorrect number. Try again.");
                    Console.ResetColor();
                }
            }

            animal.Age = vAge;


            check = true;
            double vWeight = 0;

            while (check)
            {
                Console.Write("Enter Weight : ");

                try
                {
                    vWeight = double.Parse(Console.ReadLine().Trim().Replace(".", ","));
                    check = false;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Uncorrect number. Try again.");
                    Console.ResetColor();
                }
            }

            animal.Weight = vWeight;

            Console.Write("Enter what eat : ");
            animal.WhatEat = Console.ReadLine();

            Console.Write("Enter what say : ");
            animal.WhatSay = Console.ReadLine();

            Console.Write("Enter what traffic : ");
            animal.WhatTraffic = Console.ReadLine();

            return animal;
        }

        /// <summary>
        /// Get properties for class Elephant
        /// </summary>
        /// <returns>class Elephant</returns>
        private static Elephant GetPropertiesElephant()
        {
            var animal = new Elephant();

            Console.Write("Enter Name : ");
            animal.Name = Console.ReadLine();


            var check = true;
            double vAge = 0;

            while (check)
            {
                Console.Write("Enter Age : ");
                try
                {
                    vAge = double.Parse(Console.ReadLine().Trim().Replace(".", ","));
                    check = false;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Uncorrect number. Try again.");
                    Console.ResetColor();
                }
            }

            animal.Age = vAge;


            check = true;
            double vWeight = 0;

            while (check)
            {
                Console.Write("Enter Weight : ");

                try
                {
                    vWeight = double.Parse(Console.ReadLine().Trim().Replace(".", ","));
                    check = false;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Uncorrect number. Try again.");
                    Console.ResetColor();
                }
            }

            animal.Weight = vWeight;

            Console.Write("Enter what eat : ");
            animal.WhatEat = Console.ReadLine();

            Console.Write("Enter what say : ");
            animal.WhatSay = Console.ReadLine();

            Console.Write("Enter what traffic : ");
            animal.WhatTraffic = Console.ReadLine();

            return animal;
        }

        /// <summary>
        /// Get properties for class Cat
        /// </summary>
        /// <returns>class Cat</returns>
        private static Cat GetPropertiesCat()
        {
            var animal = new Cat();

            Console.Write("Enter Name : ");
            animal.Name = Console.ReadLine();


            var check = true;
            double vAge = 0;

            while (check)
            {
                Console.Write("Enter Age : ");
                try
                {
                    vAge = double.Parse(Console.ReadLine().Trim().Replace(".", ","));
                    check = false;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Uncorrect number. Try again.");
                    Console.ResetColor();
                }
            }

            animal.Age = vAge;


            check = true;
            double vWeight = 0;

            while (check)
            {
                Console.Write("Enter Weight : ");

                try
                {
                    vWeight = double.Parse(Console.ReadLine().Trim().Replace(".", ","));
                    check = false;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Uncorrect number. Try again.");
                    Console.ResetColor();
                }
            }

            animal.Weight = vWeight;

            Console.Write("Enter what eat : ");
            animal.WhatEat = Console.ReadLine();

            Console.Write("Enter what say : ");
            animal.WhatSay = Console.ReadLine();

            Console.Write("Enter what traffic : ");
            animal.WhatTraffic = Console.ReadLine();

            return animal;
        }

        /// <summary>
        /// Get properties for class Bear
        /// </summary>
        /// <returns>class Bear</returns>
        private static Bear GetPropertiesBear()
        {
            var animal = new Bear();

            Console.Write("Enter Name : ");
            animal.Name = Console.ReadLine();


            var check = true;
            double vAge = 0;

            while (check)
            {
                Console.Write("Enter Age : ");
                try
                {
                    vAge = double.Parse(Console.ReadLine().Trim().Replace(".", ","));
                    check = false;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Uncorrect number. Try again.");
                    Console.ResetColor();
                }
            }

            animal.Age = vAge;


            check = true;
            double vWeight = 0;

            while (check)
            {
                Console.Write("Enter Weight : ");

                try
                {
                    vWeight = double.Parse(Console.ReadLine().Trim().Replace(".", ","));
                    check = false;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Uncorrect number. Try again.");
                    Console.ResetColor();
                }
            }

            animal.Weight = vWeight;

            Console.Write("Enter what eat : ");
            animal.WhatEat = Console.ReadLine();

            Console.Write("Enter what say : ");
            animal.WhatSay = Console.ReadLine();

            Console.Write("Enter what traffic : ");
            animal.WhatTraffic = Console.ReadLine();

            return animal;
        }

        /// <summary>
        /// Get selected kind animals
        /// </summary>
        /// <returns></returns>
        private static KindAnimals SelectedKind()
        {
            var vRes = KindAnimals.None;

            var check = true;

            while (check)
            {
                Console.WriteLine();
                Console.Write("Please press any key : ");

                var inputKind = Console.ReadLine().Trim();

                switch (inputKind)
                {
                    case "c":
                        vRes = KindAnimals.Cat;
                        check = false;
                        break;
                    case "b":
                        vRes = KindAnimals.Bear;
                        check = false;
                        break;
                    case "e":
                        vRes = KindAnimals.Elephant;
                        check = false;
                        break;
                    case "g":
                        vRes = KindAnimals.Giraffe;
                        check = false;
                        break;
                    case "t":
                        vRes = KindAnimals.Tiger;
                        check = false;
                        break;
                    case "x":
                        vRes = KindAnimals.None;
                        check = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Uncorrect key.");
                        Console.ResetColor();
                        ShowMenuAnimals();
                        break;
                }
            }

            return vRes;
        }

        /// <summary>
        /// show menu with public animals
        /// </summary>
        private static void ShowMenuAnimals()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("Menu add animals : ");

            Console.WriteLine("Add Bear - press b");

            Console.WriteLine("Add Cat - press c");

            Console.WriteLine("Add Elephant - press e");

            Console.WriteLine("Add Giraffe - press g");

            Console.WriteLine("Add Tigger - press t");

            Console.WriteLine("Exit - press x");
        }

        /// <summary>
        /// Show list with all added animals, sorted by animals
        /// </summary>
        private static void ShowListAnimals()
        {
            if (ListTiger.Count != 0)
            {
                foreach (var rowTiger in ListTiger)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
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

            if (ListCat.Count != 0)
            {
                foreach (var rowCat in ListCat)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
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

            if (ListBear.Count != 0)
            {
                foreach (var rowBear in ListBear)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
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

            if (ListElephant.Count != 0)
            {
                foreach (var rowEl in ListElephant)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
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

            if (ListGiraffe.Count != 0)
            {
                foreach (var rowGiraffe in ListGiraffe)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
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

        /// <summary>
        /// show main menu with exist operations
        /// </summary>
        private static void ShowMenu()
        {
            Console.WriteLine("Menu operations : ");

            Console.WriteLine("Show list animals - press s");

            Console.WriteLine("Add animal (You can add Bear, Cat, Elephant, Giraffe, Tiger) - press a");

            Console.WriteLine("Exit - press c");
        }

        /// <summary>
        /// Add default rows to list to all kind animals
        /// </summary>
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

            ListGiraffe = new List<Giraffe>();

            var gr = new Giraffe()
            {
                Age = 1.6,
                Name = "Big Sanny",
                Weight = 820,
                WhatTraffic = "26 kn/h"
            };

            ListGiraffe.Add(gr);

            ListCat = new List<Cat>();

            var cat = new Cat()
            {
                Age = 0.3,
                Name = "Murzik",
                Weight = 0.4,
                WhatTraffic = "2 kn/h",
                WhatSay = "MRRR-mRRR"
            };

            ListCat.Add(cat);

            cat = new Cat()
            {
                Age = 1,
                Name = "Snow",
                Weight = 2.5,
                WhatTraffic = "Slovly",
                WhatSay = "FrFrFR"
            };

            ListCat.Add(cat);

            ListBear = new List<Bear>();

            var bear = new Bear()
            {
                Age = 5.6,
                Name = "Big Bear",
                Weight = 346,
                WhatTraffic = "20 kn/h",
                WhatEat = "Apple, bananas, fish"
            };

            ListBear.Add(bear);
        }

    }
}
