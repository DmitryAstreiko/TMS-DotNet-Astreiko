using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Astreiko.EntityFramework.Models
{
    [NotMapped]
    //[Owned]
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
    }
}
