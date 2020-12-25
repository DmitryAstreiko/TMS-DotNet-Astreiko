using Astreiko.Homework5.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Astreiko.Homework5.Models
{
    public class Elephant : AnimalsBase, IVoice, ITraffic, IFood
    {
        public void Say()
        {
            Console.WriteLine("YYYYYYYY");
        }

        public void Traffic()
        {
            Console.WriteLine("About 40 km/h");
        }

        public void Eat()
        {
            Console.WriteLine("Grass ...");
        }
    }
}
