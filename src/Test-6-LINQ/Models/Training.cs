using System;
using System.Collections.Generic;
using System.Text;

namespace Astreiko.Homework7.Models
{
    internal class Training
    {
        /// <summary>
        /// Tracking period training
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Start date training
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Distance in training
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// Count step in training
        /// </summary>
        public int Step { get; set; }

        /// <summary>
        /// Average pulse in training
        /// </summary>
        public int AveragePulse { get; set; }
    }
}
