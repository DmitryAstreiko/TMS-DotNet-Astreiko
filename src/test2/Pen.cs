using System;

namespace test2
{
    /// <summary>
    /// Ручка.
    /// </summary>
    class Pen : Product
    {
        /// <summary>
        /// Базовый конструктор
        /// </summary>
        public Pen()
        {
            Console.WriteLine("Я создался.");
        }

        /// <summary>
        /// Конструктор с параметром цвет.
        /// </summary>
        /// <param name="color">Цвет.</param>
        public Pen(int color)
        {
            Color = color; 
            Console.WriteLine("Я создался с цвет!!!.");
        }
    }
}
