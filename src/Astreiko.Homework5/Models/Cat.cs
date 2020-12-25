using Astreiko.Homework5.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Astreiko.Homework5.Models
{
    public class Cat : AnimalsBase, IVoice, ITraffic, IFood
    {
        public void Say()
        {
            Console.WriteLine("Mmmmmmya");
        }

        public void Traffic()
        {
            Console.WriteLine("About 5 km/h");
        }

        public void Eat()
        {
            Console.WriteLine("Milk, fish, mouse ...");
        }
    }
}
