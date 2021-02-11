using Astreiko.Homework5.Interfaces;
using System;

namespace Astreiko.Homework5.Models
{
    /// <summary>
    /// Class Tiger
    /// </summary>
    public class Tiger : AnimalsBase, IVoice, ITraffic, IFood
    {
        public void Say()
        {
            if (!string.IsNullOrEmpty(WhatSay)) Console.WriteLine($"{nameof(Say)} = {WhatSay}.");
        }

        public void Traffic()
        {
            if (!string.IsNullOrEmpty(WhatTraffic)) Console.WriteLine($"{nameof(Traffic)} = {WhatTraffic}.");
        }

        public void Eat()
        {
            if (!string.IsNullOrEmpty(WhatEat)) Console.WriteLine($"{nameof(Eat)} = {WhatEat}.");
        }
    }
}
