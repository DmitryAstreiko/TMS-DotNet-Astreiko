using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Threading;

namespace Astreiko.Homework8
{
    public class Cashier
    {
        /// <summary>
        /// Thread for cashier
        /// </summary>
        //public Thread ThreadCashier { get; set; }

        /// <summary>
        /// Name cashier
        /// </summary>
        public string NameCashier { get; set; }

        private static Random randomTimeToProcess = new Random();

        public int TimeToProcess { get; set; }

        public Cashier()
        {
            TimeToProcess = randomTimeToProcess.Next(3000);
            NameCashier = Guid.NewGuid().ToString("N").Substring(1,4);
        }
    }
}
