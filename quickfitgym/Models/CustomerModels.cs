using System;
using System.Collections.Generic;

namespace quickfitgym.Models
{
    public class Customer
    {
        public string ProfilePicture { get; set; }
        public List<Pictures> Picture { get; set; }
    }

    public class Pictures
    {
        public string Picture { get; set; }
    }
}
