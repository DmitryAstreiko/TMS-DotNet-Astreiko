using System;
using System.Collections.Generic;
using System.Text;

namespace Astreiko.Homework6
{
    public class Atm
    {
        public event Action<decimal> AddBalanceHandler;
        public event Action<decimal> ShowBalanceHandler;
        public event Action<decimal> DelBalanceHandler;

        private decimal CurrentBalance;

        public decimal USDToBYN { get; set; }

        public decimal EUROToBYN { get; set; }

        public Atm()
        {
            CurrentBalance = 0M;
            USDToBYN = 2.51M;
            EUROToBYN = 3.11M;
        }

        public void GetCash(decimal DelSum)
        {
            CurrentBalance -= DelSum;
            DelBalanceHandler?.Invoke(DelSum);
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
    }
}
