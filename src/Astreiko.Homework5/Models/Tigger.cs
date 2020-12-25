using Astreiko.Homework5.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Astreiko.Homework5.Models
{
    public class Tigger : AnimalsBase, IVoice, ITraffic, IFood
    {
        public void Say()
        {
            Console.WriteLine("RRRRRR");
        }

        public void Traffic()
        {
            Console.WriteLine("more 100 km/h");
        }

        public void WhatEat()
        {
            Console.WriteLine("All animals");
        }
    }
}
