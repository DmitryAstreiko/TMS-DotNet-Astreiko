using System;

namespace Astreiko.Homework6
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMainMenu();

            var check = true;

            while (check)
            {
                Console.WriteLine();
                Console.Write("Please choose the operation : ");

                var inputChoose = Console.ReadLine().Trim();

                switch (inputChoose)
                {
                    case "a":

                        break;
                    case "w":
                        break;
                    case "d":
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

        public static void ShowMainMenu() 
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Choose operations : ");
            Console.WriteLine("Top up an account - [a]");
            Console.WriteLine("Withdrawal of funds - [w]");
            Console.WriteLine("Display actual balance - [d]");
            Console.WriteLine("Exit - [e]");
            Console.ResetColor();
        }
    }
}
