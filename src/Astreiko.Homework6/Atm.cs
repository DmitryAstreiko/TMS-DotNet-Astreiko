using System;
using System.Collections.Generic;
using System.Text;

namespace Astreiko.Homework6
{
    public class Atm
    {
        public event Action<decimal> AddBalanceHandler;
        public event Action<decimal> ShowBalanceHandler;
        public event Action<decimal, bool> DelBalanceHandler;

        private decimal _currentBalance;

        public decimal UsdToByn { get; set; }

        public decimal EuroToByn { get; set; }

        public Atm()
        {
            _currentBalance = 0M;
            UsdToByn = 2.51M;
            EuroToByn = 3.11M;
        }

        public void GetCash(decimal delSum)
        {
            Predicate<decimal> checkSum = (x) => (x > _currentBalance);

            //Сумма списания больше, чем остаток
            if (checkSum(delSum))
            {
                DelBalanceHandler?.Invoke(delSum, false);
            }
            //Сумма списания меньше или равно, чем остаток
            else
            {
                _currentBalance -= delSum;
                DelBalanceHandler?.Invoke(delSum, true);
            }
        }

        public void PutCash(decimal getedSum)
        {
            _currentBalance += getedSum;
            AddBalanceHandler?.Invoke(getedSum);
        }

        public void ShowBalance()
        {           
            ShowBalanceHandler?.Invoke(_currentBalance);
        }

        //private static bool CheckSum(decimal checkSum, decimal tempBalance)
        //{
        //    Func<decimal, decimal, decimal> funcSubst = (x, y) => (x - y);

        //    var tempCurrentBalance = tempBalance;

        //    return funcSubst(tempBalance, checkSum) >= 0;
        //    //{
        //    //    Console.ForegroundColor = ConsoleColor.Red;
        //    //    Console.WriteLine("Entered summa is greater then current balance. Operation is not possible.");
        //    //    Console.ResetColor();
        //    //}
        //}
    }
}
