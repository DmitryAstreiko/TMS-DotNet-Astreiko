using System;

namespace Astreiko.Homework6
{
    class Program
    {
        static void Main(string[] args)
        {
            var atm = new Atm();

            atm.CashAdd += AtmCashAdd;
            atm.ShowActualBalance += AtmShowActualBalance;
            atm.CashWithdrawal += AtmCashWithdrawal;

            atm.PutCash(GetSum("Enter start sum [BYN] : "));

            while (true)
            {
                ShowMainMenu();

                Console.Write("Please choose the operation : ");

                var inputChoose = Console.ReadLine().Trim();

                switch (inputChoose)
                {
                    case "a":
                        atm.PutCash(GetSum("Enter sum to add [BYN] : "));
                        break;
                    case "w":
                        ShowMenuCurrency(atm);
                        WorkWithSum(atm);
                        break;
                    case "d":
                        atm.ShowBalance();
                        break;
                    case "e":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Application will be close.");
                        Console.ResetColor();
                        Console.ReadKey();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Entered uncorect char. Please try again.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        /// <summary>
        /// Event debit with balance
        /// </summary>
        /// <param name="delSum">Amount to be debited from the account</param>
        /// <param name="resCheck">The result of checking the difference between the balance and the amount to be debited</param>
        private static void AtmCashWithdrawal(decimal delSum, bool resCheck)
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
        /// Show current balance 
        /// </summary>
        /// <param name="currentBalance">Current balance</param>
        private static void AtmShowActualBalance(decimal currentBalance)
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
        private static void AtmCashAdd(decimal addSum)
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
            while (true)
            {
                Console.Write("Select currency : ");
                var input = Console.ReadLine().Trim();

                switch (input)
                {
                    case "b":
                        atm.GetCash(GetSum("Enter sum to withdrawal [BYN] : "));
                        break;
                    case "u":
                        atm.GetCash(GetSum("Enter sum to withdrawal [USD] : ") * atm.UsdToByn);
                        break;
                    case "e":
                        atm.GetCash(GetSum("Enter sum to withdrawal [EURO] : ") * atm.EuroToByn);
                        break;
                    case "c":
                        return;
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
        /// <param name="atm">Class Atm</param>
        private static void ShowMenuCurrency(Atm atm)
        {
            Console.WriteLine();
            Console.WriteLine("Choose currency : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("BYN - [b]");
            Console.WriteLine($"USD (1 USD = {atm.UsdToByn} BYN) - [u]");
            Console.WriteLine($"EURO (1 EURO = {atm.EuroToByn} BYN) - [e]");
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
