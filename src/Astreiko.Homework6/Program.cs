using System;

namespace Astreiko.Homework6
{
    class Program
    {
        //public static decimal CurrentBalance { get; set; } = 0M;

        //public static decimal USDToBYN { get; set; } = 2.51M;

        //public static decimal EUROToBYN { get; set; } = 3.11M;

        static void Main(string[] args)
        {
            var CurrentAtm = new Atm();

            CurrentAtm.AddBalanceHandler += CurrentAtm_AddBalanceHandler;
            CurrentAtm.ShowBalanceHandler += CurrentAtm_ShowBalanceHandler;
            CurrentAtm.DelBalanceHandler += CurrentAtm_DelBalanceHandler;

            //Func<decimal, decimal, decimal> funcSum = (x, y) => (x + y);

            //CurrentAtm.CurrentBalance = funcSum(CurrentAtm.CurrentBalance, GetSum("Enter start sum [BYN]: "));

            CurrentAtm.PutCash(GetSum("Enter start sum [BYN] : "));

            ShowMainMenu();

            var check = true;

            while (check)
            {
                Console.Write("Please choose the operation : ");

                var inputChoose = Console.ReadLine().Trim();

                switch (inputChoose)
                {
                    case "a":
                        CurrentAtm.PutCash(GetSum("Enter sum to add [BYN] : "));
                        //var addSum = GetSum("Enter sum to add [BYN] : ");
                        //Console.WriteLine($"You add {addSum} to your account.");
                        //Console.WriteLine("-----");
                        //CurrentBalance = funcSum(CurrentBalance, addSum);
                        ShowMainMenu();
                        break;
                    case "w":
                        ShowMenuCurrency(CurrentAtm.EUROToBYN, CurrentAtm.USDToBYN);
                        WorkWithSum(CurrentAtm);
                        ShowMainMenu();
                        break;
                    case "d":
                        //Console.ForegroundColor = ConsoleColor.Green;
                        //Console.WriteLine($"Actual balance - {CurrentBalance}");
                        //Console.ResetColor();
                        //Console.WriteLine("-----");
                        CurrentAtm.ShowBalance();
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

        private static void CurrentAtm_DelBalanceHandler(decimal delSum)
        {
            Console.WriteLine($"You withdraw {delSum} BYN.");
            Console.WriteLine("-----");
        }

        private static void CurrentAtm_ShowBalanceHandler(decimal CurrentBalance)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Actual balance - {CurrentBalance}");
            Console.ResetColor();
            Console.WriteLine("-----");
        }

        private static void CurrentAtm_AddBalanceHandler(decimal addSum)
        {
            Console.WriteLine($"You add {addSum} to your account.");
            Console.WriteLine("-----");
        }

        private static void WorkWithSum(Atm atm)
        {
            //Func<decimal, decimal, decimal> funcSubst = (x, y) => (x - y);
            //Func<decimal, decimal, decimal, decimal> funcSubstWithConst = (x, y, k) => (x - y * k);

            var check = true;

            //var tempBalance = CurrentBalance;

            while (check)
            {
                Console.Write("Select currency : ");
                var input = Console.ReadLine().Trim();

                switch (input)
                {
                    case "b":
                        //CheckSum(funcSubst(tempBalance, GetSum("Enter sum to withdrawal [BYN] : ")));
                        atm.GetCash(GetSum("Enter sum to withdrawal [BYN] : "));
                        check = false;
                        break;
                    case "u":
                        //CheckSum(funcSubstWithConst(CurrentBalance, GetSum("Enter sum to withdrawal [USD] : "), USDToBYN));
                        atm.GetCash(GetSum("Enter sum to withdrawal [USD] : ") * atm.USDToBYN);
                        check = false;
                        break;
                    case "e":
                        //CheckSum(funcSubstWithConst(CurrentBalance, GetSum("Enter sum to withdrawal [EURO] : "), EUROToBYN));
                        atm.GetCash(GetSum("Enter sum to withdrawal [EURO] : ") * atm.EUROToBYN);
                        check = false;
                        break;
                    case "c":
                        check = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Entered uncorect char. Please try again.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        //private static void WorkWithSum()
        //{
        //    Func<decimal, decimal, decimal> funcSubst = (x, y) => (x - y);
        //    Func<decimal, decimal, decimal, decimal> funcSubstWithConst = (x, y, k) => (x - y * k);

        //    var check = true;

        //    //var tempBalance = CurrentBalance;

        //    while (check)
        //    {
        //        Console.Write("Select currency : ");
        //        var input = Console.ReadLine().Trim();

        //        switch (input)
        //        {
        //            case "b":
        //                //CheckSum(funcSubst(tempBalance, GetSum("Enter sum to withdrawal [BYN] : ")));

        //                check = false;
        //                break;
        //            case "u":
        //                CheckSum(funcSubstWithConst(CurrentBalance, GetSum("Enter sum to withdrawal [USD] : "), USDToBYN));
        //                check = false;
        //                break;
        //            case "e":
        //                CheckSum(funcSubstWithConst(CurrentBalance, GetSum("Enter sum to withdrawal [EURO] : "), EUROToBYN));
        //                check = false;
        //                break;
        //            case "c":
        //                check = false;
        //                break;
        //            default:
        //                Console.ForegroundColor = ConsoleColor.Red;
        //                Console.WriteLine("Entered uncorect char. Please try again.");
        //                Console.ResetColor();
        //                break;
        //        }
        //    }
        //}

        //private static void CheckSum(decimal checkSum)
        //{
        //    if (checkSum >= 0)
        //    {
        //        CurrentBalance = checkSum;
        //    }
        //    else
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine("Entered summa is greater then current balance. Operation is not possible.");
        //        Console.ResetColor();
        //    }
        //}

        private static void ShowMenuCurrency(decimal EUROToBYN, decimal USDToBYN)
        {
            Console.WriteLine();
            Console.WriteLine("Choose currency : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("BYN - [b]");
            Console.WriteLine($"USD (1 USD = {USDToBYN} BYN) - [u]");
            Console.WriteLine($"EURO (1 EURO = {EUROToBYN} BYN) - [e]");
            Console.WriteLine("Cancel - [c]");
            Console.ResetColor();
            Console.WriteLine("-----");
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
