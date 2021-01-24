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
        public Thread ThreadCashier { get; set; }

        /// <summary>
        /// Name cashier
        /// </summary>
        public string NameCashier { get; set; }
    }
}
