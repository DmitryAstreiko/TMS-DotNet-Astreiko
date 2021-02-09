using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astreiko.Homework9.Nbrb.by.API_Client.Models
{
    public class ShortRate
    {
        /// <summary>
        /// Internal code (внутренний код)
        /// </summary>
        public int Cur_ID { get; set; }

        /// <summary>
        /// Date (дата, на которую запрашивается курс)
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Rate (курс)
        /// </summary>
        public decimal Cur_OfficialRate { get; set; }
    }
}
