using System;

namespace Astreiko.Homework6
{
    public class Atm
    {
        /// <summary>
        /// Event top up amount with balance
        /// </summary>
        public event Action<decimal> CashAdd;

        /// <summary>
        /// Event show current balance
        /// </summary>
        public event Action<decimal> ShowActualBalance;

        /// <summary>
        /// Event debit with balance
        /// </summary>
        public event Action<decimal, bool> CashWithdrawal;

        /// <summary>
        /// Current balance
        /// </summary>
        private decimal _currentBalance;

        /// <summary>
        /// Conversion USD to BYN
        /// </summary>
        public decimal UsdToByn { get; set; }

        /// <summary>
        /// Conversion EURO to BYN
        /// </summary>
        public decimal EuroToByn { get; set; }

        /// <summary>
        /// Constructor for class Atm
        /// </summary>
        public Atm()
        {
            _currentBalance = 0M;
            UsdToByn = 2.51M;
            EuroToByn = 3.11M;
        }

        /// <summary>
        /// Withdraw amount with balance
        /// </summary>
        /// <param name="delSum"></param>
        public void GetCash(decimal delSum)
        {
            //Predicate<decimal> checkSum = (x) => (x > _currentBalance);

            //Сумма списания больше, чем остаток
            //if (checkSum(delSum))
            if(delSum > _currentBalance)
            {
                CashWithdrawal?.Invoke(delSum, false);
            }
            //Сумма списания меньше или равно, чем остаток
            else
            {
                _currentBalance -= delSum;
                CashWithdrawal?.Invoke(delSum, true);
            }
        }

        /// <summary>
        /// Top up amount to balance
        /// </summary>
        /// <param name="getedSum"></param>
        public void PutCash(decimal getedSum)
        {
            _currentBalance += getedSum;
            CashAdd?.Invoke(getedSum);
        }

        /// <summary>
        /// Show actual balance
        /// </summary>
        public void ShowBalance()
        {
            ShowActualBalance?.Invoke(_currentBalance);
        }
    }
}
