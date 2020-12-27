﻿using Astreiko.Homework5.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Astreiko.Homework5.Models
{
    public class Tigger : AnimalsBase, IVoice, ITraffic, IFood
    {
        /// <summary>
        /// Конструктор с параметрами по умолчанию
        /// </summary>
        public Tigger()
        {
            WhatSay = "RRRRRRR";

            WhatTraffic = "More 100 km/h";

            WhatEat = "All animals";
        }

        public void Say()
        {
            Console.WriteLine($"{nameof(Say)} = {WhatSay}.");
        }

        public void Traffic()
        {
            Console.WriteLine($"{nameof(Traffic)} = {WhatTraffic}.");
        }

        public void Eat()
        {
            Console.WriteLine($"{nameof(Eat)} = {WhatEat}.");
        }
    }
}
