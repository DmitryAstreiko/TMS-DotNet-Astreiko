using System;
using System.Collections.Generic;
using System.Text;

namespace Astreiko.EntityFramework.Models
{
    public class StudentAvatar
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Caption { get; set; }

        public Student Student { get; set; }
    }
}
