
using System;

namespace test2
{
    /// <summary>
    /// Это базовый класс для карандаша или ручки.
    /// </summary>
    abstract class Product
    {
        /// <summary>
        /// Цвет стержня.
        /// </summary>
        public int Color { get; set; }

        /// <summary>
        /// Ценв.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Старана происхождения.
        /// </summary>
        public Country MyProperty { get; set; }      
        
        /// <summary>
        /// Рисовать
        /// </summary>
        public void Draw()
        {
            Console.WriteLine("Рисую.");
        }

        public virtual void Do()
        {
            Console.WriteLine("Do something.");
        }
        
    }
}
