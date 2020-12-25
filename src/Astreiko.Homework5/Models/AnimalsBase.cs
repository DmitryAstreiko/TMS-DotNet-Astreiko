using System;
using System.Collections.Generic;
using System.Text;

namespace Astreiko.Homework5.Models
{
    /// <summary>
    /// Основные характеристики животного
    /// </summary>
    public abstract class AnimalsBase
    {
        /// <summary>
        /// Название животного
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Вес животного
        /// </summary>
        public string Weight { get; set; }

        /// <summary>
        /// Возраст животного
        /// </summary>
        public double Age { get; set; }

        /// <summary>
        /// Как говорит
        /// </summary>
        public string WhatSay { get; set; }

        /// <summary>
        /// Как быстро двигается
        /// </summary>
        public string WhatTraffic { get; set; }

        /// <summary>
        /// Что ест
        /// </summary>
        public string WhatEat { get; set; }
    }
}
