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
        /// Максимальный вес животного
        /// </summary>
        public string MaxWeight { get; set; }

        /// <summary>
        /// Возраст животного
        /// </summary>
        public double Age { get; set; }
    }
}
