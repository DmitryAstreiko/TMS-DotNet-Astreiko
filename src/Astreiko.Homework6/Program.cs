using System;

namespace Astreiko.Homework6
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentAtm = new Atm();

            currentAtm.AddBalanceHandler += CurrentAtm_AddBalanceHandler;
            currentAtm.ShowBalanceHandler += CurrentAtm_ShowBalanceHandler;
            currentAtm.DelBalanceHandler += CurrentAtm_DelBalanceHandler;

            currentAtm.PutCash(GetSum("Enter start sum [BYN] : "));

            ShowMainMenu();

            var check = true;

            while (check)
            {
                Console.Write("Please choose the operation : ");

                var inputChoose = Console.ReadLine().Trim();

                switch (inputChoose)
                {
                    case "a":
                        currentAtm.PutCash(GetSum("Enter sum to add [BYN] : "));
                        ShowMainMenu();
                        break;
                    case "w":
                        ShowMenuCurrency(currentAtm.EuroToByn, currentAtm.UsdToByn);
                        WorkWithSum(currentAtm);
                        ShowMainMenu();
                        break;
                    case "d":
                        currentAtm.ShowBalance();
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

        /// <summary>
        /// Handler event debit with balance
        /// </summary>
        /// <param name="delSum">Amount to be debited from the account</param>
        /// <param name="resCheck">The result of checking the difference between the balance and the amount to be debited</param>
        private static void CurrentAtm_DelBalanceHandler(decimal delSum, bool resCheck)
        {
            if (!resCheck)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entered summa is greater then current balance. Operation is not possible.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"You withdraw {delSum} BYN.");
                Console.WriteLine("-----");
            }
        }

        /// <summary>
        /// Handler event show current balance 
        /// </summary>
        /// <param name="currentBalance">Current balance</param>
        private static void CurrentAtm_ShowBalanceHandler(decimal currentBalance)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Actual balance - {currentBalance}");
            Console.ResetColor();
            Console.WriteLine("-----");
        }

        /// <summary>
        /// Handler event top up amount with balance
        /// </summary>
        /// <param name="delSum">Amount to be debited from the account</param>
        private static void CurrentAtm_AddBalanceHandler(decimal addSum)
        {
            Console.WriteLine($"You add {addSum} to your account.");
            Console.WriteLine("-----");
        }

        /// <summary>
        /// Method work with amount debit 
        /// </summary>
        /// <param name="atm">Class Atm</param>
        private static void WorkWithSum(Atm atm)
        {
            var check = true;

            while (check)
            {
                Console.Write("Select currency : ");
                var input = Console.ReadLine().Trim();

                switch (input)
                {
                    case "b":
                        atm.GetCash(GetSum("Enter sum to withdrawal [BYN] : "));
                        check = false;
                        break;
                    case "u":
                        atm.GetCash(GetSum("Enter sum to withdrawal [USD] : ") * atm.UsdToByn);
                        check = false;
                        break;
                    case "e":
                        atm.GetCash(GetSum("Enter sum to withdrawal [EURO] : ") * atm.EuroToByn);
                        check = false;
                        break;
                    case "c":
                        check = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Entered uncorrect char. Please try again.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        /// <summary>
        /// Show menu currency
        /// </summary>
        /// <param name="euroToByn">Conversion USD to BYN</param>
        /// <param name="usdToByn">Conversion EURO to BYN</param>
        private static void ShowMenuCurrency(decimal euroToByn, decimal usdToByn)
        {
            Console.WriteLine();
            Console.WriteLine("Choose currency : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("BYN - [b]");
            Console.WriteLine($"USD (1 USD = {usdToByn} BYN) - [u]");
            Console.WriteLine($"EURO (1 EURO = {euroToByn} BYN) - [e]");
            Console.WriteLine("Cancel - [c]");
            Console.ResetColor();
            Console.WriteLine("-----");
        }

        /// <summary>
        /// Get string and convers into decomal
        /// </summary>
        /// <param name="textComment">String to convert</param>
        /// <returns></returns>
        private static decimal GetSum(string textComment)
        {
            var check = true;

            var sum = 0M;

            while (check)
            {
                Console.Write($"{textComment}");

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

        /// <summary>
        /// Show main menu application
        /// </summary>
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
