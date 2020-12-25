using Astreiko.Homework5.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Astreiko.Homework5.Models
{
    public abstract class AnimalsBase
    {
        public KindAnimals KindAnimals { get; set; }

        public string Name { get; set; }

        public string MaxWeight { get; set; }

        public double Age { get; set; }
    }
}
