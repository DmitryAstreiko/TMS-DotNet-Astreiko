using System;
using System.Collections.Generic;
using System.Text;

namespace Astreiko.EntityFramework.Models
{
    public class Tag
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Homework> Homeworks { get; set; }
    }
}
