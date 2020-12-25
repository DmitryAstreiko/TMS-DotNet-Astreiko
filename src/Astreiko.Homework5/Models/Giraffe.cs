using Astreiko.Homework5.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Astreiko.Homework5.Models
{
    public class Giraffe : AnimalsBase, IVoice, ITraffic, IFood
    {
        public void Say()
        {
            Console.WriteLine("YYYYYYYYYYYY");
        }

        public void Traffic()
        {
            Console.WriteLine("About 40 km/h");
        }

        public void WhatEat()
        {
            Console.WriteLine("Leaves ...");
        }
    }
}
