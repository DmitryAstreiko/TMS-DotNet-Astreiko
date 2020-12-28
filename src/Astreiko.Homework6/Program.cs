using System;

namespace Astreiko.Homework6
{
    class Program
    {
        public static decimal CurrentBalance { get; set; } = 0M;

        static void Main(string[] args)
        {
            CurrentBalance += GetSum("Enter start sum[BYN]: ");
            Console.WriteLine("-----");

            ShowMainMenu();

            var check = true;

            while (check)
            {               
                Console.Write("Please choose the operation : ");

                var inputChoose = Console.ReadLine().Trim();

                switch (inputChoose)
                {
                    case "a":
                        //Console.Write("Enter sum to add [BYN] : ");


                        break;
                    case "w":

                        break;
                    case "d":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Actual balance - {CurrentBalance}");
                        Console.ResetColor();
                        Console.WriteLine("-----");
                        ShowMainMenu();
                        break;
                    case "e":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Application will be close.");
                        Console.ResetColor();
                        check = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Entered uncorect char. Please try again.");
                        Console.ResetColor();
                        break;
                }
            }

            Console.ReadKey();
        }

        private static decimal GetSum(string TextComment)
        {
            var check = true;

            var sum = 0M;

            while (check)
            {
                Console.Write($"{TextComment}");

                try
                {
                    sum = decimal.Parse(Console.ReadLine().Trim().Replace(".", ","));
                    check = false;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Entered uncorect sum. Please try again.");
                    Console.ResetColor();
                }
            }

            return sum;
        }

        private static void ShowMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Choose operations : ");
            Console.WriteLine("Top up an account - [a]");
            Console.WriteLine("Withdrawal of funds - [w]");
            Console.WriteLine("Display actual balance - [d]");
            Console.WriteLine("Exit - [e]");
            Console.ResetColor();
            Console.WriteLine("-----");
        }
    }
}
