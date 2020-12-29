using System;
using System.Collections.Generic;
using System.Text;

namespace Astreiko.Homework6
{
    public class Atm
    {
        public event Action<decimal> AddBalanceHandler;
        public event Action<decimal> ShowBalanceHandler;

        private decimal CurrentBalance;

        public decimal USDToBYN { get; set; }

        public decimal EUROToBYN { get; set; }

        public Atm()
        {
            CurrentBalance = 0M;
            USDToBYN = 2.51M;
            EUROToBYN = 3.11M;
        }

        public void GetCash()
        {

        }

        public void PutCash(decimal GetedSum)
        {
            //var addSum = GetSum("Enter sum to add [BYN] : ");
            CurrentBalance += GetedSum;
            AddBalanceHandler?.Invoke(GetedSum);
        }

        public void ShowBalance()
        {           
            ShowBalanceHandler?.Invoke(CurrentBalance);
        }

        //private decimal GetSum(string TextComment)
        //{
        //    var check = true;

        //    var sum = 0M;

        //    while (check)
        //    {
        //        Console.Write($"{TextComment}");

        //        try
        //        {
        //            sum = decimal.Parse(Console.ReadLine().Trim().Replace(".", ","));
        //            check = false;
        //        }
        //        catch
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("Entered uncorect sum. Please try again.");
        //            Console.ResetColor();
        //        }
        //    }

        //    return sum;
        //}
    }
}
