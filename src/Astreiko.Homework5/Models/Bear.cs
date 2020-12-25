using Astreiko.Homework5.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Astreiko.Homework5.Models
{
    public class Bear : AnimalsBase, IVoice, ITraffic, IFood
    {
        public void Say()
        {
            Console.WriteLine("GEEEEEEEE");
        }

        public void Traffic()
        {
            Console.WriteLine("About 60 km/h");
        }

        public void WhatEat()
        {
            Console.WriteLine("Honey ...");
        }
    }
}
