using System;
using System.Collections.Generic;

namespace quickfitgym.Models
{
    public class Members
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
